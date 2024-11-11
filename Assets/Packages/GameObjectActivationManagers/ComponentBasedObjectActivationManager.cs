using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GameObjectActivationManagers
{
    public class ComponentBasedObjectActivationManager<T> : GameObjectActivationManager where T : Component
    {
        public IReadOnlyList<T> Components { get; protected set; }

        public override bool Initialize()
        {
            Components = FindObjectsOfType<T>(includeInactive: true)
                        .OrderBy(testPattern => testPattern.gameObject.name)
                        .ToList().AsReadOnly();

            GameObjects = Components.Select(target => target.gameObject).ToList().AsReadOnly();

            IsInitialized = true;
            return true;
        }
    }
}