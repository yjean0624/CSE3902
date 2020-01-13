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
using Project.Enemies;
using Project.Pipes;
using Project.Controllers;
using Project.Sound;

namespace Project
{
    public sealed class GameManager
    {
        public enum PlayerTag
        {
            PlayerOne,
            PlayerTwo,
            PlayerThree,
            PlayerFour
        }
        public static GameManager Instance { get; } = new GameManager();

        private LevelManager currentLevel;

        private string levelsFileName = Config.GetLevelsFileName();

        private Dictionary<PlayerTag, GameObjects.GameObject> marios;

        public IGameState GameState;

        private int millisecondsElapsed;

        private ContentManager content;

        private List<string> levels;

        private List<PlayerTag> playersFinished;

        private Dictionary<PlayerTag, GameObjects.GameObject> checkPoint;

        private Dictionary<PlayerTag, ScoreBoard> scoreBoards;

        private float screenWidth;

        private readonly Vector2 startingLocation = new Vector2(10, 0);

        private GameManager()
        {
            marios = new Dictionary<PlayerTag, GameObjects.GameObject>();
            scoreBoards = new Dictionary<PlayerTag, ScoreBoard>();
        }
        public void LoadLevelDictionary(ContentManager content)
        {
            this.content = content;
            levels = new List<string>();
            LevelList levelList = content.Load<XMLData.LevelList>("Levels");
            foreach (string levelName in levelList.Levels)
            {
                levels.Add(levelName);
            }
        }
        public void LoadLevelMenu(float screenWidth, float screenHeight)
        {
            this.screenWidth = screenWidth;
            GameState = new LevelMenuState(levels.ToArray(),content, screenWidth);
        }
        public void LoadPlayers(int numberOfPlayers)
        {
            marios.Clear();
            ControllerController.Instance.RemoveAllPlayerControllers();
            CameraController.Instance.RemoveAllCameras();
            scoreBoards.Clear();
            marios.Add(PlayerTag.PlayerOne, new Mario(startingLocation));
            CameraController.Instance.AddCameraFollowingMario(0);
            CameraController.Instance.AddViewports(numberOfPlayers);
            ControllerController.Instance.AddPlayerController(PlayerTag.PlayerOne);
            scoreBoards.Add(PlayerTag.PlayerOne, new ScoreBoard());
            if(numberOfPlayers > 1)
            {
                marios.Add(PlayerTag.PlayerTwo, new Mario(startingLocation));
                CameraController.Instance.AddCameraFollowingMario(1);
                ControllerController.Instance.AddPlayerController(PlayerTag.PlayerTwo);
                scoreBoards.Add(PlayerTag.PlayerTwo, new ScoreBoard());
            }
            if (numberOfPlayers > 2)
            {
                marios.Add(PlayerTag.PlayerThree, new Mario(startingLocation));
                CameraController.Instance.AddCameraFollowingMario(2);
                ControllerController.Instance.AddPlayerController(PlayerTag.PlayerThree);
                scoreBoards.Add(PlayerTag.PlayerThree, new ScoreBoard());
            }
            if (numberOfPlayers > 3)
            {
                marios.Add(PlayerTag.PlayerFour, new Mario(startingLocation));
                CameraController.Instance.AddCameraFollowingMario(3);
                ControllerController.Instance.AddPlayerController(PlayerTag.PlayerFour);
                scoreBoards.Add(PlayerTag.PlayerFour, new ScoreBoard());
            }
            Sound.SoundEffectManager.Instance.PlayBackgroundMusic();
        }
        public void LoadLevel(string filename)
        {
            currentLevel = new LevelManager(filename);
            currentLevel.LoadLevel(content);
            millisecondsElapsed = 0;
            playersFinished = new List<PlayerTag>();
            checkPoint = new Dictionary<PlayerTag, GameObjects.GameObject>();
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
            GameState.Update(gameTime, content);
        }
        public int GetSecondsElapsed()
        {
            return (int)(millisecondsElapsed * Config.GetTimeRatio() / 1000);
        }
        public void AddMilliseconds(int milliseconds)
        {
            millisecondsElapsed += milliseconds;
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, float screenWidth, float screenHeight)
        {
            GameState.Draw(spriteBatch, gameTime, screenWidth, screenHeight);
        }

