using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreFinalAssignment : MonoBehaviour
{
    public GameObject proSelections, antiSelections;

    //Sending to Google Forms
    public InputField inputEmail, input1, input2, input3, input4, input5, input6;
    private string emailAnswer, pro1Answer, pro2Answer, pro3Answer, anti1Answer, anti2Answer, anti3Answer;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdEgJ2jaSnK1SYIE8uQy9uWFEgoBEBJDztlHbl6o0PTIPfzRA/formResponse";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Social() {

    }

    public void Environment() {

    }

    public void RightsAndResponsibilities() {

    }

    public void SafetyAndSecurity() {

    }

    public void Emotional() {

    }

    public void Economy() {

    }

    public void Political() {

    }

    public void Historic() {

    }

    public void Culture() {

    }

    public void Geography() {

    }

    IEnumerator Post(string emailAnswer, string pro1, string pro2, string pro3, string anti1, string anti2, string anti3) {
        WWWForm form = new WWWForm();

        form.AddField("entry.917250166", emailAnswer);
        form.AddField("entry.765760912", pro1);
        form.AddField("entry.512558240", pro2);
        form.AddField("entry.1339939876", pro3);
        form.AddField("entry.817437809", anti1);
        form.AddField("entry.765449421", anti2);
        form.AddField("entry.805901523", anti3);

        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);

        yield return www;
    }

    public void Send() {
        emailAnswer = inputEmail.GetComponent<InputField>().text;
        Debug.Log(emailAnswer);
        pro1Answer = input1.GetComponent<InputField>().text;
        Debug.Log(pro1Answer);
        pro2Answer = input2.GetComponent<InputField>().text;
        Debug.Log(pro2Answer);
        pro3Answer = input3.GetComponent<InputField>().text;
        Debug.Log(pro3Answer);
        anti1Answer = input4.GetComponent<InputField>().text;
        Debug.Log(anti1Answer);
        anti2Answer = input5.GetComponent<InputField>().text;
        Debug.Log(anti2Answer);
        anti3Answer = input6.GetComponent<InputField>().text;
        Debug.Log(anti3Answer);

        StartCoroutine(Post(emailAnswer, pro1Answer, pro2Answer, pro3Answer, anti1Answer, anti2Answer, anti3Answer));
    }
}
