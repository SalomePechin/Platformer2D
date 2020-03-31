using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    //ce script est lancé par la mort du joueur 
    public GameObject GameOverMenuUI;
    public GameObject MenuButtonUI;
    // Start is called before the first frame update
    void Start()
    {
        MenuButtonUI.SetActive(false);
        GameOverMenuUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Quit()
    {
        SceneManager.LoadScene("MenuScene");
        Debug.Log("Quitter la partie");
    }
}
