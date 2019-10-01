using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class NewsflashCH : BrexitWorkplace {
    public GameObject newsflashBar;

    public GameObject newsflashText;

    public void OnPointerEnter(PointerEventData eventData) {
        newsflashText.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData) {
        SceneManager.LoadScene("Newsflash");
        AddToToolAvailability();
    }

    public void OnPointerExit(PointerEventData eventData) {
        newsflashText.SetActive(false);
    }

    public void DisplayNewsflash() {
        SceneManager.LoadScene("Newsflash");
        Newsflash();
    }
}
