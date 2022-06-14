using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    private float _cloudSpeed;
    void Start()
    {
        _cloudSpeed = Random.Range(1f, 2f);
    }

    void Update()
    {
        Vector3 translation = Vector3.right;
        transform.Translate(translation * Time.deltaTime * _cloudSpeed);
    }
}
