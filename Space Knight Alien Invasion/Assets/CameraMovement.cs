using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject character;
    public float upLimit = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      transform.position = new Vector3(character.transform.position.x + 4.5f, transform.position.y, -10);
      if(character.transform.position.y > upLimit + this.transform.position.y){
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, character.transform.position.y, 0.09f), transform.position.z);
      }
      if(character.transform.position.y < this.transform.position.y - 2.6895f){
        transform.position = new Vector3(transform.position.x, character.transform.position.y + 2.6895f, transform.position.z);
      }
    }
}
