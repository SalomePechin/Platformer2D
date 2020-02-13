using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;
    public GameObject PauseMenuUI;//le panneau de menu pause
    public GameObject OptionMenuUI;//Le menu des options
    public GameObject MenuButtonUI;//le boutton pour acceder aux menu
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
        MenuButtonUI.SetActive(true);
        isPaused = false;
        Time.timeScale = 1f;//freeze time
    }
    public void Pause()//mettre en pause
    {
        PauseMenuUI.SetActive(true);
        MenuButtonUI.SetActive(false);
        isPaused = true;
        Time.timeScale = 0f;//freeze time

    }
    public void Options()//aller au menu des options
    {
        PauseMenuUI.SetActive(false);
        OptionMenuUI.SetActive(true);
    }
    public void Back()//revenir au menu de pause de jeu
    {
        PauseMenuUI.SetActive(true);
        OptionMenuUI.SetActive(false);
    }
    public void Control()//aller au menu des commandes
    {
        Debug.Log("Commandes");
    }
    public void Rules()//aller menu des règles du jeu
    {
        Debug.Log("Règles");
    }
    public void Quit()//quitter le jeu
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Quitter la partie");
    }
}
