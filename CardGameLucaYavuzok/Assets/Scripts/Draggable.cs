using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{

	public Transform parentToReturnTo = null;

	public enum slot {DROPZONE, INVENTORY1, INVENTORY2};
	public slot typeOfItem = slot.DROPZONE;

	bool beingDragged;

	public void OnBeginDrag (PointerEventData eventData){
		Debug.Log ("OnBeginDrag");
		parentToReturnTo = this.transform.parent;
		this.transform.SetParent (this.transform.parent.parent);

		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	public void OnDrag (PointerEventData eventData){
		//Debug.Log ("OnDrag");
		beingDragged = true;
		this.transform.position = eventData.position;
	}

	public void OnEndDrag (PointerEventData eventData){
		Debug.Log ("OnEndDrag");
		beingDragged = false;
		this.transform.SetParent (parentToReturnTo);
		GetComponent<CanvasGroup> ().blocksRaycasts = true;

//		EventSystem.current.RaycastAll (eventData);
	}


}