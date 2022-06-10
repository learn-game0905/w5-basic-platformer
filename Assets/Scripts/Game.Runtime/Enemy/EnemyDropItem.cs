using UnityEngine;

namespace Game.Runtime.Enemy
{
    public class EnemyDropItem : MonoBehaviour
    {
        [SerializeField] private GameObject itemPrefab;

        public void Drop()
        {
            Instantiate(this.itemPrefab).transform.position = transform.position;
        }
    }
}