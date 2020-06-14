﻿using chapter_08.Engine.Objects;
using chapter_08.Engine.Particles.EmitterTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace chapter_08.Engine.Particles
{
    public class Emitter : BaseGameObject
    {
        private LinkedList<Particle> _activeParticles = new LinkedList<Particle>();
        private LinkedList<Particle> _inactiveParticles = new LinkedList<Particle>();
        private BaseEmitterType _emitterType;
        private int _nbParticleEmittedPerUpdate = 0;
        private int _maxNbParticle = 0;

        public Emitter(Texture2D texture, Vector2 position, BaseEmitterType emitterType, int nbParticleEmittedPerUpdate, int maxParticles)
        {
            _emitterType = emitterType;
            _texture = texture;
            _nbParticleEmittedPerUpdate = nbParticleEmittedPerUpdate;
            _maxNbParticle = maxParticles;
            Position = position;
        }

        public void Update(GameTime gameTime)
        {
            EmitParticles(gameTime.TotalGameTime);

            var particleNode = _activeParticles.First;
            while (particleNode != null)
            {
                var nextNode = particleNode.Next;
                var stillAlive = particleNode.Value.Update(gameTime);
                if (!stillAlive)
                {
                    _activeParticles.Remove(particleNode);
                    _inactiveParticles.AddLast(particleNode.Value);
                }

                particleNode = nextNode;
            }
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            var sourceRectangle = new Rectangle(0, 0, _texture.Width, _texture.Height);

            foreach (var particle in _activeParticles)
            {
                //spriteBatch.Draw(_texture, particle.Position, Color.White);
                spriteBatch.Draw(_texture, particle.Position, sourceRectangle, Color.White * particle.Opacity, 0.0f, new Vector2(0, 0), particle.Scale, SpriteEffects.None, zIndex);
            }
        }

        private void EmitParticles(TimeSpan emitionTime)
        {
            // make sure we're not at max particles
            if (_activeParticles.Count >= _maxNbParticle)
            {
                return;
            }

            var maxAmountThatCanBeCreated = _maxNbParticle - _activeParticles.Count;
            var neededParticles = Math.Min(maxAmountThatCanBeCreated, _nbParticleEmittedPerUpdate);

            // reuse inactive particles first before creating new ones
            var nbToReuse = Math.Min(_inactiveParticles.Count, neededParticles);
            var nbToCreate = neededParticles - nbToReuse;

            for(var i = 0; i < nbToReuse; i++)
            {
                var particleNode = _inactiveParticles.First;

                EmitNewParticle(particleNode.Value, emitionTime);
                _inactiveParticles.Remove(particleNode);
            }

            for(var i = 0; i < nbToCreate; i++)
            {
                var particle = new Particle();
                EmitNewParticle(particle, emitionTime);
            }
        }

        private void EmitNewParticle(Particle particle, TimeSpan emitionTime)
        {
            var lifespan = _emitterType.GenerateLifespan();
            var direction = _emitterType.GetParticleDirection();
            var position = _emitterType.GetParticlePosition(_position);
            var velocity = _emitterType.GenerateVelocity();
            var scale = _emitterType.GenerateScale();
            var rotation = _emitterType.GenerateRotation();
            var opacity = _emitterType.GenerateOpacity();
            var gravity = _emitterType.Gravity;
            var acceleration = _emitterType.Acceleration;
            var opacityFadingRate = _emitterType.OpacityFadingRate;

            particle.Activate(lifespan, position, direction, gravity, velocity, acceleration, scale, rotation, opacity, opacityFadingRate, emitionTime);

            _activeParticles.AddLast(particle);
        }
    }
}
