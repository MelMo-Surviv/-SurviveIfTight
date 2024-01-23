using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneKontrol : MonoBehaviour
{
    public void playOnline()
    {
        SceneManager.LoadScene("Loading");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Offline()
    {
        SceneManager.LoadScene("Offline");
    }

    public void goMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
