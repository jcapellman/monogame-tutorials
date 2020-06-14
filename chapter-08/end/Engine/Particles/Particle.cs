using Microsoft.Xna.Framework;
using System;

namespace chapter_08.Engine.Particles
{
    public class Particle
    {
        public Vector2 Position { get; private set; }

        private TimeSpan _activatedTime;
        private bool _isActive;

        private TimeSpan _lifespan;
        private Vector2 _direction;
        private Vector2 _gravity;
        private float _velocity;
        private float _acceleration;
        private float _scale;
        private float _rotation;
        private float _opacity;

        public Particle() { }

        public void Activate(TimeSpan lifespan, Vector2 position, Vector2 direction, Vector2 gravity,
                             float velocity, float acceleration,
                             float scale, float rotation, float opacity,
                             TimeSpan activationTime) 
        {
            _lifespan = lifespan;
            Position = position;
            _direction = direction;
            _velocity = velocity;
            _gravity = gravity;
            _acceleration = acceleration;
            _scale = scale;
            _rotation = rotation;
            _opacity = opacity;

            _isActive = true;
            _activatedTime = activationTime;
        }

        public void Deactivate()
        {
            _isActive = false;
        }
 
        // returns false if it went past its lifespan
        public bool Update(GameTime gameTime)
        {
            // TODO: update rotation, scale, opacity
            _velocity *= _acceleration;
            _direction += _gravity;
            
            var positionDelta = _direction * _velocity;

            Position += positionDelta;

            // return true if particle can stay alive
            return gameTime.TotalGameTime - _activatedTime < _lifespan;
        }
    }
}
