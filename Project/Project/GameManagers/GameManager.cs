using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Project.GameObjects;
using XMLData;
using Project.Levels;
using Project.GameManagers;
using Project.Camera;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;

namespace Project
{
    public sealed class GameManager
    {
        public static GameManager Instance { get; } = new GameManager();
        private string startingFileName = Config.GetStartingFileName();
        public enum Transition
        {
            Forward,
            Down,
            Up
        }
        private Stack<LevelManager> levelStack = new Stack<LevelManager>();
        /*
         * The levels dictionary keys are tuples of a string indictating the level we are coming from
         * and a transition indicating where to go. Each level in the dictionary can have at most one
         * of each transition. The values in the dictionary indicate the name of the level to move to
         * with the transition.
         */
        private Dictionary<(string, Transition), string> levels = new Dictionary<(string, Transition), string>();

        private string levelsFileName = Config.GetLevelsFileName();

        private List<GameObjects.GameObject> livingMarios;

        public int coinsCollected { get; private set; }

        public IGameState GameState;

        private ScoreBoard scoreBoard;

        private const int millisecondsPerLevel = 16000;
        private int millisecondsLeft;


        private GameManager()
        {
            livingMarios = new List<GameObjects.GameObject>();
            coinsCollected = 0;
            GameState = new UnpausedGameState();
            scoreBoard = new ScoreBoard();
        }
        public void LoadLevelDictionary(ContentManager content)
        {
            LevelMap levels = content.Load<XMLData.LevelMap>(levelsFileName);
            foreach (Level nextLevel in levels.Levels)
            {
                try
                { 
                    string currentLevelName = nextLevel.CurrentLevel;
                    Transition transition
                        = (Transition)System.Enum.Parse(typeof(Transition), nextLevel.Transition);
                    string nextLevelName = nextLevel.NextLevel;
                    this.levels.Add((currentLevelName, transition), nextLevelName);
                }
                catch(Exception)
                {
                    Console.WriteLine(string.Format(Config.GetLevelDictionaryLoadingExceptionString(), nextLevel.Transition));
                }
            }
        }
        /*
         * High Level Level Management
         */
        public void LoadFirstLevel(ContentManager content)
        {
            levelStack.Push(new LevelManager());
            levelStack.Peek().LoadLevel(content, startingFileName);
            livingMarios.Add(new Mario(new Vector2(0, 0), Config.GetDefaultStartingLives()));
            CameraController.Instance.AddCameraFollowingMario(0);
            millisecondsLeft = millisecondsPerLevel;
        }
        public void ResetGame(ContentManager content)
        {
            livingMarios = new List<GameObjects.GameObject>();
            coinsCollected = 0;
            GameState = new UnpausedGameState();
            scoreBoard = new ScoreBoard();
            LoadFirstLevel(content);
        }

        private bool IsMario(GameObjects.GameObject gameObject)
        {
            Type[] interfaces = gameObject.GetType().GetInterfaces();
            foreach(Type interfaceType in interfaces)
            {
                if(interfaceType.Equals(typeof(IMario)))
                {
                    return true;
                }
            }
            return false;
        }
        public void Update(GameTime gameTime, ContentManager content)
        {
            millisecondsLeft -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if(millisecondsLeft>0)
            {
                foreach (IGameObject gameObject in GameManager.Instance.GetAllObjects())
                {
                    gameObject.Update(gameTime);
                }
                CollisionDetector.Instance.DetectCollision();
                bool hasLivingMario = false;
                foreach(IMario mario in livingMarios)
                {
                    if(!mario.GetType().Equals(typeof(DeadMario)))
                    {
                        hasLivingMario = true;
                    }
                }
                if (!hasLivingMario)
                {
                    ReloadLevel(content);
                }
            }
            else
            {
                foreach(Mario mario in livingMarios)
                {
                    mario.LoseLife();
                }
                ReloadLevel(content);
            }
        }
        public int GetSecondsLeft()
        {
            return (int)(millisecondsLeft * 2.5f / 1000);
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, float screenWidth, float screenHeight)
        {
            CameraController.Instance.Draw(spriteBatch,gameTime,screenWidth,screenHeight);
        }

