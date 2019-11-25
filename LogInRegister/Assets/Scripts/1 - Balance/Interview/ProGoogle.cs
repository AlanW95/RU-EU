using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProGoogle : MonoBehaviour {
    
    //Collecting Data through Google Forms
    public InputField inputEmail, input1, input2, input3;
    private string emailAnswer, selection1Answer, selection2Answer, selection3Answer;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSeRkxP5ZCsqPnWQbTLHudiOcRjW21pyAdkV-flT31XniuS9hw/formResponse";

    void Start() {
        emailAnswer = PlayerPrefs.GetString("PlayerEmail");
    }

    void Update() {
            
    }


    IEnumerator Post(string emailAnswer, string selection1, string selection2, string selection3) {
        WWWForm form = new WWWForm();

        form.AddField("entry.73471519", emailAnswer);
        form.AddField("entry.1263600930", selection1);
        form.AddField("entry.1537282767", selection2);
        form.AddField("entry.36802520", selection3);

        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);

        yield return www;
    }

    public void Send() {
        emailAnswer = PlayerPrefs.GetString("PlayerEmail");
        //emailAnswer = inputEmail.GetComponent<InputField>().text;
        Debug.Log(emailAnswer);

        selection1Answer = input1.GetComponent<InputField>().text;
        Debug.Log(selection1Answer);

        selection2Answer = input2.GetComponent<InputField>().text;
        Debug.Log(selection2Answer);

        selection3Answer = input3.GetComponent<InputField>().text;
        Debug.Log(selection3Answer);

        Debug.Log("Process all themes selected and sending to Google");

        StartCoroutine(Post(emailAnswer, selection1Answer, selection2Answer, selection3Answer));
    }
}
