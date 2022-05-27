using DefaultNamespace.State;

using UnityEngine;

namespace DefaultNamespace
{
    public class StateColor:BirdState
    {
        
       private float _launchForce;

       private readonly Color _color;
       private readonly BirdStateColorMgr _manager;
       private readonly BirdScript _bird;
        
       public StateColor(BirdScript bird, BirdStateColorMgr manager, Color skin)
       {
           _bird = bird;
           _manager = manager;
           _color = skin;
       }

       public float LaunchForce
       {
           set => _launchForce = value;
       }

       public void MouseDown(SpriteRenderer spriteRenderer)
       {
           spriteRenderer.color = new Color(_color.r, _color.b, _color.g, 255);
           _bird.StateColor = _manager.GETNextState();
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