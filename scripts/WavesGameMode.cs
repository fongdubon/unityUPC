using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesGameMode : MonoBehaviour
{
    [SerializeField]
    Life playerLife;
    [SerializeField]
    Life playerBaseLife;
    // Start is called before the first frame update
    void Start()
    {
        playerLife.onDeath.AddListener(OnPlayerLifeChanged);
        playerBaseLife.onDeath.AddListener(OnPlayerBaseLifeChanged);
        EnemyManager.instance.onChanged.AddListener(CheckWinCondition);
        WavesManager.instance.onChanged.AddListener(CheckWinCondition);
    }

    // Update is called once per frame
    void CheckWinCondition()
    {
        if(EnemyManager.instance.enemies.Count<=0 && WavesManager.instance.waves.Count<=0)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
    public void OnPlayerLifeChanged()
    {
        if (playerLife.amount <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
    public void OnPlayerBaseLifeChanged()
    {
        if (playerBaseLife.amount <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
