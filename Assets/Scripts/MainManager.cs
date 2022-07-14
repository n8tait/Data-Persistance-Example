using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text highScoreText;
    public TextMeshProUGUI ScoreText;
    //public Text ScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    public int m_Points;
    public int newHighScore;
    
    private bool m_GameOver = false;
    public Button yourButton;
    private AudioSource audioSource;
    public AudioClip letsGoAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(ActionButton);
        if(MenuManager.Instance != null)
        {
            if(MenuManager.Instance.highScore > MenuManager.Instance.highScoreCounter)
            {
                MenuManager.Instance.AssignName();
                MenuManager.Instance.AssignScore();
                highScoreText.text = $"High Score: {MenuManager.Instance.firstName} -> {MenuManager.Instance.highScore}";
            }
           //MenuManager.Instance.LoadName();
           // highScoreText.text = "High Score: :"+ MenuManager.Instance.highScoreLeader + newHighScore;
             else
            
            highScoreText.text = $"High Score: {MenuManager.Instance.highScoreLeader} --> {MenuManager.Instance.highScoreCounter}";
        }
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
         
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
         //highScoreText.text = "High Score: " + MenuManager.Instance.firstName + m_Points;
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
           // m_Points = MenuManager.Instance.highScore;
            
            //SetHighScore();
           // Debug.Log("SET HIgh m_Points = MenuManager.Instance.highScore");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                //MenuManager.Instance.SaveName();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        
        newHighScore += point;
            m_Points += point;
        MenuManager.Instance.highScore = newHighScore;
        ScoreText.text = $"Score : {m_Points}";
      
   

        //if(m_GameOver == true && m_Points > 0 && m_Points > MenuManager.Instance.highScore)
       // {
          //  m_Points = MenuManager.Instance.highScore;
           // Debug.Log("m_Points = MenuManager.Instance.highScore");
       // }
    }

   // public void SetHighScore(string h)
   // {
       // MenuManager.Instance.firstName = h;
      //  highScoreText.text = "High: " + h;

   // }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        SetHighScore();
        //if(m_Points > MenuManager.Instance.highScore)
        //{
            //MenuManager.Instance.SaveName();
        //}
       // MenuManager.Instance.SaveScore();
        //MenuManager.Instance.SaveName();
        //if(m_Points > 0 && m_Points > MenuManager.Instance.highScore)
        //{

        //}
        //m_Points = MenuManager.Instance.highScore;
        Debug.Log("GameOver()  m_Points =" + m_Points);
    }

    public void ActionButton()
    {
        if (!m_Started)
        {
            if (yourButton != null)
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
                audioSource.PlayOneShot(letsGoAudio, 1.0f);
            }
        }
        else if (m_GameOver)
        {
            // m_Points = MenuManager.Instance.highScore;

            //SetHighScore();
            // Debug.Log("SET HIgh m_Points = MenuManager.Instance.highScore");
            if (yourButton != null)
            {
                audioSource.PlayOneShot(letsGoAudio, 1.0f);
                //MenuManager.Instance.SaveName();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void SetHighScore()
   {

        if (m_Points > MenuManager.Instance.highScoreCounter)
        {
            m_Points = newHighScore;
            MenuManager.Instance.highScore = newHighScore;
            MenuManager.Instance.SaveName();
          highScoreText.text = $"High Score: {MenuManager.Instance.firstName} -> {MenuManager.Instance.highScore}";
            //MenuManager.Instance.LoadName();
        }

    }
}
