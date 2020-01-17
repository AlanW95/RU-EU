using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AttitudesPreFA : MonoBehaviour
{
    public GameObject startPro, startAnti;

    public GameObject proSelections, antiSelections;

    public Button b1, b2, b3, b4, b5, b6, b7, b8,
                    b9, b10, b11, b12, b13, b14, b15, b16;

    public int proCounter = 3;
    public int antiCounter = 3;

    //Sending to Google Forms
    public InputField inputEmail, input1, input2, input3, input4, input5, input6;
    private string emailAnswer, pro1Answer, pro2Answer, pro3Answer, anti1Answer, anti2Answer, anti3Answer;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdGGNZDNr436pIEYnxKJEwKR_tYzp0b3L6LW7lv79a3pc75bw/formResponse";
    
    // Start is called before the first frame update
    void Start()
    {
        startPro.SetActive(true);
        startAnti.SetActive(false);

        inputEmail.text = PlayerPrefs.GetString("PlayerEmail");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProStart() {
        proSelections.SetActive(true);
        startPro.SetActive(false);
    }

    public void AntiStart() {
        antiSelections.SetActive(true);
        startAnti.SetActive(false);
    }

    public void ProCounterDown() {
        proCounter--;
    }

    public void AntiCounterDown() {
        antiCounter--;
    }

    public void Theme1Pro() {
        if (proCounter == 2) {
            input1.text = "Social";
            b1.interactable = false;
        }

        if (proCounter == 1) {
            input2.text = "Social";
            b1.interactable = false;
        }

        if (proCounter == 0) {
            input3.text = "Social";
            b1.interactable = false;
            //change scene too
            //always set true first then other to false next
            startAnti.SetActive(true);
            proSelections.SetActive(false);
        }
    }

    public void Theme2Pro() {
        if (proCounter == 2) {
            input1.text = "Safety & Security";
            b2.interactable = false;
        }

        if (proCounter == 1) {
            input2.text = "Safety & Security";
            b2.interactable = false;
        }

        if (proCounter == 0) {
            input3.text = "Safety & Security";
            b2.interactable = false;
            //change scene too
            //always set true first then remove other to false next
            startAnti.SetActive(true);
            proSelections.SetActive(false);
        }
    }

    public void Theme3Pro() {
        if (proCounter == 2) {
            input1.text = "Rights & Responsibilities";
            b3.interactable = false;
        }

        if (proCounter == 1) {
            input2.text = "Rights & Responsibilities";
            b3.interactable = false;
        }

        if (proCounter == 0) {
            input3.text = "Rights & Responsibilities";
            b3.interactable = false;
            //change scene too
            //always set true first then remove other to false next
            startAnti.SetActive(true);
            proSelections.SetActive(false);
        }
    }

    public void Theme4Pro() {
        if (proCounter == 2) {
            input1.text = "Economic";
            b4.interactable = false;
        }

        if (proCounter == 1) {
            input2.text = "Economic";
            b4.interactable = false;
        }

        if (proCounter == 0) {
            input3.text = "Economic";
            b4.interactable = false;
            //change scene too
            startAnti.SetActive(true);
            proSelections.SetActive(false);
        }
    }

    public void Theme5Pro() {
        if (proCounter == 2) {
            input1.text = "Emotional";
            b5.interactable = false;
        }

        if (proCounter == 1) {
            input2.text = "Emotional";
            b5.interactable = false;
        }

        if (proCounter == 0) {
            input3.text = "Emotional";
            b5.interactable = false;
            //change scene too
            startAnti.SetActive(true);
            proSelections.SetActive(false);
        }
    }

    public void Theme6Pro() {
        if (proCounter == 2) {
            input1.text = "Historic";
            b6.interactable = false;
        }

        if (proCounter == 1) {
            input2.text = "Historic";
            b6.interactable = false;
        }

        if (proCounter == 0) {
            input3.text = "Historic";
            b6.interactable = false;
            //change scene too
            startAnti.SetActive(true);
            proSelections.SetActive(false);
        }
    }

    public void Theme7Pro() {
        if (proCounter == 2) {
            input1.text = "Political";
            b7.interactable = false;
        }

        if (proCounter == 1) {
            input2.text = "Political";
            b7.interactable = false;
        }

        if (proCounter == 0) {
            input3.text = "Political";
            b7.interactable = false;
            //change scene too
            startAnti.SetActive(true);
            proSelections.SetActive(false);
        }
    }

    public void Theme8Pro() {
        if (proCounter == 2) {
            input1.text = "Culture";
            b8.interactable = false;
        }

        if (proCounter == 1) {
            input2.text = "Culture";
            b8.interactable = false;
        }

        if (proCounter == 0) {
            input3.text = "Culture";
            b8.interactable = false;
            //change scene too
            startAnti.SetActive(true);
            proSelections.SetActive(false);
        }
    }

    //-----------------ANTI------------------

    public void Theme1Anti() {
        if (antiCounter == 2) {
            input4.text = "Social";
            b9.interactable = false;
        }

        if (antiCounter == 1) {
            input5.text = "Social";
            b9.interactable = false;
        }

        if (antiCounter == 0) {
            input6.text = "Social";
            b9.interactable = false;
            //change scene too and send data
            Send();
            SceneManager.LoadScene("FinalAssignmentAttitudes");
        }
    }

    public void Theme2Anti() {
        if (antiCounter == 2) {
            input4.text = "Safety & Security";
            b10.interactable = false;
        }

        if (antiCounter == 1) {
            input5.text = "Safety & Security";
            b10.interactable = false;
        }

        if (antiCounter == 0) {
            input6.text = "Safety & Security";
            b10.interactable = false;
            //change scene too and send data
            Send();
            SceneManager.LoadScene("FinalAssignmentAttitudes");
        }
    }

    public void Theme3Anti() {
        if (antiCounter == 2) {
            input4.text = "Rights & Responsibilities";
            b11.interactable = false;
        }

        if (antiCounter == 1) {
            input5.text = "Rights & Responsibilities";
            b11.interactable = false;
        }

        if (antiCounter == 0) {
            input6.text = "Rights & Responsibilities";
            b11.interactable = false;
            //change scene too and send data
            Send();
            SceneManager.LoadScene("FinalAssignmentAttitudes");
        }
    }

    public void Theme4Anti() {
        if (antiCounter == 2) {
            input4.text = "Economic";
            b12.interactable = false;
        }

        if (antiCounter == 1) {
            input5.text = "Economic";
            b12.interactable = false;
        }

        if (antiCounter == 0) {
            input6.text = "Economic";
            b12.interactable = false;
            //change scene too and send data
            Send();
            SceneManager.LoadScene("FinalAssignmentAttitudes");
        }
    }

    public void Theme5Anti() {
        if (antiCounter == 2) {
            input4.text = "Emotional";
            b13.interactable = false;
        }

        if (antiCounter == 1) {
            input5.text = "Emotional";
            b13.interactable = false;
        }

        if (antiCounter == 0) {
            input6.text = "Emotional";
            b13.interactable = false;
            //change scene too and send data
            Send();
            SceneManager.LoadScene("FinalAssignmentAttitudes");
        }
    }

    public void Theme6Anti() {
        if (antiCounter == 2) {
            input4.text = "Historic";
            b14.interactable = false;
        }

        if (antiCounter == 1) {
            input5.text = "Historic";
            b14.interactable = false;
        }

        if (antiCounter == 0) {
            input6.text = "Historic";
            b14.interactable = false;
            //change scene too and send data
            Send();
            SceneManager.LoadScene("FinalAssignmentAttitudes");
        }
    }

    public void Theme7Anti() {
        if (antiCounter == 2) {
            input4.text = "Political";
            b15.interactable = false;
        }

        if (antiCounter == 1) {
            input5.text = "Political";
            b15.interactable = false;
        }

        if (antiCounter == 0) {
            input6.text = "Political";
            b15.interactable = false;
            //change scene too and send data
            Send();
            SceneManager.LoadScene("FinalAssignmentAttitudes");
        }
    }

    public void Theme8Anti() {
        if (antiCounter == 2) {
            input4.text = "Culture";
            b16.interactable = false;
        }

        if (antiCounter == 1) {
            input5.text = "Culture";
            b16.interactable = false;
        }

        if (antiCounter == 0) {
            input6.text = "Culture";
            b16.interactable = false;
            //change scene too and send data
            Send();
            SceneManager.LoadScene("FinalAssignmentAttitudes");
        }
    }

    IEnumerator Post(string emailAnswer, string pro1, string pro2, string pro3, string anti1, string anti2, string anti3) {
        WWWForm form = new WWWForm();

        form.AddField("entry.1965455641", emailAnswer);
        form.AddField("entry.2117653514", pro1);
        form.AddField("entry.455605766", pro2);
        form.AddField("entry.201894361", pro3);
        form.AddField("entry.668132892", anti1);
        form.AddField("entry.1097623431", anti2);
        form.AddField("entry.947707503", anti3);

        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);

        yield return www;
    }

    public void Send() {
        emailAnswer = inputEmail.GetComponent<InputField>().text;
        Debug.Log(emailAnswer);

        pro1Answer = input1.GetComponent<InputField>().text;
        Debug.Log(pro1Answer);

        pro2Answer = input2.GetComponent<InputField>().text;
        Debug.Log(pro2Answer);

        pro3Answer = input3.GetComponent<InputField>().text;
        Debug.Log(pro3Answer);

        anti1Answer = input4.GetComponent<InputField>().text;
        Debug.Log(anti1Answer);

        anti2Answer = input5.GetComponent<InputField>().text;
        Debug.Log(anti2Answer);

        anti3Answer = input6.GetComponent<InputField>().text;
        Debug.Log(anti3Answer);

        Debug.Log("All data for Attitudes Pre-Final Assignment has been sent");

        StartCoroutine(Post(emailAnswer, pro1Answer, pro2Answer, pro3Answer, anti1Answer, anti2Answer, anti3Answer));
    }
}
