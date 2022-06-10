using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runtime
{
    public class PlayerMove : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private Animator animator;
        
        void Start()
        {
            this._rigidbody2D = GetComponent<Rigidbody2D>();
            this.animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                this.animator.SetTrigger("Run");
                transform.Translate(Vector3.left * 5f * Time.deltaTime);
                if (transform.localScale.x > 0)
                {
                    transform.localScale = new Vector3(
                            transform.localScale.x * -1,
                        transform.localScale.y,
                            transform.localScale.z
                        );
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                this.animator.SetTrigger("Run");
                transform.Translate(Vector3.right * 5f * Time.deltaTime);
                if (transform.localScale.x < 0)
                {
                    transform.localScale = new Vector3(
                        transform.localScale.x * -1,
                        transform.localScale.y,
                        transform.localScale.z
                    );
                }
            } 
            else if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                this.animator.SetTrigger("Attack_1");
                this.animator.SetTrigger("Attack_1");
                Debug.Log("aaaaaaaaaaaaaaaaaa");
            }
            else
            {
                // this.animator.SetTrigger("Idle");
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
            {
                Debug.Log("aaaaaaaaaaaaa");
            }
        }
    }
}
