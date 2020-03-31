using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{   /* Les Ennemies dans la préfab */
    public GameObject enemiBase;
    /*******************************/

    /* Les points de spawn */
    private Transform spawnPoint0;
    private Transform spawnPoint1;
    private Transform spawnPoint2;
    private Transform spawnPoint3;
    private Transform spawnPoint4;
    /*******************************/

    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent == GameObject.Find("Plateforme_Debut")) //si on est dans la plateform debut
        {
            spawnPoint0 = transform.Find("SpawnP_0");
        }
        spawnPoint1 = transform.Find("SpawnP_1");
        spawnPoint2 = transform.Find("SpawnP_2");
        spawnPoint3 = transform.Find("SpawnP_3");
        spawnPoint4 = transform.Find("SpawnP_4");

        Instantiate(enemiBase, spawnPoint1.position, transform.rotation);
        Instantiate(enemiBase, spawnPoint2.position, transform.rotation);
        Instantiate(enemiBase, spawnPoint3.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