        public void HitFlag(GameObjects.GameObject mario, Flagpole flagpole)
        {
            PlayerTag player = FindTagOfMario(mario);
            if (!playersFinished.Contains(player))
            {
                List<GameObjects.GameObject> flagpoles = currentLevel.GetFlagpoles();
                PlayerTag tag = FindTagOfMario(mario);
                if (!checkPoint.ContainsKey(tag) ||
                    flagpole.Location().X > checkPoint[tag].Location().X)
                {
                    SoundEffectManager.Instance.PauseBackgroundMusic();
                    SoundEffectManager.Instance.PlaySoundEffect(SoundEffectManager.SoundEffectTag.StageClear);
                    checkPoint[tag] = flagpole;
                    Flagpole lastFlagpole = flagpole;
                    foreach(Flagpole pole in flagpoles)
                    {
                        if(pole.Location().X > lastFlagpole.Location().X)
                        {
                            lastFlagpole = pole;
                        }
                    }
                    if(flagpole == lastFlagpole)
                    {
                        playersFinished.Add(player);
                        //Give points
                        scoreBoards[tag].AddPoints(Config.GetPointsPerSecond() * GetSecondsElapsed());
                        if(playersFinished.Count >= marios.Count)
                        {
                            //Determine Winner
                            PlayerTag winner = DetermineWinner();
                            //Change to winner state
                            GameState = new WinnerState(winner.ToString(), content, screenWidth, levels.ToArray());                        }
                    }
                }
            }
        }
        private PlayerTag DetermineWinner()
        {
            PlayerTag winner = PlayerTag.PlayerOne;
            if(scoreBoards.ContainsKey(PlayerTag.PlayerTwo) && 
                scoreBoards[PlayerTag.PlayerTwo].GetScore() < scoreBoards[winner].GetScore())
            {
                winner = PlayerTag.PlayerTwo;
            }
            if (scoreBoards.ContainsKey(PlayerTag.PlayerThree) &&
                scoreBoards[PlayerTag.PlayerThree].GetScore() < scoreBoards[winner].GetScore())
            {
                winner = PlayerTag.PlayerThree;
            }
            if (scoreBoards.ContainsKey(PlayerTag.PlayerFour) &&
                scoreBoards[PlayerTag.PlayerFour].GetScore() < scoreBoards[winner].GetScore())
            {
                winner = PlayerTag.PlayerFour;
            }
            return winner;
        }

