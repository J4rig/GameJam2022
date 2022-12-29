using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    [SerializeField] GameObject gridBlock;
    public int COLS = 4;
    public int ROWS = 4;
    void Start()
    {
        for (int i = 0; i < COLS; i++)
        {
            for (int j = 0; j < ROWS; j++)
            {
                Instantiate(gridBlock, new Vector3(gameObject.transform.position.x + i, gameObject.transform.position.y + j, 0), Quaternion.identity, gameObject.transform);
            }
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
