using System;
using System.Collections.Generic;
using Game.Runtime.Enemy;
using UnityEngine;

namespace Game.Runtime
{
    public class EnemyManager : MonoBehaviour
    {
        private static EnemyManager instance;
        public static EnemyManager Instance => instance;

        public IconAttribute icon;

        private void Awake()
        {
            if (instance != null) return;
            instance = this;
        }

        public List<EnemySpawn> enemySpawns;
        [SerializeField] private List<GameObject> enemies = new List<GameObject>();

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
                    this.enemies[^1].GetComponentInChildren<EnemyDropItem>().itemPrefabs = enemySpawn.dropItems;
                    this.enemies[^1].transform.position = position;
                }
            }
        }
        #if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.clear;
            foreach (var enemySpawn in this.enemySpawns)
            {
                // Gizmos.color = enemySpawn.color;
                foreach (var position in enemySpawn.positions)
                {
                    Gizmos.DrawIcon(position + Vector2.up * .5f, enemySpawn.iconName);
                    // Gizmos.DrawSphere(position, .5f);
                }
            }
        }
        #endif

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
        public string enemyName;
        public Color color;
        public string iconName;
        public List<GameObject> dropItems;
        public List<Vector2> positions;
    }
}