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

        private TurretSprite _turret;

        public override void LoadContent()
        {
            _turret = new TurretSprite(LoadTexture(TurretTexture), LoadTexture(TurretMG2Texture), 2);
            _turret.Position = new Vector2(200, 200);
            AddGameObject(_turret);
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
                    _turret.MoveLeft();
                }

                if (cmd is DevInputCommand.DevRight)
                {
                    _turret.MoveRight();
                }

                if (cmd is DevInputCommand.DevShoot)
                {
                }
            });
        }

        public override void UpdateGameState(GameTime gameTime) 
        {
        }

        protected override void SetInputManager()
        {
            InputManager = new InputManager(new DevInputMapper());
        }
    }
}