using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    private float _cloudSize;
    private float _cloudFreq;

    private Vector3 _cloudPosition;

    [SerializeField] private GameObject[] _cloudPrefabs;
    private GameObject _cloudPrefab;

    void Start()
    {
        StartCoroutine("spawnClouds");
    }
    void Update()
    {
    }
    IEnumerator spawnClouds()
    {
        while (true)
        {
            yield return new WaitForSeconds(_cloudFreq);
            SetCloudProperties();
            int cloudPrefabNumber = Random.Range(0, _cloudPrefabs.Length);
            _cloudPrefab = _cloudPrefabs[cloudPrefabNumber];
            GameObject cloud = Instantiate<GameObject>(_cloudPrefab);
            cloud.transform.position = _cloudPosition;
            cloud.transform.localScale = new Vector3(_cloudSize, _cloudSize, 0);
        }
    }
    void SetCloudProperties()
    {
        _cloudFreq = Random.Range(0.5f, 0.75f);
        _cloudSize = Random.Range(0.5f, 0.75f);
        _cloudPosition.x = -5f;
        _cloudPosition.y = Random.Range(-4.3f, 4.3f);
    }
}
