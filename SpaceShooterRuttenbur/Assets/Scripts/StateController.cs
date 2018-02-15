using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// JAN helped me with this at the last minute because I couldn't get the states to go.
/// </summary>
public class StateController : MonoBehaviour {

   
    public static StateController State;

    private string activeScene;
    private int score;
    private int upgradesLeft;
    private Vector3 playerPos;
    private int enemiesDestroyed;
    private bool bossDestroyed;
    private bool gameOver;

    public void Start()
    {

        enemiesDestroyed = 0;
        bossDestroyed = false;

        activeScene = "spaceshooter";
        score = 0;
        upgradesLeft = 2;
        playerPos = new Vector3(0f, 0f, 0f);
    }


    public string ActiveScene {
        get { return activeScene; }
        set { activeScene = value; }
    }

    
    public int Score
    {
        get { return score; }
        set { score = value; }
    }

  
    public int UpgradeLeft
    {
        get { return upgradesLeft; }
        set { upgradesLeft = value; }
    }
    
    public Vector3 PlayerPos
    {
        get { return playerPos; }
        set { playerPos = value; }
    }
    
    public int EnemyDestroyed
    {
        get { return enemiesDestroyed; }
        set { enemiesDestroyed = value; }
    }

   
    public bool BossDestroyed
    {
        get { return bossDestroyed; }
        set { bossDestroyed = value; }
    }
   
    public void LoadBossScene() {
        activeScene = "Boss";
        SceneManager.LoadScene(activeScene);
    }

  

}
