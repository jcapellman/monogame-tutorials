using chapter_11.Engine.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace chapter_11.Objects
{
    public class TurretBulletSprite : BaseGameObject
    {
        private const float BULLET_SPEED = 12.0f;
        private Vector2 _direction;

        public TurretBulletSprite(Texture2D texture, Vector2 direction)
        {
            _texture = texture;
            _direction = direction;
            _direction.Normalize();

            // TODO: find bounding box...
            //AddBoundingBox(new Engine.Objects.BoundingBox(new Vector2(BBPosX, BBPosY), BBWidth, BBHeight));
        }

        public void Update()
        {
            Position = Position + _direction * BULLET_SPEED;
        }
    }
}
