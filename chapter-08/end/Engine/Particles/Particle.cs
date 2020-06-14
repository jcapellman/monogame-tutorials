using Microsoft.Xna.Framework;
using System;

namespace chapter_08.Engine.Particles
{
    public class Particle
    {
        public Vector2 Position { get; private set; }
        public float Scale { get; private set; }
        public float Opacity { get; private set; }

        private TimeSpan _activatedTime;

        private TimeSpan _lifespan;
        private Vector2 _direction;
        private Vector2 _gravity;
        private float _velocity;
        private float _acceleration;
        private float _rotation;
        private float _opacityFadingRate;

        public Particle() { }

        public void Activate(TimeSpan lifespan, Vector2 position, Vector2 direction, Vector2 gravity,
                             float velocity, float acceleration,
                             float scale, float rotation, float opacity, float opacityFadingRate,
                             TimeSpan activationTime) 
        {
            _lifespan = lifespan;
            Position = position;
            _direction = direction;
            _velocity = velocity;
            _gravity = gravity;
            _acceleration = acceleration;
            Scale = scale;
            _rotation = rotation;
            Opacity = opacity;
            _opacityFadingRate = opacityFadingRate;

            _activatedTime = activationTime;
        }
 
        // returns false if it went past its lifespan
        public bool Update(GameTime gameTime)
        {
            // TODO: update rotation, scale, opacity
            _velocity *= _acceleration;
            _direction += _gravity;
            
            var positionDelta = _direction * _velocity;

            Position += positionDelta;

            Opacity -= _opacityFadingRate;

            // return true if particle can stay alive
            return gameTime.TotalGameTime - _activatedTime < _lifespan;
        }
    }
}
