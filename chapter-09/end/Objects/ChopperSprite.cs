using chapter_09.Engine.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace chapter_09.Objects
{
    public class ChopperSprite : BaseGameObject
    {
        private const float Speed = 8.0f;
        private const float BladeSpeed = 0.2f;
        private const int ChopperWidth = 44;
        private const int ChopperHeight = 98;
        private const int BladesStartX = 133;
        private const int BladesStartY = 98;
        private const int BladesWidth = 94;
        private const int BladesHeight = 94;
        private const float BladesCenterX = 47.5f;
        private const float BladesCenterY = 47.5f;
        private const int ChopperBladePosX = ChopperWidth / 2;
        private const int ChopperBladePosY = 34;
        private const float PI = 3.14159f;

        private float _angle = 0.0f;

        public ChopperSprite(Texture2D texture)
        {
            _texture = texture;
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            var chopperRect = new Rectangle(0, 0, ChopperWidth, ChopperHeight);
            var chopperDestRect = new Rectangle(_position.ToPoint(), new Point(ChopperWidth, ChopperHeight));

            var bladesRect = new Rectangle(BladesStartX, BladesStartY, BladesWidth, BladesHeight);
            var bladesDestRect = new Rectangle(_position.ToPoint(), new Point(BladesWidth, BladesHeight));

            spriteBatch.Draw(_texture, chopperDestRect, chopperRect, Color.White, PI, new Vector2(ChopperBladePosX, ChopperBladePosY), SpriteEffects.None, 0f);
            spriteBatch.Draw(_texture, bladesDestRect, bladesRect, Color.White, _angle, new Vector2(BladesCenterX, BladesCenterY), SpriteEffects.None, 0f);

            _angle += BladeSpeed;
        }
    }
}