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
            Handles.color = Color.clear;
            foreach (EnemySpawn enemySpawn in this._enemyManager.enemySpawns)
            {
                Handles.color = enemySpawn.color;
                for (int i = 0; i < enemySpawn.positions.Count; i++)
                {
                    Handles.Label(enemySpawn.positions[i] + Vector2.down * .5f, enemySpawn.enemyName,
                        new GUIStyle() {
                            alignment = TextAnchor.MiddleCenter,
                            fixedWidth = 30
                        });
                    enemySpawn.positions[i] = Handles.PositionHandle(enemySpawn.positions[i], Quaternion.identity);
                    EditorGUI.BeginChangeCheck();
                    Vector3 newTargetPosition = Handles.FreeMoveHandle(enemySpawn.positions[i], Quaternion.identity,
                        .5f, Vector3.one * .1f, Handles.SphereHandleCap);
                    if (EditorGUI.EndChangeCheck())
                    {
                        Undo.RecordObject(target, "Change Look At Target Position");
                        enemySpawn.positions[i] = newTargetPosition;
                    }
                }
            }
        }
    }
}