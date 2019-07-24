using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSelection : MonoBehaviour
{

    public Image SelectionLanguage;
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
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
