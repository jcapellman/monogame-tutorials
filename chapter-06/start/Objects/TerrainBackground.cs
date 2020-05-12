using chapter_06.Enum;
using chapter_06.Objects.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace chapter_06.Objects
{
    public class TerrainBackground : BaseGameObject
    {
        private float SCROLLING_SPEED = 2.0f;

        public TerrainBackground(Texture2D texture)
        {
            _texture = texture;
            _position = new Vector2(0, 0);
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            var viewport = spriteBatch.GraphicsDevice.Viewport;
            var viewportRectangle = new Rectangle(0, 0, viewport.Width, viewport.Height);

            // draw the texture twice on top of each other with an ever increasing y offset
            // this is to implement the scrolling
            // draw background 1 from (position.y - height) to position.y
            // draw background 2 from (position.y + 1) to (position.y + 1 + height)
            // but we're moving the origin instead of the object, so Y must be negative instead of positive

            var rectangle = new Rectangle(0, 0, _texture.Width, _texture.Height);

            //for (int nbVertical = 0; nbVertical < viewport.Height / _texture.Height + 1; nbVertical++)
            //{
            //    for (int nbHorizontal = 0; nbHorizontal < viewport.Width / _texture.Width + 1; nbHorizontal++)
            //    {
            //        var origin = new Vector2
            //    }
            //}

            // TODO: understand how origin works
            var originTop = new Vector2(_position.X, -(_position.Y - _texture.Height));
            var originMiddle = new Vector2(_position.X, -_position.Y);
            var originBottom = new Vector2(_position.X, -(_position.Y + _texture.Height));

            spriteBatch.Draw(_texture, rectangle, rectangle, Color.White, 0.0f, originTop, SpriteEffects.None, 0);
            spriteBatch.Draw(_texture, rectangle, rectangle, Color.White, 0.0f, originMiddle, SpriteEffects.None, 0);
            spriteBatch.Draw(_texture, rectangle, rectangle, Color.White, 0.0f, originBottom, SpriteEffects.None, 0);


            //var blankWhite = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            //blankWhite.SetData(new[] { Color.White });

            //var blankRed = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            //blankRed.SetData(new[] { Color.Red });

            //var blankBlue = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            //blankBlue.SetData(new[] { Color.Blue });


            //spriteBatch.Draw(blankWhite, rectangle, rectangle, Color.White, 0.0f, originTop, SpriteEffects.None, 0);
            //spriteBatch.Draw(blankRed, rectangle, rectangle, Color.White, 0.0f, originMiddle, SpriteEffects.None, 0);
            //spriteBatch.Draw(blankBlue, rectangle, rectangle, Color.White, 0.0f, originBottom, SpriteEffects.None, 0);

            _position.Y = (int)(_position.Y + SCROLLING_SPEED) % _texture.Height;
        }
    }
}
