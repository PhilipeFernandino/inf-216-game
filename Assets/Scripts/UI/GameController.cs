using UnityEngine;

public class GameController : MonoBehaviour {
    public int reflectors;
    public GameObject reflectorPrefab;

    private GameObject draggingReflector; 
    private bool isDragging;
    private int availableReflectors;
    
    private void Start() {
        availableReflectors = reflectors;
    }

    public void PlaceReflector() {
        if (availableReflectors > 0) {
            availableReflectors--;
            isDragging = true;
            draggingReflector = Instantiate(reflectorPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        }
    }

    private void Reset() {
        GameObject[] GOs = GameObject.FindGameObjectsWithTag("LightReflector");
        foreach(GameObject go in GOs) {
            Destroy(go);
        }
        availableReflectors = reflectors;
    }
    
    public void Update() {
        
        if (Input.GetKeyDown(KeyCode.R)) {
            Reset();
        }
        
        if (Input.GetMouseButtonDown(0) && isDragging) isDragging = false;
        
        if (isDragging) {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            draggingReflector.transform.position = pos;
        }
    }
}
