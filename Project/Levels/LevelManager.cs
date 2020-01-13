using System;
using System.Collections.Generic;
using Project.GameObjects;
using Project.Items;
using Project.Enemies;
using Project.Pipes;
using Microsoft.Xna.Framework.Content;
using XMLData;
using Project.BackgroundElements;
using Project.Blocks;
using Project.Sprites;
using Microsoft.Xna.Framework;

namespace Project.Levels
{
    public class LevelManager
    {
        private Dictionary<Type, List<GameObjects.GameObject>> collidableDictionary
            = new Dictionary<Type, List<GameObjects.GameObject>>();
        private Dictionary<Type, List<IGameObject>> noncollidableDictionary
            = new Dictionary<Type, List<IGameObject>>();
        public string fileName { get; private set; }


        public LevelManager(string fileName)
        {
            this.fileName = fileName;
            collidableDictionary.Add(typeof(IBlock), new List<GameObjects.GameObject>());
            collidableDictionary.Add(typeof(IItem), new List<GameObjects.GameObject>());
            collidableDictionary.Add(typeof(IEnemy), new List<GameObjects.GameObject>());
            collidableDictionary.Add(typeof(IPipe), new List<GameObjects.GameObject>());
            collidableDictionary.Add(typeof(IProjectile), new List<GameObjects.GameObject>());
            collidableDictionary.Add(typeof(IFlagpole), new List<GameObjects.GameObject>());
            noncollidableDictionary.Add(typeof(IBackgroundElement), new List<IGameObject>());
            noncollidableDictionary.Add(typeof(SpawnedCoin), new List<IGameObject>());
            noncollidableDictionary.Add(typeof(FireballExplosion), new List<IGameObject>());
            noncollidableDictionary.Add(typeof(Flag), new List<IGameObject>());
            //Add more...
        }
        public void LoadLevel(ContentManager content)
        {
            ObjectList objectList = content.Load<XMLData.ObjectList>(fileName);
            foreach(XMLData.GameObject nextGameObject in objectList.List)
            {
                Vector2 location = new Vector2(nextGameObject.X, nextGameObject.Y);
                //TODO create the objects related to nextGameObject.ItemName
                //This should become a dictionary or something eventually
                switch(nextGameObject.ItemName)
                {
                    case "NormalBrickBlock":
                        AddToCollidables(new NormalBrickBlock(location));
                        break;
                    case "CoinBrickBlock":
                        AddToCollidables(new CoinBrickBlock(location));
                        break;
                    case "StarBrickBlock":
                        AddToCollidables(new StarBrickBlock(location));
                        break;
                    case "GroundBlock1x1":
                        AddToCollidables(new GroundBlock(location,SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.GroundBlock1x1)));
                        break;
                    case "UndergroundBrickBlock":
                        AddToCollidables(new GroundBlock(location, SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.UndergroundBrickBlock)));
                        break;
                    case "UndergroundBlock1x1":
                        AddToCollidables(new GroundBlock(location, SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.UndergroundBlock1x1)));
                        break;
                    case "UndergroundBlock4x15":
                        AddToCollidables(new GroundBlock(location, SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.UndergroundBlock4x15)));
                        break;
                    case "GroundBlock4x65":
                        AddToCollidables(new GroundBlock(location, SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.GroundBlock4x65)));
                        break;
                    case "GroundBlock4x15":
                        AddToCollidables(new GroundBlock(location, SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.GroundBlock4x15)));
                        break;
                    case "GroundBlock4x60":
                        AddToCollidables(new GroundBlock(location, SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.GroundBlock4x60)));
                        break;
                    case "GroundBlock4x54":
                        AddToCollidables(new GroundBlock(location, SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.GroundBlock4x54)));
                        break;
                    case "InvisibleBlock":
                        AddToCollidables(new InvisibleBlock(location));
                        break;
                    case "PowerUpInvisibleBlock":
                        AddToCollidables(new PowerUpInvisibleBlock(location));
                        break;
                    case "SpeedBoostQuestionBlock":
                        AddToCollidables(new SpeedBoostQuestionBlock(location));
                        break;
                    case "ExtraLifeInvisibleBlock":
                        AddToCollidables(new ExtraLifeInvisibleBlock(location));
                        break;
                    case "CoinQuestionBlock":
                        AddToCollidables(new CoinQuestionBlock(location));
                        break;
                    case "PowerUpQuestionBlock":
                        AddToCollidables(new PowerUpQuestionBlock(location));
                        break;
                    case "FlowerQuestionBlock":
                        AddToCollidables(new FlowerQuestionBlock(location));
                        break;
                    case "SolidBlock":
                        AddToCollidables(new SolidBlock(location));
                        break;
                    case "StairBlock":
                        AddToCollidables(new StairBlock(location));
                        break;
                    case "Goomba":
                        AddToCollidables(new Goomba(location));
                        break;
                    case "Koopa":
                        AddToCollidables(new Koopa(location));
                        break;
                    case "KoopaShell":
                        AddToCollidables(new KoopaShell(location));
                        break;
                    case "StaticCoin":
                        AddToCollidables(new StaticCoin(location));
                        break;
                    case "BrownMushroom":
                        AddToCollidables(new BrownMushroom(location));
                        break;
                    case "SpeedBoostItem":
                        AddToCollidables(new SpeedBoostItem(location));
                        break;
                    case "Star":
                        AddToCollidables(new Star(location));
                        break;
                    case "PushableBlock":
                        AddToCollidables(new PushableBlock(location));
                        break;
                    case "Flower":
                        AddToCollidables(new Flower(location));
                        break;
                    case "SmallPipe":
                        AddToCollidables(new SmallPipe(location));
                        break;
                    case "MediumPipe":
                        AddToCollidables(new MediumPipe(location));
                        break;
                    case "LeftFacingPipe":
                        AddToCollidables(new LeftFacingPipe(location));
                        break;
                    case "LargePipe":
                        AddToCollidables(new LargePipe(location));
                        break;
                    case "PipeFlagpole":
                        AddToCollidables(new PipeFlagpole(location));
                        break;
                    case "PipeHalf":
                        AddToCollidables(new PipeHalf(location));
                        break;
                    case "TeleportationPipe":
                        AddToCollidables(new TeleportationPipe(location));
                        break;
                    case "Castle":
                        AddToNonCollidables(new BackgroundElement(location, SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.Castle)));
                        break;
                    case "Flagpole":
                        AddToCollidables(new Flagpole(location));
                        break;
                    case "Flag":
                        AddToNonCollidables(new Flag(location));
                        break;
                    case "OneHumpCloud":
                        AddToNonCollidables(new BackgroundElement(location, SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.OneHumpCloud)));
                        break;
                    case "TwoHumpCloud":
                        AddToNonCollidables(new BackgroundElement(location, SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.TwoHumpCloud)));
                        break;
                    case "ThreeHumpCloud":
                        AddToNonCollidables(new BackgroundElement(location, SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.ThreeHumpCloud)));
                        break;
                    case "OneHumpBush":
                        AddToNonCollidables(new BackgroundElement(location, SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.OneHumpBush)));
                        break;
                    case "TwoHumpBush":
                        AddToNonCollidables(new BackgroundElement(location, SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.TwoHumpBush)));
                        break;
                    case "ThreeHumpBush":
                        AddToNonCollidables(new BackgroundElement(location, SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.ThreeHumpBush)));
                        break;
                    case "TallHill":
                        AddToNonCollidables(new BackgroundElement(location, SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.TallHill)));
                        break;
                    case "ShortHill":
                        AddToNonCollidables(new BackgroundElement(location, SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.ShortHill)));
                        break;
                    default:
                        Console.WriteLine(string.Format(Config.GetLevelLoadingExceptionString(), nextGameObject.ItemName));
                    break;
                }
            }
        }

        public void AddToCollidables(GameObjects.GameObject gameObject)
        {
            Type[] typeAndInterfaces = GetTypeAndInterfaces(gameObject);
            foreach (Type nextTypeOrInterface in typeAndInterfaces)
            {
                foreach (Type dictionaryKey in collidableDictionary.Keys)
                {
                    if (nextTypeOrInterface.Equals(dictionaryKey))
                    {
                        collidableDictionary[dictionaryKey].Add(gameObject);
                    }
                }
            }
            RemoveExtraFireballs();
        }

        private void RemoveExtraFireballs()
        {
            int maximumNumberOfFireballs = Config.GetMaximumNumberOfFireballs();
            int fireballsFound = 0;
            List<Fireball> fireballsToRemove = new List<Fireball>();
            foreach(GameObjects.GameObject projectile in collidableDictionary[typeof(IProjectile)])
            {
                if(projectile.GetType().Equals(typeof(Fireball)))
                {
                    fireballsFound++;
                    if(fireballsFound>maximumNumberOfFireballs)
                    {
                        fireballsToRemove.Add((Fireball)projectile);
                    }
                }
            }
            foreach(Fireball fireball in fireballsToRemove)
            {
                collidableDictionary[typeof(IProjectile)].Remove(fireball);
            }
        }
        public void AddToNonCollidables(GameObjects.IGameObject gameObject)
        {
            Type[] typeAndInterfaces = GetTypeAndInterfaces(gameObject);
            foreach (Type nextTypeOrInterface in typeAndInterfaces)
            {
                foreach (Type dictionaryKey in noncollidableDictionary.Keys)
                {
                    if (nextTypeOrInterface.Equals(dictionaryKey))
                    {
                        noncollidableDictionary[dictionaryKey].Add(gameObject);
                    }
                }
            }
        }
        public void Remove(IGameObject gameObject)
        {
            foreach(List<IGameObject> list in noncollidableDictionary.Values)
            {
                list.Remove(gameObject);
            }
        }
        public void Replace(IGameObject oldObject, IGameObject newObject)
        {
            foreach (List<IGameObject> list in noncollidableDictionary.Values)
            {
                list[list.IndexOf(oldObject)] = newObject;
            }
        }
        public void Remove(GameObjects.GameObject gameObject)
        {
            foreach (List<GameObjects.GameObject> list in collidableDictionary.Values)
            {
                list.Remove(gameObject);
            }
        }
        public void Replace(GameObjects.GameObject oldObject, GameObjects.GameObject newObject)
        {
            foreach (List<GameObjects.GameObject> list in collidableDictionary.Values)
            {
                int indexOfOldObject = list.IndexOf(oldObject);
                if(indexOfOldObject >= 0)
                {
                    list[indexOfOldObject] = newObject;
                }
                
            }
        }
        public List<IGameObject> GetAllObjectsInCollisionOrder()
        {
            List<IGameObject> list = new List<IGameObject>();
            list.AddRange(noncollidableDictionary[typeof(IBackgroundElement)]);
            list.AddRange(collidableDictionary[typeof(IItem)]);
            list.AddRange(collidableDictionary[typeof(IEnemy)]);
            list.AddRange(noncollidableDictionary[typeof(SpawnedCoin)]);
            list.AddRange(collidableDictionary[typeof(IFlagpole)]);
            list.AddRange(collidableDictionary[typeof(IBlock)]);
            list.AddRange(collidableDictionary[typeof(IProjectile)]);
            list.AddRange(collidableDictionary[typeof(IPipe)]);
            list.AddRange(noncollidableDictionary[typeof(FireballExplosion)]);
            return list;
        }
        public List<IGameObject> GetAllObjectsInDrawOrder()
        {
            List<IGameObject> list = new List<IGameObject>();
            list.AddRange(noncollidableDictionary[typeof(IBackgroundElement)]);
            list.AddRange(collidableDictionary[typeof(IItem)]);
            list.AddRange(collidableDictionary[typeof(IEnemy)]);
            list.AddRange(collidableDictionary[typeof(IFlagpole)]);
            list.AddRange(collidableDictionary[typeof(IBlock)]);
            list.AddRange(collidableDictionary[typeof(IProjectile)]);
            list.AddRange(collidableDictionary[typeof(IPipe)]);
            list.AddRange(noncollidableDictionary[typeof(SpawnedCoin)]);
            list.AddRange(noncollidableDictionary[typeof(FireballExplosion)]);
            list.AddRange(noncollidableDictionary[typeof(Flag)]);
            return list;
        }
        public List<GameObjects.GameObject> GetCollidableMovers()
        {
            List<GameObjects.GameObject> list = new List<GameObjects.GameObject>();
            list.AddRange(collidableDictionary[typeof(IProjectile)]);
            list.AddRange(collidableDictionary[typeof(IEnemy)]);
            list.AddRange(collidableDictionary[typeof(IItem)]);
            return list;
        }
        public List<GameObjects.GameObject> GetCollidableNonMovers()
        {
            List<GameObjects.GameObject> list = new List<GameObjects.GameObject>();
            list.AddRange(collidableDictionary[typeof(IPipe)]);
            list.AddRange(collidableDictionary[typeof(IBlock)]);
            list.AddRange(collidableDictionary[typeof(IFlagpole)]);
            return list;
        }
        public List<GameObjects.GameObject> GetItems()
        {
            return collidableDictionary[typeof(IItem)];
        }
        public List<GameObjects.GameObject> GetBlocks()
        {
            return collidableDictionary[typeof(IBlock)];
        }
        public List<GameObjects.GameObject> GetEnemies()
        {
            return collidableDictionary[typeof(IEnemy)];
        }
        public List<GameObjects.GameObject> GetProjectiles()
        {
            return collidableDictionary[typeof(IProjectile)];
        }
        public List<GameObjects.GameObject> GetFlagpoles()
        {
            return collidableDictionary[typeof(IFlagpole)];
        }
        public List<GameObjects.GameObject> GetFlags()
        {
            return collidableDictionary[typeof(Flag)];
        }
        public List<IGameObject> GetBackgroundElements()
        {
            return noncollidableDictionary[typeof(IBackgroundElement)];
        }
        public List<IGameObject> GetSpawnedCoins()
        {
            return noncollidableDictionary[typeof(SpawnedCoin)];
        }
        public List<IGameObject> GetFireballExplosions()
        {
            return noncollidableDictionary[typeof(FireballExplosion)];
        }
        public void RemoveAll()
        {
            foreach(List<GameObjects.GameObject> list in collidableDictionary.Values)
            {
                list.Clear();
            }
            foreach (List<IGameObject> list in noncollidableDictionary.Values)
            {
                list.Clear();
            }
        }
        public void ReloadLevel(ContentManager content)
        {
            RemoveAll();
            LoadLevel(content);
        }
        private Type[] GetTypeAndInterfaces(IGameObject gameObject)
        {
            Type[] type = { gameObject.GetType() };
            Type[] interfaces = gameObject.GetType().GetInterfaces();
            List<Type> typeAndInterfacesList = new List<Type>();
            typeAndInterfacesList.AddRange(type);
            typeAndInterfacesList.AddRange(interfaces);
            Type[] typeAndInterfacesArray = typeAndInterfacesList.ToArray();
            return typeAndInterfacesArray;
        }
    }
}
