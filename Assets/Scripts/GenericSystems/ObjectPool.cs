using System.Collections.Generic;
using UnityEngine;

// Note: This is a generic version of the ObjectPool that handles GameObjects

namespace GenericSystems
{
    public class ObjectPool : Singleton<ObjectPool>
    {
        [SerializeField] private GameObject[] prefabs;

        private List<GameObject>[] _pooledObjects;

        public override void Awake()
        {
            base.Awake();

            _pooledObjects = new List<GameObject>[prefabs.Length];

            var i = 0;
            foreach (var gameObject in prefabs)
            {
                _pooledObjects[i] = new List<GameObject>();

                var newGameObject = Instantiate(gameObject); // todo: Replace prototype class instead
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
                    _pooledObjects[i].Add(obj);

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
                    if (_pooledObjects[i].Count > 0)
                    {
                        var pooledObject = _pooledObjects[i][0];
                        pooledObject.SetActive(true);
                        pooledObject.transform.parent = null; // todo: Allow custom parent?
                        _pooledObjects[i].Remove(pooledObject);

                        return pooledObject;
                    }

                    var newObject = Instantiate(prefabs[i]); // todo: Replace with prototype class
                    newObject.name = prefab.name;

                    return newObject;
                }
            }

            return null; // todo: null case needs to be handled.
        }
    }
}