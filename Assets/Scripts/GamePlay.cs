using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    private static GamePlay _instance;
    public static GamePlay Instance
    {
        get
        {
            if (_instance == null)
            {
                var go = new GameObject("GamePlay");
                _instance = go.AddComponent<GamePlay>();
            }

            return _instance;
        }
    }
    
    [Header("Controllers")]
    [SerializeField] BallController ball;
    [SerializeField] PlayerController player;

    [Header("UI components")]
    [SerializeField] Text scoreLabel;
    [SerializeField] Text livesLabel;
    [SerializeField] Text getReadyLabel;

    [Header("Game variables")]
    public uint score = 0;
    public uint lives = 3;

    public float speedIncrease;

    private uint briks = 4;
    private bool gameOver = false;

    [Header("Game objects")]
    [SerializeField] GameObject[] bricksGO;
    public ParticleSystem blast;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(_instance.gameObject);
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);

        Reset();
    }

    public void Goal()
    {
        if (lives == 0) return;

        getReadyLabel.enabled = true;
        var pos1 = player.transform.position;
        pos1.x = 0f;
        player.transform.position = pos1;

        ball.transform.position = Vector3.zero;
        ball.rb.velocity = Vector2.zero;

        scoreLabel.text = score.ToString();
        livesLabel.text = lives.ToString();

        StartCoroutine(StartGame());
    }

    private void Reset()
    {
        score = 0;
        lives = 3;
        briks = PlayerPrefs.HasKey(PlayerPrefsKeys.topScoreKey) ? (uint)PlayerPrefs.GetInt(PlayerPrefsKeys.topScoreKey) + 1 : 4;
        if (briks < 4)
            briks = 4;
        CreateBricks();

        Goal();
    }

    void CreateBricks()
    {
        for (int i = 0; i < briks; i++)
        {
            if (i < bricksGO.Length)
            {
                bricksGO[i].SetActive(true);
            }
        }
    }

    private IEnumerator StartGame()
    {
        int countDown = 3;
        yield return new WaitForSeconds(0.5f);
        while (countDown > 0)
        {
            getReadyLabel.text = countDown.ToString();
            yield return new WaitForSeconds(1f);
            countDown--;
        }
        
        getReadyLabel.enabled = false;
        gameOver = false;
        ball.Kick();
    }

    public void IncreaseSpeeds()
    {
        ball.IncreaseSpeed(speedIncrease);
        player.IncreaseSpeed(speedIncrease);
    }

    void DebugCommands()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            lives = 0;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            score = briks;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    void CheckGameOver()
    {
        if (score == briks)
        {
            SceneManager.LoadScene((int)Scenes.WIN);
            gameOver = true;
        }
        else if (lives == 0)
        {
            SceneManager.LoadScene((int)Scenes.LOSE);
            gameOver = true;
        }
    }

    void UpdateUIStats()
    {
        scoreLabel.text = score.ToString();
        livesLabel.text = lives.ToString();
    }

    private void Update()
    {
#if UNITY_EDITOR
        DebugCommands();
#endif

        if (gameOver) return;
        UpdateUIStats();
        CheckGameOver();
    }
}