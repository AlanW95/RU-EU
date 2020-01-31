using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreFAChanges : MonoBehaviour
{
    public GameObject startPro, startAnti;

    public GameObject proSelections, antiSelections;

    public Button b1, b2, b3, b4, b5, b6, b7, b8, b9, b10,
                    b11, b12, b13, b14, b15, b16, b17, b18, b19, b20;

    public int proCounter = 3;
    public int antiCounter = 3;

    //Sending to Google Forms
    public InputField inputEmail, input1, input2, input3, input4, input5, input6;
    private string emailAnswer, pro1Answer, pro2Answer, pro3Answer, anti1Answer, anti2Answer, anti3Answer;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSePsS0tWnnfTRtuKWklz_2CnSjRCyjgnUv0pmZ94Vixmi4ISA/formResponse";

    // Start is called before the first frame update
    void Start() {
        startPro.SetActive(true);
        startAnti.SetActive(false);

        inputEmail.text = PlayerPrefs.GetString("PlayerEmail");
    }

    // Update is called once per frame
    void Update() {

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

    public void SocialPro() {
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
            startAnti.SetActive(true);
            proSelections.SetActive(false);
        }
    }

    public void EnvironmentPro() {
        if (proCounter == 2) {
            input1.text = "Environment";
            b2.interactable = false;
        }

        if (proCounter == 1) {
            input2.text = "Environment";
            b2.interactable = false;
        }

        if (proCounter == 0) {
            input3.text = "Environment";
            b2.interactable = false;
            //change scene too
            startAnti.SetActive(true);
            proSelections.SetActive(false);
        }
    }

    public void RightsAndResponsibilitiesPro() {
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
            startAnti.SetActive(true);
            proSelections.SetActive(false);
        }
    }

    public void SecurityPro() {
        if (proCounter == 2) {
            input1.text = "Security";
            b4.interactable = false;
        }

        if (proCounter == 1) {
            input2.text = "Security";
            b4.interactable = false;
        }

        if (proCounter == 0) {
            input3.text = "Security";
            b4.interactable = false;
            //change scene too
            startAnti.SetActive(true);
            proSelections.SetActive(false);
        }
    }

    public void EmotionalPro() {
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

    public void EconomyPro() {
        if (proCounter == 2) {
            input1.text = "Economy";
            b6.interactable = false;
        }

        if (proCounter == 1) {
            input2.text = "Economy";
            b6.interactable = false;
        }

        if (proCounter == 0) {
            input3.text = "Economy";
            b6.interactable = false;
            //change scene too
            startAnti.SetActive(true);
            proSelections.SetActive(false);
        }
    }

    public void PoliticalPro() {
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

    public void HistoricPro() {
        if (proCounter == 2) {
            input1.text = "Historic";
            b8.interactable = false;
        }

        if (proCounter == 1) {
            input2.text = "Historic";
            b8.interactable = false;
        }

        if (proCounter == 0) {
            input3.text = "Historic";
            b8.interactable = false;
            //change scene too
            startAnti.SetActive(true);
            proSelections.SetActive(false);
        }
    }

    public void CulturePro() {
        if (proCounter == 2) {
            input1.text = "Culture";
            b9.interactable = false;
        }

        if (proCounter == 1) {
            input2.text = "Culture";
            b9.interactable = false;
        }

        if (proCounter == 0) {
            input3.text = "Culture";
            b9.interactable = false;
            //change scene too
            startAnti.SetActive(true);
            proSelections.SetActive(false);
        }
    }

    public void GeographyPro() {
        if (proCounter == 2) {
            input1.text = "Geography";
            b10.interactable = false;
        }

        if (proCounter == 1) {
            input2.text = "Geography";
            b10.interactable = false;
        }

        if (proCounter == 0) {
            input3.text = "Geography";
            b10.interactable = false;
            //change scene too
            startAnti.SetActive(true);
            proSelections.SetActive(false);
        }
    }

    public void SocialAnti() {
        if (antiCounter == 2) {
            input4.text = "Social";
            b11.interactable = false;
        }

        if (antiCounter == 1) {
            input5.text = "Social";
            b11.interactable = false;
        }

        if (antiCounter == 0) {
            input6.text = "Social";
            b11.interactable = false;
            Send();
            //change scene too
            SceneManager.LoadScene("FinalAssignmentChanges");
        }
    }

    public void EnvironmentAnti() {
        if (antiCounter == 2) {
            input4.text = "Environment";
            b12.interactable = false;
        }

        if (antiCounter == 1) {
            input5.text = "Environment";
            b12.interactable = false;
        }

        if (antiCounter == 0) {
            input6.text = "Environment";
            b12.interactable = false;
            Send();
            //change scene too
            SceneManager.LoadScene("FinalAssignmentChanges");
        }
    }

    public void RightsAndResponsibilitiesAnti() {
        if (antiCounter == 2) {
            input4.text = "Rights & Responsibilities";
            b13.interactable = false;
        }

        if (antiCounter == 1) {
            input5.text = "Rights & Responsibilities";
            b13.interactable = false;
        }

        if (antiCounter == 0) {
            input6.text = "Rights & Responsibilities";
            b13.interactable = false;
            Send();
            //change scene too
            SceneManager.LoadScene("FinalAssignmentChanges");
        }
    }

    public void SecurityAnti() {
        if (antiCounter == 2) {
            input4.text = "Security";
            b14.interactable = false;
        }

        if (antiCounter == 1) {
            input5.text = "Security";
            b14.interactable = false;
        }

        if (antiCounter == 0) {
            input6.text = "Security";
            b14.interactable = false;
            Send();
            //change scene too
            SceneManager.LoadScene("FinalAssignmentChanges");
        }
    }

    public void EmotionalAnti() {
        if (antiCounter == 2) {
            input4.text = "Emotional";
            b15.interactable = false;
        }

        if (antiCounter == 1) {
            input5.text = "Emotional";
            b15.interactable = false;
        }

        if (antiCounter == 0) {
            input6.text = "Emotional";
            b15.interactable = false;
            Send();
            //change scene too
            SceneManager.LoadScene("FinalAssignmentChanges");
        }
    }

    public void EconomyAnti() {
        if (antiCounter == 2) {
            input4.text = "Economy";
            b16.interactable = false;
        }

        if (antiCounter == 1) {
            input5.text = "Economy";
            b16.interactable = false;
        }

        if (antiCounter == 0) {
            input6.text = "Economy";
            b16.interactable = false;
            Send();
            //change scene too
            SceneManager.LoadScene("FinalAssignmentChanges");
        }
    }

    public void PoliticalAnti() {
        if (antiCounter == 2) {
            input4.text = "Political";
            b17.interactable = false;
        }

        if (antiCounter == 1) {
            input5.text = "Political";
            b17.interactable = false;
        }

        if (antiCounter == 0) {
            input6.text = "Political";
            b17.interactable = false;
            Send();
            //change scene too
            SceneManager.LoadScene("FinalAssignmentChanges");
        }
    }

    public void HistoricAnti() {
        if (antiCounter == 2) {
            input4.text = "Historic";
            b18.interactable = false;
        }

        if (antiCounter == 1) {
            input5.text = "Historic";
            b18.interactable = false;
        }

        if (antiCounter == 0) {
            input6.text = "Historic";
            b18.interactable = false;
            Send();
            //change scene too
            SceneManager.LoadScene("FinalAssignmentChanges");
        }
    }

    public void CultureAnti() {
        if (antiCounter == 2) {
            input4.text = "Culture";
            b19.interactable = false;
        }

        if (antiCounter == 1) {
            input5.text = "Culture";
            b19.interactable = false;
        }

        if (antiCounter == 0) {
            input6.text = "Culture";
            b19.interactable = false;
            Send();
            //change scene too
            SceneManager.LoadScene("FinalAssignmentChanges");
        }
    }

    public void GeographyAnti() {
        if (antiCounter == 2) {
            input4.text = "Geography";
            b20.interactable = false;
        }

        if (antiCounter == 1) {
            input5.text = "Geography";
            b20.interactable = false;
        }

        if (antiCounter == 0) {
            input6.text = "Geography";
            b20.interactable = false;
            Send();
            //change scene too
            SceneManager.LoadScene("FinalAssignmentChanges");
        }
    }

    IEnumerator Post(string emailAnswer, string pro1, string pro2, string pro3, string anti1, string anti2, string anti3) {
        WWWForm form = new WWWForm();

        form.AddField("entry.1306806779", emailAnswer);
        form.AddField("entry.956819071", pro1);
        form.AddField("entry.1636901816", pro2);
        form.AddField("entry.1220037643", pro3);
        form.AddField("entry.1622194484", anti1);
        form.AddField("entry.1380279665", anti2);
        form.AddField("entry.1262065382", anti3);

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

        StartCoroutine(Post(emailAnswer, pro1Answer, pro2Answer, pro3Answer, anti1Answer, anti2Answer, anti3Answer));
    }
}
