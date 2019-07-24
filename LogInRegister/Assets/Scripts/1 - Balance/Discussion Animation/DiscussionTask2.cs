using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DiscussionTask2 : MonoBehaviour
{
    //public GameObject[] task2StartCanvas;

    public TextMeshProUGUI textDisplay2;

    //Task 2
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

    //public GameObject proAnimationBubble;
    //public GameObject antiAnimationBubble;
    //public GameObject undecidedAnimationBubble;

    //interview style response boxes
    public GameObject responseBox;

    //Dialogue 1
    private bool isSocialFinished = false;
    private bool isEnvironmentFinished = false;
    private bool isCivicFinished = false;
    private bool isSafetyAndSecurityFinished = false;
    private bool isEmotionalFinished = false;

    //Dialogue 2
    private bool isEconomicFinished = false;
    private bool isPoliticalFinished = false;
    private bool isHistoricFinished = false;
    private bool isCultureFinished = false;
    private bool isGeographyFinished = false;

    //Dialogue 1 Context
    public GameObject contextSocial;
    public GameObject contextEnvironment;
    public GameObject contextCivic;
    public GameObject contextSafetySecurity;
    public GameObject contextEmotional;

    //Dialogue 2 Context
    public GameObject contextEconomic;
    public GameObject contextPolitical;
    public GameObject contextHistoric;
    public GameObject contextCulture;
    public GameObject contextGeography;

    public GameObject task1Selection;
    public GameObject playerSelection;
    public GameObject[] proText, antiText;
    public TextMeshProUGUI socialPro, environmentPro, rightsResponsibilitiesPro, safetySecurityPro, emotionalPro, economicPro, politicalPro, historicPro, culturePro, geographyPro;
    public TextMeshProUGUI socialAnti, environmentAnti, rightsResponsibilitiesAnti, safetySecurityAnti, emotionalAnti, economicAnti, politicalAnti, historicAnti, cultureAnti, geographyAnti;
    private bool hasPlayerSelected = false;

    public Button dialogue1, dialogue2;
    private bool isDialogue1Finished = false;
    private bool isDialogue2Finished = false;
    public GameObject task2FullCanvas;
    //public GameObject[] task2Canvas;

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

    // Start is called before the first frame update
    void Start()
    {
        //called from clicking button that leads to Task 2

        FloatingTextController.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (textDisplay2.text == discussion2[index]) {
            continueButton.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Journalist");
        }

        //StatementsSelected();

        if (countdown == 0)
        {
            //give feedback
            //this is placement at the moment
            //task2FullCanvas.SetActive(false);
            //task3.SetActive(true);
            Debug.Log("Both dialogues have been complete!");
            task2FullCanvas.SetActive(false);
            task3.SetActive(true);

            toolBG.SetActive(false);
        }
    }

    IEnumerator Type() {
        foreach (char letter in discussion2[index].ToCharArray()) {
            textDisplay2.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //Task 2 is relatively the same as the original way we had the Discussion tool but this time after each one, 
    //the player will be asked if they find the pro or anti more convincing to be used later on.
    public void StartTask2() {
        Debug.Log("This button has been pressed!");
        //startCanvas.SetActive(false);
        //task2StartCanvas[0].SetActive(false);
        //task2StartCanvas[1].SetActive(false);
        //task2StartCanvas[2].SetActive(false);
        task1Selection.SetActive(false);
        task2FullCanvas.SetActive(false);

        toolBG.SetActive(true);
        proCharacter.SetActive(false);
        antiCharacter.SetActive(false);
        undecidedCharacter.SetActive(false);

        //proAnimationBubble.SetActive(false);
        //antiAnimationBubble.SetActive(false);
        //undecidedAnimationBubble.SetActive(false);

        responseBox.SetActive(false);

        playerSelection.SetActive(false);

        /* When the tool first begins the player will be presented with the first context.
         * Everything will be SetActive(false) except the context for Social to begin.
         */

        //context statements for DIALOGUE 1
        //set false as they don't appear straight away
        contextSocial.SetActive(true); //first for testing at the moment
        contextEnvironment.SetActive(false);
        contextCivic.SetActive(false);
        contextSafetySecurity.SetActive(false);
        contextEmotional.SetActive(false);

        //context statements for DIALOGUE 2
        contextEconomic.SetActive(false);
        contextPolitical.SetActive(false);
        contextHistoric.SetActive(false);
        contextCulture.SetActive(false);
        contextGeography.SetActive(false);

        //animText.SetTrigger("Change"); //for player if added later on
    }

    public void StartTask2Dialogue2() {
        Debug.Log("This button has been pressed!");
        //startCanvas.SetActive(false);

        task1Selection.SetActive(false);
        task2FullCanvas.SetActive(false);

        toolBG.SetActive(true);
        proCharacter.SetActive(false);
        antiCharacter.SetActive(false);
        undecidedCharacter.SetActive(false);

        //proAnimationBubble.SetActive(false);
        //antiAnimationBubble.SetActive(false);
        //undecidedAnimationBubble.SetActive(false);

        responseBox.SetActive(false);

        playerSelection.SetActive(false);

        /* When the tool first begins the player will be presented with the first context.
         * Everything will be SetActive(false) except the context for Social to begin.
         */

        //context statements for DIALOGUE 1
        //set false as they don't appear straight away
        contextSocial.SetActive(false); //first for testing at the moment
        contextEnvironment.SetActive(false);
        contextCivic.SetActive(false);
        contextSafetySecurity.SetActive(false);
        contextEmotional.SetActive(false);

        //context statements for DIALOGUE 2
        contextEconomic.SetActive(true);
        contextPolitical.SetActive(false);
        contextHistoric.SetActive(false);
        contextCulture.SetActive(false);
        contextGeography.SetActive(false);

        //animText.SetTrigger("Change"); //for player if added later on
    }

    public void IfFinished() {
        //if either or are finished - go back to the screen
        if (isDialogue1Finished || isDialogue2Finished) {
            task2FullCanvas.SetActive(true);

            toolBG.SetActive(false);
        }

        //if both are finished - go to feedback
        if (isDialogue1Finished == true && isDialogue2Finished == true) {
            //give feedback
            //this is placement at the moment
            //task2FullCanvas.SetActive(false);
            //task3.SetActive(true);
            Debug.Log("Both dialogues have been complete!");
            task3.SetActive(true);

            toolBG.SetActive(false);
        }

        if (countdown == 0) {
            Debug.Log("Both dialogues have been complete!");
            task2FullCanvas.SetActive(false);
            task3.SetActive(true);
            toolBG.SetActive(false);
        }
    }

    //Task 3 will involve all the chosen statements from Task 2 and players must select 2 of those statements
    //they wish to keep for their Final Assignment article.

    //may be a good idea to use the PlayerPrefs similar to how the score was done
    /*public void StartTask3()
    {
        if (isDialogue1Finished && isDialogue2Finished)
        {
            //give feedback
            //this is placement at the moment
            //task2FullCanvas.SetActive(false);
            //task3.SetActive(true);
            Debug.Log("Both dialogues have been complete!");
            task2FullCanvas.SetActive(false);
            task3.SetActive(true);

            toolBG.SetActive(false);
        }
    }*/

    public void SocialNextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            textDisplay2.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            animText.SetTrigger("Change");

            StartCoroutine(Type());

            if (index == 1) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 3) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }

        } else {
            textDisplay2.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            isSocialFinished = true;

            if (isSocialFinished == true) {
                contextSocial.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);


                proText[0].SetActive(true);
                antiText[0].SetActive(true);
                socialPro.text = "But most immigrants have integrated well into this village and make a real contribution to village life.";
                socialAnti.text = "That's so not true! Most of them hang around with the people they came with and don't even try to learn English.";

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

    public void SocialSelected() {
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

            contextEnvironment.SetActive(true);
        }
    }

    public void EnvironmentNextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            textDisplay2.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 1) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 3) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }

        } else {
            textDisplay2.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            isEnvironmentFinished = true;

            if (isEnvironmentFinished == true) {
                contextEnvironment.SetActive(false);

                //contextCivic.SetActive(true); //move to EnvironmentSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[1].SetActive(true);
                antiText[1].SetActive(true);

                environmentPro.text = "The EU has done a lot to tackle climate change.";
                environmentAnti.text = "If the EU were effective we wouldn't need extinction revolution.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void EnvironmentSelected() {
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
            contextCivic.SetActive(true);
        }
    }

    public void CivicNextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            textDisplay2.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 1) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 3) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }
        } else {
            textDisplay2.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            isCivicFinished = true;

            if (isCivicFinished == true) {
                contextEnvironment.SetActive(false);

                //contextSafetySecurity.SetActive(true); // move this to CivicSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[2].SetActive(true);
                antiText[2].SetActive(true);

                rightsResponsibilitiesPro.text = "Being a member of the EU has provided fabulous opportunities for students to travel and study abroad to anyone who wants to take them.";
                rightsResponsibilitiesAnti.text = "You must be kidding - that is what Brexit is about! There are no opportunities for us ordinary folk, the opportunities are only for those who have money.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void CivicSelected() {
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
            contextSafetySecurity.SetActive(true);
        }
    }

    public void SafetyAndSecurityNextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            textDisplay2.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 1) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 3) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }
        } else {
            textDisplay2.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            isSafetyAndSecurityFinished = true;

            if (isSafetyAndSecurityFinished == true) {
                contextSafetySecurity.SetActive(false);

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[3].SetActive(true);
                antiText[3].SetActive(true);

                safetySecurityPro.text = "For me, one of the main benefits of EU membership has been to prevent war between the nations of Europe.";
                safetySecurityAnti.text = "But there's still lots of tensions between the nations of Europe. It's only a matter of time before serious trouble kicks off somewhere.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void SafetyAndSecuritySelected() {
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
            contextEmotional.SetActive(true);
        }
    }

    public void EmotionalNextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            textDisplay2.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 1) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 3) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }
        } else {
            textDisplay2.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            isEmotionalFinished = true;

            if (isEmotionalFinished == true) {
                contextEmotional.SetActive(false);

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[4].SetActive(true);
                antiText[4].SetActive(true);

                emotionalPro.text = "I'm really worried about leaving the EU. It feels like we're turning our backs on the rest of the world.";
                emotionalAnti.text = "All the people I know are really pleased about leaving Europe. We're planning a street party for when we go.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");

                isDialogue1Finished = true;
            }
        }
    }

    public void EmotionalSelected() {
        if (hasPlayerSelected == true) {
            hasPlayerSelected = false;
            proText[4].SetActive(false);
            antiText[4].SetActive(false);
            playerSelection.SetActive(false);
            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);
            toolBG.SetActive(false);

            //StartTask3();
            isDialogue1Finished = true;

            //store data
            //put into UnityAnalytics when available

            //instead of moving on to the next area, we will give the player feedback at this stage, with a final tool feedback screen.
        }
    }

    //-------------------------------------------------------------------------------

    //--------------DIALOGUE 2-------------------------------------------------------

    public void EconomicNextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            textDisplay2.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 1) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 3) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }

        } else {
            textDisplay2.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            isEconomicFinished = true;

            if (isEconomicFinished == true) {
                contextSocial.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[5].SetActive(true);
                antiText[5].SetActive(true);

                economicPro.text = "After Brexit, the UK economy could be around 6% smaller by 2030 and that would mean a loss of income equivalent to £4,300 a year for every British household.";
                economicAnti.text = "But once we've left the EU we'll be able to strike deals with the rest of the world so we'll be fine.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void EconomicSelected() {
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
            contextPolitical.SetActive(true);
        }
    }

    public void PoliticalNextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            textDisplay2.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 1) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 3) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }

        } else {
            textDisplay2.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            isPoliticalFinished = true;

            if (isPoliticalFinished == true) {
                contextPolitical.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[6].SetActive(true);
                antiText[6].SetActive(true);

                politicalPro.text = "Would you not rather have the Brussels elite in charge than UKIP and Nigel Farage?";
                politicalAnti.text = "Brussels is far too remote - we need to be making our own laws back here in the UK.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void PoliticalSelected() {
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
            contextHistoric.SetActive(true);
        }
    }

    public void HistoricNextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            textDisplay2.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 1) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 3) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }

        } else {
            textDisplay2.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            isHistoricFinished = true;

            if (isHistoricFinished == true) {
                contextHistoric.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[7].SetActive(true);
                antiText[7].SetActive(true);

                historicPro.text = "The people who want to go back in time have a very poor knowledge of European history.";
                historicAnti.text = "The UK has always felt the need to defend itself, which is why the UK doesn't feel very 'European'.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void HistoricSelected() {
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
            contextCulture.SetActive(true);
        }
    }

    public void CultureNextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            textDisplay2.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 1) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 3) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }

        } else {
            textDisplay2.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            isCultureFinished = true;

            if (isCultureFinished == true) {
                contextCulture.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[8].SetActive(true);
                antiText[8].SetActive(true);

                culturePro.text = "EU grants have funded many projects that contribute to a shared European cultural identity.";
                cultureAnti.text = "The European Union represents an unattractive homogenisation of European cultures.";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");
            }
        }
    }

    public void CultureSelected() {
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
            contextGeography.SetActive(true);
        }
    }

    public void GeographyNextSentence() {
        continueButton.SetActive(false);

        if (index < discussion2.Length - 1) {
            index++;
            textDisplay2.text = "";

            responseBox.SetActive(true);

            proCharacter.SetActive(true);
            antiCharacter.SetActive(true);
            undecidedCharacter.SetActive(true);

            StartCoroutine(Type());

            if (index == 1) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }

            if (index == 2) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            }

            if (index == 3) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            }

        } else {
            textDisplay2.text = "";
            continueButton.SetActive(false);

            responseBox.SetActive(false);

            //proAnimationBubble.SetActive(false);
            //antiAnimationBubble.SetActive(false);
            //undecidedAnimationBubble.SetActive(false);

            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            isGeographyFinished = true;

            if (isGeographyFinished == true) {
                contextGeography.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                proText[9].SetActive(true);
                antiText[9].SetActive(true);

                geographyPro.text = "I have no trouble in thinking of myself as both British and European.";
                geographyAnti.text = "Being British is much more important to me than being European - I really want a British passport!";

                proCharacter.SetActive(true);
                antiCharacter.SetActive(true);
                undecidedCharacter.SetActive(false);

                hasPlayerSelected = true; //when the player clicks on the appropriate text it will trigger it to store the information and progress
                animPro.SetTrigger("Triggered");
                animAnti.SetTrigger("Triggered");

                isDialogue2Finished = true;
            }
        }
    }

    public void GeographySelected() {
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
            isDialogue2Finished = true;

            //store data
            //put into Unity Analytics when available

            //instead of moving on to the next area, we will give the player feedback at this stage, with a final tool feedback screen.
        }
    }

    //-------------------------------------------------------------------------------

    public void Social() {
        dialogue1.interactable = false;
        contextSocial.SetActive(false);

        responseBox.SetActive(true);

        //proAnimationBubble.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Environment() {
        contextEnvironment.SetActive(false);

        responseBox.SetActive(true);

        //proAnimationBubble.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Civic() {
        contextCivic.SetActive(false);

        responseBox.SetActive(true);

        //proAnimationBubble.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void SafetyAndSecurity() {
        contextSafetySecurity.SetActive(false);

        responseBox.SetActive(true);

        //proAnimationBubble.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Emotional() {
        contextEmotional.SetActive(false);

        responseBox.SetActive(true);

        //proAnimationBubble.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Economic() {
        dialogue2.interactable = false;
        contextEconomic.SetActive(false);

        responseBox.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Political() {
        contextPolitical.SetActive(false);

        responseBox.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Historic() {
        contextHistoric.SetActive(false);

        responseBox.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Culture() {
        contextCulture.SetActive(false);

        responseBox.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    public void Geography() {
        contextGeography.SetActive(false);

        responseBox.SetActive(true);

        proCharacter.SetActive(true);
        antiCharacter.SetActive(true);
        undecidedCharacter.SetActive(true);

        StartCoroutine(Type());
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------------------

    //This is used for the statement selection at the end of each interview response in order to help store in PlayerPrefs
    //There may be easier ways to do this, but for the time being this way has been interpretated and hopefully works in the long run
    //Add these to the Continue button for each theme.
    /*public void StatementsSelected()
    {
        //-----------DISCUSSION 1------------------------------

        if (proDiscussion1 == true && antiDiscussion1 == false)
        {
            discussionCount++;

            if (discussionCount == 1) {
                PlayerPrefs.SetString("Discussion1", "But most immigrants have integrated well into this village and make a real contribution to village life.");
                Debug.Log(PlayerPrefs.GetString("Discussion1"));
            }

            if (discussionCount == 2) {
                PlayerPrefs.SetString("Discussion2", "But most immigrants have integrated well into this village and make a real contribution to village life.");
                Debug.Log(PlayerPrefs.GetString("Discussion2"));
            }

            if (discussionCount == 3) {
                PlayerPrefs.SetString("Discussion3", "But most immigrants have integrated well into this village and make a real contribution to village life.");
                Debug.Log(PlayerPrefs.GetString("Discussion3"));
            }

            if (discussionCount == 4) {
                PlayerPrefs.SetString("Discussion4", "But most immigrants have integrated well into this village and make a real contribution to village life.");
                Debug.Log(PlayerPrefs.GetString("Discussion4"));
            }
        }

        if (proDiscussion1 == false && antiDiscussion1 == true)
        {
            discussionCount++;
            
            if (discussionCount == 1) {
                PlayerPrefs.SetString("Discussion1", "That's so not true! Most of them hang around with the people they came with and don't even try to learn English.");
                Debug.Log(PlayerPrefs.GetString("Discussion1"));
            }

            if (discussionCount == 2) {
                PlayerPrefs.SetString("Discussion2", "That's so not true! Most of them hang around with the people they came with and don't even try to learn English.");
                Debug.Log(PlayerPrefs.GetString("Discussion2"));
            }

            if (discussionCount == 3) {
                PlayerPrefs.SetString("Discussion3", "That's so not true! Most of them hang around with the people they came with and don't even try to learn English.");
                Debug.Log(PlayerPrefs.GetString("Discussion3"));
            }

            if (discussionCount == 4) {
                PlayerPrefs.SetString("Discussion4", "That's so not true! Most of them hang around with the people they came with and don't even try to learn English.");
                Debug.Log(PlayerPrefs.GetString("Discussion4"));
            }
        }
        //-----------------------------------------------------

        //-----------DISCUSSION 2------------------------------

        if (proDiscussion2 == true && antiDiscussion2 == false)
        {
            discussionCount++;
            
            if (discussionCount == 1) {
                PlayerPrefs.SetString("Discussion1", "The EU has done a lot to tackle climate change.");
                Debug.Log(PlayerPrefs.GetString("Discussion1"));
            }

            if (discussionCount == 2) {
                PlayerPrefs.SetString("Discussion2", "The EU has done a lot to tackle climate change.");
                Debug.Log(PlayerPrefs.GetString("Discussion2"));
            }

            if (discussionCount == 3) {
                PlayerPrefs.SetString("Discussion3", "The EU has done a lot to tackle climate change.");
                Debug.Log(PlayerPrefs.GetString("Discussion3"));
            }

            if (discussionCount == 4) {
                PlayerPrefs.SetString("Discussion4", "The EU has done a lot to tackle climate change.");
                Debug.Log(PlayerPrefs.GetString("Discussion4"));
            }
        }

        if (proDiscussion2 == false && antiDiscussion2 == true)
        {
            discussionCount++;
            
            if (discussionCount == 1) {
                PlayerPrefs.SetString("Discussion1", "If the EU were effective we wouldn't need extinction revolution.");
                Debug.Log(PlayerPrefs.GetString("Discussion1"));
            }

            if (discussionCount == 2) {
                PlayerPrefs.SetString("Discussion2", "If the EU were effective we wouldn't need extinction revolution.");
                Debug.Log(PlayerPrefs.GetString("Discussion2"));
            }

            if (discussionCount == 3) {
                PlayerPrefs.SetString("Discussion3", "If the EU were effective we wouldn't need extinction revolution.");
                Debug.Log(PlayerPrefs.GetString("Discussion3"));
            }

            if (discussionCount == 4) {
                PlayerPrefs.SetString("Discussion4", "If the EU were effective we wouldn't need extinction revolution.");
                Debug.Log(PlayerPrefs.GetString("Discussion4"));
            }
        }

        //-----------------------------------------------------

        //-----------DISCUSSION 3------------------------------

        if (proDiscussion3 == true && antiDiscussion3 == false)
        {
            discussionCount++;

            if (discussionCount == 1) {
                PlayerPrefs.SetString("Discussion1", "Being a member of the EU has provided fabulous opportunities for students to travel and study abroad to anyone who wants to take them.");
                Debug.Log(PlayerPrefs.GetString("Discussion1"));
            }

            if (discussionCount == 2) {
                PlayerPrefs.SetString("Discussion2", "Being a member of the EU has provided fabulous opportunities for students to travel and study abroad to anyone who wants to take them.");
                Debug.Log(PlayerPrefs.GetString("Discussion2"));
            }

            if (discussionCount == 3) {
                PlayerPrefs.SetString("Discussion3", "Being a member of the EU has provided fabulous opportunities for students to travel and study abroad to anyone who wants to take them.");
                Debug.Log(PlayerPrefs.GetString("Discussion3"));
            }

            if (discussionCount == 4) {
                PlayerPrefs.SetString("Discussion4", "Being a member of the EU has provided fabulous opportunities for students to travel and study abroad to anyone who wants to take them.");
                Debug.Log(PlayerPrefs.GetString("Discussion4"));
            }
        }

        if (proDiscussion3 == false && antiDiscussion3 == true)
        {
            discussionCount++;

            if (discussionCount == 1) {
                PlayerPrefs.SetString("Discussion1", "You must be kidding - that is what Brexit is all about! There are no opportunities for us ordinary folk, the opportunities are only for those who have money.");
                Debug.Log(PlayerPrefs.GetString("Discussion1"));
            }

            if (discussionCount == 2) {
                PlayerPrefs.SetString("Discussion2", "You must be kidding - that is what Brexit is all about! There are no opportunities for us ordinary folk, the opportunities are only for those who have money.");
                Debug.Log(PlayerPrefs.GetString("Discussion2"));
            }

            if (discussionCount == 3) {
                PlayerPrefs.SetString("Discussion3", "You must be kidding - that is what Brexit is all about! There are no opportunities for us ordinary folk, the opportunities are only for those who have money.");
                Debug.Log(PlayerPrefs.GetString("Discussion3"));
            }

            if (discussionCount == 4) {
                PlayerPrefs.SetString("Discussion4", "You must be kidding - that is what Brexit is all about! There are no opportunities for us ordinary folk, the opportunities are only for those who have money.");
                Debug.Log(PlayerPrefs.GetString("Discussion4"));
            }
        }

        //-----------------------------------------------------

        //-----------DISCUSSION 4------------------------------

        if (proDiscussion4 == true && antiDiscussion4 == false)
        {
            discussionCount++;

            if (discussionCount == 1) {
                PlayerPrefs.SetString("Discussion1", "For me, one of the main benefits of EU membership has been to prevent war between the nations of Europe.");
                Debug.Log(PlayerPrefs.GetString("Discussion1"));
            }

            if (discussionCount == 2) {
                PlayerPrefs.SetString("Discussion2", "For me, one of the main benefits of EU membership has been to prevent war between the nations of Europe.");
                Debug.Log(PlayerPrefs.GetString("Discussion2"));
            }

            if (discussionCount == 3) {
                PlayerPrefs.SetString("Discussion3", "For me, one of the main benefits of EU membership has been to prevent war between the nations of Europe.");
                Debug.Log(PlayerPrefs.GetString("Discussion3"));
            }

            if (discussionCount == 4) {
                PlayerPrefs.SetString("Discussion4", "For me, one of the main benefits of EU membership has been to prevent war between the nations of Europe.");
                Debug.Log(PlayerPrefs.GetString("Discussion4"));
            }
        }

        if (proDiscussion4 == false && antiDiscussion4 == true)
        {
            discussionCount++;

            if (discussionCount == 1) {
                PlayerPrefs.SetString("Discussion1", "But there's still lots of tensions between the nations of Europe. It's only a matter of time before serious trouble kicks off somewhere.");
                Debug.Log(PlayerPrefs.GetString("Discussion1"));
            }

            if (discussionCount == 2) {
                PlayerPrefs.SetString("Discussion2", "But there's still lots of tensions between the nations of Europe. It's only a matter of time before serious trouble kicks off somewhere.");
                Debug.Log(PlayerPrefs.GetString("Discussion2"));
            }

            if (discussionCount == 3) {
                PlayerPrefs.SetString("Discussion3", "But there's still lots of tensions between the nations of Europe. It's only a matter of time before serious trouble kicks off somewhere.");
                Debug.Log(PlayerPrefs.GetString("Discussion3"));
            }

            if (discussionCount == 4) {
                PlayerPrefs.SetString("Discussion4", "But there's still lots of tensions between the nations of Europe. It's only a matter of time before serious trouble kicks off somewhere.");
                Debug.Log(PlayerPrefs.GetString("Discussion4"));
            }
        }

        //-----------------------------------------------------

        //-----------DISCUSSION 5------------------------------

        if (proDiscussion5 == true && antiDiscussion5 == false)
        {
            discussionCount++;

            if (discussionCount == 1) {
                PlayerPrefs.SetString("Discussion1", "I'm really worried about leaving the EU. It feels like we're turning our backs on the rest of the world.");
                Debug.Log(PlayerPrefs.GetString("Discussion1"));
            }

            if (discussionCount == 2) {
                PlayerPrefs.SetString("Discussion2", "I'm really worried about leaving the EU. It feels like we're turning our backs on the rest of the world.");
                Debug.Log(PlayerPrefs.GetString("Discussion2"));
            }

            if (discussionCount == 3) {
                PlayerPrefs.SetString("Discussion3", "I'm really worried about leaving the EU. It feels like we're turning our backs on the rest of the world.");
                Debug.Log(PlayerPrefs.GetString("Discussion3"));
            }

            if (discussionCount == 4) {
                PlayerPrefs.SetString("Discussion4", "I'm really worried about leaving the EU. It feels like we're turning our backs on the rest of the world.");
                Debug.Log(PlayerPrefs.GetString("Discussion4"));
            }
        }

        if (proDiscussion5 == false && antiDiscussion5 == true)
        {
            discussionCount++;

            if (discussionCount == 1) {
                PlayerPrefs.SetString("Discussion1", "All the people I know are really pleased about leaving Europe. We're planning a street party for when we go.");
                Debug.Log(PlayerPrefs.GetString("Discussion1"));
            }

            if (discussionCount == 2) {
                PlayerPrefs.SetString("Discussion2", "All the people I know are really pleased about leaving Europe. We're planning a street party for when we go.");
                Debug.Log(PlayerPrefs.GetString("Discussion2"));
            }

            if (discussionCount == 3) {
                PlayerPrefs.SetString("Discussion3", "All the people I know are really pleased about leaving Europe. We're planning a street party for when we go.");
                Debug.Log(PlayerPrefs.GetString("Discussion3"));
            }

            if (discussionCount == 4) {
                PlayerPrefs.SetString("Discussion4", "All the people I know are really pleased about leaving Europe. We're planning a street party for when we go.");
                Debug.Log(PlayerPrefs.GetString("Discussion4"));
            }
        }

        //-----------------------------------------------------

        //-----------DISCUSSION 6------------------------------

        if (proDiscussion6 == true && antiDiscussion6 == false)
        {
            discussionCount++;

            if (discussionCount == 1) {
                PlayerPrefs.SetString("Discussion1", "After Brexit, the UK economy could be around 6% smaller by 2030 and that would mean a loss of income equivalent to £4,300 a year for every British household.");
                Debug.Log(PlayerPrefs.GetString("Discussion1"));
            }

            if (discussionCount == 2) {
                PlayerPrefs.SetString("Discussion2", "After Brexit, the UK economy could be around 6% smaller by 2030 and that would mean a loss of income equivalent to £4,300 a year for every British household.");
                Debug.Log(PlayerPrefs.GetString("Discussion2"));
            }

            if (discussionCount == 3) {
                PlayerPrefs.SetString("Discussion3", "After Brexit, the UK economy could be around 6% smaller by 2030 and that would mean a loss of income equivalent to £4,300 a year for every British household.");
                Debug.Log(PlayerPrefs.GetString("Discussion3"));
            }

            if (discussionCount == 4) {
                PlayerPrefs.SetString("Discussion4", "After Brexit, the UK economy could be around 6% smaller by 2030 and that would mean a loss of income equivalent to £4,300 a year for every British household.");
                Debug.Log(PlayerPrefs.GetString("Discussion4"));
            }
        }

        if (proDiscussion6 == false && antiDiscussion6 == true)
        {
            discussionCount++;

            if (discussionCount == 1) {
                PlayerPrefs.SetString("Discussion1", "But once we've left the EU, we'll be able to strike deals with the rest of the world so we'll be fine.");
                Debug.Log(PlayerPrefs.GetString("Discussion1"));
            }

            if (discussionCount == 2) {
                PlayerPrefs.SetString("Discussion2", "But once we've left the EU, we'll be able to strike deals with the rest of the world so we'll be fine.");
                Debug.Log(PlayerPrefs.GetString("Discussion2"));
            }

            if (discussionCount == 3) {
                PlayerPrefs.SetString("Discussion3", "But once we've left the EU, we'll be able to strike deals with the rest of the world so we'll be fine.");
                Debug.Log(PlayerPrefs.GetString("Discussion3"));
            }

            if (discussionCount == 4) {
                PlayerPrefs.SetString("Discussion4", "But once we've left the EU, we'll be able to strike deals with the rest of the world so we'll be fine.");
                Debug.Log(PlayerPrefs.GetString("Discussion4"));
            }
        }

        //-----------------------------------------------------

        //-----------DISCUSSION 7------------------------------

        if (proDiscussion7 == true && antiDiscussion7 == false)
        {
            discussionCount++;

            if (discussionCount == 1) {
                PlayerPrefs.SetString("Discussion1", "Would you not rather have the Brussels elite in charge than UKIP and Nigel Farage?");
                Debug.Log(PlayerPrefs.GetString("Discussion1"));
            }

            if (discussionCount == 2) {
                PlayerPrefs.SetString("Discussion2", "Would you not rather have the Brussels elite in charge than UKIP and Nigel Farage?");
                Debug.Log(PlayerPrefs.GetString("Discussion2"));
            }

            if (discussionCount == 3) {
                PlayerPrefs.SetString("Discussion3", "Would you not rather have the Brussels elite in charge than UKIP and Nigel Farage?");
                Debug.Log(PlayerPrefs.GetString("Discussion3"));
            }

            if (discussionCount == 4) {
                PlayerPrefs.SetString("Discussion4", "Would you not rather have the Brussels elite in charge than UKIP and Nigel Farage?");
                Debug.Log(PlayerPrefs.GetString("Discussion4"));
            }
        }

        if (proDiscussion7 == false && antiDiscussion7 == true)
        {
            discussionCount++;

            if (discussionCount == 1) {
                PlayerPrefs.SetString("Discussion1", "Brussels is far too remote - we need to be making our own laws back here in the UK.");
                Debug.Log(PlayerPrefs.GetString("Discussion1"));
            }

            if (discussionCount == 2) {
                PlayerPrefs.SetString("Discussion2", "Brussels is far too remote - we need to be making our own laws back here in the UK.");
                Debug.Log(PlayerPrefs.GetString("Discussion2"));
            }

            if (discussionCount == 3) {
                PlayerPrefs.SetString("Discussion3", "Brussels is far too remote - we need to be making our own laws back here in the UK.");
                Debug.Log(PlayerPrefs.GetString("Discussion3"));
            }

            if (discussionCount == 4) {
                PlayerPrefs.SetString("Discussion4", "Brussels is far too remote - we need to be making our own laws back here in the UK.");
                Debug.Log(PlayerPrefs.GetString("Discussion4"));
            }
        }

        //-----------------------------------------------------

        //-----------DISCUSSION 8------------------------------

        if (proDiscussion8 == true && antiDiscussion8 == false)
        {
            discussionCount++;

            if (discussionCount == 1) {
                PlayerPrefs.SetString("Discussion1", "The people who want to go back in time have a very poor knowledge of European history.");
                Debug.Log(PlayerPrefs.GetString("Discussion1"));
            }

            if (discussionCount == 2) {
                PlayerPrefs.SetString("Discussion2", "The people who want to go back in time have a very poor knowledge of European history.");
                Debug.Log(PlayerPrefs.GetString("Discussion2"));
            }

            if (discussionCount == 3) {
                PlayerPrefs.SetString("Discussion3", "The people who want to go back in time have a very poor knowledge of European history.");
                Debug.Log(PlayerPrefs.GetString("Discussion3"));
            }

            if (discussionCount == 4) {
                PlayerPrefs.SetString("Discussion4", "The people who want to go back in time have a very poor knowledge of European history.");
                Debug.Log(PlayerPrefs.GetString("Discussion4"));
            }
        }

        if (proDiscussion8 == false && antiDiscussion8 == true)
        {
            discussionCount++;

            if (discussionCount == 1) {
                PlayerPrefs.SetString("Discussion1", "The UK has always felt the need to defend itself, which is why the UK doesn't feel very 'European'.");
                Debug.Log(PlayerPrefs.GetString("Discussion1"));
            }

            if (discussionCount == 2) {
                PlayerPrefs.SetString("Discussion2", "The UK has always felt the need to defend itself, which is why the UK doesn't feel very 'European'.");
                Debug.Log(PlayerPrefs.GetString("Discussion2"));
            }

            if (discussionCount == 3) {
                PlayerPrefs.SetString("Discussion3", "The UK has always felt the need to defend itself, which is why the UK doesn't feel very 'European'.");
                Debug.Log(PlayerPrefs.GetString("Discussion3"));
            }

            if (discussionCount == 4) {
                PlayerPrefs.SetString("Discussion4", "The UK has always felt the need to defend itself, which is why the UK doesn't feel very 'European'.");
                Debug.Log(PlayerPrefs.GetString("Discussion4"));
            }
        }

        //-----------------------------------------------------

        //-----------DISCUSSION 9------------------------------

        if (proDiscussion9 == true && antiDiscussion9 == false)
        {
            discussionCount++;

            if (discussionCount == 1) {
                PlayerPrefs.SetString("Discussion1", "EU grants have funded many projects that contribute to a shared European cultural identity.");
                Debug.Log(PlayerPrefs.GetString("Discussion1"));
            }

            if (discussionCount == 2) {
                PlayerPrefs.SetString("Discussion2", "EU grants have funded many projects that contribute to a shared European cultural identity.");
                Debug.Log(PlayerPrefs.GetString("Discussion2"));
            }

            if (discussionCount == 3) {
                PlayerPrefs.SetString("Discussion3", "EU grants have funded many projects that contribute to a shared European cultural identity.");
                Debug.Log(PlayerPrefs.GetString("Discussion3"));
            }

            if (discussionCount == 4) {
                PlayerPrefs.SetString("Discussion4", "EU grants have funded many projects that contribute to a shared European cultural identity.");
                Debug.Log(PlayerPrefs.GetString("Discussion4"));
            }
        }

        if (proDiscussion9 == false && antiDiscussion9 == true)
        {
            discussionCount++;

            if (discussionCount == 1) {
                PlayerPrefs.SetString("Discussion1", "The European Union represents an unattractive homogenisation of European cultures.");
                Debug.Log(PlayerPrefs.GetString("Discussion1"));
            }

            if (discussionCount == 2) {
                PlayerPrefs.SetString("Discussion2", "The European Union represents an unattractive homogenisation of European cultures.");
                Debug.Log(PlayerPrefs.GetString("Discussion2"));
            }

            if (discussionCount == 3) {
                PlayerPrefs.SetString("Discussion3", "The European Union represents an unattractive homogenisation of European cultures.");
                Debug.Log(PlayerPrefs.GetString("Discussion3"));
            }

            if (discussionCount == 4) {
                PlayerPrefs.SetString("Discussion4", "The European Union represents an unattractive homogenisation of European cultures.");
                Debug.Log(PlayerPrefs.GetString("Discussion4"));
            }
        }

        //-----------------------------------------------------

        //-----------DISCUSSION 10------------------------------

        if (proDiscussion10 == true && antiDiscussion10 == false)
        {
            discussionCount++;

            if (discussionCount == 1) {
                PlayerPrefs.SetString("Discussion1", "I have no trouble in thinking of myself as both British and European.");
                Debug.Log(PlayerPrefs.GetString("Discussion1"));
            }

            if (discussionCount == 2) {
                PlayerPrefs.SetString("Discussion2", "I have no trouble in thinking of myself as both British and European.");
                Debug.Log(PlayerPrefs.GetString("Discussion2"));
            }

            if (discussionCount == 3) {
                PlayerPrefs.SetString("Discussion3", "I have no trouble in thinking of myself as both British and European.");
                Debug.Log(PlayerPrefs.GetString("Discussion3"));
            }

            if (discussionCount == 4) {
                PlayerPrefs.SetString("Discussion4", "I have no trouble in thinking of myself as both British and European.");
                Debug.Log(PlayerPrefs.GetString("Discussion4"));
            }
        }

        if (proDiscussion10 == false && antiDiscussion10 == true)
        {
            discussionCount++;

            if (discussionCount == 1) {
                PlayerPrefs.SetString("Discussion1", "Being British is much more important to me than being European - I really want a British passport!");
                Debug.Log(PlayerPrefs.GetString("Discussion1"));
            }

            if (discussionCount == 2) {
                PlayerPrefs.SetString("Discussion2", "Being British is much more important to me than being European - I really want a British passport!");
                Debug.Log(PlayerPrefs.GetString("Discussion2"));
            }

            if (discussionCount == 3) {
                PlayerPrefs.SetString("Discussion3", "Being British is much more important to me than being European - I really want a British passport!");
                Debug.Log(PlayerPrefs.GetString("Discussion3"));
            }

            if (discussionCount == 4) {
                PlayerPrefs.SetString("Discussion4", "Being British is much more important to me than being European - I really want a British passport!");
                Debug.Log(PlayerPrefs.GetString("Discussion4"));
            }
        }

        //-----------------------------------------------------

    }*/

    //Add these to the Continue button then it takes
    public void ProSocialSelected()
    {
        PlayerPrefs.SetString("Discussion1", "But most immigrants have integrated well into this village and make a real contribution to village life.");
        Debug.Log(PlayerPrefs.GetString("Discussion1"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 9;
        Debug.Log("countdown: " + countdown);

        /*if (discussionCount == 1) {
            PlayerPrefs.SetString("Discussion1", "But most immigrants have integrated well into this village and make a real contribution to village life.");
            Debug.Log(PlayerPrefs.GetString("Discussion1"));
        }*/
    }

    //Add these to the Continue button then it takes
    public void AntiSocialSelected() {

        PlayerPrefs.SetString("Discussion1", "That's so not true! Most of them hang around with the people they came with and don't even try to learn English.");
        Debug.Log(PlayerPrefs.GetString("Discussion1"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 9;
        Debug.Log("countdown: " + countdown);

        /*if (discussionCount == 1) {
            PlayerPrefs.SetString("Discussion1", "That's so not true! Most of them hang around with the people they came with and don't even try to learn English.");
            Debug.Log(PlayerPrefs.GetString("Discussion1"));
        }*/
    }

    //Add these to the Continue button then it takes
    public void ProEnvironmentSelected() {

        PlayerPrefs.SetString("Discussion2", "The EU has done a lot to tackle climate change.");
        Debug.Log(PlayerPrefs.GetString("Discussion2"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 8;
        Debug.Log("countdown: " + countdown);

        /*if (discussionCount == 2) {
            PlayerPrefs.SetString("Discussion2", "The EU has done a lot to tackle climate change.");
            Debug.Log(PlayerPrefs.GetString("Discussion2"));
        }*/
    }

    //Add these to the Continue button then it takes
    public void AntiEnvironmentSelected() {

        PlayerPrefs.SetString("Discussion2", "If the EU were effective we wouldn't need extinction revolution.");
        Debug.Log(PlayerPrefs.GetString("Discussion2"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 8;
        Debug.Log("countdown: " + countdown);

        /*if (discussionCount == 2) {
            PlayerPrefs.SetString("Discussion2", "If the EU were effective we wouldn't need extinction revolution.");
            Debug.Log(PlayerPrefs.GetString("Discussion2"));
        }*/
    }

    //Add these to the Continue button then it takes
    public void ProRightsAndResponsibilitiesSelected() {

        PlayerPrefs.SetString("Discussion3", "Being a member of the EU has provided fabulous opportunities for students to travel and study abroad to anyone who wants to take them.");
        Debug.Log(PlayerPrefs.GetString("Discussion3"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 7;
        Debug.Log("countdown: " + countdown);

        /*if (discussionCount == 3) {
            PlayerPrefs.SetString("Discussion3", "Being a member of the EU has provided fabulous opportunities for students to travel and study abroad to anyone who wants to take them.");
            Debug.Log(PlayerPrefs.GetString("Discussion3"));
        }*/
    }

    //Add these to the Continue button then it takes
    public void AntiRightsAndResponsibilitiesSelected() {

        PlayerPrefs.SetString("Discussion3", "You must be kidding - that is what Brexit is all about! There are no opportunities for us ordinary folk, the opportunities are only for those who have money.");
        Debug.Log(PlayerPrefs.GetString("Discussion3"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 7;
        Debug.Log("countdown: " + countdown);

        /*if (discussionCount == 3) {
            PlayerPrefs.SetString("Discussion3", "You must be kidding - that is what Brexit is all about! There are no opportunities for us ordinary folk, the opportunities are only for those who have money.");
            Debug.Log(PlayerPrefs.GetString("Discussion3"));
        }*/
    }

    //Add these to the Continue button then it takes
    public void ProSafetyAndSecuritySelected() {

        PlayerPrefs.SetString("Discussion4", "For me, one of the main benefits of EU membership has been to prevent war between the nations of Europe.");
        Debug.Log(PlayerPrefs.GetString("Discussion4"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 6;
        Debug.Log("countdown: " + countdown);

        /*if (discussionCount == 4) {
            PlayerPrefs.SetString("Discussion4", "For me, one of the main benefits of EU membership has been to prevent war between the nations of Europe.");
            Debug.Log(PlayerPrefs.GetString("Discussion4"));
        }*/
    }

    //Add these to the Continue button then it takes
    public void AntiSafetyAndSecuritySelected() {

        PlayerPrefs.SetString("Discussion4", "But there's still lots of tensions between the nations of Europe. It's only a matter of time before serious trouble kicks off somewhere.");
        Debug.Log(PlayerPrefs.GetString("Discussion4"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 6;
        Debug.Log("countdown: " + countdown);

        /*if (discussionCount == 4) {
            PlayerPrefs.SetString("Discussion4", "But there's still lots of tensions between the nations of Europe. It's only a matter of time before serious trouble kicks off somewhere.");
            Debug.Log(PlayerPrefs.GetString("Discussion4"));
        }*/
    }

    //Add these to the Continue button then it takes
    public void ProEmotionalSelected() {

        PlayerPrefs.SetString("Discussion5", "I'm really worried about leaving the EU. It feels like we're turning our backs on the rest of the world.");
        Debug.Log(PlayerPrefs.GetString("Discussion5"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 5;
        Debug.Log("countdown: " + countdown);

        isDialogue1Finished = true;

        /*if (discussionCount == 5) {
            PlayerPrefs.SetString("Discussion5", "I'm really worried about leaving the EU. It feels like we're turning our backs on the rest of the world.");
            Debug.Log(PlayerPrefs.GetString("Discussion5"));
        }*/
    }

    //Add these to the Continue button then it takes
    public void AntiEmotionalSelected() {

        PlayerPrefs.SetString("Discussion5", "All the people I know are really pleased about leaving Europe. We're planning a street party for when we go.");
        Debug.Log(PlayerPrefs.GetString("Discussion5"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 5;
        Debug.Log("countdown: " + countdown);

        isDialogue1Finished = true;

        /*if (discussionCount == 5) {
            PlayerPrefs.SetString("Discussion5", "All the people I know are really pleased about leaving Europe. We're planning a street party for when we go.");
            Debug.Log(PlayerPrefs.GetString("Discussion5"));
        }*/
    }

    //Add these to the Continue button then it takes
    public void ProEconomicSelected() {
        
        PlayerPrefs.SetString("Discussion6", "After Brexit, the UK economy could be around 6% smaller by 2030 and that would mean a loss of income equivalent to £4,300 a year for every British household.");
        Debug.Log(PlayerPrefs.GetString("Discussion6"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 4;
        Debug.Log("countdown: " + countdown);

        /*if (discussionCount == 6) {
            PlayerPrefs.SetString("Discussion6", "After Brexit, the UK economy could be around 6% smaller by 2030 and that would mean a loss of income equivalent to £4,300 a year for every British household.");
            Debug.Log(PlayerPrefs.GetString("Discussion6"));
        }*/
    }

    //Add these to the Continue button then it takes
    public void AntiEconomicSelected() {

        PlayerPrefs.SetString("Discussion6", "But once we've left the EU, we'll be able to strike deals with the rest of the world so we'll be fine.");
        Debug.Log(PlayerPrefs.GetString("Discussion6"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 4;
        Debug.Log("countdown: " + countdown);

        /*if (discussionCount == 6) {
            PlayerPrefs.SetString("Discussion6", "But once we've left the EU, we'll be able to strike deals with the rest of the world so we'll be fine.");
            Debug.Log(PlayerPrefs.GetString("Discussion6"));
        }*/
    }

    //Add these to the Continue button then it takes
    public void ProPoliticalSelected() {

        PlayerPrefs.SetString("Discussion7", "Would you not rather have the Brussels elite in charge than UKIP and Nigel Farage?");
        Debug.Log(PlayerPrefs.GetString("Discussion7"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 3;
        Debug.Log("countdown: " + countdown);

        /*if (discussionCount == 7) {
            PlayerPrefs.SetString("Discussion7", "Would you not rather have the Brussels elite in charge than UKIP and Nigel Farage?");
            Debug.Log(PlayerPrefs.GetString("Discussion7"));
        }*/
    }

    //Add these to the Continue button then it takes
    public void AntiPoliticalSelected() {

        PlayerPrefs.SetString("Discussion7", "Brussels is far too remote - we need to be making our own laws back here in the UK.");
        Debug.Log(PlayerPrefs.GetString("Discussion7"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 3;
        Debug.Log("countdown: " + countdown);

        /*if (discussionCount == 7) {
            PlayerPrefs.SetString("Discussion7", "Brussels is far too remote - we need to be making our own laws back here in the UK.");
            Debug.Log(PlayerPrefs.GetString("Discussion7"));
        }*/
    }

    //Add these to the Continue button then it takes
    public void ProHistoricSelected() {

        PlayerPrefs.SetString("Discussion8", "The people who want to go back in time have a very poor knowledge of European history.");
        Debug.Log(PlayerPrefs.GetString("Discussion8"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 2;
        Debug.Log("countdown: " + countdown);

        /*if (discussionCount == 8) {
            PlayerPrefs.SetString("Discussion8", "The people who want to go back in time have a very poor knowledge of European history.");
            Debug.Log(PlayerPrefs.GetString("Discussion8"));
        }*/
    }

    //Add these to the Continue button then it takes
    public void AntiHistoricSelected() {

        PlayerPrefs.SetString("Discussion8", "The UK has always felt the need to defend itself, which is why the UK doesn't feel very 'European'.");
        Debug.Log(PlayerPrefs.GetString("Discussion8"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 2;
        Debug.Log("countdown: " + countdown);

        /*if (discussionCount == 8) {
            PlayerPrefs.SetString("Discussion8", "The UK has always felt the need to defend itself, which is why the UK doesn't feel very 'European'.");
            Debug.Log(PlayerPrefs.GetString("Discussion8"));
        }*/
    }

    //Add these to the Continue button then it takes
    public void ProCultureSelected() {

        PlayerPrefs.SetString("Discussion9", "EU grants have funded many projects that contribute to a shared European cultural identity.");
        Debug.Log(PlayerPrefs.GetString("Discussion9"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 1;
        Debug.Log("countdown: " + countdown);

        /*if (discussionCount == 9) {
            PlayerPrefs.SetString("Discussion9", "EU grants have funded many projects that contribute to a shared European cultural identity.");
            Debug.Log(PlayerPrefs.GetString("Discussion9"));
        }*/
    }

    //Add these to the Continue button then it takes
    public void AntiCultureSelected() {

        PlayerPrefs.SetString("Discussion9", "The European Union represents an unattractive homogenisation of European cultures.");
        Debug.Log(PlayerPrefs.GetString("Discussion9"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 1;
        Debug.Log("countdown: " + countdown);

        /*if (discussionCount == 9) {
            PlayerPrefs.SetString("Discussion9", "The European Union represents an unattractive homogenisation of European cultures.");
            Debug.Log(PlayerPrefs.GetString("Discussion9"));
        }*/
    }

    //Add these to the Continue button then it takes
    public void ProGeographySelected() {

        PlayerPrefs.SetString("Discussion10", "I have no trouble in thinking of myself as both British and European.");
        Debug.Log(PlayerPrefs.GetString("Discussion10"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 0;
        Debug.Log("countdown: " + countdown);

        isDialogue2Finished = true;

        /*if (discussionCount == 10) {
            PlayerPrefs.SetString("Discussion10", "I have no trouble in thinking of myself as both British and European.");
            Debug.Log(PlayerPrefs.GetString("Discussion10"));
        }*/
    }

    //Add these to the Continue button then it takes
    public void AntiGeographySelected() {

        PlayerPrefs.SetString("Discussion10", "Being British is much more important to me than being European - I really want a British passport!");
        Debug.Log(PlayerPrefs.GetString("Discussion10"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 0;
        Debug.Log("countdown: " + countdown);

        isDialogue2Finished = true;

        /*if (discussionCount == 10) {
            PlayerPrefs.SetString("Discussion10", "Being British is much more important to me than being European - I really want a British passport!");
            Debug.Log(PlayerPrefs.GetString("Discussion10"));
        }*/
    }
}
