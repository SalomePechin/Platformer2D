using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveLifeUI : MonoBehaviour
{
    //Obj.transform.GetChild(0).GetComponent<Image>.overrideSprite =  Resources.Load<Sprite>("Textures/sprite");
    GameObject player;
    CharacBehavior script;
    Image lifeSprite;

    [SerializeField]
    public Sprite vie0;
    public Sprite vie1;
    public Sprite vie2;
    public Sprite vie3;

    // Start is called before the first frame update
    void Start()
    {
        lifeSprite = GetComponent<Image>();
        player = GameObject.Find("Player");
        script = player.GetComponent<CharacBehavior>();
        lifeSprite.sprite = vie1;
    }

    // Update is called once per frame
    void Update()
    {
        getLifeSprite();
    }
    void getLifeSprite()
    {
        if (script.life == 0)
        {
            lifeSprite.overrideSprite = vie0;
        }
        else if (script.life == 1)
        {
            lifeSprite.overrideSprite = vie1;
        }
        else if (script.life == 2)
        {
            lifeSprite.overrideSprite = vie2;
        }
        else
        {
            lifeSprite.overrideSprite = vie3;
        }
    }
}

