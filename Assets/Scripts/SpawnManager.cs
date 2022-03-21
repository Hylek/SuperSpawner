using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Soldier soldier;
    [SerializeField] private Tank tank;
    [SerializeField] private Transform alliedSpawnPoint;

    private Spawner _spawner;
    private Unit _unit;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
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
            _unit = _spawner.SpawnUnit(soldier);
            _unit.name = soldier.name;
            
            var startPosition = alliedSpawnPoint.position;
            startPosition.x += Random.Range(-20f, 20f);
            startPosition.z += Random.Range(-8f, 10f);
            
            _unit.transform.position = startPosition;
            _unit.Activate();
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            _unit = _spawner.SpawnUnit(tank);
            _unit.name = tank.name;

            var startPosition = alliedSpawnPoint.position;
            startPosition.x += Random.Range(-20f, 20f);
            startPosition.z += Random.Range(-8f, 10f);
            
            _unit.transform.position = startPosition;
            _unit.Activate();
        }
    }
}