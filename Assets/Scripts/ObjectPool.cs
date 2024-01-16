using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GangWar
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObjectToSpawn;
        [SerializeField] private GameObject _container;
        [SerializeField] private int _capacity;

        private List<GameObject> _pool = new List<GameObject>();

        private void Start()
        {
            SpawnObject(_gameObjectToSpawn);
        }

        public bool TryGetObject(out GameObject resualt)
        {
            resualt = _pool.FirstOrDefault(p => p.activeSelf == false);

            return resualt != null;
        }

        public void SetObject(GameObject gameObject, Vector3 spawnPoint)
        {
            gameObject.SetActive(true);
            gameObject.transform.position = spawnPoint;
        }

        private void SpawnObject(GameObject objectToSpawn)
        {
            for (int i = 0; i < _capacity; i++)
            {
                GameObject spawned = Instantiate(objectToSpawn, _container.transform);
                spawned.SetActive(false);

                _pool.Add(spawned);
            }
        }
    }
}