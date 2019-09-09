using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProAntiScoring : MonoBehaviour
{

    public static int credibilityScore;

    // Start is called before the first frame update
    void Start()
    {
        credibilityScore = 50;
        PlayerPrefs.SetInt("CredibilityScore", credibilityScore);
        credibilityScore = PlayerPrefs.GetInt("CredibilityScore");
    }

    // Update is called once per frame
    void Update()
    {
        if (credibilityScore < 0) {
            credibilityScore = 0;
        }

        if (credibilityScore > 100) {
            credibilityScore = 100;
        }
    }

    public void AddCredibilityPoints() {
        credibilityScore += 15;
        PlayerPrefs.SetInt("CredibilityScore", credibilityScore);
        Debug.Log("+15 PRO. Your credibility now stands at " + credibilityScore + ".");
    }

    public void AddLowerCredibilityPoints() {
        credibilityScore += 10;
        PlayerPrefs.SetInt("CredibilityScore", credibilityScore);
        Debug.Log("+10 PRO. Your credibility now stands at " + credibilityScore + ".");
    }

    public void MinusCredibilityPoints() {
        credibilityScore -= 15;
        PlayerPrefs.SetInt("CredibilityScore", credibilityScore);
        Debug.Log("-15 ANTI. Your credibility now stands at " + credibilityScore + ".");
    }

    public void MinusLowerCredibilityPoints() {
        credibilityScore -= 10;
        PlayerPrefs.SetInt("CredibilityScore", credibilityScore);
        Debug.Log("-10 ANTI. Your credibility now stands at " + credibilityScore + ".");
    }

    public void AddNeutralCredibilityPoints() {
        credibilityScore += 5;
        PlayerPrefs.SetInt("CredibilityScore", credibilityScore);
        Debug.Log("+5 NEUTRAL. Your credibility now stands at " + credibilityScore + ".");
    }
}
