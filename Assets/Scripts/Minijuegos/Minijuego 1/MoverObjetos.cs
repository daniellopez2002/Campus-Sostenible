using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoverObjetos : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 _offset;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _offset = eventData.position - new Vector2(transform.position.x, transform.position.y);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position - _offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Basura")
        {
            Destroy(gameObject);
        }
    }
    }
}