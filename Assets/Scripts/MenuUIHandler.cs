using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
  

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    // public void SavedFirstName()
    // {
    // MenuManager.Instance.SaveName();

    // }





    //Exits/Quit program - works with a built application but not in Unity playmode
    public void Exit()
    {
        //this will save the last selected color on application exit
        //MenuManager.Instance.SaveName();
        //MenuManager.Instance.SaveScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
   }
}
