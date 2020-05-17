using chapter_06.Input.Base;
using Microsoft.Xna.Framework.Input;

namespace chapter_06.Input
{
    public class SplashInputMapper : BaseInputMapper
    {
        public override BaseInputCommand GetKeyboardState()
        {
            var state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Escape))
            {
                return new SplashInputCommand.GameExit();
            }

            if (state.IsKeyDown(Keys.Enter))
            {
                return new SplashInputCommand.GameSelect();
            }

            return new BaseInputCommand.NothingToDo();
        }
    }
}
