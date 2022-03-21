using GenericSystems;

namespace PrototypePattern
{
    public class Spawner : Singleton<Spawner>
    {
        private ICopyable _copy;

        public Unit SpawnUnit(Unit prototype)
        {
            _copy = prototype.Copy();

            return (Unit) _copy;
        }
    }
}