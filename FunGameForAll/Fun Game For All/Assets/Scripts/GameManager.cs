using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] private Image WinImage;
    [SerializeField] private Text WinText;


    private void Awake()
    {
        WinImage.gameObject.SetActive(false);
    }

    public void Win(int playerNumber, string VictoryText, Color color)
    {
        WinImage.gameObject.SetActive(true);
        WinImage.color = color;
        WinText.text = VictoryText;
    }
}
