using chapter_06.Enum;
using chapter_06.Input;
using chapter_06.Input.Base;
using chapter_06.Objects;
using chapter_06.States.Base;

using System.Collections.Generic;

namespace chapter_06.States
{
    public class SplashState : BaseGameState
    {
        public override void LoadContent()
        {
            AddGameObject(new SplashImage(LoadTexture("splash")));
        }

        public override void HandleInput(Microsoft.Xna.Framework.GameTime gameTime)
        {
            InputManager.GetCommands(cmd =>
            {
                if (cmd is SplashInputCommand.GameSelect)
                {
                    SwitchState(new GameplayState());
                }

                if (cmd is SplashInputCommand.GameExit)
                {
                    NotifyEvent(Events.GAME_QUIT);
                }
            });
        }

        protected override void SetInputManager()
        {
            var devices = new List<InputDevices> { InputDevices.KEYBOARD };
            InputManager = new InputManager(devices, new SplashInputMapper());
        }
    }
}