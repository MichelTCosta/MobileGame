    using System.Collections.Generic;
    using UnityEngine;
    
    public class PlayerMovement : MonoBehaviour
    {
    
        public JoyStickMovement joyStickMovement;
        public float playerSpeed;
        private Rigidbody2D rb;
        Animator animator;
    
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = this.GetComponent<Animator>();
        }
    
        // Update is called once per frame
    private void Update() {
       if(joyStickMovement.joystickVec.y != 0)
        {
            animator.SetBool("IsMoving", true);
                
                
        }
        else{
            animator.SetBool("IsMoving", false);
        }
        animator.SetFloat("Vertical", joyStickMovement.joystickVec.y);
        animator.SetFloat("Horizontal", joyStickMovement.joystickVec.x);

        
    }
        
        void FixedUpdate()
        {
            if(joyStickMovement.joystickVec.y != 0)
            {
                rb.velocity = new Vector2(joyStickMovement.joystickVec.x * playerSpeed, joyStickMovement.joystickVec.y * playerSpeed);
                
                
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }