using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveBonusUI : MonoBehaviour
{
    //Obj.transform.GetChild(0).GetComponent<Image>.overrideSprite =  Resources.Load<Sprite>("Textures/sprite");
    GameObject player;
    CharacBehavior script;
    Image bonusSprite;

    [SerializeField]
    public Sprite bonusPortee;
    public Sprite bonusAttaque;
    public Sprite vide;

    // Start is called before the first frame update
    void Start()
    {
        bonusSprite = GetComponent<Image>();
        player = GameObject.Find("Player");
        script = player.GetComponent<CharacBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        getBonusSprite();
    }
    void getBonusSprite()
    {
        if (script.bonusPortee)
        {
            bonusSprite.sprite = bonusPortee;
        }
        else if (script.bonusAttaque)
        {
            bonusSprite.sprite = bonusAttaque;
        }
        else
        {
            bonusSprite.sprite = vide;
        }
    }

}
