using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancerAmalgam : Character
{

    private float timeToBuff;
    private int healthBuff;
    private float statsBuff;
    private Animation anim;

    private void Awake()
    {
        characterIndex = 4;

        timeToBuff = FindObjectOfType<DataContainer>().data.cancerAmalgam.timeToBuff;
        healthBuff = FindObjectOfType<DataContainer>().data.cancerAmalgam.healthBuff;
        statsBuff = FindObjectOfType<DataContainer>().data.cancerAmalgam.statsBuff;

        anim = GetComponent<Animation>();
        StartCoroutine("Buff");
    }

    public override void Special1()
    {
        GetComponent<Animation>().Play("Attack");
    }

    public IEnumerator Buff()
    {
        yield return new WaitForSeconds(timeToBuff);
        GetComponent<Character>().MaxHealth += healthBuff;
        GetComponent<Character>().CurrentHealth += healthBuff;
        GetComponent<Character>().MoveSpeed += statsBuff;
        GetComponent<Character>().JumpForce += statsBuff;
        StartCoroutine("Buff");
    }
}
