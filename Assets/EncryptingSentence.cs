using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using System.Linq;

public class EncryptingSentence : MonoBehaviour
{
    public static string Sentence = "life is like riding a bicycle to keep your balance you must keep moving";
    //[HideInInspector] public static int SentenceLength = Sentence.Length;
    public GameObject tilePrefab;
    [HideInInspector] public int[] ASCIICodeArray= new int[256]; 
    [HideInInspector] public int[] FrecvCodesArray= new int[256];
    [HideInInspector] public int[] EncryptedSentence= new int[256];
    private GameObject Encryption;
    private GameObject Letter;
    private TMP_Text EncrpytionText;
    private TMP_Text LetterText;
    [HideInInspector] public int mistakes = 0;
    [HideInInspector] public int LettersLeft = Sentence.Length;

    private void Awake()
    {
        GenerateTiles(ref Sentence);
    }
    private void Start()
    {

        for(int i=0 ; i < Sentence.Length ; i++)
        {
            if (ASCIICodeArray[Sentence[i]] == 0)
            {
                int nrrand;
                do
                {
                    nrrand = Random.Range(1, 27);
                } while (FrecvCodesArray[nrrand] != 0);
                ASCIICodeArray[Sentence[i]] = nrrand;
                EncryptedSentence[i] = ASCIICodeArray[Sentence[i]];
                FrecvCodesArray[nrrand]++;

            }
            else
            {
                EncryptedSentence[i] = ASCIICodeArray[Sentence[i]];
                FrecvCodesArray[EncryptedSentence[i]]++;
            }

        }
        for (int i = 0; i < Sentence.Length; i++)
        {
            Encryption = this.gameObject.transform.GetChild(i).GetChild(1).gameObject;
            EncrpytionText = Encryption.GetComponent<TMP_Text>();
            EncrpytionText.SetText(EncryptedSentence[i].ToString());
            //check if the letter is unique on known letters
            Letter = this.gameObject.transform.GetChild(i).GetChild(0).gameObject;
            LetterText = Letter.GetComponent<TMP_Text>();
            if(LetterText!= null)
            {
                LettersLeft--;
                FrecvCodesArray[EncryptedSentence[i]]--;
                if (FrecvCodesArray[EncryptedSentence[i]] == 0)
                    Encryption.SetActive(false);
            }

        }


        
       /* for(int i=0; i< Sentence.Length;i++)
        { Debug.Log(EncryptedSentence[i]);}*/
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
    public void DeleteEncryption(int n)
     {
            FrecvCodesArray[n]--;
            if (FrecvCodesArray[n] == 0)
            {
                for(int i=0;i<Sentence.Length;i++)
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
        if (LettersLeft == 0)
            Debug.Log("Good job lil bro");
    }
}
