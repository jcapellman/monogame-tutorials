using chapter_09.Engine.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace chapter_09.Objects
{
    public class PlayerSprite : BaseGameObject
    {
        private const float PLAYER_SPEED = 10.0f;

        public PlayerSprite(Texture2D texture)
        {
            _texture = texture;
            AddBoundingBox(new Engine.Objects.BoundingBox(new Vector2(29, 2), 57, 147));
            AddBoundingBox(new Engine.Objects.BoundingBox(new Vector2(2, 77), 111, 37));
        }

        public void MoveLeft()
        {
            Position = new Vector2(Position.X - PLAYER_SPEED, Position.Y);
        }

        public void MoveRight()
        {
            Position = new Vector2(Position.X + PLAYER_SPEED, Position.Y);
        }
    }
}