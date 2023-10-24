using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragObject : MonoBehaviour
{
    private Vector3 mousePosition;
    private bool isDragging = false;

    [Header("Events")]
    public UnityEvent onDragStart, onDragStop;

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
        isDragging = true;
        if (isDragging)
        {
            onDragStart.Invoke();
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        }
    }

    private void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;
            onDragStop.Invoke(); // Invoke the event when dragging stops
        }
    }

    private void OnDestroy()
    {
        if (isDragging)
        {
            onDragStop.Invoke(); // Ensure the onDragStop event is invoked when the object is destroyed while dragging
        }
    }
}