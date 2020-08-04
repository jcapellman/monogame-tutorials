using chapter_11.Engine.Objects;
using chapter_11.Engine.States;
using chapter_11.States.Gameplay;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace chapter_11.Objects
{
    public class TurretSprite : BaseGameObject
    {
        private Texture2D _baseTexture;
        private Texture2D _cannonTexture;

        private float _moveSpeed;
        private const float AngleSpeed = 1.0f;
        private float _angle;
        private const int BulletsPerShot = 3;

        private int _hitAt = 100;
        private int _life = 40;

        private Vector2 _baseCenterPosition;
        private Vector2 _cannonCenterPosition;

        public event EventHandler<GameplayEvents.TurretShoots> OnTurretShoots;

        public TurretSprite(Texture2D baseTexture, Texture2D cannonTexture, float moveSpeed)
        {
            _moveSpeed = moveSpeed;
            _baseTexture = baseTexture;
            _cannonTexture = cannonTexture;
            _angle = 0.0f;

            _baseCenterPosition = new Vector2(_baseTexture.Width / 2f, _baseTexture.Height / 2f);
            _cannonCenterPosition = new Vector2(_cannonTexture.Width / 2f, _cannonTexture.Height / 2f);

            AddBoundingBox(new Engine.Objects.BoundingBox(new Vector2(0, 0), _baseTexture.Width, _baseTexture.Height));
        }

        public void Update(GameTime gametime)
        {

        }

        public override void Render(SpriteBatch spriteBatch)
        {
            var baseRectangle = new Rectangle(0, 0, _baseTexture.Width, _baseTexture.Height);
            var baseDestRectangle = new Rectangle((int) _position.X, (int) _position.Y, _baseTexture.Width, _baseTexture.Height);

            var cannonPosX = _position.X + _baseCenterPosition.X - _cannonCenterPosition.X;
            var cannonPosY = _position.Y + _baseCenterPosition.Y - 160;
            var cannonRectangle = new Rectangle(0, 0, _cannonTexture.Width, _cannonTexture.Height);
            var cannonDestRectangle = new Rectangle((int) cannonPosX, (int) cannonPosY, _cannonTexture.Width, _cannonTexture.Height);
            var cannonOrigin = new Vector2(cannonPosX + _cannonCenterPosition.X, cannonPosY + _cannonCenterPosition.Y + 41);

            // if the turret was just hit and is flashing, Color should alternate between OrangeRed and White
            var color = GetColor();

            spriteBatch.Draw(_baseTexture, baseDestRectangle, baseRectangle, color, 0, new Vector2(0, 0), SpriteEffects.None, 0f);
            //spriteBatch.Draw(_cannonTexture, cannonDestRectangle, cannonRectangle, Color.White, _angle, new Vector2(_cannonCenterPosition.X, _cannonCenterPosition.Y), SpriteEffects.None, 0f);




            //spriteBatch.Draw(_cannonTexture, cannonDestRectangle, cannonRectangle, Color.White, 1, new Vector2(_cannonCenterPosition.X, _cannonCenterPosition.Y), SpriteEffects.None, 0f);
            spriteBatch.Draw(_cannonTexture, cannonDestRectangle, cannonRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.None, 0f);
            var pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            pixel.SetData<Color>(new Color[] { Color.White });
            spriteBatch.Draw(pixel, new Rectangle((int) cannonOrigin.X - 3, (int) cannonOrigin.Y - 3, 6, 6), Color.White);
        }

        private void Shoot()
        {
            OnTurretShoots?.Invoke(this, new GameplayEvents.TurretShoots(BulletsPerShot));
        }

        public override void OnNotify(BaseGameStateEvent gameEvent)
        {
            switch (gameEvent)
            {
                case GameplayEvents.ObjectHitBy m:
                    JustHit(m.HitBy);
                    SendEvent(new GameplayEvents.ObjectLostLife(_life));
                    break;
            }
        }

        private void JustHit(IGameObjectWithDamage o)
        {
            _hitAt = 0;
            _life -= o.Damage;
        }

        private Color GetColor()
        {
            var color = Color.White;
            foreach (var flashStartEndFrames in GetFlashStartEndFrames())
            {
                if (_hitAt >= flashStartEndFrames.Item1 && _hitAt < flashStartEndFrames.Item2)
                {
                    color = Color.OrangeRed;
                }    
            }

            _hitAt++;
            return color;
        }

        private List<(int, int)> GetFlashStartEndFrames()
        {
            return new List<(int, int)>
            {
                (0, 3),
                (10, 13)
            };
        }
    }
}
