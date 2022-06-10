using UnityEngine;

namespace Game.Runtime.Collectable
{
    public abstract class Collectable : MonoBehaviour
    {
        protected abstract bool Collect(Collider2D other);

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (Collect(other))
                Destroy(gameObject);
        }
    }
}