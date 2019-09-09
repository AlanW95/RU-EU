using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeScoring : MonoBehaviour
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

    //Text selectedTheme;

    // Start is called before the first frame update
    void Start()
    {
        socialScore = PlayerPrefs.GetInt("CurrentSocialScore");
        environmentScore = PlayerPrefs.GetInt("CurrentEnvironmentScore");
        rightsAndResponsibilitiesScore = PlayerPrefs.GetInt("CurrentRightsAndResponsibilitiesScore");
        safetyAndSecurityScore = PlayerPrefs.GetInt("CurrentSafetyAndSecurityScore");
        emotionalScore = PlayerPrefs.GetInt("CurrentEmotionalScore");
        economyScore = PlayerPrefs.GetInt("CurrentEconomyScore");
        politicalScore = PlayerPrefs.GetInt("CurrentPoliticalScore");
        historicScore = PlayerPrefs.GetInt("CurrentHistoricScore");
        cultureScore = PlayerPrefs.GetInt("CurrentCultureScore");
        geographyScore = PlayerPrefs.GetInt("CurrentGeographyScore");
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    public void AddSocialPoints() {
        socialScore += 10;
        PlayerPrefs.SetInt("CurrentSocialScore", socialScore);
        Debug.Log("+10 to Social. You currently have " + socialScore + " for the theme of Social.");
    }

    public void AddEnvironmentPoints() {
        environmentScore += 10;
        PlayerPrefs.SetInt("CurrentEnvironmentScore", environmentScore);
        Debug.Log("+10 to Social. You currently have " + environmentScore + " for the theme of Environment.");
    }

    public void AddRightsResponsibilitiesPoints() {
        rightsAndResponsibilitiesScore += 10;
        PlayerPrefs.SetInt("CurrentRightsAndResponsibilitiesScore", rightsAndResponsibilitiesScore);
        Debug.Log("+10 to Rights and Responsibilities. You currently have " + rightsAndResponsibilitiesScore + " for the theme of Rights and Responsibilities.");
    }

    public void AddSafetySecurityPoints() {
        safetyAndSecurityScore += 10;
        PlayerPrefs.SetInt("CurrentSafetyAndSecurityScore", safetyAndSecurityScore);
        Debug.Log("+10 to Safety and Security. You currently have " + safetyAndSecurityScore + " for the theme of Safety and Security.");
    }

    public void AddEmotionalPoints() {
        emotionalScore += 10;
        PlayerPrefs.SetInt("CurrentEmotionalScore", emotionalScore);
        Debug.Log("+10 to Emotional. You currently have " + emotionalScore + " for the theme of Emotional.");
    }

    public void AddEconomyPoints() {
        economyScore += 10;
        PlayerPrefs.SetInt("CurrentEconomyScore", economyScore);
        Debug.Log("+10 to Economy. You currently have " + economyScore + " for the theme of Economy.");
    }

    public void AddPoliticalPoints() {
        politicalScore += 10;
        PlayerPrefs.SetInt("CurrentPoliticalScore", politicalScore);
        Debug.Log("+10 to Political. You currently have " + politicalScore + " for the theme of Political.");
    }

    public void AddHistoricPoints() {
        historicScore += 10;
        PlayerPrefs.SetInt("CurrentHistoricScore", historicScore);
        Debug.Log("+10 to Historic. You currently have " + historicScore + " for the theme of Historic.");
    }

    public void AddCulturePoints() {
        cultureScore += 10;
        PlayerPrefs.SetInt("CurrentCultureScore", cultureScore);
        Debug.Log("+10 to Culture. You currently have " + cultureScore + " for the theme of Culture.");
    }

    public void AddGeographyPoints() {
        geographyScore += 10;
        PlayerPrefs.SetInt("CurrentGeographyScore", geographyScore);
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

        PlayerPrefs.SetInt("CurrentSocialScore", socialScore);
        PlayerPrefs.SetInt("CurrentEnvironmentScore", environmentScore);
        PlayerPrefs.SetInt("CurrentRightsAndResponsibilitiesScore", rightsAndResponsibilitiesScore);
        PlayerPrefs.SetInt("CurrentSafetyAndSecurityScore", safetyAndSecurityScore);
        PlayerPrefs.SetInt("CurrentEmotionalScore", emotionalScore);
        PlayerPrefs.SetInt("CurrentEconomyScore", economyScore);
        PlayerPrefs.SetInt("CurrentPoliticalScore", politicalScore);
        PlayerPrefs.SetInt("CurrentHistoricScore", historicScore);
        PlayerPrefs.SetInt("CurrentCultureScore", cultureScore);
        PlayerPrefs.SetInt("CurrentGeographyScore", geographyScore);
    }

    public void Number1TopTheme() {
        
        //if each score is higher than each assign to new PlayerPref for Dashboard
        //Social
        if (socialScore > environmentScore && socialScore > rightsAndResponsibilitiesScore && socialScore > safetyAndSecurityScore && socialScore > emotionalScore
            && socialScore > economyScore && socialScore > politicalScore && socialScore > historicScore && socialScore > cultureScore && socialScore > geographyScore) {

            PlayerPrefs.SetInt("TopThemeScore", socialScore);
            social = "Social";
            PlayerPrefs.SetString("TopTheme", social);
            firstSelected = true;

        }
        //Environment
        if (environmentScore > socialScore && environmentScore > rightsAndResponsibilitiesScore && environmentScore > safetyAndSecurityScore && environmentScore > emotionalScore
            && environmentScore > economyScore && environmentScore > politicalScore && environmentScore > historicScore && environmentScore > cultureScore && environmentScore > geographyScore) {

            PlayerPrefs.SetInt("TopThemeScore", environmentScore);
            environment = "Environment";
            PlayerPrefs.SetString("TopTheme", environment);
            firstSelected = true;

        }
        //Rights & Responsibilities
        if (rightsAndResponsibilitiesScore > socialScore && rightsAndResponsibilitiesScore > environmentScore && rightsAndResponsibilitiesScore > safetyAndSecurityScore && rightsAndResponsibilitiesScore > emotionalScore
            && rightsAndResponsibilitiesScore > economyScore && rightsAndResponsibilitiesScore > politicalScore && rightsAndResponsibilitiesScore > historicScore && rightsAndResponsibilitiesScore > cultureScore && rightsAndResponsibilitiesScore > geographyScore) {

            PlayerPrefs.SetInt("TopThemeScore", rightsAndResponsibilitiesScore);
            rightsresponsibilities = "Rights & Responsibilities";
            PlayerPrefs.SetString("TopTheme", rightsresponsibilities);
            firstSelected = true;

        }
        //Safety & Security
        if (safetyAndSecurityScore > socialScore && safetyAndSecurityScore > environmentScore && safetyAndSecurityScore > rightsAndResponsibilitiesScore && safetyAndSecurityScore > emotionalScore
            && safetyAndSecurityScore > economyScore && safetyAndSecurityScore > politicalScore && safetyAndSecurityScore > historicScore && safetyAndSecurityScore > cultureScore && safetyAndSecurityScore > geographyScore) {

            PlayerPrefs.SetInt("TopThemeScore", safetyAndSecurityScore);
            safetysecurity = "Safety & Security";
            PlayerPrefs.SetString("TopTheme", safetysecurity);
            firstSelected = true;

        }
        //Emotional
        if (emotionalScore > socialScore && emotionalScore > environmentScore && emotionalScore > rightsAndResponsibilitiesScore && emotionalScore > safetyAndSecurityScore
            && emotionalScore > economyScore && emotionalScore > politicalScore && emotionalScore > historicScore && emotionalScore > cultureScore && emotionalScore > geographyScore) {

            PlayerPrefs.SetInt("TopThemeScore", emotionalScore);
            emotional = "Emotional";
            PlayerPrefs.SetString("TopTheme", emotional);
            firstSelected = true;

        }
        //Economy
        if (economyScore > socialScore && economyScore > environmentScore && economyScore > rightsAndResponsibilitiesScore && economyScore > safetyAndSecurityScore
            && economyScore > emotionalScore && economyScore > politicalScore && economyScore > historicScore && economyScore > cultureScore && economyScore > geographyScore) {

            PlayerPrefs.SetInt("TopThemeScore", economyScore);
            economy = "Economy";
            PlayerPrefs.SetString("TopTheme", economy);
            firstSelected = true;

        }
        //Political
        if (politicalScore > socialScore && politicalScore > environmentScore && politicalScore > rightsAndResponsibilitiesScore && politicalScore > safetyAndSecurityScore
            && politicalScore > emotionalScore && politicalScore > economyScore && politicalScore > historicScore && politicalScore > cultureScore && politicalScore > geographyScore) {

            PlayerPrefs.SetInt("TopThemeScore", politicalScore);
            political = "Political";
            PlayerPrefs.SetString("TopTheme", political);
            firstSelected = true;

        }
        //Historic 
        if (historicScore > socialScore && historicScore > environmentScore && historicScore > rightsAndResponsibilitiesScore && historicScore > safetyAndSecurityScore
            && historicScore > emotionalScore && historicScore > economyScore && historicScore > politicalScore && historicScore > cultureScore && historicScore > geographyScore) {

            PlayerPrefs.SetInt("TopThemeScore", historicScore);
            historic = "Historic";
            PlayerPrefs.SetString("TopTheme", historic);
            firstSelected = true;

        }
        //Culture
        if (cultureScore > socialScore && cultureScore > environmentScore && cultureScore > rightsAndResponsibilitiesScore && cultureScore > safetyAndSecurityScore
            && cultureScore > emotionalScore && cultureScore > economyScore && cultureScore > politicalScore && cultureScore > historicScore && cultureScore > geographyScore) {

            PlayerPrefs.SetInt("TopThemeScore", cultureScore);
            culture = "Culture";
            PlayerPrefs.SetString("TopTheme", culture);
            firstSelected = true;

        }
        //Geography
        if (geographyScore > socialScore && geographyScore > environmentScore && geographyScore > rightsAndResponsibilitiesScore && geographyScore > safetyAndSecurityScore
            && geographyScore > emotionalScore && geographyScore > economyScore && geographyScore > politicalScore && geographyScore > historicScore && geographyScore > cultureScore) {

            PlayerPrefs.SetInt("TopThemeScore", geographyScore);
            geography = "Geography";
            PlayerPrefs.SetString("TopTheme", geography);
            firstSelected = true;

        }
    }

    public void Number2TopTheme() {

    }

    public void Number3TopTheme() {

    }
}
