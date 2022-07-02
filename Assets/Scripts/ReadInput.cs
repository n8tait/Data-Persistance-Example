using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    public Text Username_field; //have to drag+drop Text(Legacy) in Inspector
    private void Start()
    {

    }

    public void GetTextInput()
    {
        //Get the text data from textinput field
        string userID = Username_field.text.ToString();
        Debug.Log(userID);

        MenuManager.Instance.firstName = userID;

    }
}