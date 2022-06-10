using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Runtime
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Slider hp;

        private int hpValue = 10;
        
        void Start()
        {
            this.hp.value = this.hpValue;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void minusBlood()
        {
            this.hpValue--;
            this.hp.value = this.hpValue;
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                // minusBlood();
            }
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                minusBlood();
            }
        }
    }
}
