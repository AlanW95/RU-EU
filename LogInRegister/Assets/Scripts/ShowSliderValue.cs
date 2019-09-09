using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowSliderValue : Dashboard
{
    TextMeshProUGUI percentageText;
    TextMeshProUGUI percentageTextTopTheme, percentageTextSecondTheme, percentageTextThirdTheme;

    // Start is called before the first frame update
    void Start()
    {
        percentageText = GetComponent<TextMeshProUGUI>();
        percentageTextTopTheme = GetComponent<TextMeshProUGUI>();
        percentageTextSecondTheme = GetComponent<TextMeshProUGUI>();
        percentageTextThirdTheme = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TextUpdatePercentage(float value) {
        percentageText.text = Mathf.RoundToInt(value) + "%";
    }

    public void TextUpdateTopTheme(float value) {
        percentageTextTopTheme.text = Mathf.RoundToInt(value) + "%";

    }

    public void TextUpdateSecondTopTheme (float value) {
        percentageTextSecondTheme.text = Mathf.RoundToInt(value) + "%";
    }

    public void TextUpdateThirdTopTheme (float value) {
        percentageTextThirdTheme.text = Mathf.RoundToInt(value) + "%";
    }
}
