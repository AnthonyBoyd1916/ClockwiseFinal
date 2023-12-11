using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyKeysScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ProgressCollectible"))
        {
            Destroy(collision.gameObject);
        }
    }
}
