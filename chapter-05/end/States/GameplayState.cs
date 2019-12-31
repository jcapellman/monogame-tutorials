using chapter_05.Enum;
using chapter_05.Objects;
using chapter_05.States.Base;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace chapter_05.States
{
    public class GameplayState : BaseGameState
    {
        private const string PlayerFighter = "F18";

        private const string BackgroundTexture = "Barren";

        public override void LoadContent()
        {
            AddGameObject(new SplashImage(LoadTexture(BackgroundTexture)));
            AddGameObject(new PlayerSprite(LoadTexture(PlayerFighter)));
        }

        public override void HandleInput()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                NotifyEvent(Events.GAME_QUIT);
            }
        }
    }
}