using chapter_09.Engine.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace chapter_09.Objects
{
    public class ChopperSprite : BaseGameObject
    {
        private const float SPEED = 8.0f;

        public ChopperSprite(Texture2D texture)
        {
            _texture = texture;
        }
    }
}