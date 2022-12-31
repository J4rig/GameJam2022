using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    public int points = 0;

    void Update()
    {
        text.text = points.ToString();
    }
}
