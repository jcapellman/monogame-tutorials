using System.Collections.Generic;

namespace chapter_06.Input.Base
{
    public class BaseInputMapper
    {
        public virtual IEnumerable<BaseInputCommand> GetKeyboardState()
        {
            return new List<BaseInputCommand>();
        }

        public virtual IEnumerable<BaseInputCommand> GetMouseState()
        {
            return new List<BaseInputCommand>();
        }

        public virtual IEnumerable<BaseInputCommand> GetGamePadState()
        {
            return new List<BaseInputCommand>();
        }
        
        public virtual IEnumerable<BaseInputCommand> GetTouchState()
        {
            return new List<BaseInputCommand>();
        }
    }
}
