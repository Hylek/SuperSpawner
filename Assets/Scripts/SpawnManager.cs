using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    private void Update()
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
                if(gameObject.GetComponent<Capsule>() != null)
                {
                    ObjectPool.Instance.PoolObject(gameObject);
                }
            }
        }
    }
}