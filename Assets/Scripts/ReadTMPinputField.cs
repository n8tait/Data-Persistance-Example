using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadTMPinputField : MonoBehaviour
{
    public GameObject TMP_InputField_Username;
    public TextMeshProUGUI username;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetUsername();
    }

    public void GetUsername()
    {//sets local variable 'name' to the TMP inputfield component 
        string name = TMP_InputField_Username.GetComponent<TMP_InputField>().text;
        Debug.Log("Username: " + name);
        //display name on screen in TextMeshProUGUI object in scene
        username.text = $"** {name} ** ";

        //set in the static class to bring data to next scene
        MenuManager.Instance.firstName = name;

    }
}