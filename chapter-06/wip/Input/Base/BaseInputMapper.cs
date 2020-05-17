namespace chapter_06.Input.Base
{
    public interface IBaseInputMapper<out T> where T : BaseInputCommand
        //public interface IBaseInputMapper
    {
        BaseInputCommand GetKeyboardState();
        BaseInputCommand GetMouseState();
        BaseInputCommand GetGamePadState();
        BaseInputCommand GetTouchState();
    }
}
