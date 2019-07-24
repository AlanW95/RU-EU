using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{

    //might be used or future mobile workplace

    public GameObject camInterview;
    public GameObject camDiscussionAnimation;

    // Start is called before the first frame update
    void Start()
    {
        camInterview.SetActive(true);
        camDiscussionAnimation.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            camInterview.SetActive(false);
            camDiscussionAnimation.SetActive(true);
        }
    }
}
