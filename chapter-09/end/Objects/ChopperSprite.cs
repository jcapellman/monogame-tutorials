using chapter_09.Engine.Objects;
using chapter_09.Engine.States;
using chapter_09.States.Gameplay;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace chapter_09.Objects
{
    public class ChopperSprite : BaseGameObject
    {
        private const float Speed = 4.0f;
        private const float BladeSpeed = 0.2f;

        // which chopper do we want from the texture
        private const int ChopperStartX = 0;
        private const int ChopperStartY = 0;
        private const int ChopperWidth = 44;
        private const int ChopperHeight = 98;

        // where are the blades on the texture
        private const int BladesStartX = 133;
        private const int BladesStartY = 98;
        private const int BladesWidth = 94;
        private const int BladesHeight = 94;

        // rotation center of the blades
        private const float BladesCenterX = 47.5f;
        private const float BladesCenterY = 47.5f;

        // positioning of the blades on the chopper
        private const int ChopperBladePosX = ChopperWidth / 2;
        private const int ChopperBladePosY = 34;

        // initial direction and speed of chopper
        private float _angle = 0.0f;
        private Vector2 _direction = new Vector2(0, 0);

        // track life total and age of chopper
        private int _age = 0;
        private int _life = 40;

        // chopper will flash red when hit
        private bool _justHit = false;
        private int _hitAt = 0;

        private List<(int, Vector2)> _path;

        public ChopperSprite(Texture2D texture, List<(int, Vector2)> path)
        {
            _texture = texture;
            _path = path;
            AddBoundingBox(new Engine.Objects.BoundingBox(new Vector2(-16, -63), 34, 98));
        }

        public void Update()
        {
            foreach(var p in _path)
            {
                int pAge = p.Item1;
                Vector2 pDirection = p.Item2;

                if (_age > pAge)
                {
                    _direction = pDirection;
                }
            }

            Position = Position + (_direction * Speed);

            _age++;
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            var chopperRect = new Rectangle(ChopperStartX, ChopperStartY, ChopperWidth, ChopperHeight);
            var chopperDestRect = new Rectangle(_position.ToPoint(), new Point(ChopperWidth, ChopperHeight));

            var bladesRect = new Rectangle(BladesStartX, BladesStartY, BladesWidth, BladesHeight);
            var bladesDestRect = new Rectangle(_position.ToPoint(), new Point(BladesWidth, BladesHeight));

            // if the chopper was just hit and is flashing, Color should alternate between OrangeRed and White
            var color = GetColor();
            spriteBatch.Draw(_texture, chopperDestRect, chopperRect, color, MathHelper.Pi, new Vector2(ChopperBladePosX, ChopperBladePosY), SpriteEffects.None, 0f);
            spriteBatch.Draw(_texture, bladesDestRect, bladesRect, Color.White, _angle, new Vector2(BladesCenterX, BladesCenterY), SpriteEffects.None, 0f);

            _angle += BladeSpeed;
        }

        private Color GetColor()
        {
            var maxFlashFrame = 13;
            var color = Color.White;

            if (_justHit)
            {
                // want to flash the chopper 2 times very quickly whenever it gets hit. Each flash lasts for 4 frames
                // flash #1: from frame 0 to frame 3
                // flash #2: from frame 10 to frame 13
                if ((_hitAt >= 0 && _hitAt < 3) ||
                    (_hitAt >= 10 && _hitAt < maxFlashFrame))
                {
                    color = Color.OrangeRed;
                }

                _hitAt++;
            }

            // reset hit tracking after frame 13
            if (_hitAt > maxFlashFrame)
            {
                _justHit = false;
                _hitAt = 0;
            }

            return color;
        }

        public override void OnNotify(BaseGameStateEvent gameEvent)
        {
            switch (gameEvent)
            {
                case GameplayEvents.ChopperHitBy m:
                    JustHit(m.HitBy);
                    SendEvent(new GameplayEvents.EnemyLostLife(_life));
                    break;
            }
        }

        private void JustHit(IGameObjectWithDamage o)
        {
            _justHit = true;
            _hitAt = 0;
            _life -= o.Damage;
        }
    }
}