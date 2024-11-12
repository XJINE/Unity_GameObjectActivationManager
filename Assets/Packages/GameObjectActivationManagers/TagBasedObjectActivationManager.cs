using System.Linq;
using UnityEngine;

namespace GameObjectActivationManagers
{
    public class TagBasedObjectActivationManager : GameObjectActivationManager
    {
        [SerializeField]
        private string _tag;
        public  string Tag => _tag;

        public override bool Initialize()
        {
            GameObjects = GameObject.FindGameObjectsWithTag(_tag)
                         .OrderBy(gameObject => gameObject.name)
                         .ToList().AsReadOnly();

            IsInitialized = true;
            return true;
        }
    }
}