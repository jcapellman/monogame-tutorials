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

        private float _angle;
        private float _moveSpeed;
        private const float Scale = 0.3f;
        private const float AngleSpeed = 0.1f;
        private const int BulletsPerShot = 3;
        private const float CannonCenterPosY = 158;

        private int _hitAt = 100;
        private int _life = 40;

        private Vector2 _baseCenterPosition;
        private Vector2 _cannonCenterPosition;
        private float _baseTextureWidth;
        private float _baseTextureHeight;
        private float _cannonTextureWidth;
        private float _cannonTextureHeight;

        public event EventHandler<GameplayEvents.TurretShoots> OnTurretShoots;

        public TurretSprite(Texture2D baseTexture, Texture2D cannonTexture, float moveSpeed)
        {
            _moveSpeed = moveSpeed;
            _baseTexture = baseTexture;
            _cannonTexture = cannonTexture;
            _angle = 0.0f;

            _baseTextureWidth = _baseTexture.Width * Scale;
            _baseTextureHeight = _baseTexture.Height * Scale;
            _cannonTextureWidth = _cannonTexture.Width * Scale;
            _cannonTextureHeight = _cannonTexture.Height * Scale;

            _baseCenterPosition = new Vector2(_baseTextureWidth / 2f, _baseTextureHeight / 2f);
            _cannonCenterPosition = new Vector2(_cannonTexture.Width / 2f, CannonCenterPosY);

            AddBoundingBox(new Engine.Objects.BoundingBox(new Vector2(0, 0), _baseTexture.Width * Scale, _baseTexture.Height * Scale));
        }

        public void Update(GameTime gametime)
        {

        }

        public override void Render(SpriteBatch spriteBatch)
        {
            // if the turret was just hit and is flashing, Color should alternate between OrangeRed and White
            var color = GetColor();

            var cannonPosX = _position.X + _baseCenterPosition.X;
            var cannonPosY = _position.Y + _baseCenterPosition.Y;
            var cannonPosition = new Vector2(cannonPosX, cannonPosY);

            spriteBatch.Draw(_baseTexture, _position, _baseTexture.Bounds, color, 0, new Vector2(0, 0), Scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(_cannonTexture, cannonPosition, _cannonTexture.Bounds, Color.White, _angle, _cannonCenterPosition, Scale, SpriteEffects.None, 0f);
        }

        public void MoveLeft()
        {
            _angle -= AngleSpeed;
        }

        public void MoveRight()
        {
            _angle += AngleSpeed;
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
