using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public Drag.ToolSlot typeOfTool = Drag.ToolSlot.INTERVIEW1;

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
