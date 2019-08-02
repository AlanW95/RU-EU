using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsflashCH : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject finalAssignmentCamera;

    public GameObject newsflash;
    public GameObject newsflashBar;

    public GameObject[] pages;

    public GameObject newsflashText;

    public GameObject backButton;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.SetActive(true);
        finalAssignmentCamera.SetActive(false);
        backButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if the Interview and Discussion tool are complete, the news flash bar will appear
    }

    void OnMouseDown() {
        //SceneManager.LoadScene("FinalAssignment"); //no longer doing this until camera is zoomed in
        mainCamera.SetActive(false);
        newsflashText.SetActive(true);
        backButton.SetActive(true);
    }

    void OnMouseHover() {
        Debug.Log("You are hovering over this laptop!");

        newsflashText.SetActive(true);
    }

    void OnMouseExit() {
        newsflashText.SetActive(false);
    }

    public void DisplayNewsflash() {
        newsflashBar.SetActive(false);
        newsflash.SetActive(true);
        backButton.SetActive(true);
    }

    public void ReturnToMobileWorkplace() {
        pages[0].SetActive(false);
        pages[1].SetActive(false);
        pages[2].SetActive(false);
        pages[3].SetActive(false);
        pages[4].SetActive(false);
        backButton.SetActive(false);
    }

    public void Page1() {
        pages[0].SetActive(true);
        pages[1].SetActive(false);
        pages[2].SetActive(false);
        pages[3].SetActive(false);
        pages[4].SetActive(false);
    }

    public void Page2() {
        pages[0].SetActive(false);
        pages[1].SetActive(true);
        pages[2].SetActive(false);
        pages[3].SetActive(false);
        pages[4].SetActive(false);
    }

    public void Page3() {
        pages[0].SetActive(false);
        pages[1].SetActive(false);
        pages[2].SetActive(true);
        pages[3].SetActive(false);
        pages[4].SetActive(false);
    }

    public void Page4() {
        pages[0].SetActive(false);
        pages[1].SetActive(false);
        pages[2].SetActive(false);
        pages[3].SetActive(true);
        pages[4].SetActive(false);
    }

    public void Page5() {
        pages[0].SetActive(false);
        pages[1].SetActive(false);
        pages[2].SetActive(false);
        pages[3].SetActive(false);
        pages[4].SetActive(true);
    }
}
