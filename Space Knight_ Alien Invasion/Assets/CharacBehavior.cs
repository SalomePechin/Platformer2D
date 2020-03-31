using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacBehavior : MonoBehaviour
{
    private float maxPositionX;//son avancement maximum
    public int score;

    public float videY;
    public Transform groundCheck;
    Rigidbody2D rb;
    Animator animator;
    GameObject scene;
    PlayerAttack playerAttack;
    public float speed;
    public float maxjump;
    public int life;
    public int maxlife = 3;
    public float normalGravityScale = 3;

    bool isGrounded;

    float desiredMovement;

    //bonus
    public bool bonusPortee = false;
    public bool bonusAttaque = false;
    public int bonusVie = 0;


    private bool facesRight = true;//orientation du perso

    // Start is called before the first frame update
    void Start()
    {
        score = 50;
        maxPositionX = transform.position.x;
        videY = GameObject.Find("BasMap").transform.position.y;
        playerAttack = GetComponent<PlayerAttack>();
        scene = GameObject.Find("Canvas");
        life = 1;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > maxPositionX)
        {
            score += 11;
            maxPositionX = transform.position.x;
        }
        if (life <= 0 || transform.position.y <= videY) //si plus de vie ou bien il tombe dans le vide
        {
            Die();
            //life = 3;
        }
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (Input.GetKey("d") || Input.GetKey("right")){

            desiredMovement += 1;
            desiredMovement = Mathf.Clamp(desiredMovement, -1, 1);
            Avancer();
        }else if(Input.GetKey("a") || Input.GetKey("left")){
            desiredMovement -= 1;
            desiredMovement = Mathf.Clamp(desiredMovement, -1, 1);
            Reculer();
        }
        else
        {
            Stop();
        }
        if(Input.GetKeyDown("space") && isGrounded){
            Jump();
        }
    }
    void Stop(){
        rb.velocity = new Vector2(0, rb.velocity.y);
        animator.SetBool("isMoving", false);//condition pour les animations
    }
    void Avancer(){
        rb.velocity = new Vector2(desiredMovement * speed, rb.velocity.y);
        if (!facesRight)//s'il regardait pas a droite on multiplie son scale en x par -1 ca fait flip tous le gamecomponent avec ces components enfants
        {
            facesRight = true;
            Flip();
        }
        if (isGrounded)
        {
            animator.SetBool("isMoving", true);
        }
        
    }
    void Reculer(){
        rb.velocity = new Vector2(desiredMovement * speed, rb.velocity.y);
        if (facesRight)//inverse d'avancer
        {
            facesRight = false;
            Flip();
        }
        if (isGrounded)
        {
            animator.SetBool("isMoving", true);
        }
        
    }
    void Jump(){
        rb.velocity = new Vector2(rb.velocity.x, maxjump);
        animator.SetTrigger("Jump");//trigger pour lancer lanim du jump (on utilise un trigger car une anim quon joue une seule fois, comme lattaque qui se fait dans le script player attack)
    }
    
    private void Flip()//fonction qui change le scale en x pour retourner le gameobject et ses enfants
    {
        transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public void TakeDamage(int damages)
    {
        this.life -= damages;
        Debug.Log("Damages taken");
    }
    void Die()
    {
        animator.SetTrigger("Dead");
        rb.gravityScale = 0;
        rb.velocity = new Vector2(0, 0);
        GetComponent<BoxCollider2D>().enabled = false;
        scene.GetComponent<GameOverMenu>().enabled = true;
        this.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("BonusPortee"))
        {
            AjouterPortee();
            EnleverDegats();
            this.bonusPortee = true;
            this.bonusAttaque = false;
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("BonusAttaque"))
        {
            AjouterDegats();
            EnleverPortee();
            this.bonusAttaque = true;
            this.bonusPortee = false;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("BonusVie"))
        {
            this.life += 1;
            if(life > maxlife)
            {
                life = maxlife;
            }
            Destroy(other.gameObject);
        }
    }
    void AjouterPortee()
    {
        playerAttack.attackRangeX += 2;
        playerAttack.attackRangeY += 2;
    }
    void EnleverPortee()
    {
        playerAttack.attackRangeX = playerAttack.baseAttackRangeX;
        playerAttack.attackRangeY = playerAttack.baseAttackRangeY;
    }
    void AjouterDegats()
    {
        playerAttack.damages += 1;

    }
    void EnleverDegats()
    {
        playerAttack.damages = playerAttack.baseDamages;
    }
    public void Pousser(Transform coordonee)
    {
        float force = 0.0f;
        //Vector2 target = new Vector2(0.0f, 0.0f);
        if (coordonee.position.x > this.transform.position.x) //sil le truc est devant l'ennemi, l'ennemi doit reculer  
        {
            force = -500.0f;
            //target = new Vector2(coordonee.transform.position.x - 10, this.transform.position.y);
            desiredMovement = -10;
        }
        else if (coordonee.position.x < this.transform.position.x)//ici le truc est derriere l'ennemie donc il faut avancer 
        {
            //target = new Vector2(coordonee.transform.position.x + 10, this.transform.position.y);
            desiredMovement = 10;
            force = 500.0f;
        }
        else//s'ils sont au même endroit on bouge en y
        {
            //target = new Vector2(coordonee.position.x, coordonee.transform.position.y + 10);
        }
        //transform.position = Vector2.MoveTowards(this.transform.position, target, 20 * Time.fixedDeltaTime);
        //rb.velocity = new Vector2(desiredMovement, this.transform.position.y);
        this.rb.AddForce(new Vector2(force, this.transform.position.y), ForceMode2D.Force);
    }
}
