using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public TextMeshProUGUI highScoreText;
    public Text userNameSaved;
    public string firstName;
    public string highScoreLeader;
    public int highScore;
    public int highScoreCounter;
    //private MainManager mainManagerScript;
    //private string savedName;

    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadName();
        LoadScore();

      // mainManagerScript = GameObject.Find("MainManager").GetComponent<MainManager>();
    }
 



    [System.Serializable] //attribute required for JsonUtility -transform into JSON must be serializable 
    class SaveData
    {
        public string firstName;
        //public int highScore;
    }

    public void SaveName()
    {
        //created a new instance of the save data and filled its team color class member
        //with the TeamColor variable saved in the MainManager:
        SaveData data = new SaveData();
        data.firstName = firstName;
        //data.highScore = highScore;
        //transform that instance to JSON
        string json = JsonUtility.ToJson(data);

        //write string to a file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        
    }

    //this method is the reversal of SaveColor method; reads the saved data and sets TeamColor
    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            firstName = data.firstName;
            //highScore = data.highScore;

            userNameSaved.text = firstName;
            


        }
    }
    [System.Serializable] //attribute required for JsonUtility -transform into JSON must be serializable 
    class SaveScoreData
    {
        
        public int highScore;
    }

    public void SaveScore()
    {
        //created a new instance of the save data and filled its team color class member
        //with the TeamColor variable saved in the MainManager:
        SaveScoreData data = new SaveScoreData();
        //data.firstName = firstName;
        data.highScore = highScore;
        //transform that instance to JSON
        string json = JsonUtility.ToJson(data);

        //write string to a file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    //this method is the reversal of SaveColor method; reads the saved data and sets TeamColor
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveScoreData data = JsonUtility.FromJson<SaveScoreData>(json);

           // firstName = data.firstName;
            highScore = data.highScore;
            highScoreText.text = "High Score: " + firstName + highScore;
            //userNameSaved.text = firstName;
            //highScoreText.text = "High Score: " + highScore;


        }
    }

    //public void CountHighScore(int highScore)
    //{

    //  highScoreCounter += highScore;

    //}

    //public void SetTextBoxUsername()
    //  {

    //  firstName = savedName;

    // savedName = userNameSaved.text;

    //}
}
