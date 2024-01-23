using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSayacı : MonoBehaviour
{
    float sayacc;
    public Text waveSayimText;
    int wave = 1;
    void Update()
    {
        sayacc += Time.deltaTime;

        if (sayacc > 60)
        {
            wave += 1;
            sayacc = 0;
        }
      waveSayimText.text = wave.ToString();
    }
}
