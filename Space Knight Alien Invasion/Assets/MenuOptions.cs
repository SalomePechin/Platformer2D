using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("Lol");
    }

    public void ChangeSkin()
    {
        Debug.Log("Changer le skin");
    }

    public void SeeRules()
    {
        Debug.Log("Voir les règles");
    }
    
    public void ConsultControls()
    {
        Debug.Log("Consulter les commandes");
    }
}
