using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockProperties : MonoBehaviour
{
    public bool isColliding;
    public int colliding = 0;
    public bool canMove;

    public bool playersBlock;

    private void Update()
    {
        if (colliding > 0)
        {
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }
    }
}
