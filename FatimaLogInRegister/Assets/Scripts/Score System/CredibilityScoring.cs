    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CredibilityScoring : MonoBehaviour
{

    public static int credibilityScore;

    Text credibilityText;
        
    // Start is called before the first frame update
    void Start()
    {
        credibilityText = GetComponent<Text>();

        credibilityScore = PlayerPrefs.GetInt("CurrentCredibilityScore");

        //For the purposes of testing, the score will always start as zero
        //-------COMMENT BELOW OUT FOR BUILDS OF GAME--------
        //credibilityScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //precautions just incase Credibility Score goes below 0
        if (credibilityScore < 0) {
            credibilityScore = 0;
        }

        credibilityText.text = "" + PlayerPrefs.GetInt("CurrentCredibilityScore", credibilityScore);
    }

    public void AddCredibilityPoints(int credibilityPointsToAdd) {
        credibilityScore += credibilityPointsToAdd;
        PlayerPrefs.SetInt("CurrentCredibilityScore", credibilityScore);
        //FloatingTextController.CreateFloatingText(credibilityPointsToAdd.ToString(), transform);
        Debug.Log("Credibility has been achieved!");
    }

    public void ResetCredibility() {
        credibilityScore = 0;
        PlayerPrefs.SetInt("CurrentCredibilityScore", credibilityScore);
    }
}
