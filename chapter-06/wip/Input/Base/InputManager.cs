using System;
using System.Collections.Generic;

namespace chapter_06.Input.Base
{
    public class InputManager
    {
        private readonly BaseInputMapper _inputMapper;

        public InputManager(BaseInputMapper inputMapper)
        {
            _inputMapper = inputMapper;
        }

        public void GetCommands(Action<BaseInputCommand> actOnState)
        {
            foreach (var command in _inputMapper.GetKeyboardState())
            {
                actOnState(command);
            }

            foreach (var command in _inputMapper.GetMouseState())
            {
                actOnState(command);
            }

            foreach (var command in _inputMapper.GetGamePadState())
            {
                actOnState(command);
            }

            foreach (var command in _inputMapper.GetTouchState())
            {
                actOnState(command);
            }
        }
    }
}
