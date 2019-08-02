using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public Animator animator;

    TextMeshProUGUI pointsText;

    // Start is called before the first frame update
    void OnEnable()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0); //grabs current clip count from animator and stores it
        Destroy(gameObject, clipInfo[0].clip.length);

        pointsText = animator.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string text)
    {
        pointsText.text = text;
    }
}
