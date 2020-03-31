using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    private GameObject[] characterList;
    private int index;

    private void Start()
    {

        index = PlayerPrefs.GetInt("SkinSelectionne");

        characterList = new GameObject[transform.childCount];

        // Remplir le tableau avec les skins
        for (int i = 0; i < transform.childCount; i++)
            characterList[i] = transform.GetChild(i).gameObject;

        // Cacher les skins
        foreach (GameObject go in characterList)
            go.SetActive(false);

        // Rendre visible l'element courant
        if (characterList[index])
            characterList[index].SetActive(true);
    }

    public void Gauche()
    {
        // Cacher le modele courant
        characterList[index].SetActive(false);

        index--;
        if (index < 0)
            index = characterList.Length - 1;

        // Rendre visible le nouveau modele
        characterList[index].SetActive(true);
    }

    public void Droite()
    {
        // Cacher le modele courant
        characterList[index].SetActive(false);

        index++;
        if (index == characterList.Length)
            index = 0;

        // Rendre visible le nouveau modele
        characterList[index].SetActive(true);
    }

    public void Confirmer()
    {
        PlayerPrefs.SetInt("SkinSelectionne", index);
        SceneManager.LoadScene("MenuScene");
    }
}
