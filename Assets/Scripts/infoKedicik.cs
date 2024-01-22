using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoKedicik : MonoBehaviour
{
    public GameObject info;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Karakter"))
        {
            info.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Karakter"))
        {
            info.SetActive(false);
        }
    }
}
