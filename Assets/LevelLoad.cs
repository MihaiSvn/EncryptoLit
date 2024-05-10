using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class LevelLoad : MonoBehaviour
{
    private TextMeshPro Level;
    private TMP_Text LevelText;
    private string LevelString;
    [SerializeField] private int LevelID;
 
    public void Start()
    {
        Level = this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        LevelText = Level.GetComponent<TMP_Text>();
        LevelString = LevelText.text;
        LevelID = int.Parse(LevelString);
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(LevelID);
    }
}
