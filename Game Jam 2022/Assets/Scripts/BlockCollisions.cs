using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockCollisions : MonoBehaviour
{
    [SerializeField] private Renderer obj;
    public bool isOnGrid;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BasicBlock"))
        {
            gameObject.GetComponentInParent<BlockProperties>().colliding++;
        }
        if (collision.gameObject.CompareTag("GridBlock"))
        {
            isOnGrid = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
 
        if (collision.gameObject.CompareTag("BasicBlock"))
        {
            gameObject.GetComponentInParent<BlockProperties>().colliding--;
        }
        if (collision.gameObject.CompareTag("GridBlock"))
        {
            isOnGrid = false;
        }
    }

    private void Update()
    {
        if (gameObject.GetComponentInParent<BlockProperties>().canMove)
        {
            if (isOnGrid)
            {
                obj.material.color = Color.white;
            }
            else
            {
                if (gameObject.GetComponentInParent<BlockProperties>().playersBlock)
                {
                    obj.material.color = Color.red;
                }
                else
                {
                    obj.material.color = Color.blue;
                }
            }
        } 
    }
}
