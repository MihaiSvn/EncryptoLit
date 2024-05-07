using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public bool FadeBool;
    void Start()
    {
        
        FadeBool = FindObjectOfType<EncryptingSentence>().FadeBool;
    }

    // Update is called once per frame
    void Update()
    {
        if(FadeBool)
            StartCoroutine("FadeAnimation");
    }
    private IEnumerator FadeAnimation()
    {
        
        float alphaVal = this.GetComponent<SpriteRenderer>().color.a;
        Color tmp = this.GetComponent<SpriteRenderer>().color;
        tmp.a = 0f;
        this.GetComponent<SpriteRenderer>().color = tmp;
        this.gameObject.SetActive(true);
        while (this.GetComponent<SpriteRenderer>().color.a < 1)
        {
            alphaVal += 0.01f;
            tmp.a = alphaVal;
            this.GetComponent<SpriteRenderer>().color = tmp;

            yield return new WaitForSeconds(0.03f); // update interval
        }
    }
}
