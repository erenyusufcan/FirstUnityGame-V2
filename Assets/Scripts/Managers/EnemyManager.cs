using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Player player;
    public Enemy enemyPrefab;
    public List<Enemy> enemies;

    public int enemyCount;

    public void RestartEnemyManager()
    {
        DeleteEnemies();
        GenerateEnemies();
    }

    

    private void GenerateEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            float enemyXPos = 0;
            enemyXPos = UnityEngine.Random.Range(-3.3f,3.3f);
            var newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = new Vector3(enemyXPos, 0, 3 + i*2f);
            enemies.Add(newEnemy);
            newEnemy.StartEnemy(player);
        }
        

    }

    private void DeleteEnemies()
    {
        foreach (var enemies in enemies)
        {
            Destroy(enemies.gameObject);
        }
        enemies.Clear();
        



    }

    public void StopEnemies()
    {
        foreach (var enemy in enemies)
        {
            enemy.Stop();
        }
    }
}