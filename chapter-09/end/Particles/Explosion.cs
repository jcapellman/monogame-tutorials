using chapter_09.Engine.Particles;
using chapter_09.Engine.Particles.EmitterTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace chapter_09.States.Particles
{
    public class ExplosionParticleState : EmitterParticleState
    {
        public override int MinLifespan => 60; // equivalent to 1 second

        public override int MaxLifespan => 90;

        public override float Velocity => 2.0f;

        public override float VelocityDeviation => 0.0f;

        public override float Acceleration => 0.999f;

        public override Vector2 Gravity => new Vector2(0, 1);

        public override float Opacity => 0.5f;

        public override float OpacityDeviation => 0.1f;

        public override float OpacityFadingRate => 0.97f;

        public override float Rotation => 0.0f;

        public override float RotationDeviation => 0.0f;

        public override float Scale => 0.3f;

        public override float ScaleDeviation => 0.1f;
    }

    public class ExplosionEmitter : Emitter
    {
        private const int NbParticles = 3;
        private const int MaxParticles = 200;
        private const float Radius = 50f;

        public ExplosionEmitter(Texture2D texture, Vector2 position) : 
            base(texture, position, new ExplosionParticleState(), new CircleEmitterType(Radius), NbParticles, MaxParticles) { }
    }
}
