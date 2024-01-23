using UnityEngine;

public class SpawnerDusman : MonoBehaviour
{
    public GameObject[] objeler; 
    public Transform spawnPozisyonu; 

    
    float timer;
    float waveTimer;

    float DusmanSpawnS�resi = 20;
    void Start()
    {
        
    }
    private void Update()
    {
        timer += Time.deltaTime;
        waveTimer += Time.deltaTime;

        if (timer > DusmanSpawnS�resi)
        {
            GameObject secilenObj = objeler[Random.Range(0, objeler.Length)];
            Instantiate(secilenObj, spawnPozisyonu.position, Quaternion.identity);

            timer = 0;
        }

        if(DusmanSpawnS�resi == 10)
        {

        }
        else if(waveTimer > 60)
        {
            DusmanSpawnS�resi -= 1;
            waveTimer = 0;
            Debug.Log("Dusman Spawn S�resi: "+DusmanSpawnS�resi);
        }
        
    }

    
}