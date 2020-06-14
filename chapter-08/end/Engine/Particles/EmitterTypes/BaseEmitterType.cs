using Microsoft.Xna.Framework;
using System;

namespace chapter_08.Engine.Particles.EmitterTypes
{
    public abstract class BaseEmitterType
    {
        private Random _rnd;

        public BaseEmitterType()
        {
            _rnd = new Random();
        }

        // how long a particle can live
        public TimeSpan MinLifespan;
        public TimeSpan MaxLifespan;

        // defines how the particles will move. Velocity and its deviation define the particle's initial velocity
        // then each update, we
        //  - increase velocity by acceleration
        //  - increase direction by gravity
        //  - multiply direction by velocity
        public float Velocity;
        public float VelocityDeviation;
        public float Acceleration;
        public Vector2 Diretion;
        public Vector2 Gravity; 
 
        public float Opacity;
        public float OpacityDeviation;

        public float Rotation;
        public float RotationDeviation;

        public float Scale;
        public float ScaleDeviation;

        public abstract Vector2 GetParticleDirection();
        public abstract Vector2 GetParticlePosition(Vector2 emitterPosition);

        public TimeSpan GenerateLifespan()
        {
            var range = MaxLifespan - MinLifespan;
            var randomTicks = _rnd.NextDouble() * range.Ticks;
            return MinLifespan + new TimeSpan((long) randomTicks);
        }

        public float GenerateVelocity()
        {
            return GenerateFloat(Velocity, VelocityDeviation);
        }

        public float GenerateOpacity()
        {
            return GenerateFloat(Opacity, OpacityDeviation);
        }

        public float GenerateRotation()
        {
            return GenerateFloat(Rotation, RotationDeviation);
        }

        public float GenerateScale()
        {
            return GenerateFloat(Scale, ScaleDeviation);
        }

        protected float GenerateFloat(float startN, float deviation)
        {
            var halfDeviation = deviation / 2.0f;
            return NextRandom(startN - halfDeviation, startN + halfDeviation);
        }

        protected int NextRandom() => _rnd.Next();
        protected int NextRandom(int max) => _rnd.Next(max);
        protected int NextRandom(int min, int max) => _rnd.Next(min, max);

        protected float NextRandom(float max) => (float)_rnd.NextDouble() * max;
        protected float NextRandom(float min, float max) => ((float)_rnd.NextDouble() * (max - min)) + min;

    }
}
