using System;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiBehavior : MonoBehaviour
{
    GameObject character;
    SpriteRenderer spriteRenderer;
    Animator animator;
    CharacBehavior playerBehavior;
    // Start is called before the first frame update
    void Start()
    {
      spriteRenderer = GetComponent<SpriteRenderer>();
      animator = GetComponent<Animator>();
      character = GameObject.Find("Player");
      playerBehavior = character.GetComponent<CharacBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
      if (isInRangeX()) {
        //Debug.Log("X");
      }
      if (isInRangeY()) {
        //Debug.Log("Y");
      }
      if (isInRange()){
        //Debug.Log("IL EST A PORTEE");
      }
      if(isInRange()){
        this.animator.Play("EnnemieDeath");
      }
    }
    bool isInRangeX(){
      return (character.transform.position.x < this.transform.position.x && playerBehavior.getRangeX() >= this.transform.position.x) || (character.transform.position.x > this.transform.position.x && playerBehavior.getRangeX() <= this.transform.position.x);

    }
    bool isInRangeY(){
      return (character.transform.position.y < this.transform.position.y && playerBehavior.getRangeY() >= this.transform.position.y) || (character.transform.position.y > this.transform.position.y && playerBehavior.getRangeY() <= this.transform.position.y);
    }
    bool isInRange(){
      return isInRangeX() && isInRangeY();
    }
}
