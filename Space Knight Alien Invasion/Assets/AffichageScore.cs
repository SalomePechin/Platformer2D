using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffichageScore : MonoBehaviour
{
    private int score;
    public Text texteScore;
    // Start is called before the first frame update
    void Start()
    {
      this.score = 0;
      this.texteScore = GetComponent<Text>();
      this.texteScore.text = "Score : " + this.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
      this.texteScore.text = "Score : " + this.score.ToString();
      if(Input.GetKeyDown("i")){
        this.score++;
      }
    }
}
