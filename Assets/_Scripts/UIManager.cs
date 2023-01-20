using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _killText;
    [SerializeField] TextMeshProUGUI _gemText;
    [SerializeField] TextMeshProUGUI _expText;
    [SerializeField] GameObject _gameOverScreen;
    public Button RestartButton;
    // Start is called before the first frame update

    void Start()
    {
        RestartButton.onClick.AddListener(GameManager.Instance.RestartGame);
    }
    //void Start()
    //{
    //    _restartButton.onClick.AddListener(RestartGame);
    //}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateKill(int amount = 0)
    {
        _killText.text = "Kill: " + amount;
    }
    public void UpdateGem(int amount = 0)
    {
        _gemText.text = "Gem: " + amount;
    }
    public void UpdateExperience(int amount = 0)
    {
        _expText.text = "Exp: " + amount;
    }

    public void GameOver()
    {
        _gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        _gameOverScreen.SetActive(false);
        UpdateKill(0);
        UpdateGem(0);
        UpdateExperience(0);
    }
}
