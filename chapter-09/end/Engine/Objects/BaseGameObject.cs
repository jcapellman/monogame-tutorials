using chapter_09.Engine.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace chapter_09.Engine.Objects
{
    public class BaseGameObject
    {
        protected Texture2D _texture;
        protected Texture2D _boundingBoxTexture;

        protected Vector2 _position = Vector2.One;
        protected List<BoundingBox> _boundingBoxes = new List<BoundingBox>();

        public int zIndex;
        public event EventHandler<BaseGameStateEvent> OnObjectChanged;

        public int Width { get { return _texture.Width; } }
        public int Height { get { return _texture.Height; } }
        public virtual Vector2 Position 
        { 
            get { return _position; } 
            set { _position = value; } 
        }

        public virtual void OnNotify(BaseGameStateEvent gameEvent) { }

        public virtual void Render(SpriteBatch spriteBatch)
        {
            Render(spriteBatch, false);
        }

        public virtual void Render(SpriteBatch spriteBatch, bool displayBoundingBox)
        {
            spriteBatch.Draw(_texture, _position, Color.White);

            if (displayBoundingBox)
            {
                RenderBoundingBoxes(spriteBatch);
            }
        }
        
        public void SendEvent(BaseGameStateEvent e)
        {
            OnObjectChanged?.Invoke(this, e);
        }

        public void AddBoundingBox(BoundingBox bb)
        {
            _boundingBoxes.Add(bb);
        }

        private void CreateBoundingBoxTexture(GraphicsDevice graphicsDevice)
        {
            _boundingBoxTexture = new Texture2D(graphicsDevice, 1, 1);
            _boundingBoxTexture.SetData<Color>(new Color[] { Color.White });
        }

        protected void RenderBoundingBoxes(SpriteBatch spriteBatch)
        {
            if (_boundingBoxTexture == null)
            {
                CreateBoundingBoxTexture(spriteBatch.GraphicsDevice);
            }

            foreach (var bb in _boundingBoxes)
            {
                spriteBatch.Draw(_boundingBoxTexture, bb.Rectangle, Color.Red);
            }
        }
    }
}