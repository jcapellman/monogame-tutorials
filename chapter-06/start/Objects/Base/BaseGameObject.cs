using chapter_06.Enum;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace chapter_06.Objects.Base
{
    public class BaseGameObject
    {
        protected Texture2D _texture;

        private Vector2 _position = Vector2.One;

        public int zIndex;

        public virtual void OnNotify(Events eventType, object argument = null) { }

        public void Render(SpriteBatch spriteBatch)
        {
            // TODO: Drawing call here
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}