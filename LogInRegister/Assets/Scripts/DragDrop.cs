using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragDrop : MonoBehaviour {
    //----------------------
    //Win State
    public GameObject youHaveWon;
    //Try Again State
    public GameObject tryAgain;
    //Correct State
    public GameObject correct;


    public GameObject kosovo, luxembourg, easternEuropean, germany, france, croatia, ireland, uk, 
                      netherlands, greece, sweden, ukraine, russia, portugal, austria, spain, italy;
    //the "empty" objects are only needed for the answers
    public GameObject kosovoEmpty, luxembourgEmpty, easternEuropeanEmpty, germanyEmpty, franceEmpty, 
                      croatiaEmpty, irelandEmpty, ukEmpty, netherlandsEmpty, greeceEmpty, swedenEmpty,
                      ukraineEmpty, russiaEmpty, portugalEmpty, austriaEmpty, spainEmpty, italyEmpty;

    Vector2 kosovoInitialPos, luxembourgInitialPos, easternEuropeanInitialPos, germanyInitialPos, 
            franceInitialPos, croatiaInitialPos, irelandInitialPos, ukInitialPos, netherlandsInitialPos,
            greeceInitialPos, swedenInitialPos, ukraineInitialPos, russiaInitialPos, portugalInitialPos,
            austriaInitialPos, spainInitialPos, italyInitialPos;

    //questions - will change after
    public GameObject statement1, statement2, statement3, statement4, 
                      statement5, statement6, statement7, statement8;

    //To tell it what one is correct or incorrect
    bool kosovoCorrect = false;
    bool luxembourgCorrect = false;
    bool easternEuropeanCorrect = false;
    bool germanyCorrect = false;
    bool franceCorrect = false;
    bool croatiaCorrect = false;
    bool irelandCorrect = false;
    bool ukCorrect = false;
    //after this might not be necessary
    bool netherlandsCorrect = false;
    bool greeceCorrect = false;
    bool swedenCorrect = false;
    bool ukraineCorrect = false;
    bool russiaCorrect = false;
    bool portugalCorrect = false;
    bool austriaCorrect = false;
    bool spainCorrect = false;
    bool italyCorrect = false;

	// Use this for initialization
	void Start () {
        //answers
        kosovoInitialPos = kosovo.transform.position;
        luxembourgInitialPos = luxembourg.transform.position;
        easternEuropeanInitialPos = easternEuropean.transform.position;
        germanyInitialPos = germany.transform.position;
        franceInitialPos = france.transform.position;
        croatiaInitialPos = croatia.transform.position;
        irelandInitialPos = ireland.transform.position;
        ukInitialPos = uk.transform.position;

        //not answers
        netherlandsInitialPos = netherlands.transform.position;
        greeceInitialPos = greece.transform.position;
        swedenInitialPos = sweden.transform.position;
        ukraineInitialPos = ukraine.transform.position;
        russiaInitialPos = russia.transform.position;
        portugalInitialPos = portugal.transform.position;
        austriaInitialPos = austria.transform.position;
        spainInitialPos = spain.transform.position;
        italyInitialPos = italy.transform.position;

        //win text
        youHaveWon.SetActive(false);

        //try again text
        tryAgain.SetActive(false);

        //correct text
        correct.SetActive(false);

        //questions
        statement1.SetActive(true); //first question will be active upon starting
        statement2.SetActive(false);
        statement3.SetActive(false);
        statement4.SetActive(false);
        statement5.SetActive(false);
        statement6.SetActive(false);
        statement7.SetActive(false);
        statement8.SetActive(false);

        //all flags except 4 from question 1 will be active
        kosovo.SetActive(true);
        luxembourg.SetActive(true);
        easternEuropean.SetActive(false);
        germany.SetActive(true);
        france.SetActive(false);
        croatia.SetActive(false);
        ireland.SetActive(false);
        uk.SetActive(false);
        netherlands.SetActive(true);
        greece.SetActive(false);
        sweden.SetActive(false);
        ukraine.SetActive(false);
        russia.SetActive(false);
        portugal.SetActive(false);
        austria.SetActive(false);
        spain.SetActive(false);
        italy.SetActive(false);

        //empty answer boxes
        kosovoEmpty.SetActive(true);
        luxembourgEmpty.SetActive(false);
        easternEuropeanEmpty.SetActive(false);
        germanyEmpty.SetActive(false);
        franceEmpty.SetActive(false);
        croatiaEmpty.SetActive(false);
        irelandEmpty.SetActive(false);
        ukEmpty.SetActive(false);
        netherlandsEmpty.SetActive(false);
        greeceEmpty.SetActive(false);
        swedenEmpty.SetActive(false);
        ukraineEmpty.SetActive(false);
        russiaEmpty.SetActive(false);
        portugalEmpty.SetActive(false);
        austriaEmpty.SetActive(false);
        spainEmpty.SetActive(false);
        italyEmpty.SetActive(false);

        // for each question, the player will have 4 different flags to choose from, with one being the correct flag

	}
	
	// Update is called once per frame
	void Update () {
        //Statement 1 - Answer: Kosovo
        if (kosovoCorrect) {
            //statement 1 is initially set as true, when the question is correct that will disappear and question 2 will appear
            statement1.SetActive(false);
            statement2.SetActive(true);

            //answer boxes - want the answer (black) box to disappear as well as the flag
            kosovoEmpty.SetActive(false);
            luxembourgEmpty.SetActive(true);
            //disable drag

            //dummy flags to help player choose between and answer
            kosovo.SetActive(false);
            germany.SetActive(false);
            luxembourg.SetActive(false);
            netherlands.SetActive(false);
            //Flags for statement 2
            croatia.SetActive(true);
            luxembourg.SetActive(true);
            uk.SetActive(true);
            ukraine.SetActive(true);

            //add score?
        }
        //Statement 2 - Answer: Luxembourg
        if (kosovoCorrect && luxembourgCorrect) {
            statement2.SetActive(false);
            statement3.SetActive(true);

            //answer boxes - want the answer (black) box to disappear as well as the flag
            luxembourgEmpty.SetActive(false);
            easternEuropeanEmpty.SetActive(true);
            //disable drag

            //flags disabled upon getting correct
            croatia.SetActive(false);
            luxembourg.SetActive(false);
            uk.SetActive(false);
            ukraine.SetActive(false);
            //Flags for statement 3
            croatia.SetActive(true);
            easternEuropean.SetActive(true);
            uk.SetActive(true);
            greece.SetActive(true);

            //add score?
        }
        //Statement 3
        if (kosovoCorrect && luxembourgCorrect && easternEuropeanCorrect) {
            statement3.SetActive(false);
            statement4.SetActive(true);

            //answer boxes - want the answer (black) box to disappear as well as the flag
            easternEuropeanEmpty.SetActive(false);
            germanyEmpty.SetActive(true);
            //disable drag

            //flags disabled upon getting correct
            croatia.SetActive(false);
            easternEuropean.SetActive(false);
            uk.SetActive(false);
            greece.SetActive(false);
            //Flags for statement 4
            germany.SetActive(true);
            italy.SetActive(true);
            spain.SetActive(true);
            france.SetActive(true);

            //add score?
        }
        //Statement 4
        if (kosovoCorrect && luxembourgCorrect && easternEuropeanCorrect && germanyCorrect) {
            statement4.SetActive(false);
            statement5.SetActive(true);

            //answer boxes - want the answer (black) box to disappear as well as the flag
            germanyEmpty.SetActive(false);
            franceEmpty.SetActive(true);
            //disable drag

            //flags disabled upon getting correct
            germany.SetActive(false);
            italy.SetActive(false);
            spain.SetActive(false);
            france.SetActive(false);
            //Flags for statement 5
            sweden.SetActive(true);
            italy.SetActive(true);
            portugal.SetActive(true);
            france.SetActive(true);

            //add score?
        }
        //Statement 5
        if (kosovoCorrect && luxembourgCorrect && easternEuropeanCorrect && germanyCorrect && franceCorrect) {
            statement5.SetActive(false);
            statement6.SetActive(true);

            //answer boxes - want the answer (black) box to disappear as well as the flag
            franceEmpty.SetActive(false);
            croatiaEmpty.SetActive(true);
            //disable drag

            //flags disabled upon getting correct
            sweden.SetActive(false);
            italy.SetActive(false);
            portugal.SetActive(false);
            france.SetActive(false);
            //Flags for statement 6
            croatia.SetActive(true);
            russia.SetActive(true);
            netherlands.SetActive(true);
            greece.SetActive(true);

            //add score?
        }
        //Statement1 6
        if (kosovoCorrect && luxembourgCorrect && easternEuropeanCorrect && germanyCorrect && franceCorrect && croatiaCorrect) {
            statement6.SetActive(false);
            statement7.SetActive(true);

            //answer boxes - want the answer (black) box to disappear as well as the flag
            croatiaEmpty.SetActive(false);
            irelandEmpty.SetActive(true);
            //disable drag

            //flags  disabled upon getting correct
            croatia.SetActive(false);
            russia.SetActive(false);
            netherlands.SetActive(false);
            greece.SetActive(false);
            //Flags for statement 7
            austria.SetActive(true);
            ireland.SetActive(true);
            portugal.SetActive(true);
            ukraine.SetActive(true);

            //add score?
        }
        //Statement 7
        if (kosovoCorrect && luxembourgCorrect && easternEuropeanCorrect && germanyCorrect && franceCorrect && croatiaCorrect && irelandCorrect) {
            statement7.SetActive(false);
            statement8.SetActive(true);

            //answer boxes - want the answer (black) box to disappear as well as the flag
            irelandEmpty.SetActive(false);
            ukEmpty.SetActive(true);
            //disable drag

            //flags disabled upon getting correct
            austria.SetActive(false);
            ireland.SetActive(false);
            portugal.SetActive(false);
            ukraine.SetActive(false);
            //Flags for statement 8
            sweden.SetActive(true);
            italy.SetActive(true);
            uk.SetActive(true);
            greece.SetActive(true);

            //add score?
        }
        //Statement 8
        if (kosovoCorrect && luxembourgCorrect && easternEuropeanCorrect && germanyCorrect && franceCorrect && croatiaCorrect && irelandCorrect && ukCorrect) {
            statement8.SetActive(false);
            youHaveWon.SetActive(true);
            //answer boxes - want the answer (black) box to disappear as well as the flag
            ukEmpty.SetActive(false);
            Debug.Log("You have won!"); //debug
            SceneManager.LoadScene("Journalist");
            //disable drag
            //add score?
        }
    }

    //to pick up and drag flags
    public void DragKosovo() {
        kosovo.transform.position = Input.mousePosition;

        /*if (kosovo.transform.position == kosovoEmpty.transform.position) {
            //want to disable the drag itself (maybe better in update)   
        }*/
    }

    public void DragLuxembourg() {
        luxembourg.transform.position = Input.mousePosition;
    }

    public void DragEasternEuropean() {
        easternEuropean.transform.position = Input.mousePosition;
    }

    public void DragGermany() {
        germany.transform.position = Input.mousePosition;
    }

    public void DragFrance() {
        france.transform.position = Input.mousePosition;
    }

    public void DragCroatia() {
        croatia.transform.position = Input.mousePosition;
    }

    public void DragIreland() {
        ireland.transform.position = Input.mousePosition;
    }

    public void DragUK() {
        uk.transform.position = Input.mousePosition;
    }

    public void DragNetherlands() {
        netherlands.transform.position = Input.mousePosition;
    }

    public void DragGreece() {
        greece.transform.position = Input.mousePosition;
    }

    public void DragSweden() {
        sweden.transform.position = Input.mousePosition;
    }

    public void DragUkraine() {
        ukraine.transform.position = Input.mousePosition;
    }

    public void DragRussia() {
        russia.transform.position = Input.mousePosition;
    }

    public void DragPortugal() {
        portugal.transform.position = Input.mousePosition;
    }

    public void DragAustria() {
        austria.transform.position = Input.mousePosition;
    }

    public void DragSpain() {
        spain.transform.position = Input.mousePosition;
    }

    public void DragItaly() {
        italy.transform.position = Input.mousePosition;
    }

    //drop flags
    public void DropKosovo() {
        float distance = Vector3.Distance(kosovo.transform.position, kosovoEmpty.transform.position);

        if (distance < 50) {
            kosovo.transform.position = kosovoEmpty.transform.position;
            kosovoCorrect = true;
            correct.SetActive(true);
            TextNotActive();
        } else {
            kosovo.transform.position = kosovoInitialPos;
            //play audio for incorrect
            //show text saying try again
            tryAgain.SetActive(true);
            TextNotActive();
        }
    }

    public void DropLuxembourg() {
        float distance = Vector3.Distance(luxembourg.transform.position, luxembourgEmpty.transform.position);

        if (distance < 50) {
            luxembourg.transform.position = luxembourgEmpty.transform.position;
            luxembourgCorrect = true;
            correct.SetActive(true);
            TextNotActive();

        } else {
            luxembourg.transform.position = luxembourgInitialPos;
            //play audio for incorrect
            //show text saying try again
            tryAgain.SetActive(true);
            TextNotActive();
        }
    }

    public void DropEasternEuropean() {
        float distance = Vector3.Distance(easternEuropean.transform.position, easternEuropeanEmpty.transform.position);

        if (distance < 50) {
            easternEuropean.transform.position = easternEuropeanEmpty.transform.position;
            easternEuropeanCorrect = true;
            correct.SetActive(true);
            TextNotActive();
        } else {
            easternEuropean.transform.position = easternEuropeanInitialPos;
            //play audio for incorrect
            //show text saying try again
            tryAgain.SetActive(true);
            TextNotActive();
        }
    }

    public void DropGermany() {
        float distance = Vector3.Distance(germany.transform.position, germanyEmpty.transform.position);

        if (distance < 50) {
            germany.transform.position = germanyEmpty.transform.position;
            germanyCorrect = true;
            correct.SetActive(true);
            TextNotActive();
        } else {
            germany.transform.position = germanyInitialPos;
            //play audio for incorrect
            //show text saying try again
            tryAgain.SetActive(true);
            TextNotActive();
        }
    }

    public void DropFrance() {
        float distance = Vector3.Distance(france.transform.position, franceEmpty.transform.position);

        if (distance < 50) {
            france.transform.position = franceEmpty.transform.position;
            franceCorrect = true;
            correct.SetActive(true);
            TextNotActive();
        } else {
            france.transform.position = franceInitialPos;
            //play audio for incorrect
            //show text saying try again
            tryAgain.SetActive(true);
            TextNotActive();
        }
    }

    public void DropCroatia() {
        float distance = Vector3.Distance(croatia.transform.position, croatiaEmpty.transform.position);

        if (distance < 50) {
            croatia.transform.position = croatiaEmpty.transform.position;
            croatiaCorrect = true;
            correct.SetActive(true);
            TextNotActive();
        } else {
            croatia.transform.position = croatiaInitialPos;
            //play audio for incorrect
            //show text saying try again
            tryAgain.SetActive(true);
            TextNotActive();
        }
    }

    public void DropIreland() {
        float distance = Vector3.Distance(ireland.transform.position, irelandEmpty.transform.position);

        if (distance < 50) {
            ireland.transform.position = irelandEmpty.transform.position;
            irelandCorrect = true;
            correct.SetActive(true);
            TextNotActive();
        } else {
            ireland.transform.position = irelandInitialPos;
            //play audio for incorrect
            //show text saying try again
            tryAgain.SetActive(true);
            TextNotActive();
        }
    }

    public void DropUK() {
        float distance = Vector3.Distance(uk.transform.position, ukEmpty.transform.position);

        if (distance < 50) {
            uk.transform.position = ukEmpty.transform.position;
            ukCorrect = true;
            correct.SetActive(true);
            TextNotActive();
        } else {
            uk.transform.position = ukInitialPos;
            //play audio for incorrect
            //show text saying try again
            tryAgain.SetActive(true);
            TextNotActive();
        }
    }

    public void DropNetherlands() {

        netherlands.transform.position = netherlandsInitialPos;
        //play audio for incorrect
        //show text saying try again
        tryAgain.SetActive(true);
        TextNotActive();

        /*float distance = Vector3.Distance(netherlands.transform.position, netherlandsEmpty.transform.position);

        if (distance < 50) {
            netherlands.transform.position = netherlandsEmpty.transform.position;
            netherlandsCorrect = false;
            correct.SetActive(true);
            TextNotActive();
        } else {
            netherlands.transform.position = netherlandsInitialPos;
            //play audio for incorrect
            //show text saying try again
            tryAgain.SetActive(true);
            TextNotActive();
        }*/
    }

    public void DropGreece() {

        greece.transform.position = greeceInitialPos;
        //play audio for incorrect
        //show text saying try again
        tryAgain.SetActive(true);
        TextNotActive();

        /*float distance = Vector3.Distance(greece.transform.position, greeceEmpty.transform.position);

        if (distance < 50) {
            greece.transform.position = greeceEmpty.transform.position;
            greeceCorrect = false;
            correct.SetActive(true);
            TextNotActive();
        } else {
            greece.transform.position = greeceInitialPos;
            //play audio for incorrect
            //show text saying try again
            tryAgain.SetActive(true);
            TextNotActive();
        }*/
    }

    public void DropSweden() {

        sweden.transform.position = swedenInitialPos;
        //play audio for incorrect
        //show text saying try again
        tryAgain.SetActive(true);
        TextNotActive();

        /*float distance = Vector3.Distance(sweden.transform.position, swedenEmpty.transform.position);

        if (distance < 50) {
            sweden.transform.position = swedenEmpty.transform.position;
            swedenCorrect = false;
            correct.SetActive(true);
            TextNotActive();
        } else {
            sweden.transform.position = swedenInitialPos;
            //play audio for incorrect
            //show text saying try again
            tryAgain.SetActive(true);
            TextNotActive();
        }*/
    }

    public void DropUkraine() {

        ukraine.transform.position = ukraineInitialPos;
        //play audio for incorrect
        //show text saying try again
        tryAgain.SetActive(true);
        TextNotActive();

        /*float distance = Vector3.Distance(ukraine.transform.position, ukraineEmpty.transform.position);

        if (distance < 50) {
            ukraine.transform.position = ukraineEmpty.transform.position;
            ukraineCorrect = false;
            correct.SetActive(true);
            TextNotActive();
        } else {
            ukraine.transform.position = ukraineInitialPos;
            //play audio for incorrect
            //show text saying try again
            tryAgain.SetActive(true);
            TextNotActive();
        }*/
    }

    public void DropRussia() {

        russia.transform.position = russiaInitialPos;
        //play audio for incorrect
        //show text saying try again
        tryAgain.SetActive(true);
        TextNotActive();

        /*float distance = Vector3.Distance(russia.transform.position, russiaEmpty.transform.position);

        if (distance < 50) {
            russia.transform.position = russiaEmpty.transform.position;
            russiaCorrect = false;
            correct.SetActive(true);
            TextNotActive();
        } else {
            russia.transform.position = russiaInitialPos;
            //play audio for incorrect
            //show text saying try again
            tryAgain.SetActive(true);
            TextNotActive();
        }*/
    }

    public void DropPortugal() {

        portugal.transform.position = portugalInitialPos;
        //play audio for incorrect
        //show text saying try again
        tryAgain.SetActive(true);
        TextNotActive();

        /*float distance = Vector3.Distance(portugal.transform.position, portugalEmpty.transform.position);

        if (distance < 50) {
            portugal.transform.position = portugalEmpty.transform.position;
            portugalCorrect = false;
            correct.SetActive(true);
            TextNotActive();
        } else {
            portugal.transform.position = portugalInitialPos;
            //play audio for incorrect
            //show text saying try again
            tryAgain.SetActive(true);
            TextNotActive();
        }*/
    }

    public void DropAustria() {

        austria.transform.position = austriaInitialPos;
        //play audio for incorrect
        //show text saying try again
        tryAgain.SetActive(true);
        TextNotActive();

        /*float distance = Vector3.Distance(austria.transform.position, austriaEmpty.transform.position);

        if (distance < 50) {
            austria.transform.position = austriaEmpty.transform.position;
            austriaCorrect = false;
            correct.SetActive(true);
            TextNotActive();
        } else {
            austria.transform.position = austriaInitialPos;
            //play audio for incorrect
            //show text saying try again
            tryAgain.SetActive(true);
            TextNotActive();
        }*/
    }

    public void DropSpain() {

        spain.transform.position = spainInitialPos;
        //play audio for incorrect
        //show text saying try again
        tryAgain.SetActive(true);
        TextNotActive();

        /*float distance = Vector3.Distance(spain.transform.position, spainEmpty.transform.position);

        if (distance < 50) {
            spain.transform.position = spainEmpty.transform.position;
            spainCorrect = false;
            correct.SetActive(true);
            TextNotActive();
        } else {
            spain.transform.position = spainInitialPos;
            //play audio for incorrect
            //show text saying try again
            tryAgain.SetActive(true);
            TextNotActive();
        }*/
    }

    public void DropItaly() {

        italy.transform.position = italyInitialPos;
        //play audio for incorrect
        //show text saying try again
        tryAgain.SetActive(true);
        TextNotActive();

        /*float distance = Vector3.Distance(italy.transform.position, italyEmpty.transform.position);

        if (distance < 50) {
            italy.transform.position = italyEmpty.transform.position;
            italyCorrect = false;
            correct.SetActive(true);
            TextNotActive();
        } else {
            italy.transform.position = italyInitialPos;
            //play audio for incorrect
            //show text saying try again
            tryAgain.SetActive(true);
            TextNotActive();
        }*/
    }

    public void TextNotActive() {
        //2 seconds delay on each - this will be repeated for the Login too
        StartCoroutine(HideText(tryAgain, 2f));
        StartCoroutine(HideText(correct, 1.5f));
    }

    //for adding a slight delay and making text disappear
    IEnumerator HideText(GameObject text, float delay) {
        yield return new WaitForSeconds(delay);
        text.SetActive(false);
    }
}
