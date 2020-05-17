using System;
using System.Collections.Generic;

namespace chapter_06.Input.Base
{
    public class InputManager
    {
        private readonly List<InputDevices> _activeDevices;
        private readonly BaseInputMapper _inputMapper;

        public InputManager(List<InputDevices> activeDevices, BaseInputMapper inputMapper)
        {
            _activeDevices = activeDevices;
            _inputMapper = inputMapper;
        }

        public void GetCommands(Action<BaseInputCommand> actOnState)
        {
            foreach (var device in _activeDevices)
            {
                if (device == InputDevices.KEYBOARD)
                {
                    actOnState(_inputMapper.GetKeyboardState());
                }

                if (device == InputDevices.MOUSE)
                {
                    actOnState(_inputMapper.GetMouseState());
                }

                if (device == InputDevices.GAMEPAD)
                {
                    actOnState(_inputMapper.GetGamePadState());
                }

                if (device == InputDevices.TOUCH)
                {
                    actOnState(_inputMapper.GetTouchState());
                }
            }
        }
    }
}
