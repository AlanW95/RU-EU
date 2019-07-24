using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntEnums : InterviewTool
{
    IEnumerator Question1() {
        foreach (char letter in Find_id("0").question) {
            textDisplay.text += letter;
        }
        yield return new WaitForSeconds(typingSpeed);
    }

    IEnumerator Positive1() {
        foreach (char letter in Find_id("0").positive) {
            textDisplay.text += letter;
        }
        yield return new WaitForSeconds(typingSpeed);
    }

    IEnumerator Negative1() {
        foreach (char letter in Find_id("0").negative) {
            textDisplay.text += letter;
        }
        yield return new WaitForSeconds(typingSpeed);
    }
}
