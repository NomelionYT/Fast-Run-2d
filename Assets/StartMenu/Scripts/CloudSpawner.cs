using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [Header("Cloud settings")]
    [SerializeField] private Cloud _cloudPrefab;
    [SerializeField] private Sprite[] _cloudSprites;
    [SerializeField] private float _minSize = 0.5f;
    [SerializeField] private float _maxSize = 0.75f;
    [SerializeField] private float _maxSpeed = 1;
    [SerializeField] private float _minSpeed = 2;
    

    [Header("Spawn settings")]
    [SerializeField] private float _minTimeToSpawn = 0.5f;
    [SerializeField] private float _maxTimeToSpawn = 0.75f;

    private float _minYToSpawn;
    private float _maxYToSpawn;
    private float _timeToNextSpawn;

    private void Start()
    {
        _minYToSpawn = Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).y;
        _maxYToSpawn = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).y;

        _minTimeToSpawn = _minTimeToSpawn > _maxTimeToSpawn ? _maxTimeToSpawn : _minTimeToSpawn;
        _minSpeed = _minSpeed > _maxSpeed ? _maxSpeed : _minSpeed;
        _minSize = _minSize > _maxSize ? _maxSize : _minSize;

        StartCoroutine(SpawnCloudsCoroutine());
    }

    private IEnumerator SpawnCloudsCoroutine()
    {
        while (true)
        {
            _timeToNextSpawn = Random.Range(_minTimeToSpawn, _maxTimeToSpawn);
            yield return new WaitForSeconds(_timeToNextSpawn);

            Cloud cloud = Instantiate(_cloudPrefab, transform);
            SetCloudProperties(cloud);
        }
    }

    private void SetCloudProperties(Cloud cloud)
    {
        float size = Random.Range(_minSize, _maxSize);
        Vector3 scale = new Vector3(size, size, 0);
        int randomIndex = Random.Range(0, _cloudSprites.Length);
        Sprite sprite = _cloudSprites[randomIndex];
        float randomY = Random.Range(_minYToSpawn, _maxYToSpawn);
        Vector3 position = new Vector3(transform.position.x, randomY, transform.position.z);
        float speed = Random.Range(_minSpeed, _maxSpeed);
        cloud.Init(sprite, scale, position, speed);
    }
}
