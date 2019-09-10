using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public Drag.ToolSlot typeOfTool = Drag.ToolSlot.INTERVIEW1;

    public Button submitButton;
    public GameObject dropzone1, dropzone2, dropzone3;
    PointerEventData eventData;

    //Trying to effectively get the submission of the article button to appear upon putting three items in
    void Update() {
        //CheckSubmission();
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
            }
        }
    }

    public void OnDrop(PointerEventData eventData) {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        Drag d = eventData.pointerDrag.GetComponent<Drag>();
        if (d != null) {
            if (typeOfTool == d.typeOfTool || typeOfTool == Drag.ToolSlot.INTERVIEW1) {
                d.parentToReturnTo = this.transform;
            }
        }
    }
}
