using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runtime
{
    public class EnemyManager : MonoBehaviour
    {
        private static EnemyManager instance;
        public static EnemyManager Instance => instance;


        private void Awake()
        {
            if (instance != null) return;
            instance = this;
        }
        
        public List<EnemySpawn> enemySpawns;
        [SerializeField]
        private List<GameObject> enemies = new List<GameObject>();
        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            foreach (var enemySpawn in this.enemySpawns)
            {
                foreach (var position in enemySpawn.positions)
                {
                    enemies.Add(Instantiate(enemySpawn.prefab));
                    this.enemies[^1].transform.position = position;
                }
            }
        }

        public void Death(GameObject enemy)
        {
            this.enemies.Remove(enemy);
            if (IsWin())
            {
                StateManager.Instance.Win();
            }
        }

        private bool IsWin()
        {
            return this.enemies.Count <= 0;
        }
    }

    [Serializable]
    public class EnemySpawn
    {
        public GameObject prefab;
        public List<Vector2> positions;
    }
}