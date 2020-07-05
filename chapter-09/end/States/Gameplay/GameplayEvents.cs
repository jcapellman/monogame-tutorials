using chapter_09.Engine.Objects;
using chapter_09.Engine.States;

namespace chapter_09.States.Gameplay
{
    public class GameplayEvents : BaseGameStateEvent
    {
        public class PlayerShootsBullets : GameplayEvents { }
        public class PlayerShootsMissile : GameplayEvents { }

        public class Collision : GameplayEvents 
        {
            public BaseGameObject HitBy { get; private set; }
            public Collision(BaseGameObject hitBy)
            {
                HitBy = hitBy;
            }
        }

        public class EnemyLostLife : GameplayEvents
        {
            public int CurrentLife { get; private set; }
            public EnemyLostLife(int currentLife)
            {
                CurrentLife = currentLife;
            }
        }
    }
}
