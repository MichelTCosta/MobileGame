using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomber : MonoBehaviour
{
    [SerializeField]EnemyPreset enemy;
    [SerializeField]Transform player;
    [SerializeField]float fieldOfView;
    [SerializeField]float explosionRange;
    [SerializeField]LayerMask playerLayer;


    Animator animator;


    float distanceFromPlayer;
    float speed;

    int damage;
    
    
    void Awake()
    {
        speed = enemy.speed;
        damage = enemy.damage;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        
    }
    void MoveToPlayer(){
        distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if(distanceFromPlayer > fieldOfView){
            this.transform.position = Vector2.MoveTowards(this.transform.position ,player.transform.position, speed * Time.deltaTime);
        }   

        //Check if the player is close enough to explode 
        if(distanceFromPlayer < fieldOfView){
            animator.SetBool("CanExplode", true);
        
           

    }
   
    }
    void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(this.transform.position, explosionRange);
    }
    

    //Do damage to the player if he's in the explosion radius
    public void ExplodeDamage(){
        Destroy(this.gameObject);
        Collider2D[] explosion = Physics2D.OverlapCircleAll(this.transform.position, explosionRange, playerLayer);
            foreach (Collider2D player in explosion)
            {
                player.GetComponent<PlayerCombat>().TakeDamage(damage);
            }
            
    }
}
