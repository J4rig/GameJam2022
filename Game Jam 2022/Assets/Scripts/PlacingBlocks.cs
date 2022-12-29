using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlacingBlocks : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    public GameObject grabbedBlock; 

    void Update()
    {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        if (grabbedBlock != null)
        {
            Vector3 pos = new Vector3(Mathf.RoundToInt(mousePos.x), Mathf.RoundToInt(mousePos.y), 0);
            grabbedBlock.transform.position = pos;

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                grabbedBlock.transform.rotation = Quaternion.Euler(0, 0, Mathf.RoundToInt(-90));
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                grabbedBlock.transform.rotation = Quaternion.Euler(0, 0, Mathf.RoundToInt(90));
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                grabbedBlock.transform.rotation = Quaternion.Euler(0, 0, Mathf.RoundToInt(-180));
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                grabbedBlock.transform.rotation = Quaternion.Euler(0, 0, Mathf.RoundToInt(0));
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (!grabbedBlock.GetComponent<BlockProperties>().isColliding)
                {
                    grabbedBlock = null;
                }            
            }
        }
    }
    

}
