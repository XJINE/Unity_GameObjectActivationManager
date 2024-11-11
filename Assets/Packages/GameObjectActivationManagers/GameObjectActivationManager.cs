using System.Collections.Generic;
using UnityEngine;

namespace GameObjectActivationManagers
{
    public abstract class GameObjectActivationManager : SingletonMonoBehaviour<GameObjectActivationManager>, IInitializable
    {
        [SerializeField] private bool activeOnStart = false;

        // NOTE:
        // Initialize "GameObjects" property in Initialize method.
        public IReadOnlyList<GameObject> GameObjects   { get; protected set; }
        public bool                      IsInitialized { get; protected set; }

        public abstract bool Initialize();

        protected void Start()
        {
            Initialize();
            SetActive(activeOnStart);
        }

        public void SetActive(bool value)
        {
            foreach (var gameObject in GameObjects)
            {
                gameObject.SetActive(value);
            }
        }
    }
}