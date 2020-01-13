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
        private static Dictionary<SoundEffectTag, SoundEffectInstance> soundEffectsMap = new Dictionary<SoundEffectTag, SoundEffectInstance>();
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
            StarMario,
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
                soundEffectsMap.Add(tag, content.Load<SoundEffect>(soundEffectFolder + "\\" + tag.ToString()).CreateInstance());
            }

        }
        public void PlaySoundEffect(SoundEffectTag soundEffectTag)
        {
                    soundEffectsMap[soundEffectTag].Play();
        }
        public void StopSoundEffect(SoundEffectTag soundEffectTag)
        {
                    soundEffectsMap[soundEffectTag].Stop();
        }
        public void PlayBackgroundMusic()
        {
            MediaPlayer.Play(backgroundMusic);
            MediaPlayer.IsRepeating = true;
        }
        public void PauseBackgroundMusic()
        {
            MediaPlayer.Pause();
        }
        public void ResumeBackgroundMusic()
        {
            MediaPlayer.Resume();
        }
        public void MuteBackgroundMusic()
        {
            MediaPlayer.Volume = 0;
        }
        public void StopBackgroudMusic()
        {
            MediaPlayer.Stop();
        }
    }
}
