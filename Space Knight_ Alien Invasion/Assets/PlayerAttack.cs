using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    Animator animator;
    public float attackRate = 2.0f;
    float nextAttackTime = 0f;
    public Transform attackPos;
    public float attackRangeX;
    public float baseAttackRangeX;
    public float attackRangeY;
    public float baseAttackRangeY;
    public LayerMask whatIsEnemies;
    public int damages;
    public int baseDamages;
    // Start is called before the first frame update
    void Start()
    {
        damages = baseDamages;
        attackRangeX = baseAttackRangeX;
        attackRangeY = baseAttackRangeY;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))//bouton principale
            {
                animator.SetTrigger("Attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0.0f, whatIsEnemies);//les ennemies qui se trouve dans la zone du collider
                for(int i = 0; i < enemiesToDamage.Length; i++)//on met des degats a chaque ennemie dans la zone
                {
                    enemiesToDamage[i].GetComponent<EnnemiBehavior>().Pousser(this.transform);
                    enemiesToDamage[i].GetComponent<EnnemiBehavior>().TakeDamage(damages);
                }
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
