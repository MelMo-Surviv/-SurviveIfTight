using Photon.Pun;
using UnityEngine;

public class kamerKontrol : MonoBehaviourPun, IPunObservable
{
    public float kilitliYPos = 0.01f;
    void Update()
    {
        if (photonView.IsMine)
        {
            // Kameran�n mevcut pozisyonunu al
            Vector3 kameraPozisyon = transform.position;

            // Kameran�n Y pozisyonunu kitle
            kameraPozisyon.y = kilitliYPos;

            // Kameran�n pozisyonunu g�ncelle
            transform.position = kameraPozisyon;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Veriyi yazma: Bu, kendi kameran�z�n bilgilerini di�er oyunculara g�ndermek i�indir.
            // �rne�in, kamera pozisyonu, rotasyonu, vb.
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            // Veriyi okuma: Bu, di�er oyuncular�n kameralar�n� takip etmek i�indir.
            // �rne�in, gelen kamera pozisyonunu ve rotasyonunu alabilirsiniz.
            transform.position = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();
        }
    }
}