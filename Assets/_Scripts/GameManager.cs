using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [SerializeField]  int _enemyKill;
    [SerializeField]  int _exp;
    [SerializeField] int _gems;

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
    }
    public void IncreaseGem() 
    {
        _gems++;
    }
    public void IncreaseEnemyKill()
    {
        _enemyKill++;
    }
}
