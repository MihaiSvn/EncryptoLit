using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class LevelLoad : MonoBehaviour
{
    private string Level;
    [SerializeField] private int LevelID;
 
    public void Start()
    {
        Level = this.gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text;
        LevelID = int.Parse(Level);
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(LevelID);
    }
}
