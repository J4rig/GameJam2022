using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckManager : MonoBehaviour
{
    public void UseCard()
    {
        List<GameObject> blocksToCreate = EventSystem.current.currentSelectedGameObject.GetComponent<DeckCardProperties>().blocks;
        int i = -3;
        foreach (GameObject block in blocksToCreate)
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            Instantiate(block, new Vector3(-20, i, 0), Quaternion.identity);
            i += 3;
        }
        Destroy(EventSystem.current.currentSelectedGameObject);
    }
}
