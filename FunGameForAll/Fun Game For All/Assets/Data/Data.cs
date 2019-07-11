using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Data", menuName = "Data/Character", order = 0)]
public class Data : ScriptableObject
{

    [System.Serializable]
    public class Character
    {
        public string name;
        public float moveSpeed;
        public float jumpForce;
        public float jumpTime;
        public int maxHealth;
    }

    public List<Character> characters = new List<Character>();

    [System.Serializable]
    public class Lascistay
    {
        //[Header("Attack1")]
        //[Header("Attack2")]
    }

    [System.Serializable]
    public class Neee
    {
        [Header("Attack1")]
        public float coolDown1;
        public GameObject projectile;
        public float projectileSpeed;
        public int projectileDamage;

        [Header("Attack2")]
        public float coolDown2;
        public GameObject wardrobe;
        public float wardrobeSpeed;
        public float wardrobeStun;
    }

    public Neee neee;

    [System.Serializable]
    public class Uther
    {
        [Header("Attack1")]
        public float coolDown1;
        public float timeBeforeAvailable;
        public float InvulnerabilityTimer;

        [Header("Attack2")]
        public float castingTime;
    }

    public Uther uther;

    [System.Serializable]
    public class Others
    {
    }

    public Others others;

}
