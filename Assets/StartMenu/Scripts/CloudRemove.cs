using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudRemove : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Remover"))
        {
            Destroy(gameObject);
        }
    }
}
