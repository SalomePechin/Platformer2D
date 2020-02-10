using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacBehavior : MonoBehaviour
{

    Rigidbody2D rb;
    public float x_range;
    public float y_range;
    public float vitesse;
    public float maxjump;
    bool isGrounded = false;
    Animator animator;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
      if(Input.GetKey("d") || Input.GetKey("right")){
        avancer();
      }else if(Input.GetKey("a") || Input.GetKey("left")){
        reculer();
      }
      else {
        stop();
      }
      if(Input.GetKey("space") && isGrounded){
        Jump();
      }
      if(Input.GetKey("r")){
        attaquer();
      }
    }
    void stop(){
      rb.velocity = new Vector2(0, rb.velocity.y);
    }
    void avancer(){
      rb.velocity = new Vector2(vitesse, rb.velocity.y);
      spriteRenderer.flipX = false;
    }
    void reculer(){
      rb.velocity = new Vector2(-vitesse, rb.velocity.y);
      spriteRenderer.flipX = true;
    }
    void Jump(){
      rb.velocity = new Vector2(rb.velocity.x, maxjump);
    }
    void attaquer(){
      animator.Play("Attaquer");
    }
    void OnCollisionEnter2D(Collision2D col){
      if(col.gameObject.CompareTag("Ground")){
        isGrounded = true;
      }
    }
    public float getRangeX(){
      if(spriteRenderer.flipX){
        return transform.position.x - 1;
      }
      else{
        return transform.position.x + 1;
      }
    }
    public float getRangeY(){
      return transform.position.y + 1;
    }
    void OnCollisionExit2D(Collision2D col){
      if(col.gameObject.CompareTag("Ground")){
        isGrounded = false;
      }
    }
}
