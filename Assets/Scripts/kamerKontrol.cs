using Photon.Pun;
using UnityEngine;

public class kamerKontrol : MonoBehaviourPun, IPunObservable
{
    public float kilitliYPos = 0.01f;
    void Update()
    {
        if (photonView.IsMine)
        {
            // Kameranýn mevcut pozisyonunu al
            Vector3 kameraPozisyon = transform.position;

            // Kameranýn Y pozisyonunu kitle
            kameraPozisyon.y = kilitliYPos;

            // Kameranýn pozisyonunu güncelle
            transform.position = kameraPozisyon;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Veriyi yazma: Bu, kendi kameranýzýn bilgilerini diðer oyunculara göndermek içindir.
            // Örneðin, kamera pozisyonu, rotasyonu, vb.
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            // Veriyi okuma: Bu, diðer oyuncularýn kameralarýný takip etmek içindir.
            // Örneðin, gelen kamera pozisyonunu ve rotasyonunu alabilirsiniz.
            transform.position = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();
        }
    }
}