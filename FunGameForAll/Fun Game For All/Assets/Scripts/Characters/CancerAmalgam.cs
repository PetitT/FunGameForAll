using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancerAmalgam : Character
{

    private float timeToBuff;
    private int healthBuff;
    private float statsBuff;
    private int damageBuff;

    private Animation anim;
    private bool canUse1 = true;
    private float attackTime;
    private int attackDamage;

    private bool canUse2 = true;
    private List<GameObject> projectiles;
    private float projectileSpeed;
    private int projectileDamage;
    private float coolDown2;

    private AudioClip brodeLaugh;
    private bool canUse3 = true;
    private float coolDown3;

    private void Awake()
    {
        characterIndex = 4;

        timeToBuff = FindObjectOfType<DataContainer>().data.cancerAmalgam.timeToBuff;
        healthBuff = FindObjectOfType<DataContainer>().data.cancerAmalgam.healthBuff;
        statsBuff = FindObjectOfType<DataContainer>().data.cancerAmalgam.statsBuff;
        damageBuff = FindObjectOfType<DataContainer>().data.cancerAmalgam.damageBuff;

        attackTime = GetComponent<Animation>().GetClip("Attack").length;
        attackDamage = FindObjectOfType<DataContainer>().data.cancerAmalgam.attackDamage;

        projectiles = FindObjectOfType<DataContainer>().data.cancerAmalgam.projectiles;
        projectileSpeed = FindObjectOfType<DataContainer>().data.cancerAmalgam.projectileSpeed;
        projectileDamage = FindObjectOfType<DataContainer>().data.cancerAmalgam.projectileDamage;
        coolDown2 = FindObjectOfType<DataContainer>().data.cancerAmalgam.coolDown2;

        brodeLaugh = FindObjectOfType<DataContainer>().data.cancerAmalgam.brodeLaugh;
        coolDown3 = FindObjectOfType<DataContainer>().data.cancerAmalgam.coolDown3;

        anim = GetComponent<Animation>();
        StartCoroutine("Buff");
    }

    public override void Special1()
    {
        if (canUse1)
        {
            StartCoroutine("Attack1");
        }
    }

    public override void Special2()
    {
        if (canUse2)
        {
            int randomProjectile = Random.Range(0, projectiles.Count - 1);
            GameObject carte = Instantiate(projectiles[randomProjectile], GameObject.Find("CardShooter").transform.position, gameObject.transform.rotation) as GameObject;
            carte.GetComponent<Projectile>().Speed = projectileSpeed;
            carte.GetComponent<DamageDealer>().Damage = projectileDamage;
            StartCoroutine("CoolDown2");
        }
    }

    public override void Special3()
    {
        if (canUse3)
        {
            StartCoroutine("Attack3");
        }
    }

    public IEnumerator Buff()
    {
        yield return new WaitForSeconds(timeToBuff);
        GetComponent<Character>().MaxHealth += healthBuff;
        GetComponent<Character>().CurrentHealth += healthBuff;
        GetComponent<Character>().MoveSpeed += statsBuff;
        GetComponent<Character>().JumpForce += statsBuff;
        attackDamage += damageBuff;
        projectileDamage += damageBuff;
        projectileSpeed += statsBuff;
        StartCoroutine("Buff");
    }

    public IEnumerator Attack1()
    {
        {
            GetComponent<Animation>().Play("Attack");
            canUse1 = false;
            GetComponentInChildren<DamageDealer>().Damage = attackDamage;
            GameObject.Find("Kingsbane").GetComponent<BoxCollider2D>().enabled = true;
            yield return new WaitForSeconds(attackTime);
            GameObject.Find("Kingsbane").GetComponent<BoxCollider2D>().enabled = false;
            canUse1 = true;
        }
    }

    public IEnumerator CoolDown2()
    {
        canUse2 = false;
        yield return new WaitForSeconds(coolDown2);
        canUse2 = true;
    }

    public IEnumerator Attack3()
    {
        canUse3 = false;
        AudioScript.PlaySound(brodeLaugh);
        yield return new WaitForSeconds(coolDown3);
        canUse3 = true;

    }
}
