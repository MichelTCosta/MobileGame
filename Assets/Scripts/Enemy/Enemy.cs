using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private EnemyPreset enemy;

    int life;
    
    
    private void Awake() {
        life = enemy.life;
        
    }

    public void TakeDamage(int damage){
        life -= damage;
        if(life <= 0){
            Die();
        }
    }


    void Die(){
        Destroy(this.gameObject);
    }

}
