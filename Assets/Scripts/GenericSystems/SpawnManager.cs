using System;
using PrototypePattern;
using Units;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GenericSystems
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private Transform alliedSpawnPoint;
        
        private Unit _unit;

        private void Update()
        {
            //ObjectPoolActions();
            PrototypeActions();
        }

        private static void ObjectPoolActions()
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                var capsule = ObjectPool.Instance.GetObject("Capsule");
                capsule.transform.Translate(Vector3.forward * Random.Range(-10f, 10f));
            }

            if (Input.GetKeyUp(KeyCode.R))
            {
                var objects = FindObjectsOfType<GameObject>();

                foreach (var gameObject in objects)
                {
                    if (gameObject.GetComponent<Capsule>() != null)
                    {
                        ObjectPool.Instance.PoolObject(gameObject);
                    }
                }
            }
        }

        private void PrototypeActions()
        {
            if (Input.GetKeyUp(KeyCode.S))
            {
                _unit = UnitFactory.GetUnit(UnitType.Soldier);

                var startPosition = alliedSpawnPoint.position;
                startPosition.x += Random.Range(-20f, 20f);
                startPosition.z += Random.Range(-8f, 10f);
            
                _unit.transform.position = startPosition;
                _unit.Activate();
            }
            if (Input.GetKeyUp(KeyCode.T))
            {
                _unit = UnitFactory.GetUnit(UnitType.Tank);

                var startPosition = alliedSpawnPoint.position;
                startPosition.x += Random.Range(-20f, 20f);
                startPosition.z += Random.Range(-8f, 10f);
            
                _unit.transform.position = startPosition;
                _unit.Activate();
            }
            
            if (Input.GetKeyUp(KeyCode.Y))
            {
                var objects = FindObjectsOfType<Unit>();

                foreach (var unit in objects)
                {
                    if (unit.GetComponent<Soldier>() != null || unit.GetComponent<Tank>() != null)
                    {
                        UnitPool.Instance.PoolObject(unit);
                    }
                }
            }
        }
    }
}