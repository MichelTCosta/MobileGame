using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickAttackDirection : MonoBehaviour
{
    [SerializeField] PlayerPreset player;
    [SerializeField] Joystick joystick;
    [SerializeField] GameObject attackArea;
    Vector2 attackPosition;
    float attackRotation;
    

    private void Update() {
        attackPosition = new Vector2 (joystick.Horizontal, joystick.Vertical);
        
        Vector2 playerPos = new Vector2 (this.transform.position.x, this.transform.position.y);
        Vector2 defaultPos = new Vector2 (0f, 0f);
        

        if(attackPosition !=  defaultPos){
           attackArea.transform.position = attackPosition  * player.attackRange + playerPos; 
           
        }
        else{
            attackArea.transform.position = new Vector2(0f ,1f)  * player.attackRange + playerPos;
        }
        
        
    }
    
}
