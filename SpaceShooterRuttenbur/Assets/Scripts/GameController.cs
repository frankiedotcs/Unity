using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// The Game Controller for Space Shooter
/// Liz "Frankie" Ruttenbur
/// </summary>
public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text restartText;
    public Text gameOverText;
    public Text scoreText;
    private bool gameOver;
    private bool restart;

    private int score;
    /// <summary>
    /// updates and gets things going for the start of the game
    /// </summary>
    void Start()
    {
        score = 0;
        UpdateScore();
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        StartCoroutine(SpawnWaves()); //calls the spawn waves
        
    }
    /// <summary>
    /// the update function
    /// that houses the restart ability for the game
    /// </summary>
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    /// <summary>
    /// Spawns the waves of hazards
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Adds the score together
    /// and updates it
    /// </summary>
    /// <param name="newScoreValue"></param>
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    /// <summary>
    /// Updates the score text
    /// </summary>
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    /// <summary>
    /// updates the game over text
    /// and sets the bool value to true 
    /// breaking through the endless cycle.
    /// </summary>
    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}