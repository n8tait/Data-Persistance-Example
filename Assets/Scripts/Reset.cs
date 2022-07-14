using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{

    public void StartNew()
    {
        
       //SceneManager.GetSceneByBuildIndex(0);
        SceneManager.LoadScene(0);
       //LoadSceneParameters.Equals(MenuManager.Instance.firstName);
        //CreateSceneParameters.ReferenceEquals(MenuManager.Instance.LoadName());
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
