using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] private Image WinImage;
    [SerializeField] private Text WinText;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject charSelectMenu;


    private float restartTime;

    private List<GameObject> characterList = new List<GameObject>();

    public List<GameObject> CharacterList { get => characterList; set => characterList = value; }

    private void Start()
    {
        WinImage.gameObject.SetActive(false);
        restartTime = FindObjectOfType<DataContainer>().data.others.restartTime;
    }

    public void Death(int playerNumber)
    {
        int winner;

        if (playerNumber == 1)
        {
            winner = 1;
        }
        else
            winner = 0;

        string victoryText = CharacterList[winner].GetComponent<Character>().VictoryText;
        Color color = characterList[winner].GetComponent<Character>().VictoryColor;
        Win(playerNumber, victoryText, color);
    }

    public void Win(int playerNumber, string VictoryText, Color color)
    {
        WinImage.gameObject.SetActive(true);
        WinImage.color = color;
        WinText.text = VictoryText;
        StartCoroutine("Restart", restartTime);
    }

    private IEnumerator Restart(float restartTime)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(restartTime);
        Destroy(characterList[0]);
        Destroy(characterList[1]);
        CharacterList.Clear();
        startMenu.SetActive(true);
        charSelectMenu.SetActive(true);
        WinImage.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
