using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cloud))]
public class CloudMover : MonoBehaviour
{
    private Cloud _cloud;

    private void Start()
    {
        _cloud = GetComponent<Cloud>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _cloud.Speed);
    }
}
