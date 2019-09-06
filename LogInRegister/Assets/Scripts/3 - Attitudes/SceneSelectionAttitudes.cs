using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelectionAttitudes : MonoBehaviour
{

    public GameObject backToJournalistDesk;

    // Start is called before the first frame update
    void Start()
    {
        backToJournalistDesk.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoBack() {
        SceneManager.LoadScene("MobileWorkplaceAttitudes");
    }
}
