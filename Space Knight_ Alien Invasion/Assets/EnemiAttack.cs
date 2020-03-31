using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiAttack : MonoBehaviour
{
    Animator animator;
    public float attackRate = 2.0f;
    float nextAttackTime = 0f;

    public Transform attackPos;
    public float attackRangeX;
    public float attackRangeY;
    public LayerMask whatIsPlayer;
    public int damages;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D col)
    {
       
        if(Time.time >= nextAttackTime)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                Debug.Log("colision");
                col.gameObject.GetComponent<CharacBehavior>().Pousser(this.transform);
                col.gameObject.GetComponent<CharacBehavior>().TakeDamage(damages);
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 0));
    }
}
