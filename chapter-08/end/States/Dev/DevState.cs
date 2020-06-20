using chapter_08.Engine.Input;
using chapter_08.Engine.States;
using chapter_08.Input;
using chapter_08.Objects;
using chapter_08.States.Dev.Particles;
using Microsoft.Xna.Framework;

namespace chapter_08.States
{
    public class DevState : BaseGameState
    {
        private const string ExhaustTexture = "Cloud";
        private const string MissileTexture = "Missile";
        private const string PlayerFighter = "fighter";

        private ExhaustEmitter _exhaustEmitter;
        private Missile _missle;
        private PlayerSprite _player;

        public override void LoadContent()
        {
            var exhaustPosition = new Vector2(_viewportWidth / 2, _viewportHeight / 2);
            //_exhaustEmitter = new ExhaustEmitter(LoadTexture(ExhaustTexture), exhaustPosition);
            //AddGameObject(_exhaustEmitter);

            _missle = new Missile(LoadTexture(MissileTexture), LoadTexture(ExhaustTexture));

            _player = new PlayerSprite(LoadTexture(PlayerFighter));
            _player.Position= new Vector2(500, 500);
            AddGameObject(_player);
        }

        public override void HandleInput(GameTime gameTime)
        {
            InputManager.GetCommands(cmd =>
            {
                if (cmd is DevInputCommand.DevQuit)
                {
                    NotifyEvent(new BaseGameStateEvent.GameQuit());
                }

                if (cmd is DevInputCommand.DevShoot)
                {
                    _missle.Position = new Vector2(_player.Position.X, _player.Position.Y - 25);
                    AddGameObject(_missle);
                }

            });
        }

        public override void UpdateGameState(GameTime gameTime) 
        {
            //_exhaustEmitter.Position = new Vector2(_exhaustEmitter.Position.X, _exhaustEmitter.Position.Y - 3f);
            //_exhaustEmitter.Update(gameTime);

            _missle.Update(gameTime);

            //if (_exhaustEmitter.Position.Y < -200)
            //{
            //    RemoveGameObject(_exhaustEmitter);
            //}

            if (_missle.Position.Y < -100)
            {
                RemoveGameObject(_missle);
            }
        }

        protected override void SetInputManager()
        {
            InputManager = new InputManager(new DevInputMapper());
        }
    }
}