using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lascistay : Character
{
    private float slowForce;

    private float blinkSpeed;
    private bool isItActive;
    private Image blink;

    private AudioClip audioClip;

    private void Awake()
    {
        characterIndex = 0;

        slowForce = FindObjectOfType<DataContainer>().data.lascistay.slowForce;
        blinkSpeed = FindObjectOfType<DataContainer>().data.lascistay.blinkSpeed;
        blink = GameObject.Find("BlinkImage").GetComponent<Image>();
        audioClip = FindObjectOfType<DataContainer>().data.lascistay.audioClip;
    }

    public override void Special1()
    {
        Time.timeScale = slowForce;
    }

    public override void Special2()
    {
        StartCoroutine("Epilepsy");
    }

    public override void Special3()
    {
        AudioScript.PlaySound(audioClip);
    }

    public IEnumerator Epilepsy()
    {
        blink.enabled = isItActive;
        isItActive = !isItActive;
        yield return new WaitForSecondsRealtime(blinkSpeed);
        StartCoroutine("Epilepsy");
    }
}
