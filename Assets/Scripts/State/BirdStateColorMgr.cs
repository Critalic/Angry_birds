using System;
using System.Collections.Generic;

using UnityEngine;

using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class BirdStateColorMgr:MonoBehaviour
    {
        [SerializeField] List<Color> skins;
        [SerializeField] private float initLaunchForce;
        
        private int _stateCount = 0;
        readonly List<StateColor> _states = new List<StateColor>();
        
        public StateColor GETNextState()
        {
            _stateCount++;
            StateColor b = _states[Random.Range(0, _states.Count)];
            b.LaunchForce = initLaunchForce - (_stateCount * 100);
            return b;
            
        }

        private void Awake()
        {
            BirdScript bird = GameObject.FindWithTag("Player").GetComponent<BirdScript>();
            foreach (var skin in skins)
            {
                StateColor s = new StateColor(bird, this, skin);
                _states.Add(s);
                Debug.Log(s);
            }
        }

        public StateColor GETInitialState()
        {
            StateColor b = _states[Random.Range(0, _states.Count)];
            b.LaunchForce = initLaunchForce;
            return b;
        }
    }
}