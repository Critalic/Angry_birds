using DefaultNamespace.State;

using UnityEngine;
using UnityEngine.Playables;

namespace DefaultNamespace.Factory
{
    public interface StateFactory
    {
        public abstract BirdState GETNextState();

        public BirdState GETInitialState();
    }
}