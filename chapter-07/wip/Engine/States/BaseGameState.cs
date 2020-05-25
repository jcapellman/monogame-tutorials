using System;
using System.Collections.Generic;
using System.Linq;
using chapter_07.Engine.Input;
using chapter_07.Engine.Objects;
using chapter_07.Engine.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace chapter_07.Engine.States
{
    public abstract class BaseGameState
    {
        private const string FallbackTexture = "Empty";
        private const string FallbackSong = "EmptySound";

        private ContentManager _contentManager;
        protected int _viewportHeight;
        protected int _viewportWidth;
        protected SoundManager _soundManager = new SoundManager();

        private readonly List<BaseGameObject> _gameObjects = new List<BaseGameObject>();

        protected InputManager InputManager {get; set;}

        public void Initialize(ContentManager contentManager, int viewportWidth, int viewportHeight)
        {
            _contentManager = contentManager;
            _viewportHeight = viewportHeight;
            _viewportWidth = viewportWidth;

            SetInputManager();
        }

        public abstract void LoadContent();
        public abstract void HandleInput(GameTime gameTime);
        public abstract void UpdateGameState(GameTime gameTime);

        public event EventHandler<BaseGameState> OnStateSwitched;
        public event EventHandler<BaseGameStateEvent> OnEventNotification;
        protected abstract void SetInputManager();

        public void UnloadContent()
        {
            _contentManager.Unload();
        }

        public virtual void Update(GameTime gameTime) 
        {
            UpdateGameState(gameTime);
            _soundManager.PlaySoundtrack();
        }

        protected Texture2D LoadTexture(string textureName)
        {
            var texture = _contentManager.Load<Texture2D>(textureName);

            return texture ?? _contentManager.Load<Texture2D>(FallbackTexture);
        }

        protected SoundEffect LoadSound(string soundName)
        {
            var song = _contentManager.Load<SoundEffect>(soundName);
            return song ?? _contentManager.Load<SoundEffect>(FallbackSong);
        }
 
        // TODO: is argument still needed if eventType is a class?
        protected void NotifyEvent(BaseGameStateEvent eventType, object argument = null)
        {
            OnEventNotification?.Invoke(this, eventType);

            foreach (var gameObject in _gameObjects)
            {
                gameObject.OnNotify(eventType, argument);
            }

            // TODO: notify _soundManager
            // TODO change eventType from enum to a class
            // _soundManager.OnNotify(eventType, argument);
        }

        protected void SwitchState(BaseGameState gameState)
        {
            OnStateSwitched?.Invoke(this, gameState);
        }

        protected void AddGameObject(BaseGameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }

        protected void RemoveGameObject(BaseGameObject gameObject)
        {
            _gameObjects.Remove(gameObject);
        }

        public void Render(SpriteBatch spriteBatch)
        {
            foreach (var gameObject in _gameObjects.OrderBy(a => a.zIndex))
            {
                gameObject.Render(spriteBatch);
            }
        }
    }
}