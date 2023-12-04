using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectToInit;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    private void Start()
    {
        Init(_gameObjectToInit);
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

    private void Init(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }
}
