using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeInSprites : MonoBehaviour
{
    private bool FadeBool;
    void Start()
    {

        //change alpha to zero to make it transparent
        Color tmp = this.GetComponent<SpriteRenderer>().color;     
        tmp.a = 0f;
        this.GetComponent<SpriteRenderer>().color = tmp;
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
        
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        float alphaVal = this.GetComponent<SpriteRenderer>().color.a;
        Color tmp = this.GetComponent<SpriteRenderer>().color;
        this.gameObject.SetActive(true);
        while (this.GetComponent<SpriteRenderer>().color.a < 1)
        {
            alphaVal += 0.01f;
            tmp.a = alphaVal;
            this.GetComponent<SpriteRenderer>().color = tmp;

            yield return new WaitForSeconds(0.01f); // update interval
        }
        
    }
}
