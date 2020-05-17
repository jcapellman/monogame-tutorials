using chapter_06.Input.Base;
using Microsoft.Xna.Framework.Input;

namespace chapter_06.Input
{
    public class GameplayInputMapper : IBaseInputMapper<BaseInputCommand>
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
                return new GameplayInputCommand.GameExit();
            }

            if (state.IsKeyDown(Keys.Left))
            {
                return new GameplayInputCommand.PlayerMoveLeft();
            }

            if (state.IsKeyDown(Keys.Right))
            {
                return new GameplayInputCommand.PlayerMoveRight();
            }

            if (state.IsKeyDown(Keys.Space))
            {
                return new GameplayInputCommand.PlayerShoots();
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
