using chapter_11.Engine.Input;
using chapter_11.Engine.States;
using chapter_11.Input;
using chapter_11.Objects;
using chapter_11.Objects.Text;
using chapter_11.States.Particles;
using Microsoft.Xna.Framework;
using System;

namespace chapter_11.States
{
    /// <summary>
    /// Used to test out new things, like particle engines and shooting missiles
    /// </summary>
    public class DevState : BaseGameState
    {
        private const string TurretTexture = "Sprites/Turrets/Tower";
        private const string TurretMG2Texture = "Sprites/Turrets/MG2";
        private const string TurretBulletTexture = "Sprites/Turrets/Bullet_MG";

        private const string PlayerFighter = "Sprites/Animations/FighterSpriteSheet";
        private PlayerSprite _playerSprite;

        private TurretSprite _turret;

        public override void LoadContent()
        {
            _turret = new TurretSprite(LoadTexture(TurretTexture), LoadTexture(TurretMG2Texture), 2);
            _turret.Position = new Vector2(605, 200);
            AddGameObject(_turret);

            _playerSprite = new PlayerSprite(LoadTexture(PlayerFighter));
            // position the player in the middle of the screen, at the bottom, leaving a slight gap at the bottom
            var playerXPos = _viewportWidth / 2 - _playerSprite.Width / 2;
            var playerYPos = _viewportHeight - _playerSprite.Height - 30;
            _playerSprite.Position = new Vector2(playerXPos, playerYPos);
            AddGameObject(_playerSprite);
        }

        public override void HandleInput(GameTime gameTime)
        {
            InputManager.GetCommands(cmd =>
            {
                if (cmd is DevInputCommand.DevQuit)
                {
                    NotifyEvent(new BaseGameStateEvent.GameQuit());
                }

                if (cmd is DevInputCommand.DevLeft)
                {
                    _playerSprite.MoveLeft();
                }

                if (cmd is DevInputCommand.DevRight)
                {
                    _playerSprite.MoveRight();
                }

                if (cmd is DevInputCommand.DevShoot)
                {
                }
            });
        }

        public override void UpdateGameState(GameTime gameTime) 
        {
            _playerSprite.Update(gameTime);
            _turret.Update(gameTime, _playerSprite.CenterPosition);
        }

        protected override void SetInputManager()
        {
            InputManager = new InputManager(new DevInputMapper());
        }
    }
}