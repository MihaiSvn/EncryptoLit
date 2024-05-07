using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeInTMP : MonoBehaviour
{
    private bool FadeBool;
    void Start()
    {

           //change alpha to zero to make it transparent
        Color tmp = this.GetComponent<TMP_Text>().color;
        tmp.a = 0f;
        this.GetComponent<TMP_Text>().color = tmp;
    }

    // Update is called once per frame
    void Update()
    {
        FadeBool = FindObjectOfType<EncryptingSentence>().FadeBool;
        if (FadeBool)
            StartCoroutine("FadeAnimation");
        
            
    }
    private IEnumerator FadeAnimation()
    {
      
        this.gameObject.GetComponent<TMP_Text>().enabled = true;
        float alphaVal = this.GetComponent<TMP_Text>().color.a;
        Color tmp = this.GetComponent<TMP_Text>().color;
        this.gameObject.SetActive(true);
        while (this.GetComponent<TMP_Text>().color.a < 1)
        {
            alphaVal += 0.01f;
            tmp.a = alphaVal;
            this.GetComponent<TMP_Text>().color = tmp;

            yield return new WaitForSeconds(0.01f); // update interval
        }
        
    }
}
