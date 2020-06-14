using Microsoft.Xna.Framework;
using System;

namespace chapter_08.Engine.Particles.EmitterTypes
{
    public class ConeEmitterType : BaseEmitterType
    {
        public Vector2 Direction;
        public float Spread;

        public override Vector2 GetParticleDirection()
        {
            if (Direction == null)
            {
                return new Vector2(0, 0);
            }

            var angle = (float) Math.Atan2(Direction.Y, Direction.X);
            var newAngle = NextRandom(angle - Spread / 2.0f, angle + Spread / 2.0f);

            var particleDirection = new Vector2((float)Math.Cos(newAngle), (float)Math.Sin(newAngle));
            particleDirection.Normalize();
            return particleDirection;
        }

        public override Vector2 GetParticlePosition(Vector2 emitterPosition)
        {
            var x = emitterPosition.X;
            var y = emitterPosition.Y;

            return new Vector2(x, y);
        }
    }
}
