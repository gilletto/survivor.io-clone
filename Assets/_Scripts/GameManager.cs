using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [SerializeField]  int _enemyKill;
    [SerializeField]  int _exp;
    [SerializeField] int _gems;
    [SerializeField] UIManager _uiManager;
    [SerializeField] EnemyManager _enemyManager;
    [SerializeField] PlayerController _player;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _enemyKill = 0;
        _exp = 0;
        _gems = 0;
    }

    public void IncreaseExperience(int amount)
    {
        _exp += amount;
        _uiManager.UpdateExperience(_exp);
    }
    public void IncreaseGem() 
    {
        _gems++;
        _uiManager.UpdateGem(_gems);
    }
    public void IncreaseEnemyKill()
    {
        _enemyKill++;
        _uiManager.UpdateKill(_enemyKill);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        _player.enabled = false;
        _uiManager.GameOver();
    }
    public void RestartGame()
    {
        ResetGame();
        Time.timeScale = 1;
    }

    private void ResetGame()
    {
        _enemyKill = 0;
        _exp = 0;
        _gems = 0;
        _enemyManager.DisposeAll();
        _player.Setup();
        _player.enabled = true;
        _uiManager.RestartGame();

    }
    public void EnemyKilled(Enemy item)
    {
        _enemyManager.RemoveEnemy(item);
    }
}
