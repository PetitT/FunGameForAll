using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neee : Character
{

    private bool canUse1 = true;
    private float coolDown1;
    private GameObject projectile;
    private float projectileSpeed;
    private int projectileDamage;

    private GameObject cannonTip;

    private bool canUse2 = true;
    private float coolDown2;
    private GameObject wardrobe;
    private float wardrobeSpeed;
    private float wardRobeStun;

    private void Awake()
    {
        characterIndex = 1;

        coolDown1 = FindObjectOfType<DataContainer>().data.neee.coolDown1;
        projectile = FindObjectOfType<DataContainer>().data.neee.projectile;
        projectileSpeed = FindObjectOfType<DataContainer>().data.neee.projectileSpeed;
        projectileDamage = FindObjectOfType<DataContainer>().data.neee.projectileDamage;
        cannonTip = GameObject.Find("NeeCannonTip");

        coolDown2 = FindObjectOfType<DataContainer>().data.neee.coolDown2;
        wardrobe = FindObjectOfType<DataContainer>().data.neee.wardrobe;
        wardrobeSpeed = FindObjectOfType<DataContainer>().data.neee.wardrobeSpeed;
        wardRobeStun = FindObjectOfType<DataContainer>().data.neee.wardrobeStun;
    }

    public override void Special1()
    {
        if (canUse1)
        {
            GameObject grandmere = Instantiate(projectile, cannonTip.transform.position, gameObject.transform.rotation) as GameObject;
            grandmere.GetComponent<Projectile>().Speed = projectileSpeed;
            grandmere.GetComponent<DamageDealer>().Damage = projectileDamage;
            StartCoroutine("CoolDown1", coolDown1);
        }
    }

    public override void Special2()
    {
        if (canUse2)
        {
            GameObject armoire = Instantiate(wardrobe, cannonTip.transform.position, gameObject.transform.rotation) as GameObject;
            armoire.GetComponent<Projectile>().Speed = wardrobeSpeed;
            armoire.GetComponent<Stun>().StunTime = wardRobeStun;
            StartCoroutine("CoolDown2", coolDown2);
        }
    }

    public override void Special3()
    {

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


