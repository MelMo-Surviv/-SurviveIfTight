using UnityEngine;
using Photon.Pun;

public class KameraKilitleme : MonoBehaviour
{
    public float kilitliYPos = 0.01f; // Kilitlenmi� Y pozisyonu

    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (view.IsMine)
        {
            // Kameran�n mevcut pozisyonunu al
            Vector3 kameraPozisyon = transform.position;

            // Kameran�n Y pozisyonunu kitle
            kameraPozisyon.y = kilitliYPos;

            // Kameran�n pozisyonunu g�ncelle
            transform.position = kameraPozisyon;
        }
        
    }
}
