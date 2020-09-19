using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler {

    private CanvasGroup canvasGroup;

    Vector3 filePos;

    private void Awake() {

        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Start()
    {
        filePos = this.gameObject.transform.position;
    }

    public void OnPointerDown(PointerEventData eventData) {

        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData) {

        Debug.Log("OnPointerUp");
    }

    public void OnBeginDrag(PointerEventData eventData) {

        Debug.Log("OnBeginDrag");
        //canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) {

        //Debug.Log ("OnDrag");
        this.transform.position = eventData.position;

    }

    public void OnEndDrag(PointerEventData eventData) {

        Debug.Log("OnEndDrag");
        //canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

}
