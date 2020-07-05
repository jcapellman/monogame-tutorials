using chapter_09.Engine.Objects;
using chapter_09.States.Particles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace chapter_09.Objects
{
    public class MissileSprite : BaseGameObject
    {
        private const float StartSpeed = 0.5f;
        private const float Acceleration = 0.15f;

        private float _speed = StartSpeed;

        // keep track of scaled down texture size
        private int _missileHeight;
        private int _missileWidth;

        // missiles are attached to their own particle emitter
        private ExhaustEmitter _exhaustEmitter;

        public override Vector2 Position 
        { 
            set 
            { 
                _exhaustEmitter.Position = new Vector2(_position.X + 18, _position.Y + _missileHeight - 10);
                base.Position = value;
            }
        }

        public MissileSprite(Texture2D missleTexture, Texture2D exhaustTexture)
        {
            _texture = missleTexture;
            _exhaustEmitter = new ExhaustEmitter(exhaustTexture, _position);

            var ratio = (float) _texture.Height / (float) _texture.Width;
            _missileWidth = 50;
            _missileHeight = (int) (_missileWidth * ratio);

            // note that the missile is scaled down! so it's bounding box must be scaled down as well
            var bbRatio = (float) _missileWidth / _texture.Width;
            var bbX = 352 * bbRatio; // 350 is the original X position of the bounding box on the original texture
            var bbY = 7 * bbRatio;
            var bbW = 150 * bbRatio;
            var bbH = 500 * bbRatio; // note that the height doesn't really matter here since the missile goes straight up, only the tip can collide with anything.

            AddBoundingBox(new Engine.Objects.BoundingBox(new Vector2(bbX, bbY), bbW, bbH));
        }

        public void Update(GameTime gameTime)
        {
            _exhaustEmitter.Update(gameTime);

            Position = new Vector2(Position.X, Position.Y - _speed);
            _speed = _speed + Acceleration;
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            // need to scale down the sprite. The original texture is very big
            var destRectangle = new Rectangle((int) Position.X, (int) Position.Y, _missileWidth, _missileHeight);
            spriteBatch.Draw(_texture, destRectangle, Color.White);

            _exhaustEmitter.Render(spriteBatch);
        }
    }
}
