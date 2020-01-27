using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LorryTruckDiscussion : MonoBehaviour {

    public TextMeshProUGUI statementTextDisplay;

    //Discussion text  
    public string[] discussion2;
    private int index;

    [SerializeField]
    private float typingSpeed;

    public GameObject continueButton;

    //background
    public GameObject toolBG;

    //3 characters for discussion tool
    public GameObject proCharacter, antiCharacter, undecidedCharacter;

    public Animator animPro, animAnti, animUndecided;
    public Animator animText;

    //interview style response box
    public GameObject responseBox;

    //Dialogue Bool Finish
    private bool isTheme1Finished = false;
    private bool isTheme2Finished = false;
    private bool isTheme3Finished = false;
    private bool isTheme4Finished = false;
    private bool isTheme5Finished = false;
    private bool isTheme6Finished = false;

    //Dialogue Context (before the dialogue begins)
    public GameObject contextTheme1, contextTheme2, contextTheme3, contextTheme4, contextTheme5;

    public GameObject playerSelection;
    public GameObject[] character1Text, character2Text;
    public TextMeshProUGUI theme1Character1, theme2Character1, theme3Character1, theme4Character1, theme5Character1;
    public TextMeshProUGUI theme1Character2, theme2Character2, theme3Character2, theme4Character2, theme5Character2;
    private bool hasPlayerSelected = false;

    private bool isDialogueFinished = false;

    //For Bottom
    private bool proDiscussion1, antiDiscussion1 = false;
    private bool proDiscussion2, antiDiscussion2 = false;
    private bool proDiscussion3, antiDiscussion3 = false;
    private bool proDiscussion4, antiDiscussion4 = false;
    private bool proDiscussion5, antiDiscussion5 = false;

    public GameObject task3;

    private int discussionCount = 0;

    private int countdown = 5;

    public GameObject startCanvas;

    // Start is called before the first frame update
    void Start()
    {
        startCanvas.SetActive(true);
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

        responseBox.SetActive(false);

        playerSelection.SetActive(false);

        /* When the tool first begins the player will be presented with the first context.
         * Everything will be SetActive(false) except the context for Social to begin.
         */

        //context statements for the dialogue
        //set false as they don't appear straight away
        //contextTheme1 is first, after each dialogue and selection, it goes to the next one
        contextTheme1.SetActive(true);
        responseBox.SetActive(true);
        contextTheme2.SetActive(false);
        contextTheme3.SetActive(false);
        contextTheme4.SetActive(false);
        contextTheme5.SetActive(false);

        //animText.SetTrigger("Change"); //for player if added later on
    }

    public void IfFinished() {
        //if either or are finished - go back to the screen
        /*if (isDialogueFinished) {

            toolBG.SetActive(false);
        }

        //if both are finished - go to feedback
        if (isDialogueFinished == true) {
            //give feedback
            //this is placement at the moment
            //task2FullCanvas.SetActive(false);
            //task3.SetActive(true);
            Debug.Log("Discussion has been complete!");
            task3.SetActive(true);

            toolBG.SetActive(false);
        }*/

        if (countdown == 0) {
            Debug.Log("Discussion has been complete!");
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

            /*if (index == 0) {
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }*/

            if (index == 1) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            } else {
                if (index == 0) {
                    animPro.SetTrigger("Triggered");
                }
            }

            if (index == 2) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            } else {
                if (index == 0) {
                    animPro.SetTrigger("Triggered");
                }
            }
        } else {
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
                responseBox.SetActive(false);

                //contextEnvironment.SetActive(true); //move this to SocialSelected()

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);


                character1Text[0].SetActive(true);
                character2Text[0].SetActive(true);
                theme1Character1.text = "Why select a national trucker with a big mouth demanding much and working little, instead of a hard-working  driver from Eastern Europe that does not complain about working over time?";
                theme1Character2.text = "Europe is very good for the happy few at the top of international companies, but not for those who have to make their living in those companies.";

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
            character1Text[0].SetActive(false);
            character2Text[0].SetActive(false);
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

            /*if (index == 0) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }*/

            if (index == 1) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            } else {
                if (index == 0) {
                    animPro.SetTrigger("Triggered");
                }
            }

            if (index == 2) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            } else {
                if (index == 0) {
                    animPro.SetTrigger("Triggered");
                }
            }

        } else {
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
                responseBox.SetActive(false);

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                character1Text[1].SetActive(true);
                character2Text[1].SetActive(true);

                theme2Character1.text = "What's the problem with having others do our hard work? Isn't it the ultimate dream to sit at home and do nothing? The only problem is that the government isn't able to make the national citizen profit.";
                theme2Character2.text = "Foreign drivers are being hosted. And what do you get if more drivers sit together? They go out to drink and then start driving.";

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
            character1Text[1].SetActive(false);
            character2Text[1].SetActive(false);
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

            /*if (index == 0) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }*/

            if (index == 1) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            } else {
                if (index == 0) {
                    animPro.SetTrigger("Triggered");
                }
            }

            if (index == 2) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            } else {
                if (index == 0) {
                    animPro.SetTrigger("Triggered");
                }
            }
        } else {
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
                responseBox.SetActive(false);

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                character1Text[2].SetActive(true);
                character2Text[2].SetActive(true);

                theme3Character1.text = "There is a huge shortage of drivers. People from Eastern Europe want to do the work.";
                theme3Character2.text = "All profits go to private companies; all costs go to society and are paid by us taxpayers.";

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
            character1Text[2].SetActive(false);
            character2Text[2].SetActive(false);
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

            /*if (index == 0) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }*/

            if (index == 1) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            } else {
                if (index == 0) {
                    animPro.SetTrigger("Triggered");
                }
            }

            if (index == 2) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            } else {
                if (index == 0) {
                    animPro.SetTrigger("Triggered");
                }
            }
        } else {
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
                responseBox.SetActive(false);

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                character1Text[3].SetActive(true);
                character2Text[3].SetActive(true);

                theme4Character1.text = "We 'lost' a lot of materials when we worked with national truckers (that were later sold on the black market without punishing them for that)… since we work with foreign drivers this has not happened anymore.";
                theme4Character2.text = "The Dutch are paying taxes for maintaining our highways so that Polish workers do not suffer back pains.";

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
            character1Text[3].SetActive(false);
            character2Text[3].SetActive(false);
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

            /*if (index == 0) {
                animUndecided.SetTrigger("Idle");
                animPro.SetTrigger("Triggered");
                //proAnimationBubble.SetActive(true);
            }*/

            if (index == 1) {
                animPro.SetTrigger("Idle");
                animAnti.SetTrigger("Triggered");

                //proAnimationBubble.SetActive(false);
                //antiAnimationBubble.SetActive(true);
            } else {
                if (index == 0) {
                    animPro.SetTrigger("Triggered");
                }
            }

            if (index == 2) {
                animAnti.SetTrigger("Idle");
                animUndecided.SetTrigger("Triggered");

                //antiAnimationBubble.SetActive(false);
                //undecidedAnimationBubble.SetActive(true);
            } else {
                if (index == 0) {
                    animPro.SetTrigger("Triggered");
                }
            }
        } else {
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
                responseBox.SetActive(false);

                //we want to give the player the option to choose between options
                playerSelection.SetActive(true);
                character1Text[4].SetActive(true);
                character2Text[4].SetActive(true);

                theme5Character1.text = "There will no longer be a cheap Eastern European trucker. New rules on which the European Parliament recently reached agreement will also bring their wages up to a competitive level.";
                theme5Character2.text = "Win win situation?? Not for us! When I started working, I was home every weekend. Not anymore. The Netherlands are going down the drain thanks to politics, the EU and the future.";

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
            character1Text[4].SetActive(false);
            character2Text[4].SetActive(false);
            playerSelection.SetActive(false);
            proCharacter.SetActive(false);
            antiCharacter.SetActive(false);
            undecidedCharacter.SetActive(false);

            //StartTask3();

            //store data
            //put into UnityAnalytics when available

            //instead of moving on to the next area, we will give the player feedback at this stage, with a final tool feedback screen.
            //contextTheme6.SetActive(true);
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

    //-------------------------------------------------------------------

    //Discussion Theme 1 - ECONOMIC

    //Add these to the Continue button then it takes
    public void Person1Theme1Selected() {
        PlayerPrefs.SetString("LorryTruckDiscussion1", "Why select a national trucker with a big mouth demanding much and working little, instead of a hard-working  driver from Eastern Europe that does not complain about working over time?");
        Debug.Log(PlayerPrefs.GetString("LorryTruckDiscussion1"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 5;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void Person2Theme1Selected() {
        PlayerPrefs.SetString("LorryTruckDiscussion1", "Europe is very good for the happy few at the top of international companies, but not for those who have to make their living in those companies.");
        Debug.Log(PlayerPrefs.GetString("LorryTruckDiscussion1"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 5;
        Debug.Log("countdown: " + countdown);
    }

    public void Person3Theme1Selected() {
        PlayerPrefs.SetString("LorryTruckDiscussion1", "Europe is good for profits of Mediamarkt, IKEA and LIDL. They bring work.");
        Debug.Log(PlayerPrefs.GetString("LorryTruckDiscussion1"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 5;
        Debug.Log("countdown: " + countdown);
    }

    //--------------------------------------------------------------

    //Discussion Theme 2 - SOCIAL

    //Add these to the Continue button then it takes
    public void Person1Theme2Selected() {

        PlayerPrefs.SetString("LorryTruckDiscussion2", "What's the problem with having others do our hard work? Isn't it the ultimate dream to sit at home and do nothing? The only problem is that the government isn't able to make the national citizen profit.");
        Debug.Log(PlayerPrefs.GetString("LorryTruckDiscussion2"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 4;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void Person2Theme2Selected() {

        PlayerPrefs.SetString("LorryTruckDiscussion2", "Foreign drivers are being hosted. And what do you get if more drivers sit together? They go out to drink and then start driving.");
        Debug.Log(PlayerPrefs.GetString("LorryTruckDiscussion2"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 4;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void Person3Theme2Selected() {

        PlayerPrefs.SetString("LorryTruckDiscussion2", "The company directors have their villas renovated by Polish workers who drive in brand new mini vans, construction markets are crowded and even open on Sundays for them. But who's fault is that?");
        Debug.Log(PlayerPrefs.GetString("LorryTruckDiscussion2"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 4;
        Debug.Log("countdown: " + countdown);
    }

    //--------------------------------------------------------------

    //Discussion Theme 3 - ECONOMIC

    //Add these to the Continue button then it takes
    public void Person1Theme3Selected() {

        PlayerPrefs.SetString("LorryTruckDiscussion3", "There is a huge shortage of drivers. People from Eastern Europe want to do the work.");
        Debug.Log(PlayerPrefs.GetString("LorryTruckDiscussion3"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 3;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void Person2Theme3Selected() {

        PlayerPrefs.SetString("LorryTruckDiscussion3", "All profits go to private companies; all costs go to society and are paid by us taxpayers.");
        Debug.Log(PlayerPrefs.GetString("LorryTruckDiscussion3"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 3;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void Person3Theme3Selected() {

        PlayerPrefs.SetString("LorryTruckDiscussion3", "It's not a black and white situation people.");
        Debug.Log(PlayerPrefs.GetString("LorryTruckDiscussion3"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 3;
        Debug.Log("countdown: " + countdown);
    }

    //--------------------------------------------------------------------

    //Discussion Theme 4 - RIGHTS & RESPONSIBILITIES

    //Add these to the Continue button then it takes
    public void Person1Theme4Selected() {

        PlayerPrefs.SetString("LorryTruckDiscussion4", "We 'lost' a lot of materials when we worked with national truckers (that were later sold on the black market without punishing them for that)… since we work with foreign drivers this has not happened anymore.");
        Debug.Log(PlayerPrefs.GetString("LorryTruckDiscussion4"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 2;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void Person2Theme4Selected() {

        PlayerPrefs.SetString("LorryTruckDiscussion4", "The Dutch are paying taxes for maintaining our highways so that Polish workers do not suffer back pains.");
        Debug.Log(PlayerPrefs.GetString("LorryTruckDiscussion4"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 2;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void Person3Theme4Selected() {

        PlayerPrefs.SetString("LorryTruckDiscussion4", "I look forward to hearing what the Minister is going to do about the thousands of jobs in the transport sector that have already been sacrificed to cheap profit. We read daily in the newspaper about the exploitation of Eastern European drivers, sham constructions and post office box companies.");
        Debug.Log(PlayerPrefs.GetString("LorryTruckDiscussion4"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 2;
        Debug.Log("countdown: " + countdown);
    }

    //--------------------------------------------------------------------------------------

    //Discussion Theme 5 - ECONOMIC

    //Add these to the Continue button then it takes
    public void Person1Theme5Selected() {

        PlayerPrefs.SetString("LorryTruckDiscussion5", "There will no longer be a cheap Eastern European trucker. New rules on which the European Parliament recently reached agreement will also bring their wages up to a competitive level.");
        Debug.Log(PlayerPrefs.GetString("LorryTruckDiscussion5"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 1;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void Person2Theme5Selected() {

        PlayerPrefs.SetString("LorryTruckDiscussion5", "Win win situation?? Not for us! When I started working, I was home every weekend. Not anymore. The Netherlands are going down the drain thanks to politics, the EU and the future.");
        Debug.Log(PlayerPrefs.GetString("LorryTruckDiscussion5"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 1;
        Debug.Log("countdown: " + countdown);
    }

    //Add these to the Continue button then it takes
    public void Person3Theme5Selected() {

        PlayerPrefs.SetString("LorryTruckDiscussion5", "Keep in mind they drink out of boredom if they drive through Europe for six to eight weeks at a time.");
        Debug.Log(PlayerPrefs.GetString("LorryTruckDiscussion5"));

        discussionCount++;
        Debug.Log(discussionCount);
        countdown = 1;
        Debug.Log("countdown: " + countdown);
    }

    //---------------------------------------------------------------------------
}
