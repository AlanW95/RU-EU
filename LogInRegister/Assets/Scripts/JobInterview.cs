using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class JobInterview : MonoBehaviour
{
    public GameObject welcomeCanvas, set2QuestionCanvas, set3QuestionCanvas, set4QuestionCanvas, set5QuestionCanvas, set6QuestionCanvas, questionsCanvas, finishCanvas;

    public GameObject questionCounter;

    public TextMeshProUGUI counterText;
    public TextMeshProUGUI welcomeText, finishedText;

    public GameObject emailgo, q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11, q12, q13, q14, q15, q16, q17, q18, q19;

    //Question Text
    //public TextMeshProUGUI questions;

    //Answer Text
    //public GameObject answer3, answer4, answer5, answer6, inputField;

    public TMP_InputField inputEmail;
    public InputField input1, input2, input3, input4, input5, input6, input7, input8, input9, input10, input11, input12, input13, input14, input15, input16, input17, input18, input19;

    public TMP_InputField q3Input, q4Input, q5Input, q6Input;

    //public TMP_InputField otherInputField;
    //public TextMeshProUGUI a1, a2, a3, a4, a5, a6;

    public GameObject email, one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve, thirteen, fourteen, fifteen, sixteen, seventeen, eighteen, nineteen;

    private string emailAnswer, q1Answer, q2Answer, q3Answer, q4Answer, q5Answer, q6Answer, q7Answer, q8Answer, q9Answer,
                    q10Answer, q11Answer, q12Answer, q13Answer, q14Answer, q15Answer, q16Answer, q17Answer, q18Answer, q19Answer;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSdUEfRXkMjAhyMkHbg9T3UvV253zYP7QhI95_gEkmJ7t7irzw/formResponse";

    public static int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        welcomeCanvas.SetActive(true);

        questionsCanvas.SetActive(false);

        set2QuestionCanvas.SetActive(false);
        set3QuestionCanvas.SetActive(false);
        set4QuestionCanvas.SetActive(false);
        set5QuestionCanvas.SetActive(false);
        set6QuestionCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        /*if (counter == 0) {
            Question1();
        }*/

        if (counter == 1) {
            Question2();
        }

        if (counter == 2) {
            Question3();
        }

        if (counter == 3) {
            Question4();
        }

        if (counter == 4) {
            Question5();
        }

        if (counter == 5) {
            Question6();
        }

        if (counter == 6) {
            Question7();
        }

        if (counter == 7) {
            Set2Questions();
            //Question8();
        }

        if (counter == 8) {
            Question9();
        }

        if (counter == 9) {
            Set3Questions();
            //Question10();
        }

        if (counter == 10) {
            Question11();
        }

        if (counter == 11) {
            Question12();
        }

        if (counter == 12) {
            Set4Questions();
            //Question13();
        }

        if (counter == 13) {
            Question14();
        }

        if (counter == 14) {
            Question15();
        }

        if (counter == 15) {
            Set5Questions();
            //Question16();
        }

        if (counter == 16) {
            Question17();
        }

        if (counter == 17) {
            Set6Questions();
            //Question18();
        }

        if (counter == 18) {
            Question19();
        }

        if (counter == 19) {
            FinishedCanvas();
        }
    }

    public void CounterUp() {
        counter++;
    }

    public void WelcomeCanvas() {
        welcomeText.text = "So first of all here are some basic questions about yourself.";
    }

    public void LoadSuccessJobInterview() {
        SceneManager.LoadScene("SuccessJobInterview");
    }

    public void EnterEmail() {
        welcomeCanvas.SetActive(false);
        questionsCanvas.SetActive(true);

        questionCounter.SetActive(false);

        emailgo.SetActive(true);
    }

    public void Question1() {
        /*welcomeCanvas.SetActive(false);
        questionsCanvas.SetActive(true);*/

        emailgo.SetActive(false);
        questionCounter.SetActive(true);
        counterText.text = "1 / 19";

        q1.SetActive(true);

        /*questions.text = "Can you tell us your age?";
        a1.text = "18 - 23";
        a2.text = "24 - 29";
        a3.text = "30 - 35";
        a4.text = "36+";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(false);
        answer6.SetActive(false);
        inputField.SetActive(false);*/
    }

    public void Question2() {
        counterText.text = "2 / 19";

        q1.SetActive(false);
        q2.SetActive(true);

        /*questions.text = "What gender are you?";
        a1.text = "Male";
        a2.text = "Female";
        a3.text = "Prefer not to say";
        answer3.SetActive(true);
        answer4.SetActive(false);
        answer5.SetActive(false);
        answer6.SetActive(false);
        inputField.SetActive(false);*/
    }

    public void Question3() {
        counterText.text = "3 / 19";

        q2.SetActive(false);
        q3.SetActive(true);

        /*questions.text = "And can you tell us your national identity?";
        a1.text = "British";
        a2.text = "German";
        a3.text = "Dutch";
        a4.text = "Croatian";
        a5.text = "Greek";
        a6.text = "Other, please state:"; //add input field
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(true);
        inputField.SetActive(true);*/
    }

    public void Question3OtherSelected() {
        //q3Input.text = input3.text;
        input3.text = q3Input.text;
    }

    public void Question4() {
        counterText.text = "4 / 19";

        q3.SetActive(false);
        q4.SetActive(true);        

        /*questions.text = "And can you tell us your country of residence?";
        a1.text = "UK";
        a2.text = "Germany";
        a3.text = "Holland";
        a4.text = "Croatia";
        a5.text = "Greece";
        a6.text = "Other, please state:"; //add input field
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(true);
        inputField.SetActive(true);*/
    }

    public void Question4OtherSelected() {
        //q4Input.text = input4.text;
        input4.text = q4Input.text;
    }

    public void Question5() {
        counterText.text = "5 / 19";

        q4.SetActive(false);
        q5.SetActive(true);
        
        /*questions.text = "What is your area of study?";
        a1.text = "Social Science";
        a2.text = "Business";
        a3.text = "Computing";
        a6.text = "Other, please state:";
        answer3.SetActive(true);
        answer4.SetActive(false);
        answer5.SetActive(false);
        answer6.SetActive(true);
        inputField.SetActive(true);*/
    }

    public void Question5OtherSelected() {
        //q5Input.text = input5.text;
        input5.text = q5Input.text;
    }

    public void Question6() {
        counterText.text = "6 / 19";

        q5.SetActive(false);
        q6.SetActive(true);

        /*questions.text = "What is your previously completed level of education?";
        a1.text = "University Education";
        a2.text = "Secondary School";
        a3.text = "Other, please state:";
        answer3.SetActive(false);
        answer3.SetActive(false);
        answer4.SetActive(false);
        answer5.SetActive(false);
        answer6.SetActive(true);
        inputField.SetActive(true);*/
    }

    public void Question6OtherSelected() {
        //q6Input.text = input6.text;
        input6.text = q6Input.text;
    }

    public void Question7() {
        counterText.text = "7 / 19";

        q6.SetActive(false);
        q7.SetActive(true);

        /*questions.text = "What is your work status?";
        a1.text = "Working fulltime";
        a2.text = "Working part time";
        a3.text = "Unemployed";
        a4.text = "Retired";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(false);
        answer6.SetActive(false);
        inputField.SetActive(false);*/
    }

    public void Set2Questions() {

        set2QuestionCanvas.SetActive(true);
    }

    public void Question8() {
        Destroy(set2QuestionCanvas);

        counterText.text = "8 / 19";

        q7.SetActive(false);
        q8.SetActive(true);

        /*questions.text = "Which of these geographical groups would you say was the most important to you in terms of where you feel you belong?";
        a1.text = "The locality or town where you live";
        a2.text = "The region or country where you live";
        a3.text = "Your country as a whole";
        a4.text = "Europe";
        a5.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(false);
        inputField.SetActive(false);*/
    }

    public void Question9() {
        counterText.text = "9 / 19";

        q8.SetActive(false);
        q9.SetActive(true);

        /*questions.text = "And the next most important?";
        a1.text = "The locality or town where you live";
        a2.text = "The region or country where you live";
        a3.text = "Your country as a whole";
        a4.text = "Europe";
        a5.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(false);
        inputField.SetActive(false);*/
    }

    public void Set3Questions() {
        set3QuestionCanvas.SetActive(true);
    }

    public void Question10() {
        Destroy(set3QuestionCanvas);

        counterText.text = "10 / 19";

        q9.SetActive(false);
        q10.SetActive(true);

        /*questions.text = "Does the term 'European identity' mean anything to you?";
        a1.text = "Yes, a lot";
        a2.text = "Yes, somewhat";
        a3.text = "Not very much";
        a4.text = "Not at all";
        a5.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(false);
        inputField.SetActive(false);*/
    }

    public void Question11() {
        counterText.text = "11 / 19";

        q10.SetActive(false);
        q11.SetActive(true);

        /*questions.text = "Do you ever think of yourself as a citizen of Europe?";
        a1.text = "Often";
        a2.text = "Sometimes";
        a3.text = "Never";
        a4.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(false);
        answer6.SetActive(false);
        inputField.SetActive(false);*/
    }

    public void Question12() {
        counterText.text = "12 / 19";

        q11.SetActive(false);
        q12.SetActive(true);

        /*questions.text = "Do you ever think of yourself as not only (your nationality) but also European?";
        a1.text = "Often";
        a2.text = "Sometimes";
        a3.text = "Never";
        a4.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(false);
        answer6.SetActive(false);
        inputField.SetActive(false);*/
    }

    public void Set4Questions() {
        set4QuestionCanvas.SetActive(true);
    }

    public void Question13() {
        Destroy(set4QuestionCanvas);

        counterText.text = "13 / 19";

        q12.SetActive(false);
        q13.SetActive(true);

        /*questions.text = "How attached or close do you feel to the EU?";
        a1.text = "Very attached/ very close";
        a2.text = "Fairly attached/ fairly close";
        a3.text = "Not very attached/ not very close";
        a4.text = "Not at all attached/ not at all close";
        a5.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(false);
        inputField.SetActive(false);*/
    }

    public void Question14() {
        counterText.text = "14 / 19";

        q13.SetActive(false);
        q14.SetActive(true);

        /*questions.text = "How much does being an EU citizen have to do with how you feel about yourself in your day-to-day life?";
        a1.text = "A great deal";
        a2.text = "Somewhat";
        a3.text = "Not very much";
        a4.text = "Not at all";
        a5.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(false);
        inputField.SetActive(false);*/
    }

    public void Question15() {
        counterText.text = "15 / 19";

        q14.SetActive(false);
        q15.SetActive(true);

        /*questions.text = "How far do you feel that what happens in the EU in general has consequences for people like you?";
        a1.text = "A great deal";
        a2.text = "Somewhat";
        a3.text = "Not very much";
        a4.text = "Not at all";
        a5.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(false);
        inputField.SetActive(false);*/
    }

    public void Set5Questions() {
        set5QuestionCanvas.SetActive(true);
    }

    public void Question16() {
        Destroy(set5QuestionCanvas);

        counterText.text = "16 / 19";

        q15.SetActive(false);
        q16.SetActive(true);

        /*questions.text = "How attached or close do you feel to your own country?";
        a1.text = "Very attached/ very close";
        a2.text = "Fairly attached/ fairly close";
        a3.text = "Not very attached/ not very close";
        a4.text = "Not at all attached/ not at all close";
        a5.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(false);
        inputField.SetActive(false);*/
    }

    public void Question17() {
        counterText.text = "17 / 19";

        q16.SetActive(false);
        q17.SetActive(true);

        /*questions.text = "In this list, can you say how you would describe yourself?";
        a1.text = "My nationality only";
        a2.text = "More my own nationality than European";
        a3.text = "Equally my own nationality and European";
        a4.text = "More European than my own nationality";
        a5.text = "European only";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(false);
        inputField.SetActive(false);*/
    }

    public void Set6Questions() {
        set6QuestionCanvas.SetActive(true);
    }

    public void Question18() {
        Destroy(set6QuestionCanvas);

        counterText.text = "18 / 19";

        q17.SetActive(false);
        q18.SetActive(true);

        /*questions.text = "Do you feel a sense of pride at belonging to your own country?";
        a1.text = "Very proud";
        a2.text = "Fairly proud";
        a3.text = "Not very proud";
        a4.text = "Not at all proud";
        a5.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(false);
        inputField.SetActive(false);*/
    }

    public void Question19() {
        counterText.text = "19 / 19";

        q18.SetActive(false);
        q19.SetActive(true);

        /*questions.text = "Do you feel a sense of pride at being an EU citizen?";
        a1.text = "Very proud";
        a2.text = "Fairly proud";
        a3.text = "Not very proud";
        a4.text = "Not at all proud";
        a5.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(false);
        inputField.SetActive(false);*/
    }

    public void FinishedCanvas() {
        questionsCanvas.SetActive(false);
        finishCanvas.SetActive(true);
        finishedText.text = "Thank you very much. We will ask you the same questions after you have played the game.";
    }

    IEnumerator Post(string emailAnswer, string q1Answer, string q2Answer, string q3Answer, string q4Answer, string q5Answer, string q6Answer, string q7Answer,
                    string q8Answer, string q9Answer, string q10Answer, string q11Answer, string q12Answer, string q13Answer, string q14Answer,
                    string q15Answer, string q16Answer, string q17Answer, string q18Answer, string q19Answer) {

        WWWForm form = new WWWForm();

        form.AddField("entry.569468777", emailAnswer);
        form.AddField("entry.598450662", q1Answer);
        form.AddField("entry.945306097", q2Answer);
        form.AddField("entry.39158012", q3Answer);
        form.AddField("entry.1292453078", q4Answer);
        form.AddField("entry.1584333848", q5Answer);
        form.AddField("entry.961712334", q6Answer);
        form.AddField("entry.1638152976", q7Answer);
        form.AddField("entry.214749853", q8Answer);
        form.AddField("entry.898159844", q9Answer);
        form.AddField("entry.1493578472", q10Answer);
        form.AddField("entry.853945003", q11Answer);
        form.AddField("entry.1428687212", q12Answer);
        form.AddField("entry.1589165296", q13Answer);
        form.AddField("entry.176801594", q14Answer);
        form.AddField("entry.560029309", q15Answer);
        form.AddField("entry.659858946", q16Answer);
        form.AddField("entry.1810636355", q17Answer);
        form.AddField("entry.1746438365", q18Answer);
        form.AddField("entry.1722127928", q19Answer);

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
        q13Answer = input13.GetComponent<InputField>().text;
        q14Answer = input14.GetComponent<InputField>().text;
        q15Answer = input15.GetComponent<InputField>().text;
        q16Answer = input16.GetComponent<InputField>().text;
        q17Answer = input17.GetComponent<InputField>().text;
        q18Answer = input18.GetComponent<InputField>().text;
        q19Answer = input19.GetComponent<InputField>().text;

        StartCoroutine(Post(emailAnswer, q1Answer, q2Answer, q3Answer, q4Answer, q5Answer, q6Answer, q7Answer, q8Answer, q9Answer, q10Answer, q11Answer, q12Answer, q13Answer, q14Answer,
                            q15Answer, q16Answer, q17Answer, q18Answer, q19Answer));
    }

    /*
     * This displays each of the ages that will be selected 
    */
    public void Q1A1() {
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
    }

    public void Q8A1() {
        //the locality or town where you live was selected for Question 8
        input8.text = "The locality or town where you live";
    }

    public void Q8A2() {
        //the region or country where you live was selected for Question 8
        input8.text = "The region or country where you live";
    }

    public void Q8A3() {
        //your country as a whole was selected for Question 8
        input8.text = "Your country as a whole";
    }

    public void Q8A4() {
        //Europe was selected for Question 8
        input8.text = "Europe";
    }

    public void Q8A5() {
        //Don't know was selected for Question 8
        input8.text = "Don't know";
    }

    public void Q9A1() {
        //the locality or town where you live was selected for Question 9
        input9.text = "The locality or town where you live";
    }

    public void Q9A2() {
        //the region or country where you live was selected for Question 9
        input9.text = "The region or country where you live";
    }

    public void Q9A3() {
        //your country as a whole was selected for Question 9
        input9.text = "Your country as a whole";
    }

    public void Q9A4() {
        //Europe was selected for Question 9
        input9.text = "Europe";
    }

    public void Q9A5() {
        //Don't know was selected for Question 9
        input9.text = "Don't know";
    }

    public void Q10A1() {
        //Yes, a lot was selected
        input10.text = "Yes, a lot";
    }

    public void Q10A2() {
        //Yes, somewhat was selected
        input10.text = "Yes, somewhat";
    }

    public void Q10A3() {
        //Not very much was selected
        input10.text = "Not very much";
    }

    public void Q10A4() {
        //Not at all was selected
        input10.text = "Not at all";
    }

    public void Q10A5() {
        //Don't know was selected for Question 10
        input10.text = "Don't know";
    }

    public void Q11A1() {
        //Often was selected for Question 11
        input11.text = "Often";
    }

    public void Q11A2() {
        //Sometimes was selected for Question 11
        input11.text = "Sometimes";
    }

    public void Q11A3() {
        //Never selected for Question 11
        input11.text = "Never";
    }

    public void Q11A4() {
        //Don't know selected for Question 11
        input11.text = "Don't know";
    }

    public void Q12A1() {
        //Often selected for Question 12
        input12.text = "Often";
    }

    public void Q12A2() {
        //Sometimes selected for Question 12
        input12.text = "Sometimes";
    }

    public void Q12A3() {
        //Never selected for Question 12
        input12.text = "Never";
    }

    public void Q12A4() {
        //Don't know selected for Question 12
        input12.text = "Don't know";
    }

    public void Q13A1() {
        //Very attached/ very close selected for Question 13
        input13.text = "Very attached/ very close";
    }

    public void Q13A2() {
        //Fairly attached/ fairly close selected for Question 13
        input13.text = "Fairly attached/ fairly close";
    }

    public void Q13A3() {
        //Not very attached/ not very close selected for Question 13
        input13.text = "Not very attached/ not very close";
    }

    public void Q13A4() {
        //Not at all attached/ not at all close selected for Question 13
        input13.text = "Not at all attached/ not at all close";
    }

    public void Q13A5() {
        //Don't know was selected for Question 13
        input13.text = "Don't know";
    }

    public void Q14A1() {
        //A great deal was selected for Question 14
        input14.text = "A great deal";
    }

    public void Q14A2() {
        //Somewhat was selected for Question 14
        input14.text = "Somewhat";
    }

    public void Q14A3() {
        //Not very much was selected for Question 14
        input14.text = "Not very much";
    }

    public void Q14A4() {
        //Not at all was selected for Question 14
        input14.text = "Not at all";
    }

    public void Q14A5() {
        //Don't know was selected for Question 14
        input14.text = "Don't know";
    }

    public void Q15A1() {
        //A great deal was selected for Question 15
        input15.text = "A great deal";
    }

    public void Q15A2() {
        //Somewhat was selected for Question 15
        input15.text = "Somewhat";
    }

    public void Q15A3() {
        //Not very much was selected for Question 15
        input15.text = "Not very much";
    }

    public void Q15A4() {
        //Not at all was selected for Question 15
        input15.text = "Not at all";
    }

    public void Q15A5() {
        //Don't know was selected for Question 15
        input15.text = "Don't know";
    }

    public void Q16A1() {
        //Very attached/ very close was selected for Question 16
        input16.text = "Very attached/ very close";
    }

    public void Q16A2() {
        //Fairly attached/ fairly close was selected to Question 16
        input16.text = "Fairly attached/ fairly close";
    }

    public void Q16A3() {
        //Not very attached/ not very close was selected for Question 16
        input16.text = "Not very attached/ not very close";
    }

    public void Q16A4() {
        //Not at all attached/ not at all close was selected for Question 16
        input16.text = "Not at all attached/ not at all close";
    }

    public void Q16A5() {
        //Don't know was selected for Question 16
        input16.text = "Don't know";
    }

    public void Q17A1() {
        //My nationality only was selected
        input17.text = "My nationality only";
    }

    public void Q17A2() {
        //More my own nationality than European was selected
        input17.text = "More my own nationality than European";
    }

    public void Q17A3() {
        //Equally my own nationality and European
        input17.text = "Equally my own nationality and European";
    }

    public void Q17A4() {
        //More European than my own nationality
        input17.text = "More European than my own nationality";
    }

    public void Q17A5() {
        //European only was selected
        input17.text = "European only";
    }

    public void Q18A1() {
        //Very proud was selected
        input18.text = "Very proud";
    }

    public void Q18A2() {
        //Fairly proud was selected
        input18.text = "Fairly proud";
    }

    public void Q18A3() {
        //Not very proud was selected
        input18.text = "Not very proud";
    }

    public void Q18A4() {
        //Not at all proud was selected
        input18.text = "Not at all proud";
    }

    public void Q18A5() {
        //Don't know was selected for Question 18
        input18.text = "Don't know";
    }

    public void Q19A1() {
        //Very proud was selected
        input19.text = "Very proud";
    }

    public void Q19A2() {
        //Fairly proud was selected
        input19.text = "Fairly proud";
    }

    public void Q19A3() {
        //Not very proud was selected
        input19.text = "Not very proud";
    }

    public void Q19A4() {
        //Not at all proud was selected
        input19.text = "Not at all proud";
    }

    public void Q19A5() {
        //Don't know was selected for Question 19
        input19.text = "Don't know";
    }
}
