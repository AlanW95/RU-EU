using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public Drag.ToolSlot typeOfTool = Drag.ToolSlot.INTERVIEW1;

    public Button submitButton;
    //public GameObject dropzone1, dropzone2, dropzone3, dropzone4;
    PointerEventData eventData;

    public int finalAssignmentCounter;

    //Trying to effectively get the submission of the article button to appear upon putting three items in
    void Update() {
        //CheckSubmission();

        PlayerPrefs.GetInt("FinalAssignmentCounter");

        /*if (finalAssignmentCounter <= -3) {
            submitButton.interactable = false;
        }*/

        if (finalAssignmentCounter == -4) {
            submitButton.interactable = true;
        }


        /*Drag d = eventData.pointerDrag.GetComponent<Drag>();
        if (finalAssignmentCounter <= -4 && d != null) {
            typeOfTool = Drag.ToolSlot.INTERVIEW2;
            d.placeholderParent = this.transform;
            
        }*/
    }

    /*public void CheckSubmission() {

        Drag d = eventData.pointerDrag.GetComponent<Drag>();
        if (d.placeholderParent == dropzone1.transform && d.placeholderParent == dropzone2.transform && d.placeholderParent == dropzone3.transform) {
            submitButton.interactable = true;
        }
    }*/

    public void OnPointerEnter(PointerEventData eventData) {
        //Debug.Log("OnPointerEnter");

        if (eventData.pointerDrag == null) {
            return;
        }

        Drag d = eventData.pointerDrag.GetComponent<Drag>();
        if (d != null) {
            if (typeOfTool == d.typeOfTool || typeOfTool == Drag.ToolSlot.INTERVIEW1) {
                d.placeholderParent = this.transform;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        //Debug.Log("OnPointerExit");

        if (eventData.pointerDrag == null) {
            return;
        }

        Drag d = eventData.pointerDrag.GetComponent<Drag>();
        if (d != null && d.placeholderParent == this.transform) {
            if (typeOfTool == d.typeOfTool || typeOfTool == Drag.ToolSlot.INTERVIEW1) {
                d.placeholderParent = d.parentToReturnTo;
                PlayerPrefs.GetInt("FinalAssignmentCounter");
                finalAssignmentCounter += 1;
                PlayerPrefs.SetInt("FinalAssignmentCounter", finalAssignmentCounter);
            }
        }
    }

    public void OnDrop(PointerEventData eventData) {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        PlayerPrefs.GetInt("FinalAssignmentCounter");
        finalAssignmentCounter -= 1;
        PlayerPrefs.SetInt("FinalAssignmentCounter", finalAssignmentCounter);
        Debug.Log("Final Assignment Counter: " + finalAssignmentCounter);

        Drag d = eventData.pointerDrag.GetComponent<Drag>();

        if (d != null) {
            if (typeOfTool == d.typeOfTool || typeOfTool == Drag.ToolSlot.INTERVIEW1) {
                d.parentToReturnTo = this.transform;
            }
        }
    }
}
