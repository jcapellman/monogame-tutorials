using chapter_06.Input.Base;
using Microsoft.Xna.Framework.Input;

namespace chapter_06.Input
{
    public class SplashInputMapper : IBaseInputMapper<BaseInputCommand>
    {
        public BaseInputCommand GetGamePadState()
        {
            return new BaseInputCommand.NothingToDo();
        }

        public BaseInputCommand GetKeyboardState()
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

        public BaseInputCommand GetMouseState()
        {
            return new BaseInputCommand.NothingToDo();
        }

        public BaseInputCommand GetTouchState()
        {
            return new BaseInputCommand.NothingToDo();
        }
    }
}
