using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacBehavior : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    
    public float x_range;
    public float y_range;
    public float speed;
    public float maxjump;
    bool isGrounded;
    [SerializeField]
    Transform groundCheck;

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
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))//si 2 lignes de "transform se touchent et que yen a c'est du "ground"
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if(Input.GetKey("d") || Input.GetKey("right")){
            Avancer();
        }else if(Input.GetKey("a") || Input.GetKey("left")){
            Reculer();
        }
        else
        {
            Stop();
        }

        if(Input.GetKeyDown("space") && isGrounded){
            Jump();
        }
       if(Input.GetKeyDown("r")){
            Attaquer();
       }
    }
    void Stop(){
        rb.velocity = new Vector2(0, rb.velocity.y);
        animator.Play("Player_Iddle");
    }
    void Avancer(){
        rb.velocity = new Vector2(speed, rb.velocity.y);
        spriteRenderer.flipX = false;
        if (isGrounded)
        {
            animator.Play("Player_Moove");
        }
        
    }
    void Reculer(){
        rb.velocity = new Vector2(-speed, rb.velocity.y);
        spriteRenderer.flipX = true;
        if (isGrounded)
        {
            animator.Play("Player_Moove");
        }
        
    }
    void Jump(){
        rb.velocity = new Vector2(rb.velocity.x, maxjump);
        animator.Play("Player_Jump");
    }
    void Attaquer(){
        animator.Play("Player_Attack");
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
