﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class JobInterview : MonoBehaviour
{
    public GameObject welcomeCanvas, questionsCanvas, finishCanvas;

    public TextMeshProUGUI counterText;
    public TextMeshProUGUI welcomeText, finishedText;

    //Question Text
    public TextMeshProUGUI questions;

    //Answer Text
    public GameObject answer3, answer4, answer5, answer6, inputField;
    public TMP_InputField otherInputField;
    public TextMeshProUGUI a1, a2, a3, a4, a5, a6;

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
            Question8();
        }

        if (counter == 8) {
            Question9();
        }

        if (counter == 9) {
            Question10();
        }

        if (counter == 10) {
            Question11();
        }

        if (counter == 11) {
            Question12();
        }

        if (counter == 12) {
            Question13();
        }

        if (counter == 13) {
            Question14();
        }

        if (counter == 14) {
            Question15();
        }

        if (counter == 15) {
            Question16();
        }

        if (counter == 16) {
            Question17();
        }

        if (counter == 17) {
            Question18();
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

    public void FinishedCanvas() {
        questionsCanvas.SetActive(false);
        finishCanvas.SetActive(true);
        finishedText.text = "Thank you very much. We will ask you the same questions after you have played the game.";
    }

    public void LoadSuccessJobInterview() {
        SceneManager.LoadScene("SuccessJobInterview");
    }

    public void Question1() {
        welcomeCanvas.SetActive(false);
        questionsCanvas.SetActive(true);
        counterText.text = "1 / 19";
        questions.text = "Can you tell us your age?";
        a1.text = "18 - 23";
        a2.text = "24 - 29";
        a3.text = "30 - 35";
        a4.text = "36+";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(false);
        answer6.SetActive(false);
        inputField.SetActive(false);
    }

    public void Question2() {
        counterText.text = "2 / 19";
        questions.text = "What gender are you?";
        a1.text = "Male";
        a2.text = "Female";
        a3.text = "Prefer not to say";
        answer3.SetActive(true);
        answer4.SetActive(false);
        answer5.SetActive(false);
        answer6.SetActive(false);
        inputField.SetActive(false);
    }

    public void Question3() {
        counterText.text = "3 / 19";
        questions.text = "And can you tell us your national identity?";
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
        inputField.SetActive(true);
    }

    public void Question4() {
        counterText.text = "4 / 19";
        questions.text = "And can you tell us your country of residence?";
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
        inputField.SetActive(true);
    }

    public void Question5() {
        counterText.text = "5 / 19";
        questions.text = "What is your area of study?";
        a1.text = "Social Science";
        a2.text = "Business";
        a3.text = "Computing";
        a6.text = "Other, please state:";
        answer3.SetActive(true);
        answer4.SetActive(false);
        answer5.SetActive(false);
        answer6.SetActive(true);
        inputField.SetActive(true);
    }

    public void Question6() {
        counterText.text = "6 / 19";
        questions.text = "What is your previously completed level of education?";
        a1.text = "University Education";
        a2.text = "Secondary School";
        a3.text = "Other, please state:";
        answer3.SetActive(false);
        answer3.SetActive(false);
        answer4.SetActive(false);
        answer5.SetActive(false);
        answer6.SetActive(true);
        inputField.SetActive(true);
    }

    public void Question7() {
        counterText.text = "7 / 19";
        questions.text = "What is your work status?";
        a1.text = "Working fulltime";
        a2.text = "Working part time";
        a3.text = "Unemployed";
        a4.text = "Retired";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(false);
        answer6.SetActive(false);
        inputField.SetActive(false);
    }

    public void Question8() {
        counterText.text = "8 / 19";
        questions.text = "Which of these geographical groups would you say was the most important to you in terms of where you feel you belong?";
        a1.text = "The locality or town where you live";
        a2.text = "The region or country where you live";
        a3.text = "Your country as a whole";
        a4.text = "Europe";
        a5.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(false);
        inputField.SetActive(false);
    }

    public void Question9() {
        counterText.text = "9 / 19";
        questions.text = "And the next most important?";
        a1.text = "The locality or town where you live";
        a2.text = "The region or country where you live";
        a3.text = "Your country as a whole";
        a4.text = "Europe";
        a5.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(false);
        inputField.SetActive(false);
    }

    public void Question10() {
        counterText.text = "10 / 19";
        questions.text = "Does the term 'European identity' mean anything to you?";
        a1.text = "Yes, a lot";
        a2.text = "Yes, somewhat";
        a3.text = "Not very much";
        a4.text = "Not at all";
        a5.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(false);
        inputField.SetActive(false);
    }

    public void Question11() {
        counterText.text = "11 / 19";
        questions.text = "Do you ever think of yourself as a citizen of Europe?";
        a1.text = "Often";
        a2.text = "Sometimes";
        a3.text = "Never";
        a4.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(false);
        answer6.SetActive(false);
        inputField.SetActive(false);
    }

    public void Question12() {
        counterText.text = "12 / 19";
        questions.text = "Do you ever think of yourself as not only (your nationality) but also European?";
        a1.text = "Often";
        a2.text = "Sometimes";
        a3.text = "Never";
        a4.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(false);
        answer6.SetActive(false);
        inputField.SetActive(false);
    }

    public void Question13() {
        counterText.text = "13 / 19";
        questions.text = "How attached or close do you feel to the EU?";
        a1.text = "Very attached/ very close";
        a2.text = "Fairly attached/ fairly close";
        a3.text = "Not very attached/ not very close";
        a4.text = "Not at all attached/ not at all close";
        a5.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(false);
        inputField.SetActive(false);
    }

    public void Question14() {
        counterText.text = "14 / 19";
        questions.text = "How much does being an EU citizen have to do with how you feel about yourself in your day-to-day life?";
        a1.text = "A great deal";
        a2.text = "Somewhat";
        a3.text = "Not very much";
        a4.text = "Not at all";
        a5.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(false);
        inputField.SetActive(false);
    }

    public void Question15() {
        counterText.text = "15 / 19";
        questions.text = "How far do you feel that what happens in the EU in general has consequences for people like you?";
        a1.text = "A great deal";
        a2.text = "Somewhat";
        a3.text = "Not very much";
        a4.text = "Not at all";
        a5.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(false);
        inputField.SetActive(false);
    }

    public void Question16() {
        counterText.text = "16 / 19";
        questions.text = "How attached or close do you feel to your own country?";
        a1.text = "Very attached/ very close";
        a2.text = "Fairly attached/ fairly close";
        a3.text = "Not very attached/ not very close";
        a4.text = "Not at all attached/ not at all close";
        a5.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(false);
        inputField.SetActive(false);
    }

    public void Question17() {
        counterText.text = "17 / 19";
        questions.text = "In this list, can you say how you would describe yourself?";
        a1.text = "My nationality only";
        a2.text = "More my own nationality than European";
        a3.text = "Equally my own nationality and European";
        a4.text = "More European than my own nationality";
        a5.text = "European only";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(false);
        inputField.SetActive(false);
    }

    public void Question18() {
        counterText.text = "18 / 19";
        questions.text = "Do you feel a sense of pride at belonging to your own country?";
        a1.text = "Very proud";
        a2.text = "Fairly proud";
        a3.text = "Not very proud";
        a4.text = "Not at all proud";
        a5.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(false);
        inputField.SetActive(false);
    }

    public void Question19() {
        counterText.text = "19 / 19";
        questions.text = "Do you feel a sense of pride at being an EU citizen?";
        a1.text = "Very proud";
        a2.text = "Fairly proud";
        a3.text = "Not very proud";
        a4.text = "Not at all proud";
        a5.text = "Don't know";
        answer3.SetActive(true);
        answer4.SetActive(true);
        answer5.SetActive(true);
        answer6.SetActive(false);
        inputField.SetActive(false);
    }
}