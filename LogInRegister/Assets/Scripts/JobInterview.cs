using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class JobInterview : MonoBehaviour
{
    public GameObject welcomeCanvas, set2QuestionCanvas, set3QuestionCanvas, set4QuestionCanvas, set5QuestionCanvas, set6QuestionCanvas, questionsCanvas, finishCanvas;

    public TextMeshProUGUI counterText;
    public TextMeshProUGUI welcomeText, finishedText;

    public GameObject q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11, q12, q13, q14, q15, q16, q17, q18, q19;

    //Question Text
    //public TextMeshProUGUI questions;

    //Answer Text
    //public GameObject answer3, answer4, answer5, answer6, inputField;
    public TMP_InputField otherInputField;
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

    public void Question1() {
        welcomeCanvas.SetActive(false);
        questionsCanvas.SetActive(true);
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
        //questionsCanvas.SetActive(false);
        set2QuestionCanvas.SetActive(true);
    }

    public void Question8() {
        set2QuestionCanvas.SetActive(false);
        //questionsCanvas.SetActive(true);

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
        questionsCanvas.SetActive(false);
        set3QuestionCanvas.SetActive(true);
    }

    public void Question10() {
        set3QuestionCanvas.SetActive(false);
        questionsCanvas.SetActive(true);

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
        questionsCanvas.SetActive(false);
        set4QuestionCanvas.SetActive(true);
    }

    public void Question13() {
        set4QuestionCanvas.SetActive(false);
        questionsCanvas.SetActive(true);

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
        questionsCanvas.SetActive(false);
        set5QuestionCanvas.SetActive(true);
    }

    public void Question16() {
        set5QuestionCanvas.SetActive(false);
        questionsCanvas.SetActive(true);

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
        questionsCanvas.SetActive(false);
        set6QuestionCanvas.SetActive(true);
    }

    public void Question18() {
        set6QuestionCanvas.SetActive(false);
        questionsCanvas.SetActive(true);

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
        emailAnswer = email.GetComponent<InputField>().text;
        q1Answer = one.GetComponent<InputField>().text;
        q2Answer = two.GetComponent<InputField>().text;
        q3Answer = three.GetComponent<InputField>().text;
        q4Answer = four.GetComponent<InputField>().text;
        q5Answer = five.GetComponent<InputField>().text;
        q6Answer = six.GetComponent<InputField>().text;
        q7Answer = seven.GetComponent<InputField>().text;
        q8Answer = eight.GetComponent<InputField>().text;
        q9Answer = nine.GetComponent<InputField>().text;
        q10Answer = ten.GetComponent<InputField>().text;
        q11Answer = eleven.GetComponent<InputField>().text;
        q12Answer = twelve.GetComponent<InputField>().text;
        q13Answer = thirteen.GetComponent<InputField>().text;
        q14Answer = fourteen.GetComponent<InputField>().text;
        q15Answer = fifteen.GetComponent<InputField>().text;
        q16Answer = sixteen.GetComponent<InputField>().text;
        q17Answer = seventeen.GetComponent<InputField>().text;
        q18Answer = eighteen.GetComponent<InputField>().text;
        q19Answer = nineteen.GetComponent<InputField>().text;

        StartCoroutine(Post(emailAnswer, q1Answer, q2Answer, q3Answer, q4Answer, q5Answer, q6Answer, q7Answer, q8Answer, q9Answer, q10Answer, q11Answer, q12Answer, q13Answer, q14Answer,
                            q15Answer, q16Answer, q17Answer, q18Answer, q19Answer));
    }

    /*
     * This displays each of the ages that will be selected 
    */
    public void Age1() {
        //age 18-23 selected

    }

    public void Age2() {
        //age 24-29 selected

    }

    public void Age3() {
        //age 30-35 selected

    }

    public void Age4() {
        // age 36+ selected

    }

    public void Male() {
        //male selected

    }

    public void Female() {
        //female selected

    }

    public void PreferNotToSay() {
        //prefer not to say selected

    }

    public void British() {
        //British selected

    }

    public void German() {
        //German selected

    }

    public void Dutch() {
        //Dutch selected

    }

    public void Croatian() {
        //Croatian selected

    }

    public void Greek() {
        //Greek selected

    }

    public void Q3OtherPleaseState() {
        //question 3 national identity other typed in input field 
    }

    public void UK() {
        //UK selected

    }

    public void Germany() {
        //Germany selected

    }

    public void Holland() {
        //Holland selected

    }

    public void Croatia() {
        //Croatia selected
    }

    public void Greece() {
        //Greece selected

    }

    public void Q4OtherPleaseState() {
        //Other, please specify selected for Question 4 on Country of Residence

    }

    public void SocialScience() {
        //Social Sceience selected

    }

    public void Business() {
        //Business selected

    }

    public void Computing() {
        //Computing selected

    }

    public void Q5OtherPleaseState() {
        //Other, please specify selected for Question 5 on area of study

    }

    public void UniversityEducation() {
        //University Education selected

    }

    public void SecondarySchool() {
        //Secondary School selected

    }

    public void Q6OtherPleaseState() {
        //Other, please specify selected for Question 6 on previously completed level of education

    }

    public void WorkingFullTime() {
        //Working Fulltime selected

    }

    public void WorkingPartTime() {
        //Working Part Time selected

    }

    public void Unemployed() {
        //Unemployed selected

    }

    public void Retired() {
        //Retired selected

    }

    public void Q8LocalityOrTownWhereYouLive() {
        //the locality or town where you live was selected for Question 8

    }

    public void Q8RegionOrCountryWhereYouLive() {
        //the region or country where you live was selected for Question 8

    }

    public void Q8YourCountryAsAWhole() {
        //your country as a whole was selected for Question 8

    }

    public void Q8Europe() {
        //Europe was selected for Question 8

    }

    public void Q8DontKnow() {
        //Don't know was selected for Question 8

    }

    public void Q9LocalityOrTownWhereYouLive() {
        //the locality or town where you live was selected for Question 9

    }

    public void Q9RegionOrCountryWhereYouLive() {
        //the region or country where you live was selected for Question 9

    }

    public void Q9YourCountryAsAWhole() {
        //your country as a whole was selected for Question 9

    }

    public void Q9Europe() {
        //Europe was selected for Question 9

    }

    public void Q9DontKnow() {
        //Don't know was selected for Question 9

    }

    public void YesALot() {
        //Yes, a lot was selected

    }

    public void YesSomewhat() {
        //Yes, somewhat was selected

    }

    public void NotVeryMuch() {
        //Not very much was selected

    }

    public void NotAtAll() {
        //Not at all was selected

    }

    public void Q10DontKnow() {
        //Don't know was selected for Question 10

    }

    public void Q11Often() {
        //Often was selected for Question 11

    }

    public void Q11Sometimes() {
        //Sometimes was selected for Question 11

    }

    public void Q11Never() {
        //Never selected for Question 11

    }

    public void Q11DontKnow() {
        //Don't know selected for Question 11

    }

    public void Q12Often() {
        //Often selected for Question 12

    }

    public void Q12Sometimes() {
        //Sometimes selected for Question 12

    }

    public void Q12Never() {
        //Never selected for Question 12

    }

    public void Q12DontKnow() {
        //Don't know selected for Question 12

    }

    public void Q13A1() {
        //Very attached/ very close selected for Question 13

    }

    public void Q13A2() {
        //Fairly attached/ fairly close selected for Question 13

    }

    public void Q13A3() {
        //Not very attached/ not very close selected for Question 13

    }

    public void Q13A4() {
        //Not at all attached/ not at all close selected for Question 13

    }

    public void Q13A5() {
        //Don't know was selected for Question 13

    }

    public void Q14A1() {
        //A great deal was selected for Question 14

    }

    public void Q14A2() {
        //Somewhat was selected for Question 14

    }

    public void Q14A3() {
        //Not very much was selected for Question 14

    }

    public void Q14A4() {
        //Not at all was selected for Question 14

    }

    public void Q14A5() {
        //Don't know was selected for Question 14

    }

    public void Q15A1() {
        //A great deal was selected for Question 15

    }

    public void Q15A2() {
        //Somewhat was selected for Question 15

    }

    public void Q15A3() {
        //Not very much was selected for Question 15

    }

    public void Q15A4() {
        //Not at all was selected for Question 15

    }

    public void Q15A5() {
        //Don't know was selected for Question 15

    }

    public void Q16A1() {
        //Very attached/ very close was selected for Question 16

    }

    public void Q16A2() {
        //Fairly attached/ fairly close was selected to Question 16

    }

    public void Q16A3() {
        //Not very attached/ not very close was selected for Question 16

    }

    public void Q16A4() {
        //Not at all attached/ not at all close was selected for Question 16

    }

    public void Q16A5() {
        //Don't know was selected for Question 16

    }

    public void Q17A1() {
        //My nationality only was selected

    }

    public void Q17A2() {
        //More my own nationality than European was selected

    }

    public void Q17A3() {
        //Equally my own nationality and European

    }

    public void Q17A4() {
        //More European than my own nationality

    }

    public void Q17A5() {
        //European only was selected

    }

    public void Q18A1() {
        //Very proud was selected

    }

    public void Q18A2() {
        //Fairly proud was selected

    }

    public void Q18A3() {
        //Not very proud was selected

    }

    public void Q18A4() {
        //Not at all proud was selected

    }

    public void Q18A5() {
        //Don't know was selected for Question 18

    }

    public void Q19A1() {
        //Very proud was selected

    }

    public void Q19A2() {
        //Fairly proud was selected

    }

    public void Q19A3() {
        //Not very proud was selected

    }

    public void Q19A4() {
        //Not at all proud was selected

    }

    public void Q19A5() {
        //Don't know was selected for Question 19

    }
}
