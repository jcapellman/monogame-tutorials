using chapter_08.Engine.Input;
using chapter_08.Engine.States;
using chapter_08.Input;
using Microsoft.Xna.Framework;

namespace chapter_08.States
{
    public class DevState : BaseGameState
    {
        public override void LoadContent()
        {
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

        public override void UpdateGameState(GameTime _) 
        { 

        }

        protected override void SetInputManager()
        {
            InputManager = new InputManager(new DevInputMapper());
        }
    }
}