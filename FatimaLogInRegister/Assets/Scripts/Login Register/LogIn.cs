using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogIn : MonoBehaviour {

    //----------------------------------------
    //valid, invalid, please enter etc.
    public GameObject invalidUsername;
    public GameObject enterUsername;
    public GameObject invalidPassword;
    public GameObject enterPassword;
    public GameObject loginSuccessful;
    //----------------------------------------

    public GameObject username;
    public GameObject password;

    private string Username;
    private string Password;

    private string[] Lines;

    private string DecryptedPass;

	// Use this for initialization
	void Start () {
        invalidUsername.SetActive(false);
        enterUsername.SetActive(false);
        invalidPassword.SetActive(false);
        enterPassword.SetActive(false);
        loginSuccessful.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (username.GetComponent<InputField>().isFocused) {
                password.GetComponent<InputField>().Select();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            if (Password != "" && Password != "") {
                LogInButton();
            }
        }

        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
	}

    public void LogInButton() {
        bool theUsername = false;
        bool thePassword = false;

        if (Username != "") {
            if (System.IO.File.Exists(Application.dataPath + Username + ".txt")) { //when building game have it as just Application.dataPath and take away TempCredentials
                theUsername = true;
                Lines = System.IO.File.ReadAllLines(Application.dataPath + Username + ".txt"); //when building game have it as just Application.dataPath and take away TempCredentials
            } else {
                invalidUsername.SetActive(true); //this sets the text active and should appear
                TextNotActive();
                Debug.LogWarning("Invalid username.");
            }
        } else {
            enterUsername.SetActive(true); //this sets the text active and should appear
            TextNotActive();
            Debug.LogWarning("Please enter a username.");
        }

        if (Password != "") {
            if (System.IO.File.Exists(Application.dataPath + Username + ".txt")) { //Application.dataPath + "/TempCredentials/" + Username + ".txt")) { //when building game have it as just Application.dataPath and take away TempCredentials

                int i = 1;
                foreach (char c in Lines[2]) {

                    i++;
                    char Decrypted = (char)(c / i);
                    DecryptedPass += Decrypted.ToString();
                }

                if (Password == DecryptedPass) {
                    thePassword = true;
                } else {
                    invalidPassword.SetActive(true); //this sets the text active and should appear
                    TextNotActive();
                    Debug.LogWarning("Invalid password.");
                }
            } else {
                /*invalidPassword.SetActive(true); //this sets the text active and should appear
                TextNotActive();
                Debug.LogWarning("Invalid password.");*/
            }
        } else {
            enterPassword.SetActive(true); //this sets the text active and should appear
            TextNotActive();
            Debug.LogWarning("Please enter a password.");
        }

        if (theUsername == true && thePassword == true) {
            //clear fields
            username.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";

            loginSuccessful.SetActive(true); //this sets the text active and should appear
            TextNotActive();
            print("Login Successful");
            //change to new scene
            //SceneManager.LoadScene("DragDrop"); //drag drop game
            //SceneManager.LoadScene("Journalist");
            SceneManager.LoadScene("ScenarioChoice");
        } else {
            username.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
        }
    }

    public void TextNotActive() {
        //2 seconds delay on each - this will be repeated for the Login too
        StartCoroutine(HideText(invalidUsername, 2.0f));
        StartCoroutine(HideText(enterUsername, 2.0f));
        StartCoroutine(HideText(invalidPassword, 2.0f));
        StartCoroutine(HideText(enterPassword, 2.0f));
        StartCoroutine(HideText(loginSuccessful, 2.0f));
    }

    IEnumerator HideText(GameObject text, float delay) {
        yield return new WaitForSeconds(delay);
        text.SetActive(false);
    }
}
