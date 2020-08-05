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

        public TurretBulletSprite(Texture2D texture, Vector2 direction, float angle)
        {
            _texture = texture;
            _direction = direction;
            _direction.Normalize();

            _bulletCenterPosition = new Vector2(_texture.Width / 2, _texture.Height / 2);
            _angle = angle;

            // TODO: find bounding box...
            //AddBoundingBox(new Engine.Objects.BoundingBox(new Vector2(BBPosX, BBPosY), BBWidth, BBHeight));
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
