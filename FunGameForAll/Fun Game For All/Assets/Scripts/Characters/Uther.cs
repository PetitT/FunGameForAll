using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uther : Character
{
    private bool canBeInterrupted = true;

    private bool canUse1;
    private float coolDown1;
    private float timeBeforeAvailable;
    private float InvulnerabilityTimer;
    private GameObject bubble;

    private float castingTime;

    void Awake()
    {
        characterIndex = 2;

        coolDown1 = FindObjectOfType<DataContainer>().data.uther.coolDown1;
        timeBeforeAvailable = FindObjectOfType<DataContainer>().data.uther.timeBeforeAvailable;
        InvulnerabilityTimer = FindObjectOfType<DataContainer>().data.uther.InvulnerabilityTimer;
        castingTime = FindObjectOfType<DataContainer>().data.uther.castingTime;
        bubble = GameObject.Find("UtherBubble");
        bubble.SetActive(false);
        StartCoroutine("CoolDown1", timeBeforeAvailable);
    }

    public override void Special1()
    {
        if (canUse1)
        {
            StartCoroutine("Bubble", InvulnerabilityTimer);
            StartCoroutine("CoolDown1", coolDown1);
        }
    }

    public override void Special2()
    {
        StartCoroutine("PDF", castingTime);
    }

    public IEnumerator Bubble(float time)
    {
        bubble.SetActive(true);
        canBeInterrupted = false;
        yield return new WaitForSeconds(InvulnerabilityTimer);
        bubble.SetActive(false);
        canBeInterrupted = true;
    }

    public IEnumerator CoolDown1(float coolDown)
    {
        canUse1 = false;
        yield return new WaitForSeconds(coolDown);
        canUse1 = true;
    }

    public IEnumerator PDF(float castingTime)
    {
        CanMove = false;
        yield return new WaitForSeconds(castingTime);
        FindObjectOfType<GameManager>().Win(PlayerNumber, VictoryText, GetComponent<Character>().VictoryColor);
        CanMove = true;
    }

    public override void NumberChanged(int value)
    {
        base.NumberChanged(value);
        if (canBeInterrupted)
        {
            StopCoroutine("PDF");
            CanMove = true;
        }
        else if (value < 0)
            CurrentHealth += value;

    }
}
