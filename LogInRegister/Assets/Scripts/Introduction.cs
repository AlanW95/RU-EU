using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Introduction : MonoBehaviour
{
    private string introductoryEN, introductoryGR, introductoryDE, introductoryNL, introductoryHR;
    public TextMeshProUGUI introductoryText;
    private bool english = false;
    private bool greek = false;
    private bool german = false;
    private bool dutch = false;
    private bool croatian = false;

    // Start is called before the first frame update
    void Start()
    {
        english = intToBool(PlayerPrefs.GetInt("EnglishSelected"));
        greek = intToBool(PlayerPrefs.GetInt("GreekSelected"));
        german = intToBool(PlayerPrefs.GetInt("GermanSelected"));
        dutch = intToBool(PlayerPrefs.GetInt("DutchSelected"));
        croatian = intToBool(PlayerPrefs.GetInt("CroatianSelected"));

        //english = true;
        //greek = false;

        //later languages
        //german = false;
        //dutch = false;
        //croatian = false;

        //Introductory Text for English being set in PlayerPrefs
        PlayerPrefs.SetString("IntroductoryEnglish", "Hello and welcome to RU EU, the educational game around issues of identity in Europe and the European Union. " +
            "\n\nThe game will begin with you going through the process of being “hired” as a journalist to complete an assignment around identity and Europe. " +
            "As such you will be asked a series of initial questions including some demographic data and attitudes about identity. " +
            "\n\nAfter these questions you will be hired and then asked to complete 5 scenarios. Each scenario provides a series of tasks choosing information from simulated interviews, " +
            "newsfeeds, discussions and developing them into an outline for a magazine article. Although you never have to write the article in the game, you do have to at various points of each scenario, " +
            "select information that could be included in the article itself. At the end of each scenario, you will have to choose and further refine from the information you have selected in that scenario. " +
            "\n\nOnce you have completed all the scenarios, the game will then end with a series of questions around the issues of identity around Europe. Once you have answered these, you have completed the RU EU educational game. " +
            "\n\nThank you for selecting this game and good luck, we hope you enjoy playing it!");

        //Introductory Text for Greek being set in PlayerPrefs
        PlayerPrefs.SetString("IntroductoryGreek", "Γεια σας και καλωσορίζουμε στην ΕΣ της ΕΕ, το εκπαιδευτικό παιχνίδι γύρω από θέματα ταυτότητας στην Ευρώπη και την Ευρωπαϊκή Ένωση. Το παιχνίδι θα ξεκινήσει από τη στιγμή που θα περάσετε τη διαδικασία να μισθώσετε ως δημοσιογράφος για να ολοκληρώσετε μια αποστολή γύρω από την ταυτότητα και την Ευρώπη. Ως εκ τούτου, θα σας ζητηθεί μια σειρά αρχικών ερωτήσεων, συμπεριλαμβανομένων μερικών δημογραφικών δεδομένων και στάσεων σχετικά με την ταυτότητα. Μετά από αυτές τις ερωτήσεις, θα προσληφθεί και στη συνέχεια θα σας ζητηθεί να συμπληρώσετε 5 σενάρια. Κάθε σενάριο παρέχει μια σειρά από καθήκοντα που επιλέγουν πληροφορίες από προσομοιωμένες συνεντεύξεις, newsfeeds, συζητήσεις και την ανάπτυξη τους σε ένα περίγραμμα για ένα άρθρο περιοδικού. Παρόλο που ποτέ δεν πρέπει να γράψετε το άρθρο στο παιχνίδι, πρέπει σε διάφορα σημεία κάθε σεναρίου να επιλέξετε πληροφορίες που θα μπορούσαν να συμπεριληφθούν στο ίδιο το άρθρο. Στο τέλος κάθε σεναρίου, θα πρέπει να επιλέξετε και να βελτιώσετε περαιτέρω τις πληροφορίες που έχετε επιλέξει σε αυτό το σενάριο. Αφού ολοκληρώσετε όλα τα σενάρια, το παιχνίδι τελειώνει με μια σειρά ερωτήσεων γύρω από τα ζητήματα της ταυτότητας σε όλη την Ευρώπη. Αφού απαντήσετε σε αυτά, ολοκληρώσατε το εκπαιδευτικό παιχνίδι της ΕΣ της ΕΕ. Σας ευχαριστούμε που επιλέξατε αυτό το παιχνίδι και καλή τύχη, ελπίζουμε να σας αρέσει να παίζετε!");

        //Introductory Text for German being set in PlayerPrefs
        PlayerPrefs.SetString("IntroductoryGerman", "[INSERT TEXT HERE]");

        //Introductory Text for Dutch being set in PlayerPrefs
        PlayerPrefs.SetString("IntroductoryDutch", "[INSERT TEXT HERE]");

        //Introductory Text for Croatian being set in PlayerPrefs
        PlayerPrefs.SetString("IntroductoryCroatian", "[INSERT TEXT HERE]");

        //Reading all previous set PlayerPrefs so they can be set depending on the bool state of each language in the Update()
        introductoryEN = PlayerPrefs.GetString("IntroductoryEnglish");
        introductoryGR = PlayerPrefs.GetString("IntroductoryGreek");
    }

    // Update is called once per frame
    void Update()
    {
        if (english) {
            introductoryText.text = introductoryEN;
        }

        if (greek) {
            introductoryText.text = introductoryGR;
        }

        if (german) {
            introductoryText.text = introductoryDE;
        }

        if (dutch) {
            introductoryText.text = introductoryNL;
        }

        if (croatian) {
            introductoryText.text = introductoryHR;
        }
    }

    public void Continue() {
        //continue after pressing -> button
        SceneManager.LoadScene("Start");
    }

    int boolToInt(bool val) {
        if (val) {
            return 1;
        } else {
            return 0;
        }
    }

    bool intToBool(int val) {
        if (val != 0) {
            return true;
        } else {
            return false;
        }
    }
}
