using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class VerifyLetterInput : MonoBehaviour
{
    public string input;
    private char[] InputChar;
    public GameObject inputField;
    public GameObject inputField2;
    private string inputText;
    public GameObject Encryption;
    private string EncryptionText;
 
    private int[] ASCIICodes = new int[256];
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
        EncryptionText = Encryption.GetComponent<TMP_Text>().text;
        ASCIICodes = FindObjectOfType<EncryptingSentence>().ASCIICodeArray;
        int Encryptionint = int.Parse(EncryptionText);
        //int Encryptionint = AtoI(EncryptionText);
        Debug.Log(Encryptionint);
        Debug.Log(ASCIICodes[input[0] - 'A' + 'a']) ;
        Debug.Log(input[0]);
        if (ASCIICodes[input[0] - 'A' + 'a'] == Encryptionint)
        {
            Debug.Log("Correct");
            //what to do if correct
        }
        else
        {
            Debug.Log("Loser");
            inputField2.GetComponent<TMP_InputField>().text = string.Empty;
            //what to do if wrong
        }

          

           
       


    }
    private int AtoI(string s)
    {
        int StringInint = 0, p = 10;
        for(int i=0; i< s.Length; i++)
        {
            StringInint += (int)s[i] - (int)'0' * p;
            p *= 10;
        }
        return StringInint;
    }
}
