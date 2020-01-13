using Microsoft.Xna.Framework;


namespace Project.Enemies.EnemyStates.KoopaShellState
{
    public class KoopaShell:AbstractEnemy
    {
        public IKoopaShellState state;
        public KoopaShell(Vector2 location) : base(location)
        {
            state = new StaticKoopaShellState(this);
        }

        public void BeFlipped()
        {
            state.BeFlipped();
        }

        public void Kick()
        {
            state.Kick();
        }
    }
}
