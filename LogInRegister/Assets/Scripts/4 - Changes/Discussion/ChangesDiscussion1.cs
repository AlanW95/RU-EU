using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangesDiscussion1 : MonoBehaviour
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

    //public GameObject contextProCharacter;

    public Animator animPro, animAnti;
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
    void Start() {
        startCanvas.SetActive(true);

        FloatingTextController.Initialize();
    }

    // Update is called once per frame
    void Update() {
        if (statementTextDisplay.text == discussion2[index]) {
            continueButton.SetActive(true);
        }

        /*if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("ChangesJournalist");
        }*/

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
        SceneManager.LoadScene("ChangesJournalist");
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
            continueButton.SetActive(false);
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

            animText.SetTrigger("Change");

            StartCoroutine(Type());

            if (index == 0) {
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

            isTheme1Finished = true;

            if (isTheme1Finished == true) {
                contextTheme1.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);


                proText[0].SetActive(true);
                antiText[0].SetActive(true);
                theme1Pro.text = "Since cost of roaming in the EU has been eliminated, I can stay in touch with friends and family without additional cost.";
                theme1Anti.text = "Emigration of educated people, combined with immigration of non-educated people, leaves my country in deep problems.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);

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

            StartCoroutine(Type());

            if (index == 0) {
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

                theme2Pro.text = "I think that the whole EU needs to insist on a consistent no-GMO policy.";
                theme2Anti.text = "EU regulations have placed negative restrictions to our economy. Whole industries, such as fishing, have been impacted.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);

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

            StartCoroutine(Type());

            if (index == 0) {
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

                theme3Pro.text = "What I really like about the EU, are the Marketing standards for fresh fruit and vegetables. Since these arrived into power, I feel much more confident when I shop my food.";
                theme3Anti.text = "The Marketing standards for fresh fruit and vegetables are terrible. Since these arrived into power, our local producers are losing from global EU traders.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);

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

            StartCoroutine(Type());

            if (index == 0) {
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

                theme4Pro.text = "General Data Protection Regulation (GDPR) is really good for the EU. I now feel that my data, as a citizen of the EU, is much safer.";
                theme4Anti.text = "EU did bring about more political stability!";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);

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

            StartCoroutine(Type());

            if (index == 0) {
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

                theme5Pro.text = "My daughter went abroad to study at a more developed EU country.She met her husband, got married, and never returned home.";
                theme5Anti.text = "I am absolutely against any further expansion of the EU.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);

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

            StartCoroutine(Type());

            if (index == 0) {
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

            isTheme6Finished = true;

            if (isTheme6Finished == true) {
                contextTheme6.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[5].SetActive(true);
                antiText[5].SetActive(true);

                theme6Pro.text = "I expected the EU will contribute more to economic prosperity of my country.";
                theme6Anti.text = "I don't think that mobility of workers is a good thing. All they bring is dishonest competition which brings down wages at home.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);

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

            StartCoroutine(Type());

            if (index == 0) {
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

            isTheme7Finished = true;

            if (isTheme7Finished == true) {
                contextTheme7.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[6].SetActive(true);
                antiText[6].SetActive(true);

                theme7Pro.text = "I am for expansion of EU in the Balkans, because that would result in much more stability.";
                theme7Anti.text = "We pay more tax to the EU than we get back from EU programs. It is time to stop this extraction of value.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);

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

            StartCoroutine(Type());

            if (index == 0) {
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

            isTheme8Finished = true;

            if (isTheme8Finished == true) {
                contextTheme8.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[7].SetActive(true);
                antiText[7].SetActive(true);

                theme8Pro.text = "After new members have joined the EU in 2014, we have seen a surge in migration.";
                theme8Anti.text = "I used to be for the EU, but now I changed my mind. I am glad that the UK decided to go for Brexit; that will be the beginning of the end of the EU.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);

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

            StartCoroutine(Type());

            if (index == 0) {
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

            isTheme9Finished = true;

            if (isTheme9Finished == true) {
                contextTheme9.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[8].SetActive(true);
                antiText[8].SetActive(true);

                theme9Pro.text = "I resist further expansion of the EU. Especially, I think that countries such as Turkey will never completely understand EU values.";
                theme9Anti.text = "People coming radically different cultures do not easily blend into our workplaces.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);

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

            StartCoroutine(Type());

            if (index == 0) {
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

            isTheme10Finished = true;

            if (isTheme10Finished == true) {
                contextTheme10.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[9].SetActive(true);
                antiText[9].SetActive(true);

                theme10Pro.text = "I do not support the EU as strongly as I used to. I am still pro-European, but also much more careful than before.";
                theme10Anti.text = "I used to be for the EU, but now I changed my mind. I am glad that the UK decided to go for Brexit; that will be the beginning of the end of the EU.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);

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

        StartCoroutine(Type());
    }

    public void Theme2() {
        contextTheme2.SetActive(false);

        responseBox.SetActive(true);

        //proAnimationBubble.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme3() {
        contextTheme3.SetActive(false);

        responseBox.SetActive(true);

        //proAnimationBubble.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme4() {
        contextTheme4.SetActive(false);

        responseBox.SetActive(true);

        //proAnimationBubble.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme5() {
        contextTheme5.SetActive(false);

        responseBox.SetActive(true);

        //proAnimationBubble.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme6() {
        contextTheme6.SetActive(false);

        responseBox.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme7() {
        contextTheme7.SetActive(false);

        responseBox.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme8() {
        contextTheme8.SetActive(false);

        responseBox.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme9() {
        contextTheme9.SetActive(false);

        responseBox.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Theme10() {
        contextTheme10.SetActive(false);

        responseBox.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    //-------------------------------------------------------------------

    //Discussion Theme 1 - SOCIAL

    //Add these to the Continue button then it takes
    public void ProTheme1Selected() {
        PlayerPrefs.SetString("ChangesDiscussion1", "Since cost of roaming in the EU has been eliminated, I can stay in touch with friends and family without additional cost.");
        Debug.Log(PlayerPrefs.GetString("ChangesDiscussion1"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 9;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void AntiTheme1Selected() {

        PlayerPrefs.SetString("ChangesDiscussion1", "Emigration of educated people, combined with immigration of non-educated people, leaves my country in deep problems.");
        Debug.Log(PlayerPrefs.GetString("ChangesDiscussion1"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 9;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void ProTheme2Selected() {

        PlayerPrefs.SetString("ChangesDiscussion2", "I think that the whole EU needs to insist on a consistent no-GMO policy.");
        Debug.Log(PlayerPrefs.GetString("ChangesDiscussion2"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 8;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void AntiTheme2Selected() {

        PlayerPrefs.SetString("ChangesDiscussion2", "EU regulations have placed negative restrictions to our economy. Whole industries, such as fishing, have been impacted.");
        Debug.Log(PlayerPrefs.GetString("ChangesDiscussion2"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 8;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void ProTheme3Selected() {

        PlayerPrefs.SetString("ChangesDiscussion3", "What I really like about the EU, are the Marketing standards for fresh fruit and vegetables. Since these arrived into power, I feel much more confident when I shop my food.");
        Debug.Log(PlayerPrefs.GetString("ChangesDiscussion3"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 7;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void AntiTheme3Selected() {

        PlayerPrefs.SetString("ChangesDiscussion3", "The Marketing standards for fresh fruit and vegetables are terrible. Since these arrived into power, our local producers are losing from global EU traders.");
        Debug.Log(PlayerPrefs.GetString("ChangesDiscussion3"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 7;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void ProTheme4Selected() {

        PlayerPrefs.SetString("ChangesDiscussion4", "General Data Protection Regulation (GDPR) is really good for the EU. I now feel that my data, as a citizen of the EU, is much safer.");
        Debug.Log(PlayerPrefs.GetString("ChangesDiscussion4"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 6;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void AntiTheme4Selected() {

        PlayerPrefs.SetString("ChangesDiscussion4", "EU did bring about more political stability!");
        Debug.Log(PlayerPrefs.GetString("ChangesDiscussion4"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 6;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void ProTheme5Selected() {

        PlayerPrefs.SetString("ChangesDiscussion5", "My daughter went abroad to study at a more developed EU country. She met her husband, got married, and never returned home.");
        Debug.Log(PlayerPrefs.GetString("ChangesDiscussion5"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 5;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void AntiTheme5Selected() {

        PlayerPrefs.SetString("ChangesDiscussion5", "I am absolutely against any further expansion of the EU.");
        Debug.Log(PlayerPrefs.GetString("ChangesDiscussion5"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 5;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void ProTheme6Selected() {

        PlayerPrefs.SetString("ChangesDiscussion6", "I expected the EU will contribute more to economic prosperity of my country.");
        Debug.Log(PlayerPrefs.GetString("ChangesDiscussion6"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 4;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void AntiTheme6Selected() {

        PlayerPrefs.SetString("ChangesDiscussion6", "I don't think that mobility of workers is a good thing. All they bring is dishonest competition which brings down wages at home.");
        Debug.Log(PlayerPrefs.GetString("ChangesDiscussion6"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 4;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void ProTheme7Selected() {

        PlayerPrefs.SetString("ChangesDiscussion7", "I am for expansion of EU in the Balkans, because that would result in much more stability.");
        Debug.Log(PlayerPrefs.GetString("ChangesDiscussion7"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 3;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void AntiTheme7Selected() {

        PlayerPrefs.SetString("ChangesDiscussion7", "We pay more tax to the EU than we get back from EU programs. It is time to stop this extraction of value.");
        Debug.Log(PlayerPrefs.GetString("ChangesDiscussion7"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 3;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void ProTheme8Selected() {

        PlayerPrefs.SetString("ChangesDiscussion8", "After new members have joined the EU in 2014, we have seen a surge in migration.");
        Debug.Log(PlayerPrefs.GetString("ChangesDiscussion8"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 2;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void AntiTheme8Selected() {

        PlayerPrefs.SetString("ChangesDiscussion8", "I used to be for the EU, but now I changed my mind. I am glad that the UK decided to go for Brexit; that will be the beginning of the end of the EU.");
        Debug.Log(PlayerPrefs.GetString("ChangesDiscussion8"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 2;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void ProTheme9Selected() {

        PlayerPrefs.SetString("ChangesDiscussion9", "I resist further expansion of the EU. Especially, I think that countries such as Turkey will never completely understand EU values.");
        Debug.Log(PlayerPrefs.GetString("ChangesDiscussion9"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 1;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void AntiTheme9Selected() {

        PlayerPrefs.SetString("ChangesDiscussion9", "People coming radically different cultures do not easily blend into our workplaces.");
        Debug.Log(PlayerPrefs.GetString("ChangesDiscussion9"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 1;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void ProTheme10Selected() {

        PlayerPrefs.SetString("ChangesDiscussion10", "I do not support the EU as strongly as I used to. I am still pro-European, but also much more careful than before.");
        Debug.Log(PlayerPrefs.GetString("ChangesDiscussion10"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 0;
        Debug.Log("countdown: " + countdown);

        isDialogueFinished = true;
    }

    //Add these to the Continue button then it takes
    public void AntiTheme10Selected() {

        PlayerPrefs.SetString("ChangesDiscussion10", "I used to be for the EU, but now I changed my mind. I am glad that the UK decided to go for Brexit; that will be the beginning of the end of the EU.");
        Debug.Log(PlayerPrefs.GetString("ChangesDiscussion10"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 0;
        Debug.Log("countdown: " + countdown);

        isDialogueFinished = true;
    }
}
