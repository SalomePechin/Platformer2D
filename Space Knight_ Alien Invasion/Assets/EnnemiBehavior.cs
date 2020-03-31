using System;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiBehavior : MonoBehaviour
{
    public Transform groundDetectionRight;
    public Transform groundDetectionLeft;

    public float videY;
    Rigidbody2D rb;
    GameObject character;
    Animator animator;
    BoxCollider2D collider2d;

    private float tempsEtourdi;
    public float debutTempsEtourdi;
    public int life;
    public float speed;
    bool isGrounded;
    [SerializeField]
    Transform groundCheck;
    float desiredMovement;

    // Start is called before the first frame update
    void Start()
    {
        videY = GameObject.Find("BasMap").transform.position.y;
        collider2d = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        character = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D groundinfoLeft = Physics2D.Raycast(groundDetectionLeft.position, Vector2.down, 2f);
        RaycastHit2D groundinfoRight = Physics2D.Raycast(groundDetectionRight.position, Vector2.down, 2f);
        /*if(tempsEtourdi <= 0)
        {
            speed = 2;
        }
        else
        {
            speed = 0;
            tempsEtourdi -= Time.fixedDeltaTime;
        }*/
        if (life <= 0 || transform.position.y <= videY)
        {
            Die();
        }

        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))//si 2 lignes de "transform se touchent et que yen a c'est du "ground"
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if(groundinfoRight.collider == false) //detection du vide a gauche
        {
            desiredMovement -= Time.deltaTime;
            desiredMovement = Mathf.Clamp(desiredMovement, -1, 1);
            Move();
        }
        else if (groundinfoLeft.collider == false) //detection du vide a droite
        {
            desiredMovement += Time.deltaTime;
            desiredMovement = Mathf.Clamp(desiredMovement, -1, 1);
            Move();
        }
        Debug.Log(groundinfoLeft.collider);
        /*if(character.transform.position.x < this.transform.position.x - 2) //l'ennemie est devant le perso donc on recule
        {
            desiredMovement -= Time.deltaTime;
            desiredMovement = Mathf.Clamp(desiredMovement, -1, 1);
            Move();
        }
        else if (character.transform.position.x > this.transform.position.x + 2) //l'ennemie est derriere le perso donc on avance
        {
            desiredMovement += Time.deltaTime;
            desiredMovement = Mathf.Clamp(desiredMovement, -1, 1);
            Move();
        }
        else
        {
            Stop();
        }*/

    }
    /*bool isInRangeX(){
      return (character.transform.position.x < this.transform.position.x && playerBehavior.getRangeX() >= this.transform.position.x) || (character.transform.position.x > this.transform.position.x && playerBehavior.getRangeX() <= this.transform.position.x);

    }
    bool isInRangeY(){
      return (character.transform.position.y < this.transform.position.y && playerBehavior.getRangeY() >= this.transform.position.y) || (character.transform.position.y > this.transform.position.y && playerBehavior.getRangeY() <= this.transform.position.y);
    }
    bool isInRange(){
      return isInRangeX() && isInRangeY();
    }*/
    void Move()
    {
        rb.velocity = new Vector2(desiredMovement * speed, rb.velocity.y);
        if (isGrounded)
        {
            animator.SetBool("isMoving", true);
        }

    }
    /*void Reculer()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
        if (isGrounded)
        {
            animator.SetBool("isMoving", true);
        }

    }*/
    void Stop()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        animator.SetBool("isMoving", false);
    }
    public void TakeDamage(int damages)
    {
        tempsEtourdi = debutTempsEtourdi;
        this.life -= damages;
        Debug.Log("Damages taken");
    }
    void Die()
    {
        animator.SetTrigger("Dead");
        rb.gravityScale = 0;
        rb.velocity = new Vector2(0, 0);
        collider2d.enabled = false;
        this.enabled = false;
    }
    public void Pousser(Transform coordonee)
    {
        float force = 0.0f;
        //Vector2 target = new Vector2(0.0f, 0.0f);
        if (coordonee.position.x > this.transform.position.x) //sil le truc est devant l'ennemi, l'ennemi doit reculer  
        {
            force = -200.0f;
            //target = new Vector2(coordonee.transform.position.x - 10, this.transform.position.y);
            desiredMovement = -1;
        }else if(coordonee.position.x < this.transform.position.x)//ici le truc est derriere l'ennemie donc il faut avancer 
        {
            //target = new Vector2(coordonee.transform.position.x + 10, this.transform.position.y);
            desiredMovement = 1;
            force = 200.0f;
        }
        else//s'ils sont au même endroit on bouge en y
        {
            //target = new Vector2(coordonee.position.x, coordonee.transform.position.y + 10);
        }
        //transform.position = Vector2.MoveTowards(this.transform.position, target, 20 * Time.fixedDeltaTime);
        this.rb.AddForce(new Vector2(force, this.transform.position.y));
    }
}
