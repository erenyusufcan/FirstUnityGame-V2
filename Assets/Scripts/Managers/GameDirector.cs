using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [Header("Managers")]
    public EnemyManager enemyManager;
    public LevelManger levelManager;

    private void Start()
    {
        RestartLevel();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        levelManager.RestartLevel();
        enemyManager.RestartEnemyManager();
    }

    public void LevelCompleted()
    {
        enemyManager.StopEnemies();
    }

   
    
}
