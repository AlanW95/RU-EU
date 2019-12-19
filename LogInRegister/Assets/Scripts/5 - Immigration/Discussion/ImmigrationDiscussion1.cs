using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ImmigrationDiscussion1 : MonoBehaviour
{
    public TextMeshProUGUI statementTextDisplay;

    //Task 2 (previously)
    public string[] discussion2;
    private int index;

    [SerializeField]
    private float typingSpeed;

    public GameObject continueButton;

    //pub scene background
    public GameObject toolBG;

    //3 main characters that will be seen throughout the discussion
    public GameObject proCharacter;
    public GameObject antiCharacter;
    public GameObject undecidedCharacter;

    //public GameObject contextProCharacter;

    public Animator animPro, animAnti, animUndecided;
    public Animator animText;

    //interview style response boxes
    public GameObject responseBox;

    //Dialogue Bool Finish
    private bool isTheme1Finished = false;
    private bool isTheme2Finished = false;
    private bool isTheme3Finished = false;
    private bool isTheme4Finished = false;
    private bool isTheme5Finished = false;
    private bool isTheme6Finished = false;
    private bool isTheme7Finished = false;
    private bool isTheme8Finished = false;
    private bool isTheme9Finished = false;
    private bool isTheme10Finished = false;

    //Dialogue Context (before dialogue begins)
    public GameObject contextTheme1, contextTheme2, contextTheme3, contextTheme4, contextTheme5, contextTheme6, contextTheme7, contextTheme8, contextTheme9, contextTheme10;
    
    public GameObject playerSelection;
    public GameObject[] proText, antiText;
    public TextMeshProUGUI theme1Pro, theme2Pro, theme3Pro, theme4Pro, theme5Pro, theme6Pro, theme7Pro, theme8Pro, theme9Pro, theme10Pro;
    public TextMeshProUGUI theme1Anti, theme2Anti, theme3Anti, theme4Anti, theme5Anti, theme6Anti, theme7Anti, theme8Anti, theme9Anti, theme10Anti;
    private bool hasPlayerSelected = false;
    
    private bool isDialogueFinished = false;

    // For bottom
    private bool proDiscussion1, antiDiscussion1 = false;
    private bool proDiscussion2, antiDiscussion2 = false;
    private bool proDiscussion3, antiDiscussion3 = false;
    private bool proDiscussion4, antiDiscussion4 = false;
    private bool proDiscussion5, antiDiscussion5 = false;
    private bool proDiscussion6, antiDiscussion6 = false;
    private bool proDiscussion7, antiDiscussion7 = false;
    private bool proDiscussion8, antiDiscussion8 = false;
    private bool proDiscussion9, antiDiscussion9 = false;
    private bool proDiscussion10, antiDiscussion10 = false;

    public GameObject task3;

    private int discussionCount = 0;

    private int countdown = 10;

    public GameObject startCanvas;

    // Start is called before the first frame update
    void Start()
    {
        startCanvas.SetActive(true);
        
        FloatingTextController.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (statementTextDisplay.text == discussion2[index]) {
            continueButton.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Journalist");
        }

        //StatementsSelected();

        if (countdown == 0) {
            //give feedback
            //this is placement at the moment
            //task2FullCanvas.SetActive(false);
            //task3.SetActive(true);
            Debug.Log("Discussion has been complete!");
            task3.SetActive(true);

            toolBG.SetActive(false);
        }
    }

    IEnumerator Type() {
        foreach (char letter in discussion2[index].ToCharArray()) {
            statementTextDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void ReturnToTheMobileWorkplace() {
        SceneManager.LoadScene("Journalist");
    }

    //Task 2 is relatively the same as the original way we had the Discussion tool but this time after each one, 
    //the player will be asked if they find the pro or anti more convincing to be used later on.

    //originally was StartTask2
    public void StartDialogue() {
        Debug.Log("This button has been pressed!");

        startCanvas.SetActive(false);

        toolBG.SetActive(true);
        proCharacter.SetActive(false);
        antiCharacter.SetActive(false);
        undecidedCharacter.SetActive(false);

        responseBox.SetActive(true);

        playerSelection.SetActive(false);

        /* When the tool first begins the player will be presented with the first context.
         * Everything will be SetActive(false) except the context for Social to begin.
         */

        //context statements for the dialogue
        //set false as they don't appear straight away
        //contextTheme1 is first, after each dialogue and selection, it goes to the next one
        contextTheme1.SetActive(true);
        contextTheme2.SetActive(false);
        contextTheme3.SetActive(false);
        contextTheme4.SetActive(false);
        contextTheme5.SetActive(false);
        contextTheme6.SetActive(false);
        contextTheme7.SetActive(false);
        contextTheme8.SetActive(false);
        contextTheme9.SetActive(false);
        contextTheme10.SetActive(false);

        //animText.SetTrigger("Change"); //for player if added later on
    }

    public void IfFinished() {
        //if either or are finished - go back to the screen
        if (isDialogueFinished) {

            toolBG.SetActive(false);
        }

        //if both are finished - go to feedback
        if (isDialogueFinished == true) {
            //give feedback
            //this is placement at the moment
            //task2FullCanvas.SetActive(false);
            //task3.SetActive(true);
            Debug.Log("Both dialogues have been complete!");
            task3.SetActive(true);

            toolBG.SetActive(false);
        }

        if (countdown == 0) {
            Debug.Log("Discussion been complete!");
            task3.SetActive(true);
            toolBG.SetActive(false);
        }
    }

    //-------------------------------------------------------------
    public void Theme1NextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            statementTextDisplay.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            animText.SetTrigger("Change");

            StartCoroutine(Type());

            if (index == 0) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 1) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }

        }
        else {
            statementTextDisplay.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            isTheme1Finished = true;

            if (isTheme1Finished == true) {
                contextTheme1.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);


                proText[0].SetActive(true);
                antiText[0].SetActive(true);
                theme1Pro.text = "Our country would not have the fantastic social mix it has today without migration.";
                theme1Anti.text = "The Bureaucrats in Brussels have no idea about the type of migrants we get here - and no idea how it impacts on our society - we have to live with them, they don't.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress

                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void Theme1Selected() {
        if (hasPlayerSelected == true) {
            hasPlayerSelected = false;
            proText[0].SetActive(false);
            antiText[0].SetActive(false);
            playerSelection.SetActive(false);
            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //store data
            //put into Unity Analytics when available

            contextTheme2.SetActive(true);
            responseBox.SetActive(true);
        }
    }

    public void Theme2NextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            statementTextDisplay.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 0) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 1) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }

        }
        else {
            statementTextDisplay.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            isTheme2Finished = true;

            if (isTheme2Finished == true) {
                contextTheme2.SetActive(false);

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[1].SetActive(true);
                antiText[1].SetActive(true);

                theme2Pro.text = "Climate change is not an issue for only one country - we need to work together - irerspective of where we live.";
                theme2Anti.text = "Migrants cause overpopualtion, too much rubbish, and damage to the environment.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void Theme2Selected() {
        if (hasPlayerSelected == true) {
            hasPlayerSelected = false;
            proText[1].SetActive(false);
            antiText[1].SetActive(false);
            playerSelection.SetActive(false);
            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //store data
            //put into Unity Analytics when available
            contextTheme3.SetActive(true);
            responseBox.SetActive(true);
        }
    }

    public void Theme3NextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            statementTextDisplay.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 0) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 1) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }
        }
        else {
            statementTextDisplay.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            isTheme3Finished = true;

            if (isTheme3Finished == true) {
                contextTheme3.SetActive(false);

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[2].SetActive(true);
                antiText[2].SetActive(true);

                theme3Pro.text = "Immigrants should have all the rights and the responsibilities that other EU citizens have.";
                theme3Anti.text = "I can understand why people in certain areas feel threatened by immigration - they feel the immigrants have more rights than they do.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void Theme3Selected() {
        if (hasPlayerSelected == true) {
            hasPlayerSelected = false;
            proText[2].SetActive(false);
            antiText[2].SetActive(false);
            playerSelection.SetActive(false);
            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //store data
            //put into Unity Analytics when available
            contextTheme4.SetActive(true);
            responseBox.SetActive(true);
        }
    }

    public void Theme4NextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            statementTextDisplay.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 0) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 1) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }
        }
        else {
            statementTextDisplay.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            isTheme4Finished = true;

            if (isTheme4Finished == true) {
                contextTheme4.SetActive(false);

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[3].SetActive(true);
                antiText[3].SetActive(true);

                theme4Pro.text = "The EU is winning the battle against illegal migration and the problems it causes.";
                theme4Anti.text = "Immigrants threaten our safety, our property, and the quality of life in general. The government should protect our people and close the borders.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void Theme4Selected() {
        if (hasPlayerSelected == true) {
            hasPlayerSelected = false;
            proText[3].SetActive(false);
            antiText[3].SetActive(false);
            playerSelection.SetActive(false);
            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //store data
            //put into UnityAnalytics when available

            //instead of moving on to the next area, we will give the player feedback at this stage, with a final tool feedback screen.
            contextTheme5.SetActive(true);
            responseBox.SetActive(true);
        }
    }

    public void Theme5NextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            statementTextDisplay.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 0) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 1) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }
        }
        else {
            statementTextDisplay.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            isTheme5Finished = true;

            if (isTheme5Finished == true) {
                contextTheme5.SetActive(false);

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[4].SetActive(true);
                antiText[4].SetActive(true);

                theme5Pro.text = "When I see immigrants I feel sad, empathetic, and compassionate.";
                theme5Anti.text = "When I see immigrants I can't help feeling angry, resentful, hatred, disgust and contempt.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void Theme5Selected() {
        if (hasPlayerSelected == true) {
            hasPlayerSelected = false;
            proText[4].SetActive(false);
            antiText[4].SetActive(false);
            playerSelection.SetActive(false);
            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //StartTask3();

            //store data
            //put into UnityAnalytics when available

            //instead of moving on to the next area, we will give the player feedback at this stage, with a final tool feedback screen.
            contextTheme6.SetActive(true);
            responseBox.SetActive(true);
        }
    }

    public void Theme6NextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            statementTextDisplay.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 0) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 1) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }

        }
        else {
            statementTextDisplay.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            isTheme6Finished = true;

            if (isTheme6Finished == true) {
                contextTheme6.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[5].SetActive(true);
                antiText[5].SetActive(true);

                theme6Pro.text = "Migrants is a key driver of economic growth in the country; they are more likely to pay taxes than claiming benefits.";
                theme6Anti.text = "There are a lot of social inequalities in European countries because immigrants are taking many good jobs.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void Theme6Selected() {
        if (hasPlayerSelected == true) {
            hasPlayerSelected = false;
            proText[5].SetActive(false);
            antiText[5].SetActive(false);
            playerSelection.SetActive(false);
            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //store data
            //put into Unity Analytics when available
            contextTheme7.SetActive(true);
            responseBox.SetActive(true);
        }
    }

    public void Theme7NextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            statementTextDisplay.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 0) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 1) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }

        }
        else {
            statementTextDisplay.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            isTheme7Finished = true;

            if (isTheme7Finished == true) {
                contextTheme7.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[6].SetActive(true);
                antiText[6].SetActive(true);

                theme7Pro.text = "We need to appreciate more of the achievements and the power we have as European countries. There is no real reason to be afraid of refugees and immigrants.";
                theme7Anti.text = "Immigrants are different to you and me. As immigration increases so does the rise of far right parties across Europe.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void Theme7Selected() {
        if (hasPlayerSelected == true) {
            hasPlayerSelected = false;
            proText[6].SetActive(false);
            antiText[6].SetActive(false);
            playerSelection.SetActive(false);
            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //store data
            //put into Unity Analytics when available
            contextTheme8.SetActive(true);
            responseBox.SetActive(true);
        }
    }

    public void Theme8NextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            statementTextDisplay.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 0) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 1) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }

        }
        else {
            statementTextDisplay.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            isTheme8Finished = true;

            if (isTheme8Finished == true) {
                contextTheme8.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[7].SetActive(true);
                antiText[7].SetActive(true);

                theme8Pro.text = "My grandparents were refugees. They taught me to love and appreciate this country.";
                theme8Anti.text = "The common history and the common future of Europeans is an ideological construct.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void Theme8Selected() {
        if (hasPlayerSelected == true) {
            hasPlayerSelected = false;
            proText[7].SetActive(false);
            antiText[7].SetActive(false);
            playerSelection.SetActive(false);
            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //store data
            //put into Unity Analytics when available
            contextTheme9.SetActive(true);
            responseBox.SetActive(true);
        }
    }

    public void Theme9NextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            statementTextDisplay.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 0) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 1) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }

        }
        else {
            statementTextDisplay.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            isTheme9Finished = true;

            if (isTheme9Finished == true) {
                contextTheme9.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[8].SetActive(true);
                antiText[8].SetActive(true);

                theme9Pro.text = "I really like the fact that having people from lots of different countries makes our country a more interesting and lively place to live.";
                theme9Anti.text = "Refugees and immigrants are far away from our culture. They don't really try to integrate well into our communities.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void Theme9Selected() {
        if (hasPlayerSelected == true) {
            hasPlayerSelected = false;
            proText[8].SetActive(false);
            antiText[8].SetActive(false);
            playerSelection.SetActive(false);
            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //store data
            //put into Unity Analytics when available
            contextTheme10.SetActive(true);
            responseBox.SetActive(true);
        }
    }

    public void Theme10NextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            statementTextDisplay.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 0) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 1) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }

        }
        else {
            statementTextDisplay.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            isTheme10Finished = true;

            if (isTheme10Finished == true) {
                contextTheme10.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[9].SetActive(true);
                antiText[9].SetActive(true);

                theme10Pro.text = "The EU is like a football team. We are not perfect but it is the best idea to stay together and sort out the difficult problems of the 21st century.";
                theme10Anti.text = "The way to keep Europe strong is to prevent non-European people to cross the borders.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");

                isDialogueFinished = true;
            }
        }
    }

    public void Theme10Selected() {
        if (hasPlayerSelected == true) {
            hasPlayerSelected = false;
            proText[9].SetActive(false);
            antiText[9].SetActive(false);
            playerSelection.SetActive(false);
            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);
            toolBG.SetActive(false);

            //StartTask3();
            isDialogueFinished = true;

            //store data
            //put into Unity Analytics when available

            //instead of moving on to the next area, we will give the player feedback at this stage, with a final tool feedback screen.
        }
    }

    //---------------------------------------------------------------------------------

    public void Theme1() {
        contextTheme1.SetActive(false);

        responseBox.SetActive(true);

        //proAnimationBubble.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme2() {
        contextTheme2.SetActive(false);

        responseBox.SetActive(true);

        //proAnimationBubble.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme3() {
        contextTheme3.SetActive(false);

        responseBox.SetActive(true);

        //proAnimationBubble.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme4() {
        contextTheme4.SetActive(false);

        responseBox.SetActive(true);

        //proAnimationBubble.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme5() {
        contextTheme5.SetActive(false);

        responseBox.SetActive(true);

        //proAnimationBubble.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme6() {
        contextTheme6.SetActive(false);

        responseBox.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme7() {
        contextTheme7.SetActive(false);

        responseBox.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme8() {
        contextTheme8.SetActive(false);

        responseBox.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme9() {
        contextTheme9.SetActive(false);

        responseBox.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme10() {
        contextTheme10.SetActive(false);

        responseBox.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    //-------------------------------------------------------------------

    //Add these to the Continue button then it takes
    public void ProTheme1Selected() {
        PlayerPrefs.SetString("ImmigrationDiscussion1", "Our country would not have the fantastic social mix it has today without migration.");
        Debug.Log(PlayerPrefs.GetString("ImmigrationDiscussion1"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 9;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void AntiTheme1Selected() {

        PlayerPrefs.SetString("ImmigrationDiscussion1", "The Bureaucrats in Brussels have no idea about the type of migrants we get here - and no idea how it impacts on our society - we have to live with them, they don't.");
        Debug.Log(PlayerPrefs.GetString("ImmigrationDiscussion1"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 9;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void ProTheme2Selected() {

        PlayerPrefs.SetString("ImmigrationDiscussion2", "Climate change is not an issue for only one country - we need to work together - irerspective of where we live.");
        Debug.Log(PlayerPrefs.GetString("ImmigrationDiscussion2"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 8;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void AntiTheme2Selected() {

        PlayerPrefs.SetString("ImmigrationDiscussion2", "Migrants cause overpopualtion, too much rubbish, and damage to the environment.");
        Debug.Log(PlayerPrefs.GetString("ImmigrationDiscussion2"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 8;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void ProTheme3Selected() {

        PlayerPrefs.SetString("ImmigrationDiscussion3", "Immigrants should have all the rights and the responsibilities that other EU citizens have.");
        Debug.Log(PlayerPrefs.GetString("ImmigrationDiscussion3"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 7;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void AntiTheme3Selected() {

        PlayerPrefs.SetString("ImmigrationDiscussion3", "I can understand why people in certain areas feel threatened by immigration - they feel the immigrants have more rights than they do.");
        Debug.Log(PlayerPrefs.GetString("ImmigrationDiscussion3"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 7;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void ProTheme4Selected() {

        PlayerPrefs.SetString("ImmigrationDiscussion4", "The EU is winning the battle against illegal migration and the problems it causes.");
        Debug.Log(PlayerPrefs.GetString("ImmigrationDiscussion4"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 6;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void AntiTheme4Selected() {

        PlayerPrefs.SetString("ImmigrationDiscussion4", "Immigrants threaten our safety, our property, and the quality of life in general. The government should protect our people and close the borders.");
        Debug.Log(PlayerPrefs.GetString("ImmigrationDiscussion4"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 6;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void ProTheme5Selected() {

        PlayerPrefs.SetString("ImmigrationDiscussion5", "When I see immigrants I feel sad, empathetic, and compassionate.");
        Debug.Log(PlayerPrefs.GetString("ImmigrationDiscussion5"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 5;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void AntiTheme5Selected() {

        PlayerPrefs.SetString("ImmigrationDiscussion5", "When I see immigrants I can't help feeling angry, resentful, hatred, disgust and contempt.");
        Debug.Log(PlayerPrefs.GetString("ImmigrationDiscussion5"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 5;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void ProTheme6Selected() {

        PlayerPrefs.SetString("ImmigrationDiscussion6", "Migrants is a key driver of economic growth in the country; they are more likely to pay taxes than claiming benefits.");
        Debug.Log(PlayerPrefs.GetString("ImmigrationDiscussion6"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 4;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void AntiTheme6Selected() {

        PlayerPrefs.SetString("ImmigrationDiscussion6", "There are a lot of social inequalities in European countries because immigrants are taking many good jobs.");
        Debug.Log(PlayerPrefs.GetString("ImmigrationDiscussion6"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 4;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void ProTheme7Selected() {

        PlayerPrefs.SetString("ImmigrationDiscussion7", "We need to appreciate more of the achievements and the power we have as European countries. There is no real reason to be afraid of refugees and immigrants.");
        Debug.Log(PlayerPrefs.GetString("ImmigrationDiscussion7"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 3;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void AntiTheme7Selected() {

        PlayerPrefs.SetString("ImmigrationDiscussion7", "Immigrants are different to you and me. As immigration increases so does the rise of far right parties across Europe.");
        Debug.Log(PlayerPrefs.GetString("ImmigrationDiscussion7"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 3;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void ProTheme8Selected() {

        PlayerPrefs.SetString("ImmigrationDiscussion8", "My grandparents were refugees. They taught me to love and appreciate this country.");
        Debug.Log(PlayerPrefs.GetString("ImmigrationDiscussion8"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 2;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void AntiTheme8Selected() {

        PlayerPrefs.SetString("ImmigrationDiscussion8", "The common history and the common future of Europeans is an ideological construct.");
        Debug.Log(PlayerPrefs.GetString("ImmigrationDiscussion8"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 2;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void ProTheme9Selected() {

        PlayerPrefs.SetString("ImmigrationDiscussion9", "I really like the fact that having people from lots of different countries makes our country a more interesting and lively place to live.");
        Debug.Log(PlayerPrefs.GetString("ImmigrationDiscussion9"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 1;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void AntiTheme9Selected() {

        PlayerPrefs.SetString("ImmigrationDiscussion9", "Refugees and immigrants are far away from our culture. They don't really try to integrate well into our communities.");
        Debug.Log(PlayerPrefs.GetString("ImmigrationDiscussion9"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 1;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void ProTheme10Selected() {

        PlayerPrefs.SetString("ImmigrationDiscussion10", "The EU is like a football team. We are not perfect but it is the best idea to stay together and sort out the difficult problems of the 21st century.");
        Debug.Log(PlayerPrefs.GetString("ImmigrationDiscussion10"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 0;
        Debug.Log("countdown: " + countdown);

        isDialogueFinished = true;
    }

    //Add these to the Continue button then it takes
    public void AntiTheme10Selected() {

        PlayerPrefs.SetString("ImmigrationDiscussion10", "The way to keep Europe strong is to prevent non-European people to cross the borders.");
        Debug.Log(PlayerPrefs.GetString("ImmigrationDiscussion10"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 0;
        Debug.Log("countdown: " + countdown);

        isDialogueFinished = true;
    }
}
