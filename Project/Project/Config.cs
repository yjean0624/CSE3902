namespace Project
{
    /*
     * This is the class for all game variables.
     * Only change things specifically for what you are working on.
     */
    public static class Config
    {
        //Game data
        private const int DefaultWindowHeight = 500;
        private const int DefaultWindowWidth = 1000;
        private const string RootDirectory = "Content";

        //GameManager data
        private const string StartingFileName = "Level1-1";
        private const string LevelsFileName = "Levels";
        private const string LevelDictionaryLoadingExceptionString = "{0} is not a valid level transition";
        private const int DefaultStartingLives = 3;

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
        private const float CameraZoom = 2.8f;
        private const float DownwardOffset = 40f;

        //Player data
        private const float PlayerJumpPower = -350.0f;
        private const float PlayerMovementSpeed = 10.0f;
        private const float PlayerInitialYVelocyWhenDead = -100f;
        private const float PlayerYVelocityThreshholdForFalling = 120.0f;
        private const float PlayerXVelocityThreshholdForIdling = 12.0f;
        private const float StarMarioTimeInMilliseconds = 10000.0f;
        private const float MaxTimeInActiveJumpingInSeconds = 2.0f;
        private const float DirectionTransitionTimeInSeconds = 0.2f;

        //Item data
        private const float ItemMovementSpeed = 10.0f;

        //Projectile data
        private const float ProjectileMovementSpeed = -100f;
        private const float MaximumExpansionOfFireballExplosion = 100f;
        private const float FireBallXVelocity = 100.0f;

        private const float DespawnThreshhold = 400f;

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
        public static int GetDefaultStartingLives()
        {
            return DefaultStartingLives;
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
        public static float GetDownwardOffset()
        {
            return DownwardOffset;
        }
        //Player data
        public static float GetJumpPower()
        {
            return PlayerJumpPower;
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
        //Item data
        public static float GetItemMovementSpeed()
        {
            return ItemMovementSpeed;
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
        public static float GetFireBallXVelocity()
        {
            return FireBallXVelocity;
        }
        public static float GetDespawnThreshhold()
        {
            return DespawnThreshhold;
        }
    }
}
