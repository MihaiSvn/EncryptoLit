using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VerifyLetterInput : MonoBehaviour
{
    public string input;
    private char[] InputChar;
    public GameObject inputField;
    public GameObject inputField2;
    private string inputText;
    public GameObject Encryption;
    private string EncryptionText;
    [HideInInspector] public float delayTime = 0.3f;
    private int[] FrecvCodesArray;
    private int[] EncryptedSentence;
    private static string Sentence;
    private EncryptingSentence DelEncr;



    private int[] ASCIICodes = new int[256];
    void Start()
    {
       FrecvCodesArray = FindObjectOfType<EncryptingSentence>().FrecvCodesArray;
       EncryptedSentence = FindObjectOfType<EncryptingSentence>().EncryptedSentence;
       Sentence = EncryptingSentence.Sentence;
        DelEncr = FindObjectOfType<EncryptingSentence>();

    }

    // Update is called once per frame
    public void ReadStringInput(string s)
    {
        input = s;

        Debug.Log(input);

        EncryptionText = Encryption.GetComponent<TMP_Text>().text;
        ASCIICodes = FindObjectOfType<EncryptingSentence>().ASCIICodeArray;
        int Encryptionint = int.Parse(EncryptionText);
 
        Debug.Log(Encryptionint);
        Debug.Log(ASCIICodes[input[0] - 'A' + 'a']);
        Debug.Log(input[0]);

        if (ASCIICodes[input[0] - 'A' + 'a'] == Encryptionint)
        {
            Debug.Log("Correct");
            StartCoroutine(RightLetter());
            DelEncr.DeleteEncryption(Encryptionint);
            FindObjectOfType<EncryptingSentence>().LettersLeft--;

            //what to do if correct
        }
        else
        {
            Debug.Log("Loser");
            StartCoroutine(WrongLetter());
            FindObjectOfType<MistakesManagement>().mistakes++;



            //what to do if wrong
        }







    }
    private IEnumerator WrongLetter()
    {
        float counter = 0f;
        float time = delayTime;

        //Get Original Pos and rot
        Transform objTransform = this.transform;
        Vector3 defaultPos = objTransform.position;
        Quaternion defaultRot = objTransform.rotation;

        //Shake Speed
        const float speed = 0.001f;

        //Angle Rotation
        const float angleRot = 20f;

        //Do the actual shaking 
        while (counter <= time)
        {
            counter += Time.deltaTime;
            inputField.GetComponent<TMP_Text>().color = Color.red;
            inputField2.GetComponent<TMP_InputField>().interactable = false;

            //Shake GameObject

            float decreaseSpeed = speed;
            float decreaseAngle = angleRot;

            Vector3 tempPos = defaultPos + UnityEngine.Random.insideUnitSphere * decreaseSpeed;
            tempPos.z = defaultPos.z;
            objTransform.position = tempPos;
            objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-angleRot, angleRot), new Vector3(0f, 0f, 1f));
            
            yield return null;

            //Check if we have reached the decreasePoint then start decreasing  decreaseSpeed value

            float decreasePoint = 3f;
            if (counter >= decreasePoint)
            {
                Debug.Log("Decreasing shake");

                //Reset counter to 0 
                counter = 0f;
                while (counter <= decreasePoint)
                {

                    //Shake GameObject
                    counter += Time.deltaTime;
                    decreaseSpeed = Mathf.Lerp(speed, 0, counter / decreasePoint);
                    decreaseAngle = Mathf.Lerp(angleRot, 0, counter / decreasePoint);

                        //Don't Translate the Z Axis if 2D Object
                        tempPos = defaultPos + UnityEngine.Random.insideUnitSphere * decreaseSpeed;
                        tempPos.z = defaultPos.z;
                        objTransform.position = tempPos;

                        //Only Rotate the Z axis if 2D
                        objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-decreaseAngle, decreaseAngle), new Vector3(0f, 0f, 1f));
                   
                    yield return null;
                }

                //Break from the outer loop
                break;
            }

        }

        objTransform.position = defaultPos; //Reset to original postion
        objTransform.rotation = defaultRot;//Reset to original rotation

        inputField2.GetComponent<TMP_InputField>().interactable = true;
        inputField.GetComponent<TMP_Text>().color = Color.black;
        inputField2.GetComponent<TMP_InputField>().text = string.Empty;
        

    }
    private IEnumerator RightLetter()
    {
        float counter = 0f;
        float time = delayTime;
        while(counter<=delayTime)
        {
            counter+= Time.deltaTime;
            inputField.GetComponent<TMP_Text>().color = Color.green;
            inputField2.GetComponent<TMP_InputField>().interactable = false;
            yield return null;
        }
        inputField.GetComponent<TMP_Text>().color = Color.black;
    }
}
