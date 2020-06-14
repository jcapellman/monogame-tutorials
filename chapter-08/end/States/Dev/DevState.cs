using chapter_08.Engine.Input;
using chapter_08.Engine.States;
using chapter_08.Input;
using chapter_08.States.Dev.Particles;
using Microsoft.Xna.Framework;

namespace chapter_08.States
{
    public class DevState : BaseGameState
    {
        private const string ExhaustTexture = "Cloud";

        private ExhaustEmitter _exhaustEmitter;

        public override void LoadContent()
        {
            var exhaustPosition = new Vector2(_viewportWidth / 2, _viewportHeight / 2);
            _exhaustEmitter = new ExhaustEmitter(LoadTexture(ExhaustTexture), exhaustPosition);
            AddGameObject(_exhaustEmitter);
        }

        public override void HandleInput(GameTime gameTime)
        {
            InputManager.GetCommands(cmd =>
            {
                if (cmd is DevInputCommand.DevQuit)
                {
                    NotifyEvent(new BaseGameStateEvent.GameQuit());
                }
            });
        }

        public override void UpdateGameState(GameTime gameTime) 
        {
            _exhaustEmitter.Position = new Vector2(_exhaustEmitter.Position.X, _exhaustEmitter.Position.Y - 2f);
            _exhaustEmitter.Update(gameTime);
        }

        protected override void SetInputManager()
        {
            InputManager = new InputManager(new DevInputMapper());
        }
    }
}