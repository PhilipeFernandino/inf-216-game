using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    public float objectRotationSpeed;
    public List<int> rotatedReflectors;
    public GameObject reflectorPreafab;

    private bool isObjectDraggable;
    private bool isObjectSelected;
    private bool isObjectRotable;


    private GameObject[] reflectorButtons;
    private GameObject selectedObject;
    private void Start()
    {
        reflectorButtons = GameObject.FindGameObjectsWithTag("ReflectorButton");

        for (int i = 0; i < reflectorButtons.Length; i++)
        {
            reflectorButtons[i].SetActive(false);

            if (i < rotatedReflectors.Count)
            {
                reflectorButtons[i].SetActive(true);
                int index = i;
                int rotation = rotatedReflectors[i];
                reflectorButtons[i].transform.eulerAngles = new Vector3(0, 0, rotation);
                reflectorButtons[i].GetComponent<Button>().onClick.AddListener(delegate { PlaceReflector(index, rotation); });
            }
        }
    }

    private void Reset()
    {
        GameObject[] lightReflectors = GameObject.FindGameObjectsWithTag("LightReflector");
        foreach (GameObject lightReflector in lightReflectors)
            Destroy(lightReflector);

        for (int i = 0; i < rotatedReflectors.Count; i++)
            reflectorButtons[i].SetActive(true);
    }

    public void PlaceReflector(int index, int rotation)
    {
        reflectorButtons[index].SetActive(false);
        isObjectSelected = true;
        isObjectDraggable = true;
        isObjectRotable = false;

        selectedObject = Instantiate(reflectorPreafab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        selectedObject.transform.eulerAngles = new Vector3(0f, 0f, rotation);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (isObjectSelected) isObjectSelected = false;
            else
            {
                Vector2 mouseOnWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mouseOnWorldPos, Vector2.zero);

                if (hit.collider != null)
                {

                    GameObject GO = hit.collider.gameObject;
                    if (GO.CompareTag("LightReflector"))
                    {
                        selectedObject = GO;
                        isObjectDraggable = true;
                        isObjectSelected = true;
                        isObjectRotable = false;
                    }

                    else if (GO.CompareTag("LightEmitter"))
                    {
                        selectedObject = GO;
                        isObjectDraggable = false;
                        isObjectSelected = true;
                        isObjectRotable = false;
                    }

                }
            }
        }

        if (isObjectSelected)
        {
            if (isObjectDraggable)
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                selectedObject.transform.position = pos;
            }
            if (isObjectRotable)
            {
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
