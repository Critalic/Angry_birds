using System.Collections.Generic;

using UnityEngine;

namespace DefaultNamespace
{
    public class BirdState
    {
        //private float _launchForce; //TODO - implement
        
       GameObject _skin;
       private BirdSkinMgr _manager;
       private BirdScript _bird;
        
       public BirdState(BirdScript bird, BirdSkinMgr manager, GameObject skin)
       {
           _bird = bird;
           _manager = manager;
           _skin = skin;
       }

       public GameObject Skin => _skin;

       public BirdScript Bird => _bird;

       public Rigidbody2D SetSkin(Rigidbody2D rigidBody)
       {
           //Set skin to given rigid body
           
           rigidBody.gameObject.SetActive(false);
           _bird.State = _manager.GETState();
           return _skin.GetComponent<Rigidbody2D>();
       }

       public void sendFlying(Vector2 direction, Rigidbody2D rigidBody)
       {
           
       }

       public override string ToString()
       {
           return "State" + _skin;
       }
    }
}