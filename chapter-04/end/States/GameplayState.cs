using chapter_04.States.Base;

using Microsoft.Xna.Framework.Content;

namespace chapter_04.States
{
    public class GameplayState : BaseGameState
    {
        public override void LoadContent(ContentManager contentManager)
        {
            
        }

        public override void UnloadContent(ContentManager contentManager)
        {
            contentManager.Unload();
        }

        public override void HandleInput()
        {
        }
    }
}