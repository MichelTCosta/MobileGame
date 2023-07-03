using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] PlayerPreset player;

    public Transform attackPoint;

    public LayerMask enemyLayer;
    public LayerMask bulletLayer;

    int damage;
    int life;

    float nextAttackTime = 0f;

    bool iFrame;
    
    private void Start() {
        damage = player.damage;
        life = player.life;
    }
    // Update is called once per frame
    void Update()
    {   
        if(Time.time >= nextAttackTime){
            Attack();
            
            nextAttackTime = Time.time + 1 / player.attackRate;
        }
    }

    
        
    void Attack(){
        // TO DO Attack Animation


        //check and damage bullet and enemys
        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.position, player.attackRange, enemyLayer);
        Collider2D[] hitBullet =  Physics2D.OverlapCircleAll(attackPoint.position, player.attackRange, bulletLayer);
        
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage);
            
        }

        foreach (Collider2D bullets in hitBullet)
        {
            bullets.GetComponent<Bullet>().TakeDamage(damage);
            
        }
    }



    //Drawn a line on the attack area
    void OnDrawGizmosSelected() {
        if(attackPoint == null){
            return; 
        }
        Gizmos.DrawWireSphere(attackPoint.position,player.attackRange);
    }



    public void TakeDamage(int damageTaken){
        if(iFrame == false){
           life -= damageTaken; 
           StartCoroutine(BecomeInvulnerable());
        }
        
        if(life <= 0){
            Die();
        }

    }
    void Die(){
        Destroy(this.gameObject);
    }
    IEnumerator BecomeInvulnerable(){
        iFrame = true;
        yield return new WaitForSeconds(1f);
        iFrame = false;
    }
}
