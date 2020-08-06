using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace chapter_11.Engine.Objects.Collisions
{
    public class SegmentAABBCollisionDetector<A> 
        where A : BaseGameObject
    {
        private Segment _segment;

        public SegmentAABBCollisionDetector(Segment segment)
        {
            _segment = segment;
        }

        public void DetectCollisions(A activeObject, Action<A> collisionHandler)
        {
            if (DetectCollision(_segment, activeObject))
            {
                collisionHandler(activeObject);
            }
        }

        public void DetectCollisions(List<A> activeObjects, Action<A> collisionHandler)
        {
            foreach(var activeObject in activeObjects)
            {
                if (DetectCollision(_segment, activeObject))
                {
                    collisionHandler(activeObject);
                }
            }
        }

        private bool DetectCollision(Segment segment, A activeObject)
        {
            foreach(var activeBB in activeObject.BoundingBoxes)
            {
                if (DetectCollision(segment.P1, activeBB) || DetectCollision(segment.P2, activeBB))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        private bool DetectCollision(Vector2 p, BoundingBox bb)
        {
            if (p.X < bb.Position.X + bb.Width &&
                p.X > bb.Position.X &&
                p.Y < bb.Position.Y + bb.Height &&
                p.Y > bb.Position.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
