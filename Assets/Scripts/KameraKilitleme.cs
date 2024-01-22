using UnityEngine;
using Photon.Pun;

public class KameraKilitleme : MonoBehaviour
{
    public float kilitliYPos = 0.01f; // Kilitlenmiþ Y pozisyonu

    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (view.IsMine)
        {
            // Kameranýn mevcut pozisyonunu al
            Vector3 kameraPozisyon = transform.position;

            // Kameranýn Y pozisyonunu kitle
            kameraPozisyon.y = kilitliYPos;

            // Kameranýn pozisyonunu güncelle
            transform.position = kameraPozisyon;
        }
        
    }
}
