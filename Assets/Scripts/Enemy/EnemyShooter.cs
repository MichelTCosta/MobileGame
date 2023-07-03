using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] BulletPreset bullet;
    [SerializeField] EnemyPreset enemyShooter;

    [SerializeField]Transform firePoint;
    [SerializeField]Transform player;

    [SerializeField]GameObject bulletPrefab;

    [SerializeField]float shotRate;
    [SerializeField] float sightLine;

    float speed;
    float bulletSpeed;
    float nextShotTime;
    float distanceFromPlayer;


    private void Awake() {
        bulletSpeed = bullet.speed;
        speed = enemyShooter.speed;
    }

    // Update is called once per frame
    void Update()
    {
            //Make the enemy look to player
        if(player != null){
           transform.right = player.position - this.transform.position; 
           Shoot();
        }
        MoveToPlayer();
         
        
    }
    
    void Shoot(){
        if(distanceFromPlayer < sightLine && Time.time >= nextShotTime){
            GameObject bullet = Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
            nextShotTime = Time.time + 1 / shotRate; 
        }
        
    }
    void MoveToPlayer(){
        distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if(distanceFromPlayer > sightLine){
            this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    void OnDrawGizmosSelected(){
        
        Gizmos.DrawWireSphere(this.transform.position, sightLine);
    }
    

}
