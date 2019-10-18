using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PostQuestions : MonoBehaviour
{
    public GameObject welcomeCanvas, set2QuestionCanvas, set3QuestionCanvas, set4QuestionCanvas, set5QuestionCanvas, set6QuestionCanvas, questionsCanvas, finishCanvas;

    public GameObject questionCounter;

    public TextMeshProUGUI counterText;
    public TextMeshProUGUI welcomeText, finishedText;

    public GameObject emailgo, q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11, q12;

    //Question Text
    //public TextMeshProUGUI questions;

    //Answer Text
    //public GameObject answer3, answer4, answer5, answer6, inputField;

    public TMP_InputField inputEmail;
    public InputField input1, input2, input3, input4, input5, input6, input7, input8, input9, input10, input11, input12;

    //public TMP_InputField q3Input, q4Input, q5Input, q6Input;

    //public TMP_InputField otherInputField;
    //public TextMeshProUGUI a1, a2, a3, a4, a5, a6;

    public GameObject email, one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve;

    private string emailAnswer, q1Answer, q2Answer, q3Answer, q4Answer, q5Answer, q6Answer, q7Answer, q8Answer, q9Answer,
                    q10Answer, q11Answer, q12Answer;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLScKbmpsu9MRM6-XxGEa40Sj2IHXIK5cVWLG5esComlNN9H0vQ/formResponse";

    public static int counter = 0;

    // Start is called before the first frame update
    void Start() {
        welcomeCanvas.SetActive(true);

        questionsCanvas.SetActive(false);

        set2QuestionCanvas.SetActive(false);
        set3QuestionCanvas.SetActive(false);
        set4QuestionCanvas.SetActive(false);
        set5QuestionCanvas.SetActive(false);
        set6QuestionCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

        /*if (counter == 0) {
            Question1();
        }*/

        if (counter == 1) {
            Question2();
        }

        if (counter == 2) {
            Set3Questions();
        }

        if (counter == 3) {
            Question3();
        }

        if (counter == 4) {
            Question4();
        }

        if (counter == 5) {
            Question5();
        }

        if (counter == 6) {
            Set4Questions();
        }

        if (counter == 7) {
            Question6();
        }

        if (counter == 8) {
            Question7();
        }

        if (counter == 9) {
            Question8();
        }

        if (counter == 10) {
            Set5Questions();
        }

        if (counter == 11) {
            Question9();
        }

        if (counter == 12) {
            Question10();
        }

        if (counter == 13) {
            Set6Questions();
        }

        if (counter == 14) {
            Question11();
        }

        if (counter == 15) {
            Question12();
        }

        if (counter == 16) {
            FinishedCanvas();
        }
    }

    public void CounterUp() {
        counter++;
    }

    public void WelcomeCanvas() {
        welcomeText.text = "So first of all here are some basic questions about yourself.";
    }

    public void LoadEndScreen() {
        SceneManager.LoadScene("ThankYou");
    }

    public void EnterEmail() {
        welcomeCanvas.SetActive(false);
        questionsCanvas.SetActive(true);

        questionCounter.SetActive(false);

        emailgo.SetActive(true);
    }

    

    public void Set2Questions() {
        emailgo.SetActive(false);
        questionCounter.SetActive(true);

        set2QuestionCanvas.SetActive(true);
    }

    public void Question1() {
        Destroy(set2QuestionCanvas);

        counterText.text = "1 / 12";

        q1.SetActive(true);
    }

    public void Question2() {
        counterText.text = "2 / 12";

        q1.SetActive(false);
        q2.SetActive(true);
    }

    public void Set3Questions() {
        set3QuestionCanvas.SetActive(true);
    }

    public void Question3() {
        Destroy(set3QuestionCanvas);

        counterText.text = "3 / 12";

        q2.SetActive(false);
        q3.SetActive(true);
    }

    public void Question4() {
        counterText.text = "4 / 12";

        q3.SetActive(false);
        q4.SetActive(true);
    }

    public void Question5() {
        counterText.text = "5 / 12";

        q4.SetActive(false);
        q5.SetActive(true);
    }

    public void Set4Questions() {
        set4QuestionCanvas.SetActive(true);
    }

    public void Question6() {
        Destroy(set4QuestionCanvas);

        counterText.text = "6 / 12";

        q5.SetActive(false);
        q6.SetActive(true);
    }

    public void Question7() {
        counterText.text = "7 / 12";

        q6.SetActive(false);
        q7.SetActive(true);
    }

    public void Question8() {
        counterText.text = "8 / 12";

        q7.SetActive(false);
        q8.SetActive(true);
    }

    public void Set5Questions() {
        set5QuestionCanvas.SetActive(true);
    }

    public void Question9() {
        Destroy(set5QuestionCanvas);

        counterText.text = "9 / 12";

        q8.SetActive(false);
        q9.SetActive(true);
    }

    public void Question10() {
        counterText.text = "10 / 12";

        q9.SetActive(false);
        q10.SetActive(true);
    }

    public void Set6Questions() {
        set6QuestionCanvas.SetActive(true);
    }

    public void Question11() {
        Destroy(set6QuestionCanvas);

        counterText.text = "11 / 12";

        q10.SetActive(false);
        q11.SetActive(true);
    }

    public void Question12() {
        counterText.text = "12 / 12";

        q11.SetActive(false);
        q12.SetActive(true);
    }

    public void FinishedCanvas() {
        questionsCanvas.SetActive(false);
        finishCanvas.SetActive(true);
        finishedText.text = "Thank you very much. We will ask you the same questions after you have played the game.";
    }

    IEnumerator Post(string emailAnswer, string q1Answer, string q2Answer, string q3Answer, string q4Answer, string q5Answer, string q6Answer, string q7Answer,
                    string q8Answer, string q9Answer, string q10Answer, string q11Answer, string q12Answer) {

        WWWForm form = new WWWForm();

        form.AddField("entry.256827944", emailAnswer);
        form.AddField("entry.1910940254", q1Answer);
        form.AddField("entry.2006394398", q2Answer);
        form.AddField("entry.2033645187", q3Answer);
        form.AddField("entry.1063855103", q4Answer);
        form.AddField("entry.229185954", q5Answer);
        form.AddField("entry.679286435", q6Answer);
        form.AddField("entry.1294473665", q7Answer);
        form.AddField("entry.1355500608", q8Answer);
        form.AddField("entry.1685660916", q9Answer);
        form.AddField("entry.579330320", q10Answer);
        form.AddField("entry.540947686", q11Answer);
        form.AddField("entry.1684224458", q12Answer);

        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);

        yield return www;
    }

    public void Send() {
        emailAnswer = inputEmail.GetComponent<TMP_InputField>().text;
        q1Answer = input1.GetComponent<InputField>().text;
        q2Answer = input2.GetComponent<InputField>().text;
        q3Answer = input3.GetComponent<InputField>().text;
        q4Answer = input4.GetComponent<InputField>().text;
        q5Answer = input5.GetComponent<InputField>().text;
        q6Answer = input6.GetComponent<InputField>().text;
        q7Answer = input7.GetComponent<InputField>().text;
        q8Answer = input8.GetComponent<InputField>().text;
        q9Answer = input9.GetComponent<InputField>().text;
        q10Answer = input10.GetComponent<InputField>().text;
        q11Answer = input11.GetComponent<InputField>().text;
        q12Answer = input12.GetComponent<InputField>().text;

        StartCoroutine(Post(emailAnswer, q1Answer, q2Answer, q3Answer, q4Answer, q5Answer, q6Answer, q7Answer, q8Answer, q9Answer, q10Answer, q11Answer, q12Answer));
    }

    /*
     * This displays each of the ages that will be selected 
    */
    /*public void Q1A1() {
        //age 18-23 selected
        input1.text = "18-23";
    }

    public void Q1A2() {
        //age 24-29 selected
        input1.text = "24-29";
    }

    public void Q1A3() {
        //age 30-35 selected
        input1.text = "30-35";
    }

    public void Q1A4() {
        // age 36+ selected
        input1.text = "36+";
    }

    public void Q2A1() {
        //male selected
        input2.text = "Male";
    }

    public void Q2A2() {
        //female selected
        input2.text = "Female";
    }

    public void Q2A3() {
        //prefer not to say selected
        input2.text = "Prefer not to say";
    }

    public void Q3A1() {
        //British selected
        input3.text = "British";
    }

    public void Q3A2() {
        //German selected
        input3.text = "German";
    }

    public void Q3A3() {
        //Dutch selected
        input3.text = "Dutch";
    }

    public void Q3A4() {
        //Croatian selected
        input3.text = "Croatian";
    }

    public void Q3A5() {
        //Greek selected
        input3.text = "Greek";
    }

    public void Q3A6() {
        //question 3 national identity other typed in input field 
        // this should be referenced as the box available for the question
    }

    public void Q4A1() {
        //UK selected
        input4.text = "UK";
    }

    public void Q4A2() {
        //Germany selected
        input4.text = "Germany";
    }

    public void Q4A3() {
        //Holland selected
        input4.text = "Holland";
    }

    public void Q4A4() {
        //Croatia selected
        input4.text = "Croatia";
    }

    public void Q4A5() {
        //Greece selected
        input4.text = "Greece";
    }

    public void Q4A6() {
        //Other, please specify selected for Question 4 on Country of Residence
        // this should be referenced as the box available for the question
    }

    public void Q5A1() {
        //Social Sceience selected
        input5.text = "Social Science";
    }

    public void Q5A2() {
        //Business selected
        input5.text = "Business";
    }

    public void Q5A3() {
        //Computing selected
        input5.text = "Computing";
    }

    public void Q5A4() {
        //Other, please specify selected for Question 5 on area of study
        // this should be referenced as the box available for the question
    }

    public void Q6A1() {
        //University Education selected
        input6.text = "University Education";
    }

    public void Q6A2() {
        //Secondary School selected
        input6.text = "Secondary School";
    }

    public void Q6A3() {
        //Other, please specify selected for Question 6 on previously completed level of education
        // this should be referenced as the box available for the question
    }

    public void Q7A1() {
        //Working Fulltime selected
        input7.text = "Working fulltime";
    }

    public void Q7A2() {
        //Working Part Time selected
        input7.text = "Working part time";
    }

    public void Q7A3() {
        //Unemployed selected
        input7.text = "Unemployed";
    }

    public void Q7A4() {
        //Retired selected
        input7.text = "Retired";
    }*/

    public void Q1A1() {
        //the locality or town where you live was selected for Question 8
        input1.text = "The locality or town where you live";
    }

    public void Q1A2() {
        //the region or country where you live was selected for Question 8
        input1.text = "The region or country where you live";
    }

    public void Q1A3() {
        //your country as a whole was selected for Question 8
        input1.text = "Your country as a whole";
    }

    public void Q1A4() {
        //Europe was selected for Question 8
        input1.text = "Europe";
    }

    public void Q1A5() {
        //Don't know was selected for Question 8
        input1.text = "Don't know";
    }

    public void Q2A1() {
        //the locality or town where you live was selected for Question 9
        input2.text = "The locality or town where you live";
    }

    public void Q2A2() {
        //the region or country where you live was selected for Question 9
        input2.text = "The region or country where you live";
    }

    public void Q2A3() {
        //your country as a whole was selected for Question 9
        input2.text = "Your country as a whole";
    }

    public void Q2A4() {
        //Europe was selected for Question 9
        input2.text = "Europe";
    }

    public void Q2A5() {
        //Don't know was selected for Question 9
        input2.text = "Don't know";
    }

    public void Q3A1() {
        //Yes, a lot was selected
        input3.text = "Yes, a lot";
    }

    public void Q3A2() {
        //Yes, somewhat was selected
        input3.text = "Yes, somewhat";
    }

    public void Q3A3() {
        //Not very much was selected
        input3.text = "Not very much";
    }

    public void Q3A4() {
        //Not at all was selected
        input3.text = "Not at all";
    }

    public void Q3A5() {
        //Don't know was selected for Question 10
        input3.text = "Don't know";
    }

    public void Q4A1() {
        //Often was selected for Question 11
        input4.text = "Often";
    }

    public void Q4A2() {
        //Sometimes was selected for Question 11
        input4.text = "Sometimes";
    }

    public void Q4A3() {
        //Never selected for Question 11
        input4.text = "Never";
    }

    public void Q4A4() {
        //Don't know selected for Question 11
        input4.text = "Don't know";
    }

    public void Q5A1() {
        //Often selected for Question 12
        input5.text = "Often";
    }

    public void Q5A2() {
        //Sometimes selected for Question 12
        input5.text = "Sometimes";
    }

    public void Q5A3() {
        //Never selected for Question 12
        input5.text = "Never";
    }

    public void Q5A4() {
        //Don't know selected for Question 12
        input5.text = "Don't know";
    }

    public void Q6A1() {
        //Very attached/ very close selected for Question 13
        input6.text = "Very attached/ very close";
    }

    public void Q6A2() {
        //Fairly attached/ fairly close selected for Question 13
        input6.text = "Fairly attached/ fairly close";
    }

    public void Q6A3() {
        //Not very attached/ not very close selected for Question 13
        input6.text = "Not very attached/ not very close";
    }

    public void Q6A4() {
        //Not at all attached/ not at all close selected for Question 13
        input6.text = "Not at all attached/ not at all close";
    }

    public void Q6A5() {
        //Don't know was selected for Question 13
        input6.text = "Don't know";
    }

    public void Q7A1() {
        //A great deal was selected for Question 14
        input7.text = "A great deal";
    }

    public void Q7A2() {
        //Somewhat was selected for Question 14
        input7.text = "Somewhat";
    }

    public void Q7A3() {
        //Not very much was selected for Question 14
        input7.text = "Not very much";
    }

    public void Q7A4() {
        //Not at all was selected for Question 14
        input7.text = "Not at all";
    }

    public void Q7A5() {
        //Don't know was selected for Question 14
        input7.text = "Don't know";
    }

    public void Q8A1() {
        //A great deal was selected for Question 15
        input8.text = "A great deal";
    }

    public void Q8A2() {
        //Somewhat was selected for Question 15
        input8.text = "Somewhat";
    }

    public void Q8A3() {
        //Not very much was selected for Question 15
        input8.text = "Not very much";
    }

    public void Q8A4() {
        //Not at all was selected for Question 15
        input8.text = "Not at all";
    }

    public void Q8A5() {
        //Don't know was selected for Question 15
        input8.text = "Don't know";
    }

    public void Q9A1() {
        //Very attached/ very close was selected for Question 16
        input9.text = "Very attached/ very close";
    }

    public void Q9A2() {
        //Fairly attached/ fairly close was selected to Question 16
        input9.text = "Fairly attached/ fairly close";
    }

    public void Q9A3() {
        //Not very attached/ not very close was selected for Question 16
        input9.text = "Not very attached/ not very close";
    }

    public void Q9A4() {
        //Not at all attached/ not at all close was selected for Question 16
        input9.text = "Not at all attached/ not at all close";
    }

    public void Q9A5() {
        //Don't know was selected for Question 16
        input9.text = "Don't know";
    }

    public void Q10A1() {
        //My nationality only was selected
        input10.text = "My nationality only";
    }

    public void Q10A2() {
        //More my own nationality than European was selected
        input10.text = "More my own nationality than European";
    }

    public void Q10A3() {
        //Equally my own nationality and European
        input10.text = "Equally my own nationality and European";
    }

    public void Q10A4() {
        //More European than my own nationality
        input10.text = "More European than my own nationality";
    }

    public void Q10A5() {
        //European only was selected
        input10.text = "European only";
    }

    public void Q11A1() {
        //Very proud was selected
        input11.text = "Very proud";
    }

    public void Q11A2() {
        //Fairly proud was selected
        input11.text = "Fairly proud";
    }

    public void Q11A3() {
        //Not very proud was selected
        input11.text = "Not very proud";
    }

    public void Q11A4() {
        //Not at all proud was selected
        input11.text = "Not at all proud";
    }

    public void Q11A5() {
        //Don't know was selected for Question 18
        input11.text = "Don't know";
    }

    public void Q12A1() {
        //Very proud was selected
        input12.text = "Very proud";
    }

    public void Q12A2() {
        //Fairly proud was selected
        input12.text = "Fairly proud";
    }

    public void Q12A3() {
        //Not very proud was selected
        input12.text = "Not very proud";
    }

    public void Q12A4() {
        //Not at all proud was selected
        input12.text = "Not at all proud";
    }

    public void Q12A5() {
        //Don't know was selected for Question 19
        input12.text = "Don't know";
    }
}
