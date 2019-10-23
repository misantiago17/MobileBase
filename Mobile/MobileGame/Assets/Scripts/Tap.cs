using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    // OBS: limitar o drag em favor do tap, se tiver segurando tempo suficiente vira drag
    // Talvez considerar tap se o objecto não se mover

    // Tempo maximo até o player soltar o botão para que ele considere como tap
    public float tapTime = 0.15f;

    private bool tapped = false;
    private float timer = 0;

    private void OnMouseDown() {
        tapped = true;
    }

    private void OnMouseUp() {

        tapped = false;

        if (timer <= tapTime) {
            // Do action
            Debug.Log("Fiz um tap");
        }

        timer = 0;
    }

    private void Update() {

        if (tapped) {
            timer += Time.deltaTime;
        }

    }

}
