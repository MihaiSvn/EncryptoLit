using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
public class VerifyLetterInput : MonoBehaviour
{
    public string input;
    private char[] InputChar;
    public GameObject inputField;
    private TextMeshPro inputText;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ReadStringInput(string s)
    {
        input = s;

        Debug.Log(input);
        /*if (!char.IsLetter(input[0]))
        {
            inputText = inputField.GetComponent<TextMeshPro>();
            inputText.text = null;
            Debug.Log("no");
            
        }*/
    }
}
