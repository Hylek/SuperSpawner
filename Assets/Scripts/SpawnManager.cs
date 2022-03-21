using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Soldier soldier;
    [SerializeField] private Tank tank;

    private AlliedSpawner _spawner;
    private Unit _unit;

    private void Awake()
    {
        _spawner = GetComponent<AlliedSpawner>();
    }

    private void Update()
    {
        ObjectPoolActions();
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
            _unit = _spawner.SpawnAlly(soldier);
            _unit.name = soldier.name;
            _unit.transform.Translate(Vector3.left * Random.Range(-10f, 10f));
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            _unit = _spawner.SpawnAlly(tank);
            _unit.name = tank.name;
            _unit.transform.Translate(Vector3.right * Random.Range(-10f, 10f));
        }
    }
}