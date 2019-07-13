using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicornKitty : Character
{
    private GameObject shootThingy;

    private bool canUse1 = true;
    private float coolDown1;
    private GameObject projectile;
    private float projectileSpeed;
    private int projectileSlow;

    private bool canUse2 = true;
    private float coolDown2;
    private GameObject heart;
    private float heartTimer;
    private float explosionDuration;
    private int explosionDamage;    

    private void Awake()
    {
        characterIndex = 3;

        shootThingy = GameObject.Find("ShootThingy");

        coolDown1 = FindObjectOfType<DataContainer>().data.unicornKitten.coolDown1;
        projectile = FindObjectOfType<DataContainer>().data.unicornKitten.projectile;
        projectileSpeed = FindObjectOfType<DataContainer>().data.unicornKitten.projectileSpeed;
        projectileSlow = FindObjectOfType<DataContainer>().data.unicornKitten.projectileSlow;

        coolDown2 = FindObjectOfType<DataContainer>().data.unicornKitten.coolDown2;
        heart = FindObjectOfType<DataContainer>().data.unicornKitten.heart;
        heartTimer = FindObjectOfType<DataContainer>().data.unicornKitten.heartTimer;
        explosionDuration = FindObjectOfType<DataContainer>().data.unicornKitten.explosionDuration;
        explosionDamage = FindObjectOfType<DataContainer>().data.unicornKitten.explosionDamage;
    }

    public override void Special1()
    {
        if (canUse1)
        {
            GameObject purin = Instantiate(projectile, shootThingy.transform.position, gameObject.transform.rotation) as GameObject;
            purin.GetComponent<Projectile>().Speed = projectileSpeed;
            purin.GetComponent<Glue>().Slow = projectileSlow;
            StartCoroutine("CoolDown1", coolDown1);
        }
    }

    public override void Special2()
    {
        if (canUse2)
        {
            GameObject hearty = Instantiate(heart, shootThingy.transform.position, gameObject.transform.rotation) as GameObject;
            hearty.GetComponent<HeartExplosion>().Timer1 = heartTimer;
            hearty.GetComponent<HeartExplosion>().ExplosionTimer = explosionDuration;
            hearty.GetComponent<HeartExplosion>().ExplosionDamage = explosionDamage;
            StartCoroutine("CoolDown2", coolDown2);
        }
    }

    public IEnumerator CoolDown1(float coolDown)
    {
        canUse1 = false;
        yield return new WaitForSeconds(coolDown);
        canUse1 = true;
    }

    public IEnumerator CoolDown2(float coolDown)
    {
        canUse2 = false;
        yield return new WaitForSeconds(coolDown);
        canUse2 = true;
    }
}
