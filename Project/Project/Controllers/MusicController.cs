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
                SoundEffectManager.Instance.PauseBGM();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F2))
            {
                SoundEffectManager.Instance.ResumeBGM();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F3))
            {
                SoundEffectManager.Instance.MuteBGM();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F4))
            {
                SoundEffectManager.Instance.StopBGM();
            }
        }
    }
}
