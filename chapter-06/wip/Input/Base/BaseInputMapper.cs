namespace chapter_06.Input.Base
{
    //public interface IBaseInputMapper
    //{
    //    BaseInputCommand GetKeyboardState();
    //    BaseInputCommand GetMouseState();
    //    BaseInputCommand GetGamePadState();
    //    BaseInputCommand GetTouchState();
    //}
    public class BaseInputMapper
    {
        public virtual BaseInputCommand GetKeyboardState()
        {
            return new BaseInputCommand.NothingToDo();
        }

        public virtual BaseInputCommand GetMouseState()
        {
            return new BaseInputCommand.NothingToDo();
        }

        public virtual BaseInputCommand GetGamePadState()
        {
            return new BaseInputCommand.NothingToDo();
        }
        
        public virtual BaseInputCommand GetTouchState()
        {
            return new BaseInputCommand.NothingToDo();
        }
    }
}
