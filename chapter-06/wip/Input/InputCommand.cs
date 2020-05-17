using chapter_06.Input.Base;

namespace chapter_06.Input
{
    public class SplashInputCommand : BaseInputCommand 
    {
        // Out of Game Commands
        public class GameSelect : SplashInputCommand { }
        public class GameExit : SplashInputCommand { }
    }

    public class GameplayInputCommand : BaseInputCommand 
    { 
        public class GameExit : GameplayInputCommand { }
        public class PlayerMoveLeft : GameplayInputCommand { }
        public class PlayerMoveRight : GameplayInputCommand { }
        public class PlayerShoots : GameplayInputCommand { }
    }
}
