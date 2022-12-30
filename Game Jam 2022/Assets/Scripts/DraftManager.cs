using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class DraftManager : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;

    [SerializeField] private GameObject endTurnButton;

    [SerializeField] private GameObject player1DeckPanel;
    [SerializeField] private GameObject player2DeckPanel;

    [SerializeField] private GameObject draftPanel;

    [SerializeField] private List<GameObject> allCards = new List<GameObject>(); //all card types
    [SerializeField] private List<GameObject> shufledCards = new List<GameObject>(); //sellected cards for game
    [SerializeField] private List<GameObject> cardsShown = new List<GameObject>(); //cards that are sown in draft panel

    [SerializeField] private List<GameObject> player1Hand = new List<GameObject>();
    [SerializeField] private List<GameObject> player2Hand = new List<GameObject>();

    public bool playersTurn = true;
    public bool drafting = false;
    public bool cardPlayed = false;

    public void endTurn ()
    {
        if (player1Hand.Count + player2Hand.Count == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            playersTurn = !playersTurn;
            cardPlayed = false;
        } 
    }

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            shufledCards.Add(allCards[Random.Range(0, allCards.Count)]);
        }
        drafting = true; //drafting phase begins
        endTurnButton.SetActive(false);
    }

    private void Update()
    {
        if (playersTurn)
        {
            player1DeckPanel.SetActive(true);
            player2DeckPanel.SetActive(false);
            Text.text = "Red";
            Text.color = Color.red;
        }
        else
        {
            player1DeckPanel.SetActive(false);
            player2DeckPanel.SetActive(true);
            Text.text = "Blue";
            Text.color = Color.blue;
        }

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
        else
        {
            drafting = false; //drafting phase ends
            if (cardPlayed)
            {
                endTurnButton.SetActive(true);
            }         
        }
    }

    private int n;
    private void removeItem(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == EventSystem.current.currentSelectedGameObject)
            {
                n = i;
                break;
            }
        }
        list.RemoveAt(n);
    }

    public void TakeCard()
    {
        if (playersTurn)
        {
            player1DeckPanel.SetActive(true);
            player2DeckPanel.SetActive(false);
            player1Hand.Add(EventSystem.current.currentSelectedGameObject.GetComponent<DraftCardProperties>().DeckCard);
            Instantiate(EventSystem.current.currentSelectedGameObject.GetComponent<DraftCardProperties>().DeckCard, new Vector3(0, 0, 0), Quaternion.identity, player1DeckPanel.transform);
        }
        else
        {
            player1DeckPanel.SetActive(false);
            player2DeckPanel.SetActive(true);
            player2Hand.Add(EventSystem.current.currentSelectedGameObject.GetComponent<DraftCardProperties>().DeckCard);
            Instantiate(EventSystem.current.currentSelectedGameObject.GetComponent<DraftCardProperties>().DeckCard, new Vector3(0, 0, 0), Quaternion.identity, player2DeckPanel.transform);
        }
        playersTurn = !playersTurn;
        
        removeItem(cardsShown);
        removeItem(shufledCards);
        Destroy(EventSystem.current.currentSelectedGameObject);
    }

    public void UseCard()
    {
        if (cardPlayed || drafting)
        {
            return;
        }
        List<GameObject> blocksToCreate = EventSystem.current.currentSelectedGameObject.GetComponent<DeckCardProperties>().blocks;
        int i = -3;
        foreach (GameObject block in blocksToCreate)
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            GameObject inst = Instantiate(block, new Vector3(-18, i, 0), Quaternion.identity);
            inst.GetComponent<BlockProperties>().canMove = true;
            inst.GetComponent<BlockProperties>().playersBlock = playersTurn;
            i += 3;
        }
        cardPlayed = true;
        if (playersTurn)
        {
            removeItem(player1Hand);
        }
        else
        {
            removeItem(player2Hand);
        }
        Destroy(EventSystem.current.currentSelectedGameObject);
    }
}