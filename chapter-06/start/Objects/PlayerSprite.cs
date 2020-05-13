using chapter_06.Enum;
using chapter_06.Objects.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace chapter_06.Objects
{
    public class PlayerSprite : BaseGameObject
    {
        public PlayerSprite(Texture2D texture)
        {
            _texture = texture;
        }
    }
}