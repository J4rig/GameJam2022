using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameObject clickedBlock = gameObject.transform.parent.gameObject;
        Debug.Log(clickedBlock.name);

        GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlacingBlocks>().grabbedBlock = clickedBlock;
    }
}
