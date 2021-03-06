using GenericSystems;
using UnityEngine;

namespace PrototypePattern
{
    public class Spawner : MonoBehaviour
    {
        private ICopyable _copy;

        public Unit SpawnUnit(Unit prototype)
        {
            _copy = prototype.Copy();

            return (Unit) _copy;
        }
    }
}