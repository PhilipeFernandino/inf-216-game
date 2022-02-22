using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public int availableReflectors;
    public GameObject reflectorPrefab;

    private GameObject draggingReflector; 
    private bool isDragging;
    
    public void PlaceReflector() {
        if (availableReflectors > 0) {
            availableReflectors--;
            isDragging = true;
            draggingReflector = Instantiate(reflectorPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        }
    }
    
    public void Update() {
        if (Input.GetMouseButtonDown(0) && isDragging) isDragging = false;
        if (isDragging) {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            draggingReflector.transform.position = pos;
        }
    }
}
