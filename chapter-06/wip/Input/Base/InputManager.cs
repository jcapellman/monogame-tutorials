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
                    foreach (var command in _inputMapper.GetKeyboardState())
                    {
                        actOnState(command);
                    }
                }

                if (device == InputDevices.MOUSE)
                {
                    foreach (var command in _inputMapper.GetMouseState())
                    {
                        actOnState(command);
                    }
                }

                if (device == InputDevices.GAMEPAD)
                {
                    foreach (var command in _inputMapper.GetGamePadState())
                    {
                        actOnState(command);
                    }
                }

                if (device == InputDevices.TOUCH)
                {
                    foreach (var command in _inputMapper.GetTouchState())
                    {
                        actOnState(command);
                    }
                }
            }
        }
    }
}
