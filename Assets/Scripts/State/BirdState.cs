using UnityEngine;

using Color = System.Drawing.Color;

namespace DefaultNamespace.State
{
    public interface BirdState
    {
        public void MouseDown(SpriteRenderer spriteRenderer);

        public void MouseUp(Vector2 startPos, Rigidbody2D rigidBody, SpriteRenderer spriteRenderer);
    }
}