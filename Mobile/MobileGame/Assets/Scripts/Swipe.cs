using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{ 
    // O que está implementado é Swipe horizontal

    // Distancia máxima para se considerar que o foi um swipe
    public float minDistance = 1.0f;

    [SerializeField]
    public Sprite[] sprites;
    public GameObject changingObject;

    private bool swipping = false;
    private float distance;

    private Vector3 initialSwipePos;
    private Vector3 finalSwipePos;

    private int currentIndex = 0;

    private void OnMouseDown() {

        swipping = true;

        initialSwipePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp() {

        swipping = false;

        finalSwipePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // distance in X where the swipe ended
        distance = initialSwipePos.x - finalSwipePos.x;

        if (distance < 0) {  // Right

            // check if it's a valid swipe
            if (distance <= minDistance * -1) {

                // Do Action
                SpriteRenderer rend = changingObject.GetComponent<SpriteRenderer>();

                currentIndex++;
                if (currentIndex == sprites.Length) {
                    currentIndex = 0;
                } 

                rend.sprite = sprites[currentIndex]; 
            }

        } else if (distance > 0) {  // Left

            // check if it's a valid swipe
            if (distance >= minDistance) {

                // Do Action
                SpriteRenderer rend = changingObject.GetComponent<SpriteRenderer>();

                currentIndex--;
                if (currentIndex == -1) {
                    currentIndex = sprites.Length -1;
                }

                rend.sprite = sprites[currentIndex];
            }
        } 
   
    }

}
