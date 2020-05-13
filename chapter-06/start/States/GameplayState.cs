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

        private PlayerSprite _playerSprite;

        public override void LoadContent()
        {
            var terrain = new TerrainBackground(LoadTexture(BackgroundTexture));
            _playerSprite = new PlayerSprite(LoadTexture(PlayerFighter));

            AddGameObject(terrain);
            AddGameObject(_playerSprite);

            // position the player in the middle of the screen, at the bottom, leaving a slight gap at the bottom
            var playerXPos = _viewportWidth / 2 - _playerSprite.Width / 2;
            var playerYPos = _viewportHeight - _playerSprite.Height - 30;
            _playerSprite.Position = new Vector2(playerXPos, playerYPos);
        }

        public override void HandleInput()
        {
            var state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Escape))
            {
                NotifyEvent(Events.GAME_QUIT);
            }

            if (state.IsKeyDown(Keys.Left))
            {
                _playerSprite.MoveLeft();
                KeepPlayerInBounds();
            }

            if (state.IsKeyDown(Keys.Right))
            {
                _playerSprite.MoveRight();
                KeepPlayerInBounds();
            }
        }

        private void KeepPlayerInBounds()
        {
            if (_playerSprite.Position.X < 0)
            {
                _playerSprite.Position = new Vector2(0, _playerSprite.Position.Y);
            }

            if (_playerSprite.Position.X > _viewportWidth - _playerSprite.Width)
            {
                _playerSprite.Position = new Vector2(_viewportWidth - _playerSprite.Width, _playerSprite.Position.Y);
            }

            if (_playerSprite.Position.Y < 0)
            {
                _playerSprite.Position = new Vector2(_playerSprite.Position.X, 0);
            }

            if (_playerSprite.Position.Y > _viewportHeight - _playerSprite.Height)
            {
                _playerSprite.Position = new Vector2(_playerSprite.Position.X, _viewportHeight - _playerSprite.Height);
            }
        }
    }
}