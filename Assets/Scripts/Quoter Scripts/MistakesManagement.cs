using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MistakesManagement : MonoBehaviour
{
    public int mistakes;
    private int LastMistakes;
    public GameObject Health;
    private float delayTimeForReset;
    // Start is called before the first frame update
    void Start()
    {
        mistakes= 0;
        LastMistakes= 0;
        delayTimeForReset = FindObjectOfType<UnknownTile>().delayTime;
        delayTimeForReset += 0.5f;
    }

    void Update()
    {
        if(mistakes != LastMistakes)     //since update is called once per frame, LastMistakes is used to check if mistakes changed
        {
            GameObject HealthGameObject = Health.gameObject.transform.GetChild(mistakes - 1).gameObject;
            HealthGameObject.GetComponent<Image>().color = Color.red;
            LastMistakes = mistakes;
        }
        if (mistakes == 3)
        {
            StartCoroutine(WaitAndReset());
            
        }
            

    }
    private IEnumerator WaitAndReset()   //reset scene if you lose
    {
        yield return new WaitForSeconds(delayTimeForReset);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
