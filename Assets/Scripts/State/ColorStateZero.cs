using DefaultNamespace.State;

using UnityEngine;

namespace State
{
    public class ColorStateZero:BirdState
    {
        private readonly Color _color;
        private readonly Bird _bird;
        public ColorStateZero(Bird bird, Color skin)
        {
            _bird = bird;
            _color = skin;
        }

        public void MouseDown(SpriteRenderer spriteRenderer)
        {
            spriteRenderer.color = new Color(_color.r, _color.g, _color.b, 255);
            _bird.SetState(new ColorStateZero(_bird, Color.yellow));
        }

        public void MouseUp(Vector2 startPos, Rigidbody2D rigidBody, SpriteRenderer spriteRenderer)
        {
            Debug.Log("No launch force");
           
            var currPos = rigidBody.position;
            var direction = startPos - currPos;
            direction.Normalize();
        
            rigidBody.isKinematic = false;
            rigidBody.AddForce(direction*0);
        
            spriteRenderer.color = Color.white;
        }
        
        public override string ToString()
        {
            return "State 0 launchforce";
        }
    }
}