using chapter_06.Enum;
using chapter_06.Objects;
using chapter_06.States.Base;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace chapter_06.States
{
    public class GameplayState : BaseGameState
    {
        private const string PlayerFighter = "fighter";

        private const string BackgroundTexture = "Barren";

        public override void LoadContent()
        {
            var terrain = new TerrainBackground(LoadTexture(BackgroundTexture));
            var playerSprite = new PlayerSprite(LoadTexture(PlayerFighter));

            AddGameObject(terrain);
            AddGameObject(playerSprite);

            // position the player in the middle of the screen, at the bottom, leaving a slight gap at the bottom
            var playerXPos = _viewportWidth / 2 - playerSprite.Width / 2;
            var playerYPos = _viewportHeight - playerSprite.Height - 30;
            playerSprite.SetPosition(new Vector2(playerXPos, playerYPos));
        }

        public override void HandleInput()
        {
            var state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Escape))
            {
                NotifyEvent(Events.GAME_QUIT);
            }
        }
    }
}