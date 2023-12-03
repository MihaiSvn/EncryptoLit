using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PutEncryption : MonoBehaviour
{
    private int[] Encryptions;
    [SerializeField] public int index;
    public TMP_Text EncryptionText;
    private void Start()
    {
          
    }
    void Update()
    {
        Encryptions = FindObjectOfType<EncryptingSentence>().EncryptedSentence;
        EncryptionText.SetText(Encryptions[index].ToString());
    }
}
