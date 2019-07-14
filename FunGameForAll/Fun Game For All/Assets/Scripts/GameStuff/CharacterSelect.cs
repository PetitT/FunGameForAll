using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    private int firstCharIndex = -1;
    private int secondCharIndex = -1;

    [SerializeField] private GameObject startPos1;
    [SerializeField] private GameObject startPos2;

    private int playerTurn = 0;

    public void CharButton(int charIndex)
    {
        if (playerTurn == 0)
        {
            firstCharIndex = charIndex;
        }

        else
        {
            secondCharIndex = charIndex;
        }

    }

    public void Confirm()
    {
        if (playerTurn == 0 && firstCharIndex != -1)
            playerTurn++;
        else if (playerTurn == 1 && secondCharIndex != -1)
        {
            StartGame();
            playerTurn = 0;
        }
      
    }

    private void StartGame()
    {
        GameObject player1 = Instantiate(FindObjectOfType<DataContainer>().data.charPrefab[firstCharIndex], startPos1.transform.position, startPos1.transform.rotation);
        player1.GetComponent<Character>().PlayerNumber = 1;
        FindObjectOfType<GameManager>().CharacterList.Add(player1);
        GameObject player2 = Instantiate(FindObjectOfType<DataContainer>().data.charPrefab[secondCharIndex], startPos2.transform.position, startPos1.transform.rotation);
        player2.GetComponent<Character>().PlayerNumber = 2;
        FindObjectOfType<GameManager>().CharacterList.Add(player2);
        GameObject.Find("CharacterSelect").SetActive(false);
    }

    public void StartCharSelect()
    {
        GameObject.Find("Menu").SetActive(false);
    }
}
