using System;
using Game.Runtime;
using UnityEditor;
using UnityEngine;

namespace Game.Editor
{
    [CustomEditor(typeof(EnemyManager))]
    public class EnemyManagerEditor : UnityEditor.Editor
    {
        private EnemyManager _enemyManager;

        private void OnEnable()
        {
            this._enemyManager = target as EnemyManager;
        }

        private void OnSceneGUI()
        {
            foreach (EnemySpawn enemySpawn in this._enemyManager.enemySpawns)
            {
                for (int i = 0; i < enemySpawn.positions.Count; i++)
                {
                    enemySpawn.positions[i] = Handles.PositionHandle(enemySpawn.positions[i], Quaternion.identity);
                }
            }
        }
    }
}