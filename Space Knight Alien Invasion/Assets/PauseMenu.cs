using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;
    public GameObject PauseMenuUI;//le panneau de menu pause
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) // si le jeu est deja en pause on reprend
            {
                Resume();
            }else { // Sinon on met pause
                Pause();
            }
        }
    }


    public void Resume()//reprendre le jeu
    {
        PauseMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;//freeze time
    }
    public void Pause()//mettre en pause
    {
        PauseMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;//freeze time

    }
}
