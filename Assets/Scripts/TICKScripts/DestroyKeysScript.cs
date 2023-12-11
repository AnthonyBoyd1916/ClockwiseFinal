using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyKeysScript : MonoBehaviour
{
    [SerializeField] private GameObject[] vps;
    private int counter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("VPs"))
        {
            collision.gameObject.SetActive(false);
            counter++;
        }
    }

    private void Update()
    {
        if (counter == 3 )
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("VictoryScreen");
        }
    }
}
