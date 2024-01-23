using UnityEngine;

public class dusman : MonoBehaviour
{
    public string takipEdilecekTag = "Karakter";
    public float hareketHizi = 1.4f;
    void Update()
    {
        GameObject takipEdilecekObj = GameObject.FindGameObjectWithTag(takipEdilecekTag);

        if (takipEdilecekObj != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, takipEdilecekObj.transform.position, hareketHizi * Time.deltaTime);
        }
    }
}
