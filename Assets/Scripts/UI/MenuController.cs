using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public List<GameObject> levelButtons = new List<GameObject>();
    public void Start()
    {
        for (int i = 0; i < levelButtons.Count; i++)
        {
            int index = i;
            levelButtons[i].GetComponent<Button>().onClick.AddListener(delegate { StartLevel(index); });
            if (LevelData.won[i])
            {
                levelButtons[i].GetComponent<Image>().color = Color.green;
            }
        }
    }
    public void StartLevel(int index)
    {
        LevelData.levelIndexLoaded = index;
        SceneManager.LoadScene("Level " + (index + 1), LoadSceneMode.Single);
    }
}
