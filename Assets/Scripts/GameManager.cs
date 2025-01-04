using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private GameObject gameOverPannel;
    private int coin = 0;
    [HideInInspector]
    public bool isGameOver = false;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void IncreaseCoin()
    {
        coin++;
        text.SetText(coin.ToString());
        if (coin % 5 == 0)
        {
            Player player = FindObjectOfType<Player>();
            if (player != null)
                player.Upgrade();
        }
    }

    public void SetGameover()
    {
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner != null)
        {
            enemySpawner.StopEnemyRoutine();
            isGameOver = true;
        }

        Invoke("ShowGameOverPannel", 1f);
    }

    void ShowGameOverPannel()
    {
        gameOverPannel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
