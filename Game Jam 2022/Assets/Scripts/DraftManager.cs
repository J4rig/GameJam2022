using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DraftManager : MonoBehaviour
{

    [SerializeField] private GameObject deckPanel;
    [SerializeField] private GameObject draftPanel;

    [SerializeField] private List<GameObject> allCards = new List<GameObject>(); //all card types
    [SerializeField] private List<GameObject> shufledCards = new List<GameObject>(); //sellected cards for game
    [SerializeField] private List<GameObject> cardsShown = new List<GameObject>(); //cards that are sown in draft panel

    private int n;

    public void ShufleCards()
    {
        for (int i = 0; i < 10; i++)
        {
            shufledCards.Add(allCards[Random.Range(0, allCards.Count)]);
        }
    }

    private void Update()
    {

        if (shufledCards.Count > 0)
        {
            if (cardsShown.Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    cardsShown.Add(shufledCards[Random.Range(0, shufledCards.Count)]);
                    Instantiate(cardsShown[i], new Vector3(0, 0, 0), Quaternion.identity, draftPanel.transform);
                }
            }
        }
    }

    private void removeItem(List<GameObject> list)
    {
        for (int i = 0; i < cardsShown.Count; i++)
        {
            if (cardsShown[i] == EventSystem.current.currentSelectedGameObject)
            {
                n = i;
                break;
            }
        }
        list.RemoveAt(n);
    }

    public void TakeCard()
    {
        Instantiate(EventSystem.current.currentSelectedGameObject.GetComponent<DraftCardProperties>().DeckCard, new Vector3(0, 0, 0), Quaternion.identity, deckPanel.transform);

        removeItem(cardsShown);
        removeItem(shufledCards);
        Destroy(EventSystem.current.currentSelectedGameObject);
    }
}