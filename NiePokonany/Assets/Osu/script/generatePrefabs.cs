using UnityEngine;
using UnityEngine.UI;

public class generatePrefabs : MonoBehaviour
{
    // zmienne do generowania
    [Header("Generator")]
    [SerializeField] private float timer = 1;
    private bool isGenerate = true;

    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private GameObject bombDamage;

    private Vector3 vectorLeft = new Vector3(12f, 6.6f, 0.5f);
    private Vector3 vectorRight = new Vector3(12f, 6.6f, -0.2f);

    [Header("animacje")]
    [SerializeField] private Animator anim;
    [SerializeField] private int damageValue;
    [SerializeField] private pointCounter points;
    private bool isDamage = false;
    private float animTimer = 2;
    private bool isAnimTimer = false;

    [Range(0, 100)][SerializeField] private float health;
    [Range(0, 50)][SerializeField] private float damage;

    [SerializeField] private Image healthbar;
    [SerializeField] private Image damagebar;

    private void Update()
    {
        healthbar.fillAmount = health / 100;
        damagebar.fillAmount = damage / 50;
    }

    private void FixedUpdate()
    {
        //generowanie obiektów
        if (isGenerate)
        {
            if (timer <= 0)
            {
                GeneratePrefab();
                timer = 1;
                anim.SetBool("isHit", false);
                anim.SetBool("isThrow", true);
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }

        //zadawanie obra¿eñ
        if(animTimer <= 0 && isAnimTimer)
        {
            getDamage();
            animTimer = 2;
            isAnimTimer = false;
            anim.SetBool("isThrow", false);
            anim.SetBool("isHit", true);
            isGenerate = true;
            timer = 1;
        }
        else if (isAnimTimer)
        {
            animTimer -= Time.deltaTime;
        }

        //koniec gry
        if(health <= 0)
        {
            end();
        }
    }

    // ============= Generowanie objektów do interakcji =============
    private void GeneratePrefab() // generowanie poruszaj¹cych siê obiektów do trafiania
    {
        int rnd = Random.Range(1, 6);

        if (rnd == 1)
        {
            int a = Random.Range(0, 2);

            if (a == 0)
            {
                TwoPrefab(vectorLeft, vectorRight);
            }
            else
            {
                TwoPrefab(vectorLeft, vectorRight);
            }
        }
        else
        {
            int a = Random.Range(0, 2);

            switch (a)
            {
                case 0:
                    OnePrefab(vectorLeft);
                    break;

                case 1:
                    OnePrefab(vectorRight);
                    break;
            }
        }
    }

    private void TwoPrefab(Vector3 ob1, Vector3 ob2)
    {
        GameObject prefab = WhichPrefab();
        Instantiate(prefab, ob1, prefab.transform.rotation);
        prefab = WhichPrefab();
        Instantiate(prefab, ob2, prefab.transform.rotation);
    }

    private void OnePrefab(Vector3 ob1)
    {
        GameObject prefab = WhichPrefab();
        Instantiate(prefab, ob1, prefab.transform.rotation);
    }

    private GameObject WhichPrefab()
    {
        GameObject which;
        int z = Random.Range(0, 5);

        if (z == 0)
        {
            which = prefabs[1];
        }
        else
        {
            which = prefabs[0];
        }

        return which;
    }

    // ============= Zarz¹dzanie paskami =============
    public void addDamage(int z)
    {
        if (isDamage && damage > 0)
        {
            isAnimTimer = true;
            Instantiate(bombDamage, new Vector3(0f, 0f, 0f), bombDamage.transform.rotation);
            SubtractDamage();
            isGenerate = false;
            anim.SetBool("isThrow", false);
        }
        else if(points.Points() >= 0)
        {
            if (z >= 1 && z <= 2)
            {
                AddDamage(z);
            }
            else
            {
                AddDamage(z);
            }
        }

        if(damage >= 50)
        {
            isDamage = true;
        }
    }

    private void getDamage()
    {
        int d = Random.Range(damageValue - 2, damageValue + 3);
        health -= d;
    }

    public void AddDamage(int z)
    {
        if(damage + z > 50)
        {
            damage = 50;
        }
        else
        {
            damage += z;
        }
    }

    public void RemoveDamage(int z)
    {
        if(damage - z < 0 && (z <= 3 && z >= 1))
        {
            damage = 0;
        }
        else
        {
            damage -= z;
        }
    }

    public void SubtractDamage()
    {
        if(isDamage && damage > 0)
        {
            damage -= 25;
        }
        if (damage <= 10)
        {
            isDamage = false;
        }
    }

    //koniec gry
    private void end()
    {
        isGenerate = false;
        anim.SetBool("isThrow", false);
        anim.SetBool("isHit", false);
    }
}
