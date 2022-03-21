using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    public GameObject[] prefabs;

    public List<GameObject>[] pooledObjects;

    public override void Awake()
    {
        base.Awake();

        pooledObjects = new List<GameObject>[prefabs.Length];

        var i = 0;
        foreach (var gameObject in prefabs)
        {
            pooledObjects[i] = new List<GameObject>();

            var newGameObject = Instantiate(gameObject);
            newGameObject.name = gameObject.name;
            PoolObject(newGameObject);
            i++;
        }
    }

    public void PoolObject(GameObject obj)
    {
        for (var i = 0; i < prefabs.Length; i++)
        {
            if (prefabs[i].name == obj.name)
            {
                obj.SetActive(false);
                obj.transform.parent = gameObject.transform;
                pooledObjects[i].Add(obj);

                return;
            }
        }
        Destroy(obj);
    }

    public GameObject GetObject(string typeName)
    {
        for (var i = 0; i < prefabs.Length; i++)
        {
            var prefab = prefabs[i];

            if (prefab.name == typeName)
            {
                if (pooledObjects[i].Count > 0)
                {
                    var pooledObject = pooledObjects[i][0];
                    pooledObject.SetActive(true);
                    pooledObject.transform.parent = null; // todo: Allow custom parent?
                    pooledObjects[i].Remove(pooledObject);

                    return pooledObject;
                }
            }
            return Instantiate(prefabs[i]);
        }

        return null; // todo: null case needs to be handled.
    }
}