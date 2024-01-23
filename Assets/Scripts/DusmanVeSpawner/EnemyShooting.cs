using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private GameObject player;
    public AudioSource atýsSes;

    //Animator enemyAnim;

    public string takipEdilecekTag = "Karakter";
    public float hareketHizi = 0.1f;

    float timer;
    
    void Start()
    {
        //enemyAnim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Karakter");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        GameObject takipEdilecekObj = GameObject.FindGameObjectWithTag(takipEdilecekTag);

        if (distance < 100)
        {
            timer += Time.deltaTime;

            if (timer > 9f)
            {
                atýsSes.Play();
                //enemyAnim.SetBool("attackEnemy", true);
                timer = 0;
                shoot();
            }
        }
        else
        {
            //enemyAnim.SetBool("attackEnemy", false);
        }

        if (takipEdilecekObj != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, takipEdilecekObj.transform.position, hareketHizi * Time.deltaTime);
        }


    }
    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }


}
