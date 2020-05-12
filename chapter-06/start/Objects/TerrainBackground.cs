using chapter_06.Enum;
using chapter_06.Objects.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace chapter_06.Objects
{
    public class TerrainBackground : BaseGameObject
    { 
        public TerrainBackground(Texture2D texture)
        {
            _texture = texture;
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            // TODO: Drawing call here
            var viewport = spriteBatch.GraphicsDevice.Viewport;
            var rectangle = new Rectangle(0, 0, viewport.Width, viewport.Height);
            spriteBatch.Draw(_texture, rectangle, Color.White);
        }
    }
}
