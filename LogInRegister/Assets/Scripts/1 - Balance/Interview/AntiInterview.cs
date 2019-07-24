using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AntiInterview : MonoBehaviour
{
    //scene will involve; start canvas then theme selection canvas, then the reporter bubble will appear followed by continue etc depending on completion of statement
    public GameObject startCanvas;

    public GameObject themeSelectionCanvas;
    public GameObject themeSelectionContinueButton;

    public GameObject proCanvas;

    public GameObject rankingCanvas;

    public GameObject scoreCanvas;
    public GameObject feedbackCanvas;

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;

    [SerializeField]
    private float typingSpeed; //removing this
    public GameObject continueButton;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
