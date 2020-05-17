using chapter_06.Input.Base;
using Microsoft.Xna.Framework.Input;

namespace chapter_06.Input
{
    public class GameplayInputMapper : BaseInputMapper
    {
        public override BaseInputCommand GetKeyboardState()
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
    }
}
