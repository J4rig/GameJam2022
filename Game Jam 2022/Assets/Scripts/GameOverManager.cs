using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    void Start()
    {
        if (PlayerPrefs.GetInt("Player1score") < PlayerPrefs.GetInt("Player2score"))
        {
            text.text = "Red Player Won";
            text.color = Color.red;
        }
        else
        {
            text.text = "Blue Player Won";
            text.color = Color.blue;
        }
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
