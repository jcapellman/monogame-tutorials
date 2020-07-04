using chapter_09.Engine.Input;
using chapter_09.Engine.States;
using chapter_09.Input;
using chapter_09.Objects;
using chapter_09.States.Particles;
using Microsoft.Xna.Framework;

namespace chapter_09.States
{
    /// <summary>
    /// Used to test out new things, like particle engines and shooting missiles
    /// </summary>
    public class DevState : BaseGameState
    {
        private const string ExhaustTexture = "Cloud";
        private const string ChopperTexture = "Chopper";

        private ChopperSprite _chopper;

        public override void LoadContent()
        {
            _chopper = new ChopperSprite(LoadTexture(ChopperTexture));
            _chopper.Position = new Vector2(500, 500);
            AddGameObject(_chopper);
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
        }

        protected override void SetInputManager()
        {
            InputManager = new InputManager(new DevInputMapper());
        }
    }
}