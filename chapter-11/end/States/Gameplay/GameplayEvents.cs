using chapter_11.Engine.Objects;
using chapter_11.Engine.States;

namespace chapter_11.States.Gameplay
{
    public class GameplayEvents : BaseGameStateEvent
    {
        public class PlayerShootsBullets : GameplayEvents { }
        public class PlayerShootsMissile : GameplayEvents { }
        public class PlayerDies : GameplayEvents { }

        public class ObjectHitBy : GameplayEvents
        {
            public IGameObjectWithDamage HitBy { get; private set; }
            public ObjectHitBy(IGameObjectWithDamage gameObject)
            {
                HitBy = gameObject;
            }
        }

        public class ObjectLostLife : GameplayEvents
        {
            public int CurrentLife { get; private set; }
            public ObjectLostLife(int currentLife)
            {
                CurrentLife = currentLife;
            }
        }

        public class TurretShoots : GameplayEvents 
        { 
            public int NbShots { get; private set; }
            public TurretShoots(int nbShots)
            {
                NbShots = nbShots;
            }
        }
    }
}
