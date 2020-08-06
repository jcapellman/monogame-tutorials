using chapter_11.Engine.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace chapter_11.Objects
{
    public class TurretBulletSprite : BaseGameObject
    {
        private const float BULLET_SPEED = 18.0f;
        private Vector2 _direction;
        private Vector2 _bulletCenterPosition;
        private float _angle;
        private Matrix _rotationMatrix;

        public Segment CollisionSegment
        { 
            get
            {
                var segment = _direction * _texture.Height;
                return new Segment(_position, Vector2.Transform(segment, _rotationMatrix));
            } 
        }

        public TurretBulletSprite(Texture2D texture, Vector2 direction, float angle)
        {
            _texture = texture;
            _direction = direction;
            _direction.Normalize();

            _bulletCenterPosition = new Vector2(_texture.Width / 2, _texture.Height / 2);
            _angle = angle;

            // This bullet will not have a bounding box at this point. We will instead use the intersection
            // of a line with other bounding boxes. To find the line, we will rotate the texture's height, so we
            // need to create a rotation matrix
            _rotationMatrix = Matrix.CreateRotationZ(_angle);
        }

        public void Update()
        {
            Position = Position + _direction * BULLET_SPEED;
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, _texture.Bounds, Color.White, _angle, _bulletCenterPosition, 1f, SpriteEffects.None, 0f);
        }
    }
}
