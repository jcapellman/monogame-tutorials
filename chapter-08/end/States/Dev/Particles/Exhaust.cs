using chapter_08.Engine.Particles;
using chapter_08.Engine.Particles.EmitterTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace chapter_08.States.Dev.Particles
{
    public class ExhaustType : ConeEmitterType
    {
        public ExhaustType()
        {
            Gravity = new Vector2(0, 0);
            Spread = 1.0f;
            Acceleration = 0.8f;
            MinLifespan = TimeSpan.FromSeconds(1.0);
            MaxLifespan = TimeSpan.FromSeconds(2.0);
            Velocity = 4.0f;
            VelocityDeviation = 2.0f;
            Direction = new Vector2(0, 1.0f); // pointing down
            Scale = 0.1f;
            Opacity = 0.8f;
            OpacityFadingRate = 0.02f;
        }
    }

    public class ExhaustEmitter : Emitter
    {
        private const int NbParticles = 4;
        private const int MaxParticles = 1000;
        public ExhaustEmitter(Texture2D texture, Vector2 position) : 
            base(texture, position, new ExhaustType(), NbParticles, MaxParticles) { }
    }
}
