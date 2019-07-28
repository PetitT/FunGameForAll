using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Data", menuName = "Data/Character", order = 0)]
public class Data : ScriptableObject
{

    
    public List<GameObject> charPrefab = new List<GameObject>();

    [System.Serializable]
    public class Character
    {
        public string name;
        public float moveSpeed;
        public float jumpForce;
        public float jumpTime;
        public int maxHealth;
        public Color color;
        public string victoryText;
    }

    public List<Character> characters = new List<Character>();

    [System.Serializable]
    public class Lascistay
    {
        [Header("Attack1")]
        public float blinkSpeed;
        public Image blinkImage;

        [Header("Attack2")]
        public float slowForce;

        [Header("Attack3")]
        public AudioClip audioClip;
    }

    public Lascistay lascistay;

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
    public class UnicornKitten
    {
        [Header("Attack1")]
        public float coolDown1;
        public GameObject projectile;
        public float projectileSpeed;
        public int projectileSlow;

        [Header("Attack2")]
        public float coolDown2;
        public GameObject heart;
        public float heartTimer;
        public float explosionDuration;
        public int explosionDamage;
    }

    public UnicornKitten unicornKitten;

    [System.Serializable]
    public class CancerAmalgam
    {
        [Header("Passive")]
        public float timeToBuff;
        public int healthBuff;
        public float statsBuff;
        public int damageBuff;

        [Header("Attack1")]
        public int attackDamage;

        [Header("Attack2")]
        public List<GameObject> projectiles = new List<GameObject>();
        public float coolDown2;
        public int projectileDamage;
        public float projectileSpeed;

        [Header("Attack3")]
        public AudioClip brodeLaugh;
        public float coolDown3;
    }

    public CancerAmalgam cancerAmalgam;

    [System.Serializable]
    public class Others
    {
        public GameObject explosion;
        public float restartTime;
    }

    public Others others;

}
