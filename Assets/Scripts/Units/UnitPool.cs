using System.Collections.Generic;
using GenericSystems;
using PrototypePattern;
using UnityEngine;

namespace Units
{
    public class UnitPool : Singleton<UnitPool>
    {
        [SerializeField] private Unit[] units;

        private List<Unit>[] _pooledUnits;

        public override void Awake()
        {
            base.Awake();

            _pooledUnits = new List<Unit>[units.Length];

            var i = 0;
            foreach (var unit in units)
            {
                _pooledUnits[i] = new List<Unit>();

                var unitCopy = Spawner.Instance.SpawnUnit(unit);
                unitCopy.name = unit.name;
                PoolObject(unitCopy);
                i++;
            }
        }

        public void PoolObject(Unit unit)
        {
            for (var i = 0; i < units.Length; i++)
            {
                if (units[i].name == unit.name)
                {
                    unit.gameObject.SetActive(false);
                    unit.transform.parent = gameObject.transform;
                    _pooledUnits[i].Add(unit);

                    return;
                }
            }
            Destroy(unit);
        }

        public Unit GetUnit(string typeName)
        {
            for (var i = 0; i < units.Length; i++)
            {
                var prefab = units[i];

                if (prefab.name == typeName)
                {
                    if (_pooledUnits[i].Count > 0)
                    {
                        var pooledUnit = _pooledUnits[i][0];
                        pooledUnit.gameObject.SetActive(true);
                        pooledUnit.transform.parent = null; // todo: Allow custom parent?
                        _pooledUnits[i].Remove(pooledUnit);

                        return pooledUnit;
                    }

                    var newObject = Spawner.Instance.SpawnUnit(units[i]);
                    newObject.name = prefab.name;

                    return newObject;
                }
            }

            return null; // todo: null case needs to be handled.
        }
    }
}