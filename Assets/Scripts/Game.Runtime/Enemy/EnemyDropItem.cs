using System.Collections.Generic;
using UnityEngine;

namespace Game.Runtime.Enemy
{
    public class EnemyDropItem : MonoBehaviour
    {
        public List<GameObject> itemPrefabs;

        public void Drop()
        {
            if (this.itemPrefabs == null) return;
            for (int i = 0; i < itemPrefabs.Count; i++)
            {
                var position = transform.position;
                position.x += .75f * i;
                Instantiate(itemPrefabs[i]).transform.position = position;
            }
        }
    }
}