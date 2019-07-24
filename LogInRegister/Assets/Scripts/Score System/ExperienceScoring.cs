using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceScoring : MonoBehaviour
{

    public static int xpScore;

    Text xpText;

    // Start is called before the first frame update
    void Start()
    {
        xpText = GetComponent<Text>();

        xpScore = PlayerPrefs.GetInt("CurrentXPScore");

        //For the purposes of testing, the score will always start as zero
        //-------COMMENT BELOW OUT FOR BUILDS OF GAME--------
        //xpScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //precautions just incase the XP Score goes below 0
        if (xpScore < 0) {
            xpScore = 0;
        }

        xpText.text = "+" + PlayerPrefs.GetInt("CurrentXPScore", xpScore);
    }

    public void AddXPPoints(int xpPointsToAdd) {
        xpScore += xpPointsToAdd;
        PlayerPrefs.SetInt("CurrentXPScore", xpScore);
        //FloatingTextController.CreateFloatingText(xpPointsToAdd.ToString(), transform);
        Debug.Log("XP has been achieved!");
        Debug.Log("+" + xpPointsToAdd);
    }

    public void ResetXP() {
        xpScore = 0;
        PlayerPrefs.SetInt("CurrentXPScore", xpScore);
    }
}
