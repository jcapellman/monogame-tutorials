using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace chapter_04.Objects.Base
{
    public class BaseGameObject
    {
        private Texture2D _texture;

        private Vector2 _position;

        public int zIndex;

        public void Render(SpriteBatch spriteBatch)
        {
            // TODO: Drawing call here
        }
    }
}