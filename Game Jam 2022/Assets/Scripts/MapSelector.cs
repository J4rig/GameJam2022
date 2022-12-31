using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelector : MonoBehaviour
{
    [SerializeField] private List<GameObject> maps = new List<GameObject>();
    [SerializeField] private GameObject shownMap;
    private int i;
    void Start()
    {
        i = 0;
        shownMap = Instantiate(maps[i], new Vector3(0,0,0), Quaternion.identity);
    }

    public void nextMap()
    {
        if (i < maps.Count-1)
        {
            i++;
            Destroy(shownMap);
            shownMap = Instantiate(maps[i], new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    public void prevMap()
    {
        
        if (i > 0)
        {
            i--;
            Destroy(shownMap);
            shownMap = Instantiate(maps[i], new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    public void startGame()
    {
        PlayerPrefs.SetString("selectedMap", shownMap.name);
        SceneManager.LoadScene("Game");
    }
}
