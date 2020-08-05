using chapter_11.Engine.Objects;
using chapter_11.Engine.States;
using Microsoft.Xna.Framework;

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
            public struct BulletInfo 
            {
                public Vector2 Direction;
                public Vector2 Position;
            }

            public BulletInfo Bullet1 { get; private set; }
            public BulletInfo Bullet2 { get; private set; }
            public TurretShoots(BulletInfo bullet1, BulletInfo bullet2)
            {
                Bullet1 = bullet1;
                Bullet2 = bullet2;
            }
        }
    }
}
