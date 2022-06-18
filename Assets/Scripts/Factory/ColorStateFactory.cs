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
        readonly List<ColorStateReady> _states = new List<ColorStateReady>();

        private void Awake()
        {
            Bird bird = GameObject.FindWithTag("Player").GetComponent<Bird>();
            foreach (var skin in skins)
            {
                ColorStateReady s = new ColorStateReady(bird, this, skin);
                _states.Add(s);
                Debug.Log(s);
            }
        }
        
        public BirdState GETNextState()
        {
            _stateCount++;
            ColorStateReady b = _states[Random.Range(0, _states.Count)];
            b.LaunchForce = initLaunchForce - (_stateCount * 100);
            return b;
        }

        public BirdState GETInitialState()
        {
            ColorStateReady b = _states[Random.Range(0, _states.Count)];
            b.LaunchForce = initLaunchForce;
            return b;
        }
    }
}