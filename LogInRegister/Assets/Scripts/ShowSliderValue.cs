using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowSliderValue : MonoBehaviour
{

    TextMeshProUGUI percentageText;

    // Start is called before the first frame update
    void Start()
    {
        percentageText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TextUpdate(float value) {
        percentageText.text = Mathf.RoundToInt(value) + "%";
    }
}
