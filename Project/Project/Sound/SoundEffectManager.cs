using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Project.Sound
{
    public sealed class SoundEffectManager
    {
        private static string soundEffectFolder = Config.GetSFXFolder();
        private static Song backgroundMusic;
        private static string songName = Config.GetBGMSongName();
        private static Dictionary<SoundEffectTag, SoundEffect> soundEffectsMap = new Dictionary<SoundEffectTag, SoundEffect>();
        public enum SoundEffectTag
        {
            BreakBlock,
            Bump,
            CollectCoin,
            EnterPipe,//not in use yet
            Fireworks,// not in use yet
            GainExtraLife,
            Gameover,
            Jump,
            JumpSlightly,
            Kick,
            MarioDie,
            Pause,
            PowerUp,
            PowerUpAppears,
            Stomp,
            StageClear,
            ThrowFireball,
            TouchFlagpole//not in use yet
        }
        public static SoundEffectManager Instance { get; } = new SoundEffectManager();
        private SoundEffectManager()
        {
        }
        public void LoadAllSoundEffects(ContentManager content)
        {
            backgroundMusic = content.Load<Song>(soundEffectFolder + "\\" + songName);
            foreach (SoundEffectTag tag in System.Enum.GetValues(typeof(SoundEffectTag)))
            {
                soundEffectsMap.Add(tag, content.Load<SoundEffect>(soundEffectFolder + "\\" + tag.ToString()));
            }

        }
        public void PlaySoundEffect(SoundEffectTag soundEffectTag)
        {
            foreach (SoundEffectTag tag in System.Enum.GetValues(typeof(SoundEffectTag)))
            {
                if (soundEffectTag == tag)
                {
                    soundEffectsMap[soundEffectTag].Play();
                }
            }
        }
        public void PlayBGM()
        {
            MediaPlayer.Play(backgroundMusic);
            MediaPlayer.IsRepeating = true;
        }
        public void PauseBGM()
        {
            MediaPlayer.Pause();
        }
        public void ResumeBGM()
        {
            MediaPlayer.Resume();
        }
        public void MuteBGM()
        {
            MediaPlayer.Volume = 0;
        }
        public void StopBGM()
        {
            MediaPlayer.Stop();
        }
    }
}
