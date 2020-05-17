using chapter_06.Input.Base;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace chapter_06.Input
{
    public class SplashInputMapper : BaseInputMapper
    {
        public override IEnumerable<BaseInputCommand> GetKeyboardState()
        {
            var commands = new List<SplashInputCommand>();
            var state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Escape))
            {
                commands.Add(new SplashInputCommand.GameExit());
            }

            if (state.IsKeyDown(Keys.Enter))
            {
                commands.Add(new SplashInputCommand.GameSelect());
            }

            return commands;
        }
    }
}