        /*
         * LevelManager Methods
         */
        public string GetCurrentLevelName()
        {
            return currentLevel.fileName;
        }
        public void AddToCollidables(GameObjects.GameObject gameObject)
        {
            currentLevel.AddToCollidables(gameObject);
        }
        public void AddToNonCollidables(GameObjects.IGameObject gameObject)
        {
            currentLevel.AddToNonCollidables(gameObject);
        }
        public void Remove(IGameObject gameObject)
        {
            currentLevel.Remove(gameObject);
        }
        public void Replace(IGameObject oldObject, IGameObject newObject)
        {
            currentLevel.Replace(oldObject, newObject);
        }
        public void Remove(GameObjects.GameObject gameObject)
        {
            if (IsMario(gameObject))
            {
                //reset it instead
                if(checkPoint.ContainsKey(FindTagOfMario(gameObject)))
                {
                    marios[FindTagOfMario(gameObject)] = new Mario(checkPoint[FindTagOfMario(gameObject)].Location());
                }
                else
                {
                    marios[FindTagOfMario(gameObject)] = new Mario(startingLocation);
                }
            }
            else
            {
                currentLevel.Remove(gameObject);
            }
                
        }
        private PlayerTag FindTagOfMario(GameObjects.GameObject gameObject)
        {
            PlayerTag tag = PlayerTag.PlayerOne;
            foreach (KeyValuePair<PlayerTag, GameObjects.GameObject> nextMario in marios)
            {
                if (nextMario.Value == gameObject)
                {
                    tag = nextMario.Key;
                }
            }
            return tag;
        }
        public void Replace(GameObjects.GameObject oldObject, GameObjects.GameObject newObject)
        {
            if (IsMario(oldObject))
            {
                marios[FindTagOfMario(oldObject)] = newObject;
            }
            else
            {
                currentLevel.Replace(oldObject, newObject);
            }
                
        }
        public List<IGameObject> GetAllObjectsInCollisionOrder()
        {
            List<IGameObject> list = new List<IGameObject>();
            list.AddRange(currentLevel.GetAllObjectsInCollisionOrder());
            foreach(KeyValuePair<PlayerTag, GameObjects.GameObject> mario in marios)
            {
                if(mario.Value != null)
                {
                    list.Add(mario.Value);
                }
            }
            return list;
        }
        public List<IGameObject> GetAllObjectsInDrawOrder()
        {
            List<IGameObject> list = new List<IGameObject>();
            list.AddRange(currentLevel.GetAllObjectsInDrawOrder());
            int index = GetIndexOfFirstPipe(list);
            foreach (KeyValuePair<PlayerTag, GameObjects.GameObject> mario in marios)
            {
                if (mario.Value != null)
                {
                    list.Insert(index, mario.Value);
                }
            }
            return list;
        }
        private int GetIndexOfFirstPipe(List<IGameObject> list)
        {
            int index = 0;
            while(index < list.Count)
            {
                foreach(Type nextInterface in list[index].GetType().GetInterfaces())
                {
                    if(nextInterface == typeof(IPipe))
                    {
                        return index;
                    }
                }
                index++;
            }
            return index;
        }
        public List<GameObjects.GameObject> GetCollidableMovers()
        {
            List<GameObjects.GameObject> list = new List<GameObjects.GameObject>();
            list.AddRange(currentLevel.GetCollidableMovers());
            foreach (KeyValuePair<PlayerTag, GameObjects.GameObject> mario in marios)
            {
                if (mario.Value != null)
                {
                    list.Add(mario.Value);
                }
            }
            return list;
        }
        public List<GameObjects.GameObject> GetCollidableNonMovers()
        {
            return currentLevel.GetCollidableNonMovers();
        }
        public List<GameObjects.GameObject> GetMarios()
        {
            List<GameObjects.GameObject> marios = new List<GameObjects.GameObject>();
            marios.AddRange(this.marios.Values);
            return marios;
        }
        public IMario GetMario(PlayerTag tag)
        {
            return (IMario)marios[tag];
        }
        public List<GameObjects.GameObject> GetItems()
        {
            return currentLevel.GetItems();
        }
        public List<GameObjects.GameObject> GetBlocks()
        {
            return currentLevel.GetBlocks();
        }
        public List<GameObjects.GameObject> GetEnemies()
        {
            return currentLevel.GetEnemies();
        }
        public List<GameObjects.GameObject> GetProjectiles()
        {
            return currentLevel.GetProjectiles();
        }
        public List<GameObjects.GameObject> GetFlagpole()
        {
            return currentLevel.GetFlagpoles();
        }
        public List<IGameObject> GetBackgroundElements()
        {
            return currentLevel.GetBackgroundElements();
        }
        public List<IGameObject> GetSpawnedCoins()
        {
            return currentLevel.GetSpawnedCoins();
        }
        public List<IGameObject> GetFireballExplosions()
        {
            return currentLevel.GetFireballExplosions();
        }
        public void RemoveAll()
        {
            currentLevel.RemoveAll();
            marios.Clear();
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
            return scoreBoards[PlayerTag.PlayerOne].GetScore();
        }
        public int GetScore(PlayerTag tag)
        {
            return scoreBoards[tag].GetScore();
        }
    }
}
