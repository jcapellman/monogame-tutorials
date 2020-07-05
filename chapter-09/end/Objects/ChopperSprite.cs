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

        private int _age = 0;
        private Vector2 _direction = new Vector2(0, 0);
        private int _life = 50;
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
            var chopperRect = new Rectangle(0, 0, ChopperWidth, ChopperHeight);
            var chopperDestRect = new Rectangle(_position.ToPoint(), new Point(ChopperWidth, ChopperHeight));

            var bladesRect = new Rectangle(BladesStartX, BladesStartY, BladesWidth, BladesHeight);
            var bladesDestRect = new Rectangle(_position.ToPoint(), new Point(BladesWidth, BladesHeight));

            var color = GetColor();
            spriteBatch.Draw(_texture, chopperDestRect, chopperRect, color, PI, new Vector2(ChopperBladePosX, ChopperBladePosY), SpriteEffects.None, 0f);
            spriteBatch.Draw(_texture, bladesDestRect, bladesRect, Color.White, _angle, new Vector2(BladesCenterX, BladesCenterY), SpriteEffects.None, 0f);

            _angle += BladeSpeed;
        }

        private Color GetColor()
        {
            var color = Color.White;
            if (_justHit)
            {
                // want to flash the chopper 4 times per seconds when it gets hit for a few frames
                // so every 15 frames, flash for 5 frames.
                if ((_hitAt >= 0 && _hitAt < 3) ||
                    (_hitAt >= 10 && _hitAt < 13))
                {
                    color = Color.OrangeRed;
                }

                _hitAt++;
            }

            if (_hitAt > 60)
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
                case GameplayEvents.MissileHitsChopper _:
                    _justHit = true;
                    _hitAt = 0;
                    _life -= 25;
                    SendEvent(new GameplayEvents.EnemyLostLife(_life));
                    break;

                case GameplayEvents.BulletHitsChopper _:
                    _justHit = true;
                    _hitAt = 0;
                    _life -= 5;
                    SendEvent(new GameplayEvents.EnemyLostLife(_life));
                    break;
            }
        }
    }
}