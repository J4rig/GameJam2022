using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BasicBlock"))
        {
            gameObject.GetComponentInParent<BlockProperties>().colliding++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
 
        if (collision.gameObject.CompareTag("BasicBlock"))
        {
            gameObject.GetComponentInParent<BlockProperties>().colliding--;
        }
    }
}
