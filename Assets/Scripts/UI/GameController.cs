using UnityEngine;

public class GameController : MonoBehaviour {
    
    public int reflectors;
    public GameObject reflectorPrefab;
    public float objectRotationSpeed;

    private bool isObjectDraggable;
    private bool isObjectSelected;
    private bool isObjectRotable;
    private GameObject selectedObject; 
    private int availableReflectors;
    
    private void Reset() {
        GameObject[] GOs = GameObject.FindGameObjectsWithTag("LightReflector");
        foreach(GameObject go in GOs) {
            Destroy(go);
        }
        availableReflectors = reflectors;
    }

    public void PlaceReflector() {
        if (availableReflectors > 0) {
            availableReflectors--;
            isObjectSelected = true;
            isObjectDraggable = true;
            selectedObject = Instantiate(reflectorPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        }
    }
    
    private void Start() {
        availableReflectors = reflectors;
    }

    public void Update() {
    
        if (Input.GetKeyDown(KeyCode.R)) {
            Reset();
        }

        if (Input.GetMouseButtonDown(0)) {
            if (isObjectSelected) isObjectSelected = false;
            else {
                Vector2 mouseOnWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mouseOnWorldPos, Vector2.zero);
                
                if (hit.collider != null) {
                    
                    GameObject GO = hit.collider.gameObject;
                    //talvez fosse melhor se cada objeto decidisse como ele deseja se mover, chamando um metodo de interface para 
                    //o objeto selecionado 
                    if (GO.CompareTag("LightReflector")) {
                        selectedObject = hit.collider.transform.parent.gameObject;
                        isObjectDraggable = true;
                        isObjectSelected = true;
                        isObjectRotable = true;
                    } 
                    
                    else if (GO.CompareTag("LightEmitter")) {
                        selectedObject = hit.collider.gameObject;
                        isObjectDraggable = false;
                        isObjectSelected = true;
                        isObjectRotable = true;
                    }

                }
            }
        }
        
        if (isObjectSelected) {
            if (isObjectDraggable) {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                selectedObject.transform.position = pos;
            }
            if (isObjectRotable) {
                int rotateDir = 0;
                float rotationSpeed = objectRotationSpeed;
                if (Input.GetKey(KeyCode.LeftShift)) rotationSpeed /= 4;
                if (Input.GetKey(KeyCode.Q)) rotateDir = -1;
                else if (Input.GetKey(KeyCode.E)) rotateDir = 1;
                selectedObject.transform.Rotate(rotationSpeed * Vector3.forward * rotateDir);
            }
        }
    }
}
