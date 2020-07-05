﻿using chapter_09.Engine.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace chapter_09.Objects
{
    public class BulletSprite : BaseGameObject
    {
        private const float BULLET_SPEED = 10.0f;

        public BulletSprite(Texture2D texture)
        {
            _texture = texture;
            AddBoundingBox(new Engine.Objects.BoundingBox(new Vector2(9, 4), 10, 22));
        }

        public void MoveUp()
        {
            Position = new Vector2(Position.X, Position.Y - BULLET_SPEED);
        }
    }
}
