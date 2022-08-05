using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class ReadInput : MonoBehaviour
{
    public TextMeshProUGUI usernameTMP;
    public TMP_InputField register_username;
    string username;
    // have to drag+drop Text(Legacy) in Inspector OR TextMeshPro??
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GetTextInput()
    //Get the text data from textinput field
    {
        this.GetComponentInChildren<TMP_InputField>().text = username;
        
        Debug.Log(username);

        MenuManager.Instance.firstName = username;
        usernameTMP.text = $"Hello  {username}";
 
            }
}
