using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// The Game Controller for Space Shooter
/// Liz "Frankie" Ruttenbur
/// </summary>
public class GameController : MonoBehaviour {

    /// <summary>
    /// public variables
    /// </summary>
    /// 
    public GameObject player;
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text restartText;
    public Text gameOverText;
    public Text scoreText;
    public Text upgradeText;
    public int totalEnemies = 15;
    public bool bossDestroyed;

    /// <summary>
    /// private variables
    /// </summary>
    private bool gameOver;
    private bool restart;
    private int score;
    private int enemiesDestroyed = 0;
    private float delayBeforeLoading = 5.0f;
    private float timeElapsed;
    
    public int EnemyDestroyed
    {
        get { return enemiesDestroyed; }
        set { enemiesDestroyed = value; }
    }
    
    void Start()
    {

        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        upgradeText.text = "";

        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                score = 0;
                bossDestroyed = false;
                enemiesDestroyed = 0;
                restartText.text = "";
                gameOverText.text = "";
                upgradeText.text = "";
                SceneManager.LoadScene("spaceshooter");
            }
        }
        else if(enemiesDestroyed >= totalEnemies)
        {
            SceneManager.LoadScene("BossLevel");
        }
        else if (bossDestroyed)
        {
            timeElapsed += Time.deltaTime;
            gameOverText.text = "YOU WIN!";
            if (timeElapsed >= delayBeforeLoading)
            {
                SceneManager.LoadScene("Score");
            }

       
        }
        else
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= delayBeforeLoading)
            {
                SceneManager.LoadScene("Score");
            }
            
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

    public void SaveLevel()
    {
        LevelController.Level.EnemyDestroyed = enemiesDestroyed;
        LevelController.Level.BossDestroyed = bossDestroyed;
        LevelController.Level.Score = score;
        LevelController.Level.UpgradeLeft = player.GetComponent<PlayerController>().upgradesLeft;
        LevelController.Level.PlayerPos = player.transform.position;
    }
}