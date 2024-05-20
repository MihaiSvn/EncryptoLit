using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    /* public void DifGuesser()
     {
         SceneManager.LoadScene(1);
     }
     public void Quoter()
     {
         SceneManager.LoadScene(2);
     }*/
    public void Quit()
    {
        Application.Quit();
    }


}
