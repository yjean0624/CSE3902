namespace Project
{
    /*
     * This is the class for all game variables.
     * Only change things specifically for what you are working on.
     */
    public static class Config
    {
        //Game data
        private const int DefaultWindowHeight = 800;
        private const int DefaultWindowWidth = 1600;
        private const string RootDirectory = "Content";

        //GameManager data
        private const string StartingFileName = "Level1-1";
        private const string LevelsFileName = "Levels";
        private const string LevelDictionaryLoadingExceptionString = "{0} is not a valid level transition";
        private const string LevelTransitionExceptionString = "{0} cannot transition {1}";
        private const int DefaultStartingLives = 3;
        private const int MillisecondsPerLevel = 160000;
        private const float TimeRatio = 2.5f;
        private const int PointsPerSecond = 50;
        private const int PointsPerGoombaKill = 100;
        private const int PointsPerKoopaKill = 200;
        private const int PointsPerKoopaShellHit = 200;
        private const int PointsPerCoin = 200;
        private const int PointsPerFlagpole = 400;
        private const int PointsPerBrickBreak = 50;
        private const int PointsPerBrownMushroom = 200;
        private const int PointsPerFireFlower = 200;

        //LevelManager data
        private const string LevelLoadingExceptionString = "LoadLevel doesn't know what to do with: {0}";
        private const int MaximumNumberOfFireballs = 2;

        //SoundEffectManager data
        private const string soundEffectFolder = "Sound";
        private const string songName = "backgroundMusic";

        //SpriteMachine data
        private const string TexturesFileName = "Textures";
        private const string TextureLoadingExceptionString = "Could not find tag: {0} in tagDictionary of SpriteMachine";
        private const string VerifyingTexturesAnnouncement = "Verifying Textures";
        private const string VerifyingTexturesFrameDataExceptionString = "No Frame data found for {0}";
        private const string VerifyingTexturesSpritesheetDataExceptionString = "No spritesheet data found for {0}";
        private const string VerifyingTexturesFramerateExceptionString = "No framerate found for {0}";

        //Physics data
        private const float Gravity = 1000.81f;
        private const float DefaultFriction = 0.9f;
        private const string PhysicsToString = "xPosition {0} " + "yPosition {1} " +
                                               "xVelocity {2} " + "yVelocity {3} " +
                                               "xAcceleration {4} " + "yAcceleration {5} " +
                                               "friction {6}";
        //Camera data
        private const float CameraZoom = 2.0f;
        private const float OneStoreyDownwardOffset = 30f;
        private const float TwoStoreyDownwardOffset = 30f;

        //Player data
        private const float PlayerInitialJumpPower = -280.0f;
        private const float PlayerPassiveJumpPower = -7.5f;
        private const float PlayerMovementSpeed = 12.0f;
        private const float PlayerInitialYVelocyWhenDead = -100f;
        private const float PlayerYVelocityThreshholdForFalling = 120.0f;
        private const float PlayerXVelocityThreshholdForIdling = 12.0f;
        private const float StarMarioTimeInMilliseconds = 10000.0f;
        private const float MaxTimeInActiveJumpingInSeconds = 2.0f;
        private const float DirectionTransitionTimeInSeconds = 0.2f;
        private const float AdditionalMultiplierPerBoost = 0.2f;
        private const float SpeedBoostDeteriorationRate = 0.001f;

        //Item data
        private const float ItemMovementSpeed = 60.0f;
        private const float StarBounceSpeed = -200.0f;

        //Projectile data
        private const float ProjectileMovementSpeed = -100f;
        private const float MaximumExpansionOfFireballExplosion = 15f;
        private const float FireballExplosionExpansionRate = 3f;
        private const float FireBallXVelocity = 100.0f;

        private const float DespawnThreshhold = 400f;

        //CollisionResolution data
        private const string CollisionResolutionException = "Unexpected Direction Received in ";

        //Enemy data
        private const float EnemyMovingSpeed = 40f;
        private const float KoopaShellMovingSpeed = 200f;
        private const float ReversedEnemyFallingSpeed = 100f;
        private const float StompedGoombaDisappearTime = 400f;
        private const float MovingShellDecidingSpeed = 100f;
        private const float KoopaToKoopaShellFaultTolerancePosition = 10f;

        //Game data
        public static int GetDefaultWindowHeight()
        {
            return DefaultWindowHeight;
        }
        public static int GetDefaultWindowWidth()
        {
            return DefaultWindowWidth;
        }
        public static string GetRootDirectory()
        {
            return RootDirectory;
        }
        //GameManager data
        public static string GetStartingFileName()
        {
            return StartingFileName;
        }
        public static string GetLevelsFileName()
        {
            return LevelsFileName;
        }
        public static string GetLevelDictionaryLoadingExceptionString()
        {
            return LevelDictionaryLoadingExceptionString;
        }
        public static string GetLevelTransitionExceptionString()
        {
            return LevelTransitionExceptionString;
        }
        public static int GetDefaultStartingLives()
        {
            return DefaultStartingLives;
        }
        public static int GetMillisecondsPerLevel()
        {
            return MillisecondsPerLevel;
        }
        public static float GetTimeRatio()
        {
            return TimeRatio;
        }
        public static int GetPointsPerSecond()
        {
            return PointsPerSecond;
        }
        public static int GetPointsPerGoombaKill()
        {
            return PointsPerGoombaKill;
        }
        public static int GetPointsPerKoopaKill()
        {
            return PointsPerKoopaKill;
        }
        public static int GetPointsPerKoopaShellHit()
        {
            return PointsPerKoopaShellHit;
        }
        public static int GetPointsPerCoin()
        {
            return PointsPerCoin;
        }
        public static int GetPointsPerFlagpole()
        {
            return PointsPerFlagpole;
        }
        public static int GetPointsPerBrickBreak()
        {
            return PointsPerBrickBreak;
        }
        public static int GetPointsPerBrownMushroom()
        {
            return PointsPerBrownMushroom;
        }
        public static int GetPointsPerFireFlower()
        {
            return PointsPerFireFlower;
        }
        //LevelManager data
        public static string GetLevelLoadingExceptionString()
        {
            return LevelLoadingExceptionString;
        }
        public static int GetMaximumNumberOfFireballs()
        {
            return MaximumNumberOfFireballs;
        }
        //SoundEffectManager data
        public static string GetSFXFolder()
        {
            return soundEffectFolder;
        }
        public static string GetBGMSongName()
        {
            return songName;
        }
        //SpriteMachine data
        public static string GetTexturesFileName()
        {
            return TexturesFileName;
        }
        public static string GetTextureLoadingExceptionString()
        {
            return TextureLoadingExceptionString;
        }
        public static string GetVerifyingTexturesAnnouncement()
        {
            return VerifyingTexturesAnnouncement;
        }
        public static string GetVerifyingTexturesFrameDataExceptionString()
        {
            return VerifyingTexturesFrameDataExceptionString;
        }
        public static string GetVerifyingTexturesSpritesheetDataExceptionString()
        {
            return VerifyingTexturesSpritesheetDataExceptionString;
        }
        public static string GetVerifyingTexturesFramerateExceptionString()
        {
            return VerifyingTexturesFramerateExceptionString;
        }
        //Physics data
        public static float GetGravity()
        {
            return Gravity;
        }
        public static float GetDefaultFriction()
        {
            return DefaultFriction;
        }
        public static string GetPhysicsToString()
        {
            return PhysicsToString;
        }
        //Camera data
        public static float GetCameraZoom()
        {
            return CameraZoom;
        }
        public static float GetOneStoreyDownwardOffset()
        {
            return OneStoreyDownwardOffset;
        }
        public static float GetTwoStoreyDownwardOffset()
        {
            return TwoStoreyDownwardOffset;
        }
        //Player data
        public static float GetPlayerInitialJumpPower()
        {
            return PlayerInitialJumpPower;
        }
        public static float GetPlayerPassiveJumpPower()
        {
            return PlayerPassiveJumpPower;
        }
        public static float GetPlayerMovementSpeed()
        {
            return PlayerMovementSpeed;
        }
        public static float GetPlayerInitialYVelocyWhenDead()
        {
            return PlayerInitialYVelocyWhenDead;
        }
        public static float GetPlayerYVelocityThreshholdForFalling()
        {
            return PlayerYVelocityThreshholdForFalling;
        }
        public static float GetPlayerXVelocityThreshholdForIdling()
        {
            return PlayerXVelocityThreshholdForIdling;
        }
        public static float GetStarMarioTimeInMilliseconds()
        {
            return StarMarioTimeInMilliseconds;
        }
        public static float GetMaxTimeInActiveJumpingInSeconds()
        {
            return MaxTimeInActiveJumpingInSeconds;
        }
        public static float GetDirectionTransitionTimeInSeconds()
        {
            return DirectionTransitionTimeInSeconds;
        }
        public static float GetAdditionalMultiplierPerBoost()
        {
            return AdditionalMultiplierPerBoost;
        }
        public static float GetSpeedBoostDeteriorationRate()
        {
            return SpeedBoostDeteriorationRate;
        }
        //Item data
        public static float GetItemMovementSpeed()
        {
            return ItemMovementSpeed;
        }
        public static float GetStarBounceSpeed()
        {
            return StarBounceSpeed;
        }
        //Projectile data
        public static float GetProjectileMovementSpeed()
        {
            return ProjectileMovementSpeed;
        }
        public static float GetMaximumExpansionOfFireballExplosion()
        {
            return MaximumExpansionOfFireballExplosion;
        }
        public static float GetFireballExplosionExpansionRate()
        {
            return FireballExplosionExpansionRate;
        }
        public static float GetFireBallXVelocity()
        {
            return FireBallXVelocity;
        }
        public static float GetDespawnThreshhold()
        {
            return DespawnThreshhold;
        }
        public static string GetCollisionResolutionException()
        {
            return CollisionResolutionException;
        }

        //Enemy data
        public static float GetEnemyMovingSpeed()
        {
            return EnemyMovingSpeed;
        }

        public static float GetKoopaShellMovingSpeed()
        {
            return KoopaShellMovingSpeed;
        }
        public static float GetReversedEnemyFallingSpeed()
        {
            return ReversedEnemyFallingSpeed;
        }
        public static float GetStompedGoombaDisappearTime()
        {
            return StompedGoombaDisappearTime;
        }
        public static float GetMovingShellDecidingSpeed()
        {
            return MovingShellDecidingSpeed;
        }
        public static float GetKoopaToKoopaShellFaultTolerancePosition()
        {
            return KoopaToKoopaShellFaultTolerancePosition;
        }


    }
}
