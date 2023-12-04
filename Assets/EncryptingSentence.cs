using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EncryptingSentence : MonoBehaviour
{
    [SerializeField] public static string Sentence = "lifeislikeridingabicycletokeepyourbalanceyoumustkeepmoving";
    //private static int SentenceLength = Sentence.Length;
    [HideInInspector] public int[] ASCIICodeArray= new int[256]; 
    private int[] FrecvCodesArray= new int[256];
    [HideInInspector] public int[] EncryptedSentence= new int[256];
    private GameObject Encryption;
    private TMP_Text EncrpytionText;
    private void Start()
    {
        for(int i=0 ; i < Sentence.Length ; i++)
        {
            if (ASCIICodeArray[Sentence[i]]==0)
            {
                int nrrand;
                do
                {
                    nrrand = Random.Range(1, 27);
                } while (FrecvCodesArray[nrrand]!=0);
                ASCIICodeArray[Sentence[i]] = nrrand;
                EncryptedSentence[i] = ASCIICodeArray[Sentence[i]];
                FrecvCodesArray[nrrand] = 1;

            }
            else EncryptedSentence[i] = ASCIICodeArray[Sentence[i]];

        }
        for (int i = 0; i < Sentence.Length; i++)
        {
            Encryption = this.gameObject.transform.GetChild(i).GetChild(1).gameObject;
            EncrpytionText = Encryption.GetComponent<TMP_Text>();
            EncrpytionText.SetText(EncryptedSentence[i].ToString());

        }
        

        
       /* for(int i=0; i< Sentence.Length;i++)
        { Debug.Log(EncryptedSentence[i]);}*/
    }
}
