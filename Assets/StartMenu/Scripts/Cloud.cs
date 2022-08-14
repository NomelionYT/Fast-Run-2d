using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Cloud : MonoBehaviour
{
    private float _speed;

    public float Speed => _speed;

    public void Init(Sprite sprite, Vector3 scale, Vector3 position, float speed)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        transform.localScale = scale;
        transform.position = position;
        _speed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CloudRemover remover))
        {
            Destroy(gameObject);
        }
    }
}