        /*
         * LevelManager Methods
         */
        public void AddToCollidables(GameObjects.GameObject gameObject)
        {
            if(IsMario(gameObject))
            {
                livingMarios.Add(gameObject);
            }
            else
            {
                levelStack.Peek().AddToCollidables(gameObject);
            }
        }
        public void AddToNonCollidables(GameObjects.IGameObject gameObject)
        {
            levelStack.Peek().AddToNonCollidables(gameObject);
        }
        public void Remove(IGameObject gameObject)
        {
            levelStack.Peek().Remove(gameObject);
        }
        public void Replace(IGameObject oldObject, IGameObject newObject)
        {
            levelStack.Peek().Replace(oldObject, newObject);
        }
        public void Remove(GameObjects.GameObject gameObject)
        {
            if (IsMario(gameObject))
            {
                int index = livingMarios.IndexOf(gameObject);
                if(index>=0)
                {
                    livingMarios[index] = null;
                }
                livingMarios.Remove(gameObject);
            }
            else
            {
                levelStack.Peek().Remove(gameObject);
            }
                
        }
        public void Replace(GameObjects.GameObject oldObject, GameObjects.GameObject newObject)
        {
            if (IsMario(oldObject))
            {
                livingMarios[livingMarios.IndexOf(oldObject)] = newObject;
            }
            else
            {
                levelStack.Peek().Replace(oldObject, newObject);
            }
                
        }
        public List<IGameObject> GetAllObjects()
        {
            List<IGameObject> list = new List<IGameObject>();
            list.AddRange(levelStack.Peek().GetAllObjects());
            list.AddRange(livingMarios);
            return list;
        }
        public List<GameObjects.GameObject> GetCollidableMovers()
        {
            List<GameObjects.GameObject> list = new List<GameObjects.GameObject>();
            list.AddRange(levelStack.Peek().GetCollidableMovers());
            list.AddRange(livingMarios);
            return list;
        }
        public List<GameObjects.GameObject> GetCollidableNonMovers()
        {
            return levelStack.Peek().GetCollidableNonMovers();
        }
        public List<GameObjects.GameObject> GetMarios()
        {
            List<GameObjects.GameObject> marios = new List<GameObjects.GameObject>();
            marios.AddRange(this.livingMarios);
            return marios;
        }
        public List<GameObjects.GameObject> GetItems()
        {
            return levelStack.Peek().GetItems();
        }
        public List<GameObjects.GameObject> GetBlocks()
        {
            return levelStack.Peek().GetBlocks();
        }
        public List<GameObjects.GameObject> GetEnemies()
        {
            return levelStack.Peek().GetEnemies();
        }
        public List<GameObjects.GameObject> GetProjectiles()
        {
            return levelStack.Peek().GetProjectiles();
        }
        public List<GameObjects.GameObject> GetFlagpole()
        {
            return levelStack.Peek().GetFlagpole();
        }
        public List<IGameObject> GetBackgroundElements()
        {
            return levelStack.Peek().GetBackgroundElements();
        }
        public List<IGameObject> GetSpawnedCoins()
        {
            return levelStack.Peek().GetSpawnedCoins();
        }
        public List<IGameObject> GetFireballExplosions()
        {
            return levelStack.Peek().GetFireballExplosions();
        }
        public void RemoveAll()
        {
            levelStack.Peek().RemoveAll();
            livingMarios.Clear();
        }
        public void ReloadLevel(ContentManager content)
        {
            levelStack.Peek().ReloadLevel(content);
            millisecondsLeft = millisecondsPerLevel;
            for (int i = 0; i< livingMarios.Count; i++)
            {
                //replace the mario with a new mario with the same number of lives but at the beginning of the level
                Mario mario = new Mario(new Vector2(0, 0), ((IMario)livingMarios[i]).GetLives());
                livingMarios[i] = mario;
            }
        }

        /*
         * Coin Methods
         */
         public void CollectCoin()
         {
            coinsCollected++;
         }

        /*
         * Game states
         */
         public void Pause()
        {
            GameState.Pause();
        }
        public void Unpause()
        {
            GameState.Unpause();
        }
        public bool IsPaused()
        {
            return GameState.IsPaused();
        }
        /*
         * ScoreBoard
         */
        public int GetScore()
        {
            return scoreBoard.GetScore();
        }
    }
}
