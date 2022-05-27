using System;
using System.Collections.Generic;
using System.Linq;

using UnityEditorInternal.Profiling.Memory.Experimental;

using UnityEngine;

using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class BirdSkinMgr:MonoBehaviour
    {
        [SerializeField] List<GameObject> skins;

        List<BirdState> states = new List<BirdState>();
        
        public GameObject GETRandomSkin()
        {
            return skins[Random.Range(0, skins.Count)];
        }
        
        public List<GameObject> GETSkins()
        {
            return skins;
        }
        
        public BirdState GETState(GameObject skin)
        {
            return states.Single(bird => bird.Skin.gameObject.name.Equals(skin.gameObject.name));

        }
        
        public BirdState GETState()
        {
            return states[1];

        }

        private void Awake()
        {
            BirdScript bird = GameObject.FindWithTag("Player").GetComponent<BirdScript>();
            foreach (var skin in skins)
            {
                BirdState s = new BirdState(bird, this, skin);
                states.Add(s);
            }
            
        }
    }
}