using DefaultNamespace.Factory;
using DefaultNamespace.State;

using State;

using UnityEngine;

namespace DefaultNamespace
{
    public class ColorStateReady:BirdState
    {
        
       private float _launchForce;

       private readonly Color _color;
       private readonly ColorStateFactory _colorFactory;
       private readonly Bird _bird;
        
       public ColorStateReady(Bird bird, ColorStateFactory colorFactory, Color skin)
       {
           _bird = bird;
           _colorFactory = colorFactory;
           _color = skin;
       }

       public float LaunchForce
       {
           set => _launchForce = value;
       }

       public void MouseDown(SpriteRenderer spriteRenderer)
       {
           spriteRenderer.color = new Color(_color.r, _color.g, _color.b, 255);
           
           if (_launchForce <= 0)
           {
               _bird.SetState(new ColorStateZero(_bird, Color.magenta));
           } else
           {
               _bird.SetState(_colorFactory.GETNextState()); 
           }
           
       }
       
       public void MouseUp(Vector2 startPos, Rigidbody2D rigidBody, SpriteRenderer spriteRenderer)
       {
           Debug.Log("Launch force = " + _launchForce);
           
           var currPos = rigidBody.position;
           var direction = startPos - currPos;
           direction.Normalize();
        
           rigidBody.isKinematic = false;
           rigidBody.AddForce(direction*_launchForce);
        
           spriteRenderer.color = Color.white;
       }

       public override string ToString()
       {
           return "State " + _color;
       }
    }
}