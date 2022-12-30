using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockCollisions : MonoBehaviour
{
    [SerializeField] private Renderer obj;
    public bool colliding;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BasicBlock"))
        {
            gameObject.GetComponentInParent<BlockProperties>().colliding++;
        }
        else if (collision.gameObject.CompareTag("GridBlock"))
        {
            colliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
 
        if (collision.gameObject.CompareTag("BasicBlock"))
        {
            gameObject.GetComponentInParent<BlockProperties>().colliding--;
        }
        else if (collision.gameObject.CompareTag("GridBlock"))
        {
            colliding = false;
        }
    }

    private void Update()
    {
        if (gameObject.GetComponentInParent<BlockProperties>().canMove)
        {
            if (colliding)
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
