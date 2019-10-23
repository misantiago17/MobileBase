using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DragAndDrop : MonoBehaviour
{
    // Drag in only one axis
    public bool freezeX = false;
    public bool freezeY = false;

    private bool dragging = false;
    private float distance;

    // distante from where you clicled inside the object
    private Vector3 offSet;

    // Raycast
    private Ray ray;
    private Vector3 rayPoint;   // Raycast as a Vector3

    // Do a highlight if the mouse entered the game object
    private void OnMouseEnter() {
    }

    private void OnMouseOver() {
        
    }

    private void OnMouseExit() {

    }

    private void OnMouseDown() {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);

        offSet = transform.position - rayPoint;

        dragging = true;
    }

    private void OnMouseUp() {
        dragging = false;
    }

    private void FixedUpdate() {
        if (dragging) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            rayPoint = ray.GetPoint(distance);

            float X = transform.position.x;
            float Y = transform.position.y;

            if (!freezeX) {
                X = rayPoint.x + offSet.x;
            }

            if (!freezeY) {
                Y = rayPoint.y + offSet.y;
            }

            transform.position = new Vector3(X,Y);
        }
    }
}
