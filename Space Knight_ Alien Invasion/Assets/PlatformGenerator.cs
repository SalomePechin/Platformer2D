using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 50f;

    private int score;

    [SerializeField] GameObject player;

    /* Toutes les plateformes dans la prefab */
    public GameObject prefabPlatform_Deb;
    public GameObject prefabPlatform_Petit;
    public GameObject prefabPlatform_Moy;
    /*****************************************/
    private float distanceBetweenPlatform = 5;
    public GameObject thePlatform;
    public Transform platformEndpoint;
    private float nextPlatformSize;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Player").GetComponentInChildren<CharacBehavior>().score;
        thePlatform = GameObject.Find("Plateforme_Debut");
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        platformEndpoint = thePlatform.transform.Find("EndPoint");
        
    }

    // Update is called once per frame
    void Update()
    {
        score = GameObject.Find("Player").GetComponentInChildren<CharacBehavior>().score;
        if (Vector3.Distance(player.transform.position, platformEndpoint.position ) < PLAYER_DISTANCE_SPAWN_LEVEL_PART) //la distance entre le joueur et la derniere platform (son endpoint) est inferieur a 200f
        {
            int rangeMin = 0;
            int rangeMax = 2;
            int rdm = Random.Range(rangeMin, rangeMax + 1);
            Debug.Log(rdm);
            //thePlatform = prefabPlatform2; //la nouvelle plateforme est la nouvelle reference
            //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;//réinstanciation de la taille
            //transform.position = new Vector3(transform.position.x + distanceBetween + oldWidth/2, transform.position.y, transform.position.z); //on decale le point ou on va générer la nouvelle plateforme
            if(rdm % 3 == 0)
            {
                nextPlatformSize = prefabPlatform_Moy.GetComponent<BoxCollider2D>().size.x;
                Vector3 vectorPosition = new Vector3(platformEndpoint.transform.position.x + distanceBetweenPlatform + (nextPlatformSize/2), thePlatform.transform.position.y);
                thePlatform = Instantiate(prefabPlatform_Moy, vectorPosition, thePlatform.transform.rotation);//instanciation de la nouvelle plateform
                platformEndpoint = thePlatform.transform.Find("EndPoint");//on change le endpoint
            }
            else if (rdm % 3 == 1)
            {
                nextPlatformSize = prefabPlatform_Petit.GetComponent<BoxCollider2D>().size.x;
                Debug.Log("petite plateform : " + nextPlatformSize);
                Vector3 vectorPosition = new Vector3(platformEndpoint.transform.position.x + distanceBetweenPlatform + (nextPlatformSize / 2), thePlatform.transform.position.y);
                thePlatform = Instantiate(prefabPlatform_Petit, vectorPosition, thePlatform.transform.rotation);//instanciation de la nouvelle plateform
                platformEndpoint = thePlatform.transform.Find("EndPoint");//on change le endpoint
            }
            else
            {
                nextPlatformSize = prefabPlatform_Deb.GetComponent<BoxCollider2D>().size.x;
                
                Vector3 vectorPosition = new Vector3(platformEndpoint.transform.position.x + distanceBetweenPlatform + (nextPlatformSize / 2), thePlatform.transform.position.y);
                thePlatform = Instantiate(prefabPlatform_Deb, vectorPosition, thePlatform.transform.rotation);//instanciation de la nouvelle plateform
                platformEndpoint = thePlatform.transform.Find("EndPoint");//on change le endpoint
            }
       } 
    }
}
