using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
     [SerializeField]BulletPreset bullet;
   float timeToDisapear = 30f;
   int life;
    
    void Awake()
    {
        life = bullet.life;
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.GetComponent<PlayerCombat>().TakeDamage(bullet.damage);
            Destroy(this.gameObject);
        }
        
    }
    private void Update() {
        DestroyBullet();
    }

    void DestroyBullet(){
        timeToDisapear -= Time.deltaTime;
        if(timeToDisapear <= 0){
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int Damage){
        life -= Damage;
        if(life <= 0){
            Destroy(this.gameObject);
        }
    }
}
