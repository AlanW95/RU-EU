using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour {
    //----------------------------------------
    //valid, invalid, please enter etc.
    public GameObject invalidUsername;
    public GameObject enterUsername;
    public GameObject incorrectEmail;
    public GameObject enterEmail;
    public GameObject passwordCharacters;
    public GameObject enterPassword;
    public GameObject passwordNoMatch;
    public GameObject registrationComplete;
    //----------------------------------------
    //game objects for fields, used below also
    public GameObject username;
    public GameObject email;
    public GameObject password;
    public GameObject confirmPassword;
    private string Username;
    private string Email;
    private string Password;
    private string ConfirmPassword;

    private string form; // will hold all the previous variables

    private bool emailValid = false;

    private string[] Characters = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                   "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
                                   "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "_", "-"};

    //GameObjects for making Registration fields disappear and Login fields appear

    //REGISTRATION
    //gameobjects for fields already made above
    //public GameObject username;   public GameObject email;    public GameObject password;     public GameObject confirmPassword;

    public GameObject registerNowText;
    public GameObject registerHeaderText;
    public GameObject signupPlayText;
    public GameObject alreadyRegisteredText;
    public GameObject loginText;
    public GameObject signupButton;


    //LOGIN
    public GameObject loginHeaderText;
    public GameObject loginUsernameText;
    public GameObject loginUsername;
    public GameObject loginPasswordText;
    public GameObject loginPassword;
    public GameObject loginButton;

	// Use this for initialization
	void Start () {
        invalidUsername.SetActive(false);
        enterUsername.SetActive(false);
        incorrectEmail.SetActive(false);
        enterEmail.SetActive(false);
        passwordCharacters.SetActive(false);
        enterPassword.SetActive(false);
        passwordNoMatch.SetActive(false);
        registrationComplete.SetActive(false);

        //registration fields are active by default, login fields are not
        loginHeaderText.SetActive(false);
        loginUsernameText.SetActive(false);
        loginUsername.SetActive(false);
        loginPasswordText.SetActive(false);
        loginPassword.SetActive(false);
        loginButton.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        //this basically allows the user to tab between each field instead of using the mouse
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (username.GetComponent<InputField>().isFocused) {
                email.GetComponent<InputField>().Select();
            }

            if (email.GetComponent<InputField>().isFocused) {
                password.GetComponent<InputField>().Select();
            }

            if (password.GetComponent<InputField>().isFocused) {
                confirmPassword.GetComponent<InputField>().Select();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            //string variable
            if (Username != "" && Email != "" && Password != "" && ConfirmPassword != "") {
                RegisterButton();
            }
        }

        Username = username.GetComponent<InputField>().text;
        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        ConfirmPassword = confirmPassword.GetComponent<InputField>().text;
	}

    public void RegisterButton() {
        bool theUsername = false;
        bool theEmail = false;
        bool thePassword = false;
        bool theConfirmPassword = false;

        if (Username != "") {
            if (!System.IO.File.Exists(Application.dataPath + Username + ".txt")) {//Application.dataPath + "/TempCredentials/" + Username + ".txt")) { //when building game have it as just Application.dataPath and take away TempCredentials
                theUsername = true;
            } else {
                invalidUsername.SetActive(true); //this sets the text active and should appear
                TextNotActive();
                Debug.LogWarning("Invalid username."); //debugging
            }
        } else {
            enterUsername.SetActive(true); //this sets the text active and should appear
            TextNotActive();
            Debug.LogWarning("Please enter a username."); //debugging
        }

        if (Email != "") {
            EmailValidation();
            if (emailValid) {
                if (Email.Contains("@")) {
                    if (Email.Contains(".")) {
                        theEmail = true;
                    } else {
                        incorrectEmail.SetActive(true); //this sets the text active and should appear
                        TextNotActive();
                        Debug.LogWarning("Incorrect email."); //debugging
                    }
                } else {
                    incorrectEmail.SetActive(true); //this sets the text active and should appear
                    TextNotActive();
                    Debug.LogWarning("Incorrect email."); //debugging
                }
            } else {
                incorrectEmail.SetActive(true); //this sets the text active and should appear
                TextNotActive();
                Debug.LogWarning("Incorrect email."); //debugging
            }
        } else {
            enterEmail.SetActive(true); //this sets the text active and should appear
            TextNotActive();
            Debug.LogWarning("Please enter email."); //debugging
        }

        if (Password != "") {
            if (Password.Length > 5) {
                thePassword = true;
            } else {
                passwordCharacters.SetActive(true); //this sets the text active and should appear
                TextNotActive();
                Debug.LogWarning("Password must have 6 characters."); //debugging
            }
        } else {
            enterPassword.SetActive(true); //this sets the text active and should appear
            TextNotActive();
            Debug.LogWarning("Please enter a password."); //debugging
        }

        if (ConfirmPassword != "") {
            if (ConfirmPassword == Password) {
                theConfirmPassword = true;
            } else {
                passwordNoMatch.SetActive(true); //this sets the text active and should appear
                TextNotActive();
                Debug.LogWarning("Password doesn't match."); //debugging
            }
        } else {
            enterPassword.SetActive(true); //this sets the text active and should appear
            TextNotActive();
            Debug.LogWarning("Please enter a password."); //debugging
        }

        //this can be done alternatively through a database possibly?
        if (theUsername == true && theEmail == true && thePassword == true && theConfirmPassword == true) {
            bool Clear = true;
            int i = 1;

            foreach(char c in Password) {
                if (Clear) {
                    Password = "";
                    Clear = false;
                }
                i++;
                char Encrypted = (char)(c * i);
                Password += Encrypted.ToString();
            }
            form = (Username + "\r\n" + Email + "\r\n" + Password);
            System.IO.File.WriteAllText(Application.dataPath + Username + ".txt", form); //when building game have it as just Application.dataPath and take away TempCredentials

            //clear input fields
            username.GetComponent<InputField>().text = "";
            email.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            confirmPassword.GetComponent<InputField>().text = "";
            Debug.LogWarning("Registration complete!"); //debugging
            registrationComplete.SetActive(true); //this sets the text active and should appear
            TextNotActive();
            AlreadySignedUp();
        }
    }

    void EmailValidation() {
        bool startsWith = false;
        bool endsWith = false;

        for (int i = 0; i < Characters.Length; i++) {
            if (Email.StartsWith(Characters[i])) {
                startsWith = true;
            }
        }

        for (int i = 0; i < Characters.Length; i++) {
            if (Email.EndsWith(Characters[i])) {
                endsWith = true;
            }
        }

        if (startsWith == true && endsWith == true) {
            emailValid = true;
        } else {
            emailValid = false;
        }
    }

    public void TextNotActive() {
        //2 seconds delay on each - this will be repeated for the Login too
        StartCoroutine(HideText(invalidUsername, 2.0f));
        StartCoroutine(HideText(enterUsername, 2.0f));
        StartCoroutine(HideText(incorrectEmail, 2.0f));
        StartCoroutine(HideText(enterEmail, 2.0f));
        StartCoroutine(HideText(passwordCharacters, 2.0f));
        StartCoroutine(HideText(enterPassword, 2.0f));
        StartCoroutine(HideText(passwordNoMatch, 2.0f));
        StartCoroutine(HideText(registrationComplete, 2.0f));
    }
    
    IEnumerator HideText(GameObject text, float delay) {
        yield return new WaitForSeconds(delay);
        text.SetActive(false);
    }

    public void AlreadySignedUp() {
        //registration disappears
        registerHeaderText.SetActive(false);
        signupPlayText.SetActive(false);
        alreadyRegisteredText.SetActive(false);
        loginText.SetActive(false);
        username.SetActive(false);
        email.SetActive(false);
        password.SetActive(false);
        confirmPassword.SetActive(false);
        signupButton.SetActive(false);


        //login appears
        registerNowText.SetActive(true);
        loginHeaderText.SetActive(true);
        loginUsernameText.SetActive(true);
        loginUsername.SetActive(true);
        loginPasswordText.SetActive(true);
        loginPassword.SetActive(true);
        loginButton.SetActive(true);
    }

    public void SignUp() {
        //registration appears
        registerHeaderText.SetActive(true);
        signupPlayText.SetActive(true);
        alreadyRegisteredText.SetActive(true);
        loginText.SetActive(true);
        username.SetActive(true);
        email.SetActive(true);
        password.SetActive(true);
        confirmPassword.SetActive(true);
        signupButton.SetActive(true);


        //login disappears
        registerNowText.SetActive(false);
        loginHeaderText.SetActive(false);
        loginUsernameText.SetActive(false);
        loginUsername.SetActive(false);
        loginPasswordText.SetActive(false);
        loginPassword.SetActive(false);
        loginButton.SetActive(false);
    }
}
