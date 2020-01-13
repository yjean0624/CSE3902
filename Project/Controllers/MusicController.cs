using Microsoft.Xna.Framework.Input;
using Project.Sound;

namespace Project.Controllers
{
    public class MusicController : IController
    {
        public MusicController()
        {

        }
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.F1))
            {
                SoundEffectManager.Instance.PauseBackgroundMusic();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F2))
            {
                SoundEffectManager.Instance.ResumeBackgroundMusic();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F3))
            {
                SoundEffectManager.Instance.MuteBackgroundMusic();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F4))
            {
                SoundEffectManager.Instance.StopBackgroudMusic();
            }
        }
    }
}
