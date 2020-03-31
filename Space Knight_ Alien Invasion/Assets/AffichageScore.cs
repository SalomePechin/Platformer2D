using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffichageScore : MonoBehaviour
{
    private GameObject player;
    private float maxPositionX;//son avancement maximum
    public int score;
    private Text texteScore;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        maxPositionX = player.transform.position.x;

        this.score = player.GetComponentInChildren<CharacBehavior>().score; ;
        this.texteScore = GetComponent<Text>();
        this.texteScore.text = "Score : " + this.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        score = player.GetComponentInChildren<CharacBehavior>().score;
        this.texteScore.text = "Score : " + this.score.ToString();
    }
}
