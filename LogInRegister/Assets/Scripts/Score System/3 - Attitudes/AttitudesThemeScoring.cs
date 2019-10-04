using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttitudesThemeScoring : MonoBehaviour
{
    public static int socialScore;
    public static int environmentScore;
    public static int rightsAndResponsibilitiesScore;
    public static int safetyAndSecurityScore;
    public static int emotionalScore;
    public static int economyScore;
    public static int politicalScore;
    public static int historicScore;
    public static int cultureScore;
    public static int geographyScore;

    public static string social, environment, rightsresponsibilities, safetysecurity, emotional, economy, political, historic, culture, geography;

    private bool firstSelected = false, secondSelected = false, thirdSelected = false;

    public static string firstPlace, secondPlace, thirdPlace;

    //Text selectedTheme;

    // Start is called before the first frame update
    void Start() {
        socialScore = PlayerPrefs.GetInt("CurrentAttitudesSocialScore");
        environmentScore = PlayerPrefs.GetInt("CurrentAttitudesEnvironmentScore");
        rightsAndResponsibilitiesScore = PlayerPrefs.GetInt("CurrentAttitudesRightsAndResponsibilitiesScore");
        safetyAndSecurityScore = PlayerPrefs.GetInt("CurrentAttitudesSafetyAndSecurityScore");
        emotionalScore = PlayerPrefs.GetInt("CurrentAttitudesEmotionalScore");
        economyScore = PlayerPrefs.GetInt("CurrentAttitudesEconomyScore");
        politicalScore = PlayerPrefs.GetInt("CurrentAttitudesPoliticalScore");
        historicScore = PlayerPrefs.GetInt("CurrentAttitudesHistoricScore");
        cultureScore = PlayerPrefs.GetInt("CurrentAttitudesCultureScore");
        geographyScore = PlayerPrefs.GetInt("CurrentAttitudesGeographyScore");
    }

    // Update is called once per frame
    void Update() {
        if (socialScore < 0) {
            socialScore = 0;
        }

        if (environmentScore < 0) {
            environmentScore = 0;
        }

        if (rightsAndResponsibilitiesScore < 0) {
            rightsAndResponsibilitiesScore = 0;
        }

        if (safetyAndSecurityScore < 0) {
            safetyAndSecurityScore = 0;
        }

        if (emotionalScore < 0) {
            emotionalScore = 0;
        }

        if (economyScore < 0) {
            economyScore = 0;
        }

        if (politicalScore < 0) {
            politicalScore = 0;
        }

        if (historicScore < 0) {
            historicScore = 0;
        }

        if (cultureScore < 0) {
            cultureScore = 0;
        }

        if (geographyScore < 0) {
            geographyScore = 0;
        }

        Number1TopTheme();
        Number2TopTheme();
    }

    public void AddSocialPoints() {
        socialScore += 10;
        PlayerPrefs.SetInt("CurrentAttitudesSocialScore", socialScore);
        Debug.Log("+10 to Social. You currently have " + socialScore + " for the theme of Social.");
    }

    public void AddEnvironmentPoints() {
        environmentScore += 10;
        PlayerPrefs.SetInt("CurrentAttitudesEnvironmentScore", environmentScore);
        Debug.Log("+10 to Social. You currently have " + environmentScore + " for the theme of Environment.");
    }

    public void AddRightsResponsibilitiesPoints() {
        rightsAndResponsibilitiesScore += 10;
        PlayerPrefs.SetInt("CurrentAttitudesRightsAndResponsibilitiesScore", rightsAndResponsibilitiesScore);
        Debug.Log("+10 to Rights and Responsibilities. You currently have " + rightsAndResponsibilitiesScore + " for the theme of Rights and Responsibilities.");
    }

    public void AddSafetySecurityPoints() {
        safetyAndSecurityScore += 10;
        PlayerPrefs.SetInt("CurrentAttitudesSafetyAndSecurityScore", safetyAndSecurityScore);
        Debug.Log("+10 to Safety and Security. You currently have " + safetyAndSecurityScore + " for the theme of Safety and Security.");
    }

    public void AddEmotionalPoints() {
        emotionalScore += 10;
        PlayerPrefs.SetInt("CurrentAttitudesEmotionalScore", emotionalScore);
        Debug.Log("+10 to Emotional. You currently have " + emotionalScore + " for the theme of Emotional.");
    }

    public void AddEconomyPoints() {
        economyScore += 10;
        PlayerPrefs.SetInt("CurrentAttitudesEconomyScore", economyScore);
        Debug.Log("+10 to Economy. You currently have " + economyScore + " for the theme of Economy.");
    }

    public void AddPoliticalPoints() {
        politicalScore += 10;
        PlayerPrefs.SetInt("CurrentAttitudesPoliticalScore", politicalScore);
        Debug.Log("+10 to Political. You currently have " + politicalScore + " for the theme of Political.");
    }

    public void AddHistoricPoints() {
        historicScore += 10;
        PlayerPrefs.SetInt("CurrentAttitudesHistoricScore", historicScore);
        Debug.Log("+10 to Historic. You currently have " + historicScore + " for the theme of Historic.");
    }

    public void AddCulturePoints() {
        cultureScore += 10;
        PlayerPrefs.SetInt("CurrentAttitudesCultureScore", cultureScore);
        Debug.Log("+10 to Culture. You currently have " + cultureScore + " for the theme of Culture.");
    }

    public void AddGeographyPoints() {
        geographyScore += 10;
        PlayerPrefs.SetInt("CurrentAttitudesGeographyScore", geographyScore);
        Debug.Log("+10 to Geography. You currently have " + geographyScore + " for the theme of Geography.");
    }

    public void ResetAllThemes() {
        socialScore = 0;
        environmentScore = 0;
        rightsAndResponsibilitiesScore = 0;
        safetyAndSecurityScore = 0;
        emotionalScore = 0;
        economyScore = 0;
        politicalScore = 0;
        historicScore = 0;
        cultureScore = 0;
        geographyScore = 0;

        PlayerPrefs.SetInt("CurrentAttitudesSocialScore", socialScore);
        PlayerPrefs.SetInt("CurrentAttitudesEnvironmentScore", environmentScore);
        PlayerPrefs.SetInt("CurrentAttitudesRightsAndResponsibilitiesScore", rightsAndResponsibilitiesScore);
        PlayerPrefs.SetInt("CurrentAttitudesSafetyAndSecurityScore", safetyAndSecurityScore);
        PlayerPrefs.SetInt("CurrentAttitudesEmotionalScore", emotionalScore);
        PlayerPrefs.SetInt("CurrentAttitudesEconomyScore", economyScore);
        PlayerPrefs.SetInt("CurrentAttitudesPoliticalScore", politicalScore);
        PlayerPrefs.SetInt("CurrentAttitudesHistoricScore", historicScore);
        PlayerPrefs.SetInt("CurrentAttitudesCultureScore", cultureScore);
        PlayerPrefs.SetInt("CurrentAttitudesGeographyScore", geographyScore);
    }

    public void Number1TopTheme() {

        //if each score is higher than each assign to new PlayerPref for Dashboard
        //Social
        if (socialScore > environmentScore && socialScore > rightsAndResponsibilitiesScore && socialScore > safetyAndSecurityScore && socialScore > emotionalScore
            && socialScore > economyScore && socialScore > politicalScore && socialScore > historicScore && socialScore > cultureScore && socialScore > geographyScore) {

            PlayerPrefs.SetInt("TopAttitudesThemeScore", socialScore);
            social = "Social";
            PlayerPrefs.SetString("TopAttitudesTheme", social);
            firstPlace = "SocialFirst";
            firstSelected = true;

        }
        //Environment
        if (environmentScore > socialScore && environmentScore > rightsAndResponsibilitiesScore && environmentScore > safetyAndSecurityScore && environmentScore > emotionalScore
            && environmentScore > economyScore && environmentScore > politicalScore && environmentScore > historicScore && environmentScore > cultureScore && environmentScore > geographyScore) {

            PlayerPrefs.SetInt("TopAttitudesThemeScore", environmentScore);
            environment = "Environment";
            PlayerPrefs.SetString("TopAttitudesTheme", environment);
            firstPlace = "EnvironmentFirst";
            firstSelected = true;

        }
        //Rights & Responsibilities
        if (rightsAndResponsibilitiesScore > socialScore && rightsAndResponsibilitiesScore > environmentScore && rightsAndResponsibilitiesScore > safetyAndSecurityScore && rightsAndResponsibilitiesScore > emotionalScore
            && rightsAndResponsibilitiesScore > economyScore && rightsAndResponsibilitiesScore > politicalScore && rightsAndResponsibilitiesScore > historicScore && rightsAndResponsibilitiesScore > cultureScore && rightsAndResponsibilitiesScore > geographyScore) {

            PlayerPrefs.SetInt("TopAttitudesThemeScore", rightsAndResponsibilitiesScore);
            rightsresponsibilities = "Rights & Responsibilities";
            PlayerPrefs.SetString("TopAttitudesTheme", rightsresponsibilities);
            firstPlace = "RightsAndResponsibilitiesFirst";
            firstSelected = true;

        }
        //Safety & Security
        if (safetyAndSecurityScore > socialScore && safetyAndSecurityScore > environmentScore && safetyAndSecurityScore > rightsAndResponsibilitiesScore && safetyAndSecurityScore > emotionalScore
            && safetyAndSecurityScore > economyScore && safetyAndSecurityScore > politicalScore && safetyAndSecurityScore > historicScore && safetyAndSecurityScore > cultureScore && safetyAndSecurityScore > geographyScore) {

            PlayerPrefs.SetInt("TopAttitudesThemeScore", safetyAndSecurityScore);
            safetysecurity = "Security";
            PlayerPrefs.SetString("TopAttitudesTheme", safetysecurity);
            firstPlace = "SafetySecurityFirst";
            firstSelected = true;

        }
        //Emotional
        if (emotionalScore > socialScore && emotionalScore > environmentScore && emotionalScore > rightsAndResponsibilitiesScore && emotionalScore > safetyAndSecurityScore
            && emotionalScore > economyScore && emotionalScore > politicalScore && emotionalScore > historicScore && emotionalScore > cultureScore && emotionalScore > geographyScore) {

            PlayerPrefs.SetInt("TopAttitudesThemeScore", emotionalScore);
            emotional = "Emotional";
            PlayerPrefs.SetString("TopAttitudesTheme", emotional);
            firstPlace = "EmotionalFirst";
            firstSelected = true;

        }
        //Economy
        if (economyScore > socialScore && economyScore > environmentScore && economyScore > rightsAndResponsibilitiesScore && economyScore > safetyAndSecurityScore
            && economyScore > emotionalScore && economyScore > politicalScore && economyScore > historicScore && economyScore > cultureScore && economyScore > geographyScore) {

            PlayerPrefs.SetInt("TopAttitudesThemeScore", economyScore);
            economy = "Economy";
            PlayerPrefs.SetString("TopAttitudesTheme", economy);
            firstPlace = "EconomyFirst";
            firstSelected = true;

        }
        //Political
        if (politicalScore > socialScore && politicalScore > environmentScore && politicalScore > rightsAndResponsibilitiesScore && politicalScore > safetyAndSecurityScore
            && politicalScore > emotionalScore && politicalScore > economyScore && politicalScore > historicScore && politicalScore > cultureScore && politicalScore > geographyScore) {

            PlayerPrefs.SetInt("TopAttitudesThemeScore", politicalScore);
            political = "Political";
            PlayerPrefs.SetString("TopAttitudesTheme", political);
            firstPlace = "PoliticalFirst";
            firstSelected = true;

        }
        //Historic 
        if (historicScore > socialScore && historicScore > environmentScore && historicScore > rightsAndResponsibilitiesScore && historicScore > safetyAndSecurityScore
            && historicScore > emotionalScore && historicScore > economyScore && historicScore > politicalScore && historicScore > cultureScore && historicScore > geographyScore) {

            PlayerPrefs.SetInt("TopAttitudesThemeScore", historicScore);
            historic = "Historic";
            PlayerPrefs.SetString("TopAttitudesTheme", historic);
            firstPlace = "HistoricFirst";
            firstSelected = true;

        }
        //Culture
        if (cultureScore > socialScore && cultureScore > environmentScore && cultureScore > rightsAndResponsibilitiesScore && cultureScore > safetyAndSecurityScore
            && cultureScore > emotionalScore && cultureScore > economyScore && cultureScore > politicalScore && cultureScore > historicScore && cultureScore > geographyScore) {

            PlayerPrefs.SetInt("TopAttitudesThemeScore", cultureScore);
            culture = "Culture";
            PlayerPrefs.SetString("TopAttitudesTheme", culture);
            firstPlace = "CultureFirst";
            firstSelected = true;

        }
        //Geography
        if (geographyScore > socialScore && geographyScore > environmentScore && geographyScore > rightsAndResponsibilitiesScore && geographyScore > safetyAndSecurityScore
            && geographyScore > emotionalScore && geographyScore > economyScore && geographyScore > politicalScore && geographyScore > historicScore && geographyScore > cultureScore) {

            PlayerPrefs.SetInt("TopAttitudesThemeScore", geographyScore);
            geography = "Geography";
            PlayerPrefs.SetString("TopAttitudesTheme", geography);
            firstPlace = "GeographyFirst";
            firstSelected = true;
        }
    }

    public void Number2TopTheme() {
        //TOP THEME IS SOCIAL
        if (firstPlace == "SocialFirst") {
            //For Environment
            if (environmentScore < socialScore && environmentScore > rightsAndResponsibilitiesScore && environmentScore > safetyAndSecurityScore && environmentScore > emotionalScore
            && environmentScore > economyScore && environmentScore > politicalScore && environmentScore > historicScore && environmentScore > cultureScore && environmentScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", environmentScore);
                environment = "Environment";
                PlayerPrefs.SetString("SecondAttitudesTheme", environment);
                secondPlace = "EnvironmentSecond";
                secondSelected = true;
            }
            //For Rights & Responsibilities
            if (rightsAndResponsibilitiesScore < socialScore && rightsAndResponsibilitiesScore > environmentScore && rightsAndResponsibilitiesScore > safetyAndSecurityScore && rightsAndResponsibilitiesScore > emotionalScore
            && rightsAndResponsibilitiesScore > economyScore && rightsAndResponsibilitiesScore > politicalScore && rightsAndResponsibilitiesScore > historicScore && rightsAndResponsibilitiesScore > cultureScore && rightsAndResponsibilitiesScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", rightsAndResponsibilitiesScore);
                rightsresponsibilities = "Rights & Responsibilities";
                PlayerPrefs.SetString("SecondAttitudesTheme", rightsresponsibilities);
                secondPlace = "RightsAndResponsibilitiesSecond";
                secondSelected = true;
            }
            //For Security
            if (safetyAndSecurityScore < socialScore && safetyAndSecurityScore > environmentScore && safetyAndSecurityScore > rightsAndResponsibilitiesScore && safetyAndSecurityScore > emotionalScore
            && safetyAndSecurityScore > economyScore && safetyAndSecurityScore > politicalScore && safetyAndSecurityScore > historicScore && safetyAndSecurityScore > cultureScore && safetyAndSecurityScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", safetyAndSecurityScore);
                safetysecurity = "Security";
                PlayerPrefs.SetString("SecondAttitudesTheme", safetysecurity);
                secondPlace = "SafetySecuritySecond";
                secondSelected = true;
            }
            //For Emotional
            if (emotionalScore < socialScore && emotionalScore > environmentScore && emotionalScore > rightsAndResponsibilitiesScore && emotionalScore > safetyAndSecurityScore
            && emotionalScore > economyScore && emotionalScore > politicalScore && emotionalScore > historicScore && emotionalScore > cultureScore && emotionalScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", emotionalScore);
                emotional = "Emotional";
                PlayerPrefs.SetString("SecondAttitudesTheme", emotional);
                secondPlace = "EmotionalSecond";
                secondSelected = true;
            }
            //For Economy
            if (economyScore < socialScore && economyScore > environmentScore && economyScore > rightsAndResponsibilitiesScore && economyScore > safetyAndSecurityScore
            && economyScore > emotionalScore && economyScore > politicalScore && economyScore > historicScore && economyScore > cultureScore && economyScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", economyScore);
                economy = "Economy";
                PlayerPrefs.SetString("SecondAttitudesTheme", economy);
                secondPlace = "EconomySecond";
                secondSelected = true;
            }
            //For Political
            if (politicalScore < socialScore && politicalScore > environmentScore && politicalScore > rightsAndResponsibilitiesScore && politicalScore > safetyAndSecurityScore
            && politicalScore > emotionalScore && politicalScore > economyScore && politicalScore > historicScore && politicalScore > cultureScore && politicalScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", politicalScore);
                political = "Political";
                PlayerPrefs.SetString("SecondAttitudesTheme", political);
                secondPlace = "PoliticalSecond";
                secondSelected = true;
            }
            //For Historic
            if (historicScore < socialScore && historicScore > environmentScore && historicScore > rightsAndResponsibilitiesScore && historicScore > safetyAndSecurityScore
            && historicScore > emotionalScore && historicScore > economyScore && historicScore > politicalScore && historicScore > cultureScore && historicScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", historicScore);
                historic = "Historic";
                PlayerPrefs.SetString("SecondAttitudesTheme", historic);
                secondPlace = "HistoricSecond";
                secondSelected = true;
            }
            //For Culture
            if (cultureScore < socialScore && cultureScore > environmentScore && cultureScore > rightsAndResponsibilitiesScore && cultureScore > safetyAndSecurityScore
            && cultureScore > emotionalScore && cultureScore > economyScore && cultureScore > politicalScore && cultureScore > historicScore && cultureScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", cultureScore);
                culture = "Culture";
                PlayerPrefs.SetString("SecondAttitudesTheme", culture);
                secondPlace = "CultureSecond";
                secondSelected = true;
            }
            //For Geography
            if (geographyScore < socialScore && geographyScore > environmentScore && geographyScore > rightsAndResponsibilitiesScore && geographyScore > safetyAndSecurityScore
            && geographyScore > emotionalScore && geographyScore > economyScore && geographyScore > politicalScore && geographyScore > historicScore && geographyScore > cultureScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", geographyScore);
                geography = "Geography";
                PlayerPrefs.SetString("SecondAttitudesTheme", geography);
                secondPlace = "GeographySecond";
                secondSelected = true;
            }
        }

        //TOP THEME IS ENVIRONMENT
        if (firstPlace == "EnvironmentFirst") {
            //For Social
            if (socialScore < environmentScore && socialScore > rightsAndResponsibilitiesScore && socialScore > safetyAndSecurityScore && socialScore > emotionalScore
            && socialScore > economyScore && socialScore > politicalScore && socialScore > historicScore && socialScore > cultureScore && socialScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", socialScore);
                social = "Social";
                PlayerPrefs.SetString("SecondAttitudesTheme", social);
                secondPlace = "SocialSecond";
                secondSelected = true;
            }
            //For Rights & Responsibilities
            if (rightsAndResponsibilitiesScore < environmentScore && rightsAndResponsibilitiesScore > socialScore && rightsAndResponsibilitiesScore > safetyAndSecurityScore && rightsAndResponsibilitiesScore > emotionalScore
            && rightsAndResponsibilitiesScore > economyScore && rightsAndResponsibilitiesScore > politicalScore && rightsAndResponsibilitiesScore > historicScore && rightsAndResponsibilitiesScore > cultureScore && rightsAndResponsibilitiesScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", rightsAndResponsibilitiesScore);
                rightsresponsibilities = "Rights & Responsibilities";
                PlayerPrefs.SetString("SecondAttitudesTheme", rightsresponsibilities);
                secondPlace = "RightsAndResponsibilitiesSecond";
                secondSelected = true;
            }
            //For Security
            if (safetyAndSecurityScore < environmentScore && safetyAndSecurityScore > socialScore && safetyAndSecurityScore > rightsAndResponsibilitiesScore && safetyAndSecurityScore > emotionalScore
            && safetyAndSecurityScore > economyScore && safetyAndSecurityScore > politicalScore && safetyAndSecurityScore > historicScore && safetyAndSecurityScore > cultureScore && safetyAndSecurityScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", safetyAndSecurityScore);
                safetysecurity = "Security";
                PlayerPrefs.SetString("SecondAttitudesTheme", safetysecurity);
                secondPlace = "SafetySecuritySecond";
                secondSelected = true;
            }
            //For Emotional
            if (emotionalScore < environmentScore && emotionalScore > socialScore && emotionalScore > rightsAndResponsibilitiesScore && emotionalScore > safetyAndSecurityScore
            && emotionalScore > economyScore && emotionalScore > politicalScore && emotionalScore > historicScore && emotionalScore > cultureScore && emotionalScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", emotionalScore);
                emotional = "Emotional";
                PlayerPrefs.SetString("SecondAttitudesTheme", emotional);
                secondPlace = "EmotionalSecond";
                secondSelected = true;
            }
            //For Economy
            if (economyScore < environmentScore && economyScore > environmentScore && socialScore > rightsAndResponsibilitiesScore && economyScore > safetyAndSecurityScore
            && economyScore > emotionalScore && economyScore > politicalScore && economyScore > historicScore && economyScore > cultureScore && economyScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", economyScore);
                economy = "Economy";
                PlayerPrefs.SetString("SecondAttitudesTheme", economy);
                secondPlace = "EconomySecond";
                secondSelected = true;
            }
            //For Political
            if (politicalScore < environmentScore && politicalScore > socialScore && politicalScore > rightsAndResponsibilitiesScore && politicalScore > safetyAndSecurityScore
            && politicalScore > emotionalScore && politicalScore > economyScore && politicalScore > historicScore && politicalScore > cultureScore && politicalScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", politicalScore);
                political = "Political";
                PlayerPrefs.SetString("SecondAttitudesTheme", political);
                secondPlace = "PoliticalSecond";
                secondSelected = true;
            }
            //For Historic
            if (historicScore < environmentScore && historicScore > socialScore && historicScore > rightsAndResponsibilitiesScore && historicScore > safetyAndSecurityScore
            && historicScore > emotionalScore && historicScore > economyScore && historicScore > politicalScore && historicScore > cultureScore && historicScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", historicScore);
                historic = "Historic";
                PlayerPrefs.SetString("SecondAttitudesTheme", historic);
                secondPlace = "HistoricSecond";
                secondSelected = true;
            }
            //For Culture
            if (cultureScore < environmentScore && cultureScore > socialScore && cultureScore > rightsAndResponsibilitiesScore && cultureScore > safetyAndSecurityScore
            && cultureScore > emotionalScore && cultureScore > economyScore && cultureScore > politicalScore && cultureScore > historicScore && cultureScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", cultureScore);
                culture = "Culture";
                PlayerPrefs.SetString("SecondAttitudesTheme", culture);
                secondPlace = "CultureSecond";
                secondSelected = true;
            }
            //For Geography
            if (geographyScore < environmentScore && geographyScore > socialScore && geographyScore > rightsAndResponsibilitiesScore && geographyScore > safetyAndSecurityScore
            && geographyScore > emotionalScore && geographyScore > economyScore && geographyScore > politicalScore && geographyScore > historicScore && geographyScore > cultureScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", geographyScore);
                geography = "Geography";
                PlayerPrefs.SetString("SecondAttitudesTheme", geography);
                secondPlace = "GeographySecond";
                secondSelected = true;
            }
        }

        //TOP THEME IS RIGHTS & RESPONSIBILITIES
        if (firstPlace == "RightsAndResponsibilitiesFirst") {
            //For Social
            if (socialScore < rightsAndResponsibilitiesScore && socialScore > environmentScore && socialScore > safetyAndSecurityScore && socialScore > emotionalScore
            && socialScore > economyScore && socialScore > politicalScore && socialScore > historicScore && socialScore > cultureScore && socialScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", socialScore);
                social = "Social";
                PlayerPrefs.SetString("SecondAttitudesTheme", social);
                secondPlace = "SocialSecond";
                secondSelected = true;
            }
            //For Environment
            if (environmentScore < rightsAndResponsibilitiesScore && environmentScore > socialScore && environmentScore > safetyAndSecurityScore && environmentScore > emotionalScore
            && environmentScore > economyScore && environmentScore > politicalScore && environmentScore > historicScore && environmentScore > cultureScore && environmentScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", environmentScore);
                environment = "Environment";
                PlayerPrefs.SetString("SecondAttitudesTheme", environment);
                secondPlace = "EnvironmentSecond";
                secondSelected = true;
            }
            //For Security
            if (safetyAndSecurityScore < rightsAndResponsibilitiesScore && safetyAndSecurityScore > socialScore && safetyAndSecurityScore > environmentScore && safetyAndSecurityScore > emotionalScore
            && safetyAndSecurityScore > economyScore && safetyAndSecurityScore > politicalScore && safetyAndSecurityScore > historicScore && safetyAndSecurityScore > cultureScore && safetyAndSecurityScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", safetyAndSecurityScore);
                safetysecurity = "Security";
                PlayerPrefs.SetString("SecondAttitudesTheme", safetysecurity);
                secondPlace = "SafetySecuritySecond";
                secondSelected = true;
            }
            //For Emotional
            if (emotionalScore < rightsAndResponsibilitiesScore && emotionalScore > socialScore && emotionalScore > environmentScore && emotionalScore > safetyAndSecurityScore
            && emotionalScore > economyScore && emotionalScore > politicalScore && emotionalScore > historicScore && emotionalScore > cultureScore && emotionalScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", emotionalScore);
                emotional = "Emotional";
                PlayerPrefs.SetString("SecondAttitudesTheme", emotional);
                secondPlace = "EmotionalSecond";
                secondSelected = true;
            }
            //For Economy
            if (economyScore < rightsAndResponsibilitiesScore && economyScore > socialScore && economyScore > environmentScore && economyScore > safetyAndSecurityScore
            && economyScore > emotionalScore && economyScore > politicalScore && economyScore > historicScore && economyScore > cultureScore && economyScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", economyScore);
                economy = "Economy";
                PlayerPrefs.SetString("SecondAttitudesTheme", economy);
                secondPlace = "EconomySecond";
                secondSelected = true;
            }
            //For Political
            if (politicalScore < rightsAndResponsibilitiesScore && politicalScore > socialScore && politicalScore > environmentScore && politicalScore > safetyAndSecurityScore
            && politicalScore > emotionalScore && politicalScore > economyScore && politicalScore > historicScore && politicalScore > cultureScore && politicalScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", politicalScore);
                political = "Political";
                PlayerPrefs.SetString("SecondAttitudesTheme", political);
                secondPlace = "PoliticalSecond";
                secondSelected = true;
            }
            //For Historic
            if (historicScore < rightsAndResponsibilitiesScore && historicScore > socialScore && historicScore > environmentScore && historicScore > safetyAndSecurityScore
            && historicScore > emotionalScore && historicScore > economyScore && historicScore > politicalScore && historicScore > cultureScore && historicScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", historicScore);
                historic = "Historic";
                PlayerPrefs.SetString("SecondAttitudesTheme", historic);
                secondPlace = "HistoricSecond";
                secondSelected = true;
            }
            //For Culture
            if (cultureScore < rightsAndResponsibilitiesScore && cultureScore > socialScore && cultureScore > environmentScore && cultureScore > safetyAndSecurityScore
            && cultureScore > emotionalScore && cultureScore > economyScore && cultureScore > politicalScore && cultureScore > historicScore && cultureScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", cultureScore);
                culture = "Culture";
                PlayerPrefs.SetString("SecondAttitudesTheme", culture);
                secondPlace = "CultureSecond";
                secondSelected = true;
            }
            //For Geography
            if (geographyScore < rightsAndResponsibilitiesScore && geographyScore > socialScore && geographyScore > environmentScore && geographyScore > safetyAndSecurityScore
            && geographyScore > emotionalScore && geographyScore > economyScore && geographyScore > politicalScore && geographyScore > historicScore && geographyScore > cultureScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", geographyScore);
                geography = "Geography";
                PlayerPrefs.SetString("SecondAttitudesTheme", geography);
                secondPlace = "GeographySecond";
                secondSelected = true;
            }
        }

        //TOP THEME IS SAFETY & SECURITY
        if (firstPlace == "SafetySecurityFirst") {
            //For Social
            if (socialScore < safetyAndSecurityScore && socialScore > environmentScore && socialScore > rightsAndResponsibilitiesScore && socialScore > emotionalScore
            && socialScore > economyScore && socialScore > politicalScore && socialScore > historicScore && socialScore > cultureScore && socialScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", socialScore);
                social = "Social";
                PlayerPrefs.SetString("SecondAttitudesTheme", social);
                secondPlace = "SocialSecond";
                secondSelected = true;
            }
            //For Environment
            if (environmentScore < safetyAndSecurityScore && environmentScore > socialScore && environmentScore > rightsAndResponsibilitiesScore && environmentScore > emotionalScore
            && environmentScore > economyScore && environmentScore > politicalScore && environmentScore > historicScore && environmentScore > cultureScore && environmentScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", environmentScore);
                environment = "Environment";
                PlayerPrefs.SetString("SecondAttitudesTheme", environment);
                secondPlace = "EnvironmentSecond";
                secondSelected = true;
            }
            //For Rights & Responsibilities
            if (rightsAndResponsibilitiesScore < safetyAndSecurityScore && rightsAndResponsibilitiesScore > socialScore && rightsAndResponsibilitiesScore > environmentScore && rightsAndResponsibilitiesScore > emotionalScore
            && rightsAndResponsibilitiesScore > economyScore && rightsAndResponsibilitiesScore > politicalScore && rightsAndResponsibilitiesScore > historicScore && rightsAndResponsibilitiesScore > cultureScore && rightsAndResponsibilitiesScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", rightsAndResponsibilitiesScore);
                rightsresponsibilities = "Rights & Responsibilities";
                PlayerPrefs.SetString("SecondAttitudesTheme", rightsresponsibilities);
                secondPlace = "RightsAndResponsibilitiesSecond";
                secondSelected = true;
            }
            //For Emotional
            if (emotionalScore < safetyAndSecurityScore && emotionalScore > socialScore && emotionalScore > environmentScore && emotionalScore > rightsAndResponsibilitiesScore
            && emotionalScore > economyScore && emotionalScore > politicalScore && emotionalScore > historicScore && emotionalScore > cultureScore && emotionalScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", emotionalScore);
                emotional = "Emotional";
                PlayerPrefs.SetString("SecondAttitudesTheme", emotional);
                secondPlace = "EmotionalSecond";
                secondSelected = true;
            }
            //For Economy
            if (economyScore < safetyAndSecurityScore && economyScore > socialScore && economyScore > environmentScore && economyScore > rightsAndResponsibilitiesScore
            && economyScore > emotionalScore && economyScore > politicalScore && economyScore > historicScore && economyScore > cultureScore && economyScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", economyScore);
                economy = "Economy";
                PlayerPrefs.SetString("SecondAttitudesTheme", economy);
                secondPlace = "EconomySecond";
                secondSelected = true;
            }
            //For Political
            if (politicalScore < safetyAndSecurityScore && politicalScore > socialScore && politicalScore > environmentScore && politicalScore > rightsAndResponsibilitiesScore
            && politicalScore > emotionalScore && politicalScore > economyScore && politicalScore > historicScore && politicalScore > cultureScore && politicalScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", politicalScore);
                political = "Political";
                PlayerPrefs.SetString("SecondAttitudesTheme", political);
                secondPlace = "PoliticalSecond";
                secondSelected = true;
            }
            //For Historic
            if (historicScore < safetyAndSecurityScore && historicScore > socialScore && historicScore > environmentScore && historicScore > rightsAndResponsibilitiesScore
            && historicScore > emotionalScore && historicScore > economyScore && historicScore > politicalScore && historicScore > cultureScore && historicScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", historicScore);
                historic = "Historic";
                PlayerPrefs.SetString("SecondAttitudesTheme", historic);
                secondPlace = "HistoricSecond";
                secondSelected = true;
            }
            //For Culture
            if (cultureScore < safetyAndSecurityScore && cultureScore > socialScore && cultureScore > environmentScore && cultureScore > rightsAndResponsibilitiesScore
            && cultureScore > emotionalScore && cultureScore > economyScore && cultureScore > politicalScore && cultureScore > historicScore && cultureScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", cultureScore);
                culture = "Culture";
                PlayerPrefs.SetString("SecondAttitudesTheme", culture);
                secondPlace = "CultureSecond";
                secondSelected = true;
            }
            //For Geography
            if (geographyScore < safetyAndSecurityScore && geographyScore > socialScore && geographyScore > environmentScore && geographyScore > rightsAndResponsibilitiesScore
            && geographyScore > emotionalScore && geographyScore > economyScore && geographyScore > politicalScore && geographyScore > historicScore && geographyScore > cultureScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", geographyScore);
                geography = "Geography";
                PlayerPrefs.SetString("SecondAttitudesTheme", geography);
                secondPlace = "GeographySecond";
                secondSelected = true;
            }
        }

        //TOP THEME IS EMOTIONAL
        if (firstPlace == "EmotionalFirst") {
            //For Social
            if (socialScore < emotionalScore && socialScore > environmentScore && socialScore > rightsAndResponsibilitiesScore && socialScore > safetyAndSecurityScore
            && socialScore > economyScore && socialScore > politicalScore && socialScore > historicScore && socialScore > cultureScore && socialScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", socialScore);
                social = "Social";
                PlayerPrefs.SetString("SecondAttitudesTheme", social);
                secondPlace = "SocialSecond";
                secondSelected = true;
            }
            //For Environment
            if (environmentScore < emotionalScore && environmentScore > socialScore && environmentScore > rightsAndResponsibilitiesScore && environmentScore > safetyAndSecurityScore
            && environmentScore > economyScore && environmentScore > politicalScore && environmentScore > historicScore && environmentScore > cultureScore && environmentScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", environmentScore);
                environment = "Environment";
                PlayerPrefs.SetString("SecondAttitudesTheme", environment);
                secondPlace = "EnvironmentSecond";
                secondSelected = true;
            }
            //For Rights & Responsibilities
            if (rightsAndResponsibilitiesScore < emotionalScore && rightsAndResponsibilitiesScore > socialScore && rightsAndResponsibilitiesScore > environmentScore && rightsAndResponsibilitiesScore > safetyAndSecurityScore
            && rightsAndResponsibilitiesScore > economyScore && rightsAndResponsibilitiesScore > politicalScore && rightsAndResponsibilitiesScore > historicScore && rightsAndResponsibilitiesScore > cultureScore && rightsAndResponsibilitiesScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", rightsAndResponsibilitiesScore);
                rightsresponsibilities = "Rights & Responsibilities";
                PlayerPrefs.SetString("SecondAttitudesTheme", rightsresponsibilities);
                secondPlace = "RightsAndResponsibilitiesSecond";
                secondSelected = true;
            }
            //For Security
            if (safetyAndSecurityScore < emotionalScore && safetyAndSecurityScore > socialScore && safetyAndSecurityScore > environmentScore && safetyAndSecurityScore > rightsAndResponsibilitiesScore
            && safetyAndSecurityScore > economyScore && safetyAndSecurityScore > politicalScore && safetyAndSecurityScore > historicScore && safetyAndSecurityScore > cultureScore && safetyAndSecurityScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", safetyAndSecurityScore);
                safetysecurity = "Security";
                PlayerPrefs.SetString("SecondAttitudesTheme", safetysecurity);
                secondPlace = "SafetySecuritySecond";
                secondSelected = true;
            }
            //For Economy
            if (economyScore < emotionalScore && economyScore > socialScore && economyScore > environmentScore && economyScore > rightsAndResponsibilitiesScore
            && economyScore > safetyAndSecurityScore && economyScore > politicalScore && economyScore > historicScore && economyScore > cultureScore && economyScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", economyScore);
                economy = "Economy";
                PlayerPrefs.SetString("SecondAttitudesTheme", economy);
                secondPlace = "EconomySecond";
                secondSelected = true;
            }
            //For Political
            if (politicalScore < emotionalScore && politicalScore > socialScore && politicalScore > environmentScore && politicalScore > rightsAndResponsibilitiesScore
            && politicalScore > safetyAndSecurityScore && politicalScore > economyScore && politicalScore > historicScore && politicalScore > cultureScore && politicalScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", politicalScore);
                political = "Political";
                PlayerPrefs.SetString("SecondAttitudesTheme", political);
                secondPlace = "PoliticalSecond";
                secondSelected = true;
            }
            //For Historic
            if (historicScore < emotionalScore && historicScore > socialScore && historicScore > environmentScore && historicScore > rightsAndResponsibilitiesScore
            && historicScore > safetyAndSecurityScore && historicScore > economyScore && historicScore > politicalScore && historicScore > cultureScore && historicScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", historicScore);
                historic = "Historic";
                PlayerPrefs.SetString("SecondAttitudesTheme", historic);
                secondPlace = "HistoricSecond";
                secondSelected = true;
            }
            //For Culture
            if (cultureScore < emotionalScore && cultureScore > socialScore && cultureScore > environmentScore && cultureScore > rightsAndResponsibilitiesScore
            && cultureScore > safetyAndSecurityScore && cultureScore > economyScore && cultureScore > politicalScore && cultureScore > historicScore && cultureScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", cultureScore);
                culture = "Culture";
                PlayerPrefs.SetString("SecondAttitudesTheme", culture);
                secondPlace = "CultureSecond";
                secondSelected = true;
            }
            //For Geography
            if (geographyScore < emotionalScore && geographyScore > socialScore && geographyScore > environmentScore && geographyScore > rightsAndResponsibilitiesScore
            && geographyScore > safetyAndSecurityScore && geographyScore > economyScore && geographyScore > politicalScore && geographyScore > historicScore && geographyScore > cultureScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", geographyScore);
                geography = "Geography";
                PlayerPrefs.SetString("SecondAttitudesTheme", geography);
                secondPlace = "GeographySecond";
                secondSelected = true;
            }
        }

        //TOP THEME IS ECONOMY
        if (firstPlace == "EconomyFirst") {
            //For Social
            if (socialScore < economyScore && socialScore > environmentScore && socialScore > rightsAndResponsibilitiesScore && socialScore > safetyAndSecurityScore
            && socialScore > emotionalScore && socialScore > politicalScore && socialScore > historicScore && socialScore > cultureScore && socialScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", socialScore);
                social = "Social";
                PlayerPrefs.SetString("SecondAttitudesTheme", social);
                secondPlace = "SocialSecond";
                secondSelected = true;
            }
            //For Environment
            if (environmentScore < economyScore && environmentScore > socialScore && environmentScore > rightsAndResponsibilitiesScore && environmentScore > safetyAndSecurityScore
            && environmentScore > emotionalScore && environmentScore > politicalScore && environmentScore > historicScore && environmentScore > cultureScore && environmentScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", environmentScore);
                environment = "Environment";
                PlayerPrefs.SetString("SecondAttitudesTheme", environment);
                secondPlace = "EnvironmentSecond";
                secondSelected = true;
            }
            //For Rights & Responsibilities
            if (rightsAndResponsibilitiesScore < economyScore && rightsAndResponsibilitiesScore > socialScore && rightsAndResponsibilitiesScore > environmentScore && rightsAndResponsibilitiesScore > safetyAndSecurityScore
            && rightsAndResponsibilitiesScore > emotionalScore && rightsAndResponsibilitiesScore > politicalScore && rightsAndResponsibilitiesScore > historicScore && rightsAndResponsibilitiesScore > cultureScore && rightsAndResponsibilitiesScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", rightsAndResponsibilitiesScore);
                rightsresponsibilities = "Rights & Responsibilities";
                PlayerPrefs.SetString("SecondAttitudesTheme", rightsresponsibilities);
                secondPlace = "RightsAndResponsibilitiesSecond";
                secondSelected = true;
            }
            //For Security
            if (safetyAndSecurityScore < economyScore && safetyAndSecurityScore > socialScore && safetyAndSecurityScore > environmentScore && safetyAndSecurityScore > rightsAndResponsibilitiesScore
            && safetyAndSecurityScore > emotionalScore && safetyAndSecurityScore > politicalScore && safetyAndSecurityScore > historicScore && safetyAndSecurityScore > cultureScore && safetyAndSecurityScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", safetyAndSecurityScore);
                safetysecurity = "Security";
                PlayerPrefs.SetString("SecondAttitudesTheme", safetysecurity);
                secondPlace = "SafetySecuritySecond";
                secondSelected = true;
            }
            //For Emotional
            if (emotionalScore < economyScore && emotionalScore > socialScore && emotionalScore > environmentScore && emotionalScore > rightsAndResponsibilitiesScore
            && emotionalScore > safetyAndSecurityScore && emotionalScore > politicalScore && emotionalScore > historicScore && emotionalScore > cultureScore && emotionalScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", emotionalScore);
                emotional = "Emotional";
                PlayerPrefs.SetString("SecondAttitudesTheme", emotional);
                secondPlace = "EmotionalSecond";
                secondSelected = true;
            }
            //For Political
            if (politicalScore < economyScore && politicalScore > socialScore && politicalScore > environmentScore && politicalScore > rightsAndResponsibilitiesScore
            && politicalScore > safetyAndSecurityScore && politicalScore > emotionalScore && politicalScore > historicScore && politicalScore > cultureScore && politicalScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", politicalScore);
                political = "Political";
                PlayerPrefs.SetString("SecondAttitudesTheme", political);
                secondPlace = "PoliticalSecond";
                secondSelected = true;
            }
            //For Historic
            if (historicScore < economyScore && historicScore > socialScore && historicScore > environmentScore && historicScore > rightsAndResponsibilitiesScore
            && historicScore > safetyAndSecurityScore && historicScore > emotionalScore && historicScore > politicalScore && historicScore > cultureScore && historicScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", historicScore);
                historic = "Historic";
                PlayerPrefs.SetString("SecondAttitudesTheme", historic);
                secondPlace = "HistoricSecond";
                secondSelected = true;
            }
            //For Culture
            if (cultureScore < economyScore && cultureScore > socialScore && cultureScore > environmentScore && cultureScore > rightsAndResponsibilitiesScore
            && cultureScore > safetyAndSecurityScore && cultureScore > emotionalScore && cultureScore > politicalScore && cultureScore > historicScore && cultureScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", cultureScore);
                culture = "Culture";
                PlayerPrefs.SetString("SecondAttitudesTheme", culture);
                secondPlace = "CultureSecond";
                secondSelected = true;
            }
            //For Geography
            if (geographyScore < economyScore && geographyScore > socialScore && geographyScore > environmentScore && geographyScore > rightsAndResponsibilitiesScore
            && geographyScore > safetyAndSecurityScore && geographyScore > emotionalScore && geographyScore > politicalScore && geographyScore > historicScore && geographyScore > cultureScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", geographyScore);
                geography = "Geography";
                PlayerPrefs.SetString("SecondAttitudesTheme", geography);
                secondPlace = "GeographySecond";
                secondSelected = true;
            }
        }

        //TOP THEME IS POLITICAL
        if (firstPlace == "PoliticalFirst") {
            //For Social
            if (socialScore < politicalScore && socialScore > environmentScore && socialScore > rightsAndResponsibilitiesScore && socialScore > safetyAndSecurityScore
            && socialScore > emotionalScore && socialScore > economyScore && socialScore > historicScore && socialScore > cultureScore && socialScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", socialScore);
                social = "Social";
                PlayerPrefs.SetString("SecondAttitudesTheme", social);
                secondPlace = "SocialSecond";
                secondSelected = true;
            }
            //For Environment
            if (environmentScore < politicalScore && environmentScore > socialScore && environmentScore > rightsAndResponsibilitiesScore && environmentScore > safetyAndSecurityScore
            && environmentScore > emotionalScore && environmentScore > economyScore && environmentScore > historicScore && environmentScore > cultureScore && environmentScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", environmentScore);
                environment = "Environment";
                PlayerPrefs.SetString("SecondAttitudesTheme", environment);
                secondPlace = "EnvironmentSecond";
                secondSelected = true;
            }
            //For Rights & Responsibilities
            if (rightsAndResponsibilitiesScore < politicalScore && rightsAndResponsibilitiesScore > socialScore && rightsAndResponsibilitiesScore > environmentScore && rightsAndResponsibilitiesScore > safetyAndSecurityScore
            && rightsAndResponsibilitiesScore > emotionalScore && rightsAndResponsibilitiesScore > economyScore && rightsAndResponsibilitiesScore > historicScore && rightsAndResponsibilitiesScore > cultureScore && rightsAndResponsibilitiesScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", rightsAndResponsibilitiesScore);
                rightsresponsibilities = "Rights & Responsibilities";
                PlayerPrefs.SetString("SecondAttitudesTheme", rightsresponsibilities);
                secondPlace = "RightsAndResponsibilitiesSecond";
                secondSelected = true;
            }
            //For Security
            if (safetyAndSecurityScore < politicalScore && safetyAndSecurityScore > socialScore && safetyAndSecurityScore > environmentScore && safetyAndSecurityScore > rightsAndResponsibilitiesScore
            && safetyAndSecurityScore > emotionalScore && safetyAndSecurityScore > economyScore && safetyAndSecurityScore > historicScore && safetyAndSecurityScore > cultureScore && safetyAndSecurityScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", safetyAndSecurityScore);
                safetysecurity = "Security";
                PlayerPrefs.SetString("SecondAttitudesTheme", safetysecurity);
                secondPlace = "SafetySecuritySecond";
                secondSelected = true;
            }
            //For Emotional
            if (emotionalScore < politicalScore && emotionalScore > socialScore && emotionalScore > environmentScore && emotionalScore > rightsAndResponsibilitiesScore
            && emotionalScore > safetyAndSecurityScore && emotionalScore > economyScore && emotionalScore > historicScore && emotionalScore > cultureScore && emotionalScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", emotionalScore);
                emotional = "Emotional";
                PlayerPrefs.SetString("SecondAttitudesTheme", emotional);
                secondPlace = "EmotionalSecond";
                secondSelected = true;
            }
            //For Economy
            if (economyScore < politicalScore && economyScore > socialScore && economyScore > environmentScore && economyScore > rightsAndResponsibilitiesScore
            && economyScore > safetyAndSecurityScore && economyScore > emotionalScore && economyScore > historicScore && economyScore > cultureScore && economyScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", economyScore);
                economy = "Economy";
                PlayerPrefs.SetString("SecondAttitudesTheme", economy);
                secondPlace = "EconomySecond";
                secondSelected = true;
            }
            //For Historic
            if (historicScore < politicalScore && historicScore > socialScore && historicScore > environmentScore && historicScore > rightsAndResponsibilitiesScore
            && historicScore > safetyAndSecurityScore && historicScore > emotionalScore && historicScore > economyScore && historicScore > cultureScore && historicScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", historicScore);
                historic = "Historic";
                PlayerPrefs.SetString("SecondAttitudesTheme", historic);
                secondPlace = "HistoricSecond";
                secondSelected = true;
            }
            //For Culture
            if (cultureScore < politicalScore && cultureScore > socialScore && cultureScore > environmentScore && cultureScore > rightsAndResponsibilitiesScore
            && cultureScore > safetyAndSecurityScore && cultureScore > emotionalScore && cultureScore > economyScore && cultureScore > historicScore && cultureScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", cultureScore);
                culture = "Culture";
                PlayerPrefs.SetString("SecondAttitudesTheme", culture);
                secondPlace = "CultureSecond";
                secondSelected = true;
            }
            //For Geography
            if (geographyScore < politicalScore && geographyScore > socialScore && geographyScore > environmentScore && geographyScore > rightsAndResponsibilitiesScore
            && geographyScore > safetyAndSecurityScore && geographyScore > emotionalScore && geographyScore > economyScore && geographyScore > historicScore && geographyScore > cultureScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", geographyScore);
                geography = "Geography";
                PlayerPrefs.SetString("SecondAttitudesTheme", geography);
                secondPlace = "GeographySecond";
                secondSelected = true;
            }
        }

        //TOP THEME IS HISTORIC
        if (firstPlace == "HistoricFirst") {
            //For Social
            if (socialScore < historicScore && socialScore > environmentScore && socialScore > rightsAndResponsibilitiesScore && socialScore > safetyAndSecurityScore
            && socialScore > emotionalScore && socialScore > economyScore && socialScore > politicalScore && socialScore > cultureScore && socialScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", socialScore);
                social = "Social";
                PlayerPrefs.SetString("SecondAttitudesTheme", social);
                secondPlace = "SocialSecond";
                secondSelected = true;
            }
            //For Environment
            if (environmentScore < historicScore && environmentScore > socialScore && environmentScore > rightsAndResponsibilitiesScore && environmentScore > safetyAndSecurityScore
            && environmentScore > emotionalScore && environmentScore > economyScore && environmentScore > politicalScore && environmentScore > cultureScore && environmentScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", environmentScore);
                environment = "Environment";
                PlayerPrefs.SetString("SecondAttitudesTheme", environment);
                secondPlace = "EnvironmentSecond";
                secondSelected = true;
            }
            //For Rights & Responsibilities
            if (rightsAndResponsibilitiesScore < historicScore && rightsAndResponsibilitiesScore > socialScore && rightsAndResponsibilitiesScore > environmentScore && rightsAndResponsibilitiesScore > safetyAndSecurityScore
            && rightsAndResponsibilitiesScore > emotionalScore && rightsAndResponsibilitiesScore > economyScore && rightsAndResponsibilitiesScore > politicalScore && rightsAndResponsibilitiesScore > cultureScore && rightsAndResponsibilitiesScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", rightsAndResponsibilitiesScore);
                rightsresponsibilities = "Rights & Responsibilities";
                PlayerPrefs.SetString("SecondAttitudesTheme", rightsresponsibilities);
                secondPlace = "RightsAndResponsibilitiesSecond";
                secondSelected = true;
            }
            //For Security
            if (safetyAndSecurityScore < historicScore && safetyAndSecurityScore > socialScore && safetyAndSecurityScore > environmentScore && safetyAndSecurityScore > rightsAndResponsibilitiesScore
            && safetyAndSecurityScore > emotionalScore && safetyAndSecurityScore > economyScore && safetyAndSecurityScore > politicalScore && safetyAndSecurityScore > cultureScore && safetyAndSecurityScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", safetyAndSecurityScore);
                safetysecurity = "Security";
                PlayerPrefs.SetString("SecondAttitudesTheme", safetysecurity);
                secondPlace = "SafetySecuritySecond";
                secondSelected = true;
            }
            //For Emotional
            if (emotionalScore < historicScore && emotionalScore > socialScore && emotionalScore > environmentScore && emotionalScore > rightsAndResponsibilitiesScore
            && emotionalScore > safetyAndSecurityScore && emotionalScore > economyScore && emotionalScore > politicalScore && emotionalScore > cultureScore && emotionalScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", emotionalScore);
                emotional = "Emotional";
                PlayerPrefs.SetString("SecondAttitudesTheme", emotional);
                secondPlace = "EmotionalSecond";
                secondSelected = true;
            }
            //For Economy
            if (economyScore < historicScore && economyScore > socialScore && economyScore > environmentScore && economyScore > rightsAndResponsibilitiesScore
            && economyScore > safetyAndSecurityScore && economyScore > emotionalScore && economyScore > politicalScore && economyScore > cultureScore && economyScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", economyScore);
                economy = "Economy";
                PlayerPrefs.SetString("SecondAttitudesTheme", economy);
                secondPlace = "EconomySecond";
                secondSelected = true;
            }
            //For Political
            if (politicalScore < historicScore && politicalScore > socialScore && politicalScore > environmentScore && politicalScore > rightsAndResponsibilitiesScore
            && politicalScore > safetyAndSecurityScore && politicalScore > emotionalScore && politicalScore > economyScore && politicalScore > cultureScore && politicalScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", politicalScore);
                political = "Political";
                PlayerPrefs.SetString("SecondAttitudesTheme", political);
                secondPlace = "PoliticalSecond";
                secondSelected = true;
            }
            //For Culture
            if (cultureScore < historicScore && cultureScore > socialScore && cultureScore > environmentScore && cultureScore > rightsAndResponsibilitiesScore
            && cultureScore > safetyAndSecurityScore && cultureScore > emotionalScore && cultureScore > economyScore && cultureScore > politicalScore && cultureScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", cultureScore);
                culture = "Culture";
                PlayerPrefs.SetString("SecondAttitudesTheme", culture);
                secondPlace = "CultureSecond";
                secondSelected = true;
            }
            //For Geography
            if (geographyScore < historicScore && geographyScore > socialScore && geographyScore > environmentScore && geographyScore > rightsAndResponsibilitiesScore
            && geographyScore > safetyAndSecurityScore && geographyScore > emotionalScore && geographyScore > economyScore && geographyScore > politicalScore && geographyScore > cultureScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", geographyScore);
                geography = "Geography";
                PlayerPrefs.SetString("SecondAttitudesTheme", geography);
                secondPlace = "GeographySecond";
                secondSelected = true;
            }
        }

        //TOP THEME IS CULTURE
        if (firstPlace == "CultureFirst") {
            //For Social
            if (socialScore < cultureScore && socialScore > environmentScore && socialScore > rightsAndResponsibilitiesScore && socialScore > safetyAndSecurityScore
            && socialScore > emotionalScore && socialScore > economyScore && socialScore > politicalScore && socialScore > historicScore && socialScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", socialScore);
                social = "Social";
                PlayerPrefs.SetString("SecondAttitudesTheme", social);
                secondPlace = "SocialSecond";
                secondSelected = true;
            }
            //For Environment
            if (environmentScore < cultureScore && environmentScore > socialScore && environmentScore > rightsAndResponsibilitiesScore && environmentScore > safetyAndSecurityScore
            && environmentScore > emotionalScore && environmentScore > economyScore && environmentScore > politicalScore && environmentScore > historicScore && environmentScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", environmentScore);
                environment = "Environment";
                PlayerPrefs.SetString("SecondAttitudesTheme", environment);
                secondPlace = "EnvironmentSecond";
                secondSelected = true;
            }
            //For Rights & Responsibilities
            if (rightsAndResponsibilitiesScore < cultureScore && rightsAndResponsibilitiesScore > socialScore && rightsAndResponsibilitiesScore > environmentScore && rightsAndResponsibilitiesScore > safetyAndSecurityScore
            && rightsAndResponsibilitiesScore > emotionalScore && rightsAndResponsibilitiesScore > economyScore && rightsAndResponsibilitiesScore > politicalScore && rightsAndResponsibilitiesScore > historicScore && rightsAndResponsibilitiesScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", rightsAndResponsibilitiesScore);
                rightsresponsibilities = "Rights & Responsibilities";
                PlayerPrefs.SetString("SecondAttitudesTheme", rightsresponsibilities);
                secondPlace = "RightsAndResponsibilitiesSecond";
                secondSelected = true;
            }
            //For Security
            if (safetyAndSecurityScore < cultureScore && safetyAndSecurityScore > socialScore && safetyAndSecurityScore > environmentScore && safetyAndSecurityScore > rightsAndResponsibilitiesScore
            && safetyAndSecurityScore > emotionalScore && safetyAndSecurityScore > economyScore && safetyAndSecurityScore > politicalScore && safetyAndSecurityScore > historicScore && safetyAndSecurityScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", safetyAndSecurityScore);
                safetysecurity = "Security";
                PlayerPrefs.SetString("SecondAttitudesTheme", safetysecurity);
                secondPlace = "SafetySecuritySecond";
                secondSelected = true;
            }
            //For Emotional
            if (emotionalScore < cultureScore && emotionalScore > socialScore && emotionalScore > environmentScore && emotionalScore > rightsAndResponsibilitiesScore
            && emotionalScore > safetyAndSecurityScore && emotionalScore > economyScore && emotionalScore > politicalScore && emotionalScore > historicScore && emotionalScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", emotionalScore);
                emotional = "Emotional";
                PlayerPrefs.SetString("SecondAttitudesTheme", emotional);
                secondPlace = "EmotionalSecond";
                secondSelected = true;
            }
            //For Economy
            if (economyScore < cultureScore && economyScore > socialScore && economyScore > environmentScore && economyScore > rightsAndResponsibilitiesScore
            && economyScore > safetyAndSecurityScore && economyScore > emotionalScore && economyScore > politicalScore && economyScore > historicScore && economyScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", economyScore);
                economy = "Economy";
                PlayerPrefs.SetString("SecondAttitudesTheme", economy);
                secondPlace = "EconomySecond";
                secondSelected = true;
            }
            //For Political
            if (politicalScore < cultureScore && politicalScore > socialScore && politicalScore > environmentScore && politicalScore > rightsAndResponsibilitiesScore
            && politicalScore > safetyAndSecurityScore && politicalScore > emotionalScore && politicalScore > economyScore && politicalScore > historicScore && politicalScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", politicalScore);
                political = "Political";
                PlayerPrefs.SetString("SecondAttitudesTheme", political);
                secondPlace = "PoliticalSecond";
                secondSelected = true;
            }
            //For Historic
            if (historicScore < cultureScore && historicScore > socialScore && historicScore > environmentScore && historicScore > rightsAndResponsibilitiesScore
            && historicScore > safetyAndSecurityScore && historicScore > emotionalScore && historicScore > economyScore && historicScore > politicalScore && historicScore > geographyScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", historicScore);
                historic = "Historic";
                PlayerPrefs.SetString("SecondAttitudesTheme", historic);
                secondPlace = "HistoricSecond";
                secondSelected = true;
            }
            //For Geography
            if (geographyScore < cultureScore && geographyScore > socialScore && geographyScore > environmentScore && geographyScore > rightsAndResponsibilitiesScore
            && geographyScore > safetyAndSecurityScore && geographyScore > emotionalScore && geographyScore > economyScore && geographyScore > politicalScore && geographyScore > historicScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", geographyScore);
                geography = "Geography";
                PlayerPrefs.SetString("SecondAttitudesTheme", geography);
                secondPlace = "GeographySecond";
                secondSelected = true;
            }
        }

        //TOP THEME IS GEOGRAPHY
        if (firstPlace == "GeographyFirst") {
            //For Social
            if (socialScore < geographyScore && socialScore > environmentScore && socialScore > rightsAndResponsibilitiesScore && socialScore > safetyAndSecurityScore
            && socialScore > emotionalScore && socialScore > economyScore && socialScore > politicalScore && socialScore > historicScore && socialScore > cultureScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", socialScore);
                social = "Social";
                PlayerPrefs.SetString("SecondAttitudesTheme", social);
                secondPlace = "SocialSecond";
                secondSelected = true;
            }
            //For Environment
            if (environmentScore < geographyScore && environmentScore > socialScore && environmentScore > rightsAndResponsibilitiesScore && environmentScore > safetyAndSecurityScore
            && environmentScore > emotionalScore && environmentScore > economyScore && environmentScore > politicalScore && environmentScore > historicScore && environmentScore > cultureScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", environmentScore);
                environment = "Environment";
                PlayerPrefs.SetString("SecondAttitudesTheme", environment);
                secondPlace = "EnvironmentSecond";
                secondSelected = true;
            }
            //For Rights & Responsibilities
            if (rightsAndResponsibilitiesScore < geographyScore && rightsAndResponsibilitiesScore > socialScore && rightsAndResponsibilitiesScore > environmentScore && rightsAndResponsibilitiesScore > safetyAndSecurityScore
            && rightsAndResponsibilitiesScore > emotionalScore && rightsAndResponsibilitiesScore > economyScore && rightsAndResponsibilitiesScore > politicalScore && rightsAndResponsibilitiesScore > historicScore && rightsAndResponsibilitiesScore > cultureScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", rightsAndResponsibilitiesScore);
                rightsresponsibilities = "Rights & Responsibilities";
                PlayerPrefs.SetString("SecondAttitudesTheme", rightsresponsibilities);
                secondPlace = "RightsAndResponsibilitiesSecond";
                secondSelected = true;
            }
            //For Security
            if (safetyAndSecurityScore < geographyScore && safetyAndSecurityScore > socialScore && safetyAndSecurityScore > environmentScore && safetyAndSecurityScore > rightsAndResponsibilitiesScore
            && safetyAndSecurityScore > emotionalScore && safetyAndSecurityScore > economyScore && safetyAndSecurityScore > politicalScore && safetyAndSecurityScore > historicScore && safetyAndSecurityScore > cultureScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", safetyAndSecurityScore);
                safetysecurity = "Security";
                PlayerPrefs.SetString("SecondAttitudesTheme", safetysecurity);
                secondPlace = "SafetySecuritySecond";
                secondSelected = true;
            }
            //For Emotional
            if (emotionalScore < geographyScore && emotionalScore > socialScore && emotionalScore > environmentScore && emotionalScore > rightsAndResponsibilitiesScore
            && emotionalScore > safetyAndSecurityScore && emotionalScore > economyScore && emotionalScore > politicalScore && emotionalScore > historicScore && emotionalScore > cultureScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", emotionalScore);
                emotional = "Emotional";
                PlayerPrefs.SetString("SecondAttitudesTheme", emotional);
                secondPlace = "EmotionalSecond";
                secondSelected = true;
            }
            //For Economy
            if (economyScore < geographyScore && economyScore > socialScore && economyScore > environmentScore && economyScore > rightsAndResponsibilitiesScore
            && economyScore > safetyAndSecurityScore && economyScore > emotionalScore && economyScore > politicalScore && economyScore > historicScore && economyScore > cultureScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", economyScore);
                economy = "Economy";
                PlayerPrefs.SetString("SecondAttitudesTheme", economy);
                secondPlace = "EconomySecond";
                secondSelected = true;
            }
            //For Political
            if (politicalScore < geographyScore && politicalScore > socialScore && politicalScore > environmentScore && politicalScore > rightsAndResponsibilitiesScore
            && politicalScore > safetyAndSecurityScore && politicalScore > emotionalScore && politicalScore > economyScore && politicalScore > historicScore && politicalScore > cultureScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", politicalScore);
                political = "Political";
                PlayerPrefs.SetString("SecondAttitudesTheme", political);
                secondPlace = "PoliticalSecond";
                secondSelected = true;
            }
            //For Historic
            if (historicScore < geographyScore && historicScore > socialScore && historicScore > environmentScore && historicScore > rightsAndResponsibilitiesScore
            && historicScore > safetyAndSecurityScore && historicScore > emotionalScore && historicScore > economyScore && historicScore > politicalScore && historicScore > cultureScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", historicScore);
                historic = "Historic";
                PlayerPrefs.SetString("SecondAttitudesTheme", historic);
                secondPlace = "HistoricSecond";
                secondSelected = true;
            }
            //For Culture
            if (cultureScore < geographyScore && cultureScore > socialScore && cultureScore > environmentScore && cultureScore > rightsAndResponsibilitiesScore
            && cultureScore > safetyAndSecurityScore && cultureScore > emotionalScore && cultureScore > economyScore && cultureScore > politicalScore && cultureScore > historicScore) {
                PlayerPrefs.SetInt("SecondAttitudesThemeScore", cultureScore);
                culture = "Culture";
                PlayerPrefs.SetString("SecondAttitudesTheme", culture);
                secondPlace = "CultureSecond";
                secondSelected = true;
            }
        }
    }
}
