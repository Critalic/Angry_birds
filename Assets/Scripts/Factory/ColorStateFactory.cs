using System;
using System.Collections.Generic;

using DefaultNamespace.Factory;
using DefaultNamespace.State;

using UnityEngine;

using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class ColorStateFactory: MonoBehaviour, StateFactory
    {
        [SerializeField] List<Color> skins;
        [SerializeField] private float initLaunchForce;
        
        private int _stateCount = 0;
        readonly List<ColorStatePreset> _states = new List<ColorStatePreset>();

        private void Awake()
        {
            BirdScript bird = GameObject.FindWithTag("Player").GetComponent<BirdScript>();
            foreach (var skin in skins)
            {
                ColorStatePreset s = new ColorStatePreset(bird, this, skin);
                _states.Add(s);
                Debug.Log(s);
            }
        }
        
        public BirdState GETNextState()
        {
            _stateCount++;
            ColorStatePreset b = _states[Random.Range(0, _states.Count)];
            b.LaunchForce = initLaunchForce - (_stateCount * 100);
            return b;
            
        }

        public BirdState GETInitialState()
        {
            ColorStatePreset b = _states[Random.Range(0, _states.Count)];
            b.LaunchForce = initLaunchForce;
            return b;
        }
    }
}