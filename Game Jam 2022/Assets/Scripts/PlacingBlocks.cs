using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlacingBlocks : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    public GameObject grabbedBlock;

    private void Start()
    {
        string mapName = PlayerPrefs.GetString("selectedMap");
        mapName = mapName.Substring(0, mapName.IndexOf("("));
        GameObject map = Resources.Load<GameObject>("Prefabs/StartingGrids/" + mapName);
        Instantiate(map, new Vector3(0, 0, 0), Quaternion.identity);
    }

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
                int outside = 0;
                foreach (Transform block in grabbedBlock.transform)
                {
                    Debug.Log(block.name);
                    if (block.GetComponent<BlockCollisions>() != null)
                    {
                        if (!block.GetComponent<BlockCollisions>().isOnGrid)
                        {
                            outside++;
                        }
                    }        
                }
                if (!grabbedBlock.GetComponent<BlockProperties>().isColliding)
                {
                    grabbedBlock.GetComponent<BlockProperties>().canMove = false;

                    if (grabbedBlock.GetComponent<BlockProperties>().playersBlock)
                    {
                        GameObject.FindGameObjectWithTag("RedPoints").GetComponent<Points>().points += outside;
                    }
                    else
                    {
                        GameObject.FindGameObjectWithTag("BluePoints").GetComponent<Points>().points += outside;
                    }
                    grabbedBlock = null;
                }       
            }
        }
    }
    

}
