using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DiscussionAnimation : MonoBehaviour {

    /* For this tool, we will have the context that introduces the conversation
     * followed by the pro, anti and undecided opinion of the topic */

    public TextMeshProUGUI textDisplay;
    //Task 1
    public string[] discussion;
    private int index;

    [SerializeField]
    private float typingSpeed;

    public GameObject continueButton;

    public GameObject startCanvas;

    //Pub scene background
    public GameObject toolBG;

    //3 main character that will be seen throughout the discussion
    //public GameObject[] characters; //pro, anti, interviewer; when calling do characters[0].SetActive(false/true); the number should be 0, 1 or 2.
    public GameObject proCharacter;
    public GameObject antiCharacter;
    public GameObject undecidedCharacter;

    public GameObject contextProCharacter;

    public Animator animPro, animAnti, animUndecided, animPlayer;

    //public GameObject proAnimationBubble;
    //public GameObject antiAnimationBubble;
    //public GameObject undecidedAnimationBubble;

    //interview style response boxes
    public GameObject responseBox;

    //context statements
    public GameObject[] task1Notice;
    public GameObject contextTask1;

    public GameObject task1Selection;
    public TextMeshProUGUI proTextDisplay;
    public TextMeshProUGUI antiTextDisplay;
    //public TextMeshProUGUI undecidedTextDisplay;

    public GameObject task2FullCanvas;
    //public GameObject[] task2Canvas;

    public Animator animText;

    //Selection of who they believe is Pro and Anti
    //Win, Try Again and Corect State
    public GameObject tryAgain, correct;

    public GameObject pro, anti;
    public GameObject emptyPro, emptyAnti;

    Vector2 proInitialPos, antiInitialPos;

    bool isProCorrect = false;
    bool isAntiCorrect = false;

    // Start is called before the first frame update
    void Start()
    {
        startCanvas.SetActive(true);

        FloatingTextController.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (textDisplay.text == discussion[index]) {
            continueButton.SetActive(true);
        }

        if (isProCorrect && isAntiCorrect) {
            Debug.Log("You matched both correctly!");
            task1Selection.SetActive(false);
            task2FullCanvas.SetActive(true);
            //task2Canvas[0].SetActive(true);
            //task2Canvas[1].SetActive(true);
            //task2Canvas[2].SetActive(true);
            toolBG.SetActive(false);
            isProCorrect = false;
            isAntiCorrect = false;
            //add score
            //progress to stage 2
            //add a button that appears once both are correct, then select that button to progress
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Journalist");
        }
    }

    public void ReturnToTheMobileWorkplace() {
        SceneManager.LoadScene("Journalist");
    }

    IEnumerator Type() {
        foreach (char letter in discussion[index].ToCharArray()) {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void StartTask1() {
        //deactivate the Start Canvas
        startCanvas.SetActive(false);

        toolBG.SetActive(true);
        contextProCharacter.SetActive(true);
        proCharacter.SetActive(false);
        antiCharacter.SetActive(false);
        undecidedCharacter.SetActive(false);

        //false to begin with then come up individually
        //proAnimationBubble.SetActive(false);
        //antiAnimationBubble.SetActive(false);
        //undecidedAnimationBubble.SetActive(false);

        responseBox.SetActive(true);

        task1Selection.SetActive(false);

        task1Notice[0].SetActive(true);
        task1Notice[1].SetActive(true);
        contextTask1.SetActive(true);

        animText.SetTrigger("Change");
    }

    public void Task1NextSentence() {
        continueButton.SetActive(false);

        if (index < discussion.Length - 1) {
            index++;
            textDisplay.text = "";

            responseBox.SetActive(true);
            contextProCharacter.SetActive(false);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            animText.SetTrigger("Change");

            StartCoroutine(Type());

            if (index == 0 || index == 4 || index == 8 || index == 12 || index == 16) { //question
                //animPlayer.SetTrigger("Triggered");
                animUndecided.SetTrigger("Idle");
                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(false);
            }

            if (index == 1 || index == 5 || index == 9 || index == 13 || index == 17) { //pro (remainer) response
                //animPlayer.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(false);
            }

            if (index == 2 || index == 6 || index == 10 || index == 14 || index == 18) { //anti (leaver) response
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
                //undecidedAnimationBubble.SetActive(false);
            }

            if (index == 3 || index == 7 || index == 11 || index == 15 || index == 19) { //undecided response
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }

        } else {
            animUndecided.SetTrigger("Idle");

            textDisplay.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            task1Selection.SetActive(true);
            //after finished
            proInitialPos = pro.transform.position;
            antiInitialPos = anti.transform.position;
            tryAgain.SetActive(false); //Try Again State
            correct.SetActive(false); //Correct State
            pro.SetActive(true);
            emptyPro.SetActive(true);
            anti.SetActive(true);
            emptyAnti.SetActive(true);
        }
    }

    //-------------------------------------------------------------------------------

    public void Task1() {
        contextTask1.SetActive(false);
        task1Notice[0].SetActive(false);
        task1Notice[1].SetActive(false);

        responseBox.SetActive(true);

        //proAnimationBubble.SetActive(true);

        contextProCharacter.SetActive(false);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void DragPro() {
        pro.transform.position = Input.mousePosition;
    }

    public void DragAnti() {
        anti.transform.position = Input.mousePosition;
    }

    public void DropPro() {
        float distance = Vector3.Distance(pro.transform.position, emptyPro.transform.position);

        if (distance < 50) {
            pro.transform.position = emptyPro.transform.position;
            isProCorrect = true;
            correct.SetActive(true);
            TextNotActive();
        } else {
            pro.transform.position = proInitialPos;
            //play audio for incorrect
            //show text saying try again etc
            tryAgain.SetActive(true);
            TextNotActive();
        }
    }

    public void DropAnti() {
        float distance = Vector3.Distance(anti.transform.position, emptyAnti.transform.position);

        if (distance < 50) {
            anti.transform.position = emptyAnti.transform.position;
            isAntiCorrect = true;
            correct.SetActive(true);
            TextNotActive();
        } else {
            anti.transform.position = antiInitialPos;
            //play audio for incorrect
            //show text saying try again etc
            tryAgain.SetActive(true);
            TextNotActive();
        }
    }

    public void TextNotActive() {
        //delay for the text for roughly 2 seconds
        StartCoroutine(HideText(tryAgain, 2f));
        StartCoroutine(HideText(correct, 1.5f));
    }

    //for adding a slight delay on have the text display then disappearing
    IEnumerator HideText(GameObject text, float delay) {
        yield return new WaitForSeconds(delay);
        text.SetActive(false);
    }
}
