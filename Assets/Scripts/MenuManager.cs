using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI userNameSaved;
    public string firstName;
    public string highScoreLeader;
    public int highScore; 

    // Awake is called 1st -before Start which is called in the first frame update
    void Awake()
    {
        if (Instance != null) //this is the singleton pattern to ensure only 1 MenuManager ever exists
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    // creates a static member to the MenuManager class & this code enables you to access
    //MenuManager from any script using only dot notation i.e.  MenuManager.Instance.AssignName()
    }

    
}
