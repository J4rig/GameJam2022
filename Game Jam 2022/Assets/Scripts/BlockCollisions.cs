using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollisions : MonoBehaviour
{
    [SerializeField] private Renderer obj;
    [SerializeField] private bool colliding;
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
        if (colliding)
        {
            obj.material.color = Color.white;
        }
        else
        {
            obj.material.color = Color.red;
        }
    }
}
