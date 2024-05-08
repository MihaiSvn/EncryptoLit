using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using System.Linq;
using Unity.VisualScripting.Dependencies.Sqlite;
using System.Diagnostics.Tracing;
using System.Text.RegularExpressions;
using UnityEngine.UIElements;

public class EncryptingSentence : MonoBehaviour
{
    public GameObject WinScreen; //WinScreen parent
    public GameObject SentenceScreen;   //SentenceScreen parent
    [SerializeField] private float Fraction_Words = 5; //the fraction of words given
    public static string Sentence;   //normal sentence(grabbed from sentence object)
    private string SentenceWOSpaces;  //sentence without spaces for encryption
    public GameObject tilePrefab;     //tile prefab for generating letters
    [HideInInspector] public int[] ASCIICodeArray= new int[256];    //vector that stores each letter's random encryption on the index of their ASCII code
    [HideInInspector] public int[] FrecvCodesArray= new int[256];   //vector for how many of each encryption there are
    [HideInInspector] public int[] EncryptedSentence= new int[256];  //vector that holds the sentence as if it was all encrypted
    private GameObject Encryption;    //object for each encryption object in sentence parent
    private GameObject Letter;        //object for each letter object in sentence parent
    private TMP_Text EncrpytionText;  //the actual text field of each encryption
    private TMP_Text LetterText;      //the actual text field of each letter
    private TMP_InputField LetterInput;       //input field for each letter
    [HideInInspector] public int mistakes = 0;   //used for lose condition
    [HideInInspector] public int LettersLeft;    //used for win condition
    public GameObject Button;
    public GameObject ButtonPosWin;

    [HideInInspector] public bool FadeBool = false;   //used for fade in animation on win condition
    private void Awake()
    {
        Sentence = this.GetComponent<TMP_Text>().text;  //gets the text from the sentence object
        //GenerateTiles(ref Sentence);
    }
    private void Start()
    {
      
        Sentence = this.GetComponent<TMP_Text>().text;  //gets the text from the sentence object
        SentenceWOSpaces = Sentence.Replace(" ", string.Empty);  //removes spaces from sentence
        LettersLeft = SentenceWOSpaces.Length;     //used for win condition
        //create encryption for each unique letter
        for (int i=0 ; i < SentenceWOSpaces.Length ; i++)
        {
            if (ASCIICodeArray[SentenceWOSpaces[i]] == 0)
            {
                int nrrand;
                do
                {
                    nrrand = Random.Range(1, 27);
                } while (FrecvCodesArray[nrrand] != 0);
                ASCIICodeArray[SentenceWOSpaces[i]] = nrrand;
                EncryptedSentence[i] = ASCIICodeArray[SentenceWOSpaces[i]];
                FrecvCodesArray[nrrand]++;

            }
            else
            {
                EncryptedSentence[i] = ASCIICodeArray[SentenceWOSpaces[i]];
                FrecvCodesArray[EncryptedSentence[i]]++;
            }

        }
        //put encryption on screen
        for (int i = 0; i < SentenceWOSpaces.Length; i++)
        {
            Encryption = this.gameObject.transform.GetChild(i).GetChild(1).gameObject;
            EncrpytionText = Encryption.GetComponent<TMP_Text>();
            EncrpytionText.SetText(EncryptedSentence[i].ToString());

        }
        Debug.Log(SentenceWOSpaces.Length);    
        int GivenLetters = (int)Mathf.Round(SentenceWOSpaces.Length / Fraction_Words) + 1;  //how many letters are given
        Debug.Log(GivenLetters);
        //put the random letters
        int[] RandomFrecv = new int[256];
        int randomgive;
        while(GivenLetters!=0)
        {
            do
            {
                randomgive = Random.Range(0, SentenceWOSpaces.Length - 1);
            } while (RandomFrecv[randomgive] != 0);
            RandomFrecv[randomgive]++;
            
            
            char RandomLetter = SentenceWOSpaces[randomgive];
       
            Letter = this.gameObject.transform.GetChild(randomgive).gameObject;
            LetterInput = Letter.GetComponent<TMP_InputField>();
            LetterInput.onValueChanged.SetPersistentListenerState(0, UnityEngine.Events.UnityEventCallState.Off);
            LetterInput.text = RandomLetter.ToString().ToUpper();
            LettersLeft--;
            LetterInput.interactable = false;
            DeleteEncryption(EncryptedSentence[randomgive]);
            LetterInput.onValueChanged.SetPersistentListenerState(0, UnityEngine.Events.UnityEventCallState.RuntimeOnly);
            GivenLetters--;
        }
    }

    private void GenerateTiles(ref string a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            if (!(a[i] >= 'a' && a[i] <= 'z'))
            {
                continue;
            }
            GameObject crt = Instantiate(tilePrefab, transform);
            crt.transform.localPosition = new Vector3((i * 50) % 500, -(i/10)*50, 0);
          
        }
        a = string.Concat(a.Where(c => !char.IsWhiteSpace(c)));
    }
    public void DeleteEncryption(int n)    //changes vector for how many of each encryption there are and checks if it should delete the encryption
     {
            FrecvCodesArray[n]--;
            if (FrecvCodesArray[n] == 0)
            {
                for(int i=0;i<SentenceWOSpaces.Length;i++)
                {
                    Encryption = this.gameObject.transform.GetChild(i).GetChild(1).gameObject;
                    string EncrpytionTextString = Encryption.GetComponent<TMP_Text>().text;
                    int EncryptionTextInt = int.Parse(EncrpytionTextString);
                    if (EncryptionTextInt == n) 
                        Encryption.SetActive(false);
                }
            }
            
     }
    private void Update() 
    {
        if (LettersLeft == 0)     //win condition
        {
            FadeBool = true;   //change used for fade in scripts
            Vector3 NewButtonPos = new Vector3(-699f, 401f, 0f);
            Button.gameObject.transform.position = ButtonPosWin.gameObject.transform.position;
            for(int i=0;i <= SentenceWOSpaces.Length;i++)     //disable all letters, commas, dots and health
                this.gameObject.transform.GetChild(i).gameObject.SetActive(false);

            
            Debug.Log("Good job lil bro");
        }
            
    }

    
}
