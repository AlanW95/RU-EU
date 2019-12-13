using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LanguageSelection : MonoBehaviour
{

    private bool english = false;
    private bool greek = false;
    private bool german = false;
    private bool dutch = false;
    private bool croatian = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //Setting PlayerPrefs back so it effectively works
        english = false;
        PlayerPrefs.SetInt("EnglishSelected", boolToInt(english));

        greek = false;
        PlayerPrefs.SetInt("GreekSelected", boolToInt(greek));

        german = false;
        PlayerPrefs.SetInt("GermanSelected", boolToInt(german));

        dutch = false;
        PlayerPrefs.SetInt("DutchSelected", boolToInt(dutch));

        croatian = false;
        PlayerPrefs.SetInt("CroatianSelected", boolToInt(croatian));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void English() {
        english = true;
        PlayerPrefs.SetInt("EnglishSelected", boolToInt(english));
        Debug.Log(PlayerPrefs.GetInt("EnglishSelected"));
        SceneManager.LoadScene("OpeningIntroduction");
        Debug.Log("English has been selected");
    }

    public void Greek() {
        greek = true;
        PlayerPrefs.SetInt("GreekSelected", boolToInt(greek));
        SceneManager.LoadScene("OpeningIntroduction");
        Debug.Log("Greek has been selected");
    }

    public void German() {
        german = true;
        PlayerPrefs.SetInt("GermanSelected", boolToInt(german));
        SceneManager.LoadScene("OpeningIntroduction");
    }

    public void Dutch() {
        dutch = true;
        PlayerPrefs.SetInt("DutchSelected", boolToInt(dutch));
        SceneManager.LoadScene("OpeningIntroduction");
    }

    public void Croatian() {
        croatian = true;
        PlayerPrefs.SetInt("CroatianSelected", boolToInt(croatian));
        SceneManager.LoadScene("OpeningIntroduction");
    }

    //These conversion functions allow me to tell the games language through playerprefs
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

    /*public Image SelectionLanguage;
    public List<Sprite> FlagList = new List<Sprite>();
    private int flagSpot = 0;

    public void RightSelection() {
        if (flagSpot < FlagList.Count - 1) {
            flagSpot++;
            SelectionLanguage.sprite = FlagList[flagSpot];
        } else { //loops through the flags instead of making you go the other way
            if (flagSpot == FlagList.Count - 1) {
                flagSpot = 0;
                SelectionLanguage.sprite = FlagList[flagSpot];
            }
        }
    }

    public void LeftSelection() {

        if (flagSpot > 0) {
            flagSpot--;
            SelectionLanguage.sprite = FlagList[flagSpot];
        } else { //loops through the flags instead of making you go the other way
            if (flagSpot == 0) {
                flagSpot = FlagList.Count - 1;
                SelectionLanguage.sprite = FlagList[flagSpot];
            }
        }
    }*/
}
