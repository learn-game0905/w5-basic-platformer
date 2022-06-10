using System;
using UnityEngine;

namespace Game.Runtime
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset;

        private void LateUpdate()
        {
            if (this.target == null) return;
            transform.position = this.target.position + this.offset;
        }
    }
}