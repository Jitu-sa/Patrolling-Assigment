using UnityEngine;
using System.Collections.Generic;

public class StarPool : MonoBehaviour
{
    public static StarPool Instance;

    public GameObject starPrefab;
    public int maxStars = 5;

    List<GameObject> pool = new List<GameObject>();

    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;

    void Awake()
    {
        Instance = this;

        for (int i = 0; i < maxStars; i++)
        {
            GameObject star = Instantiate(starPrefab);
            star.SetActive(false);
            pool.Add(star);
        }
    }

    void Start()
    {
        for (int i = 0; i < maxStars; i++)
        {
            SpawnStar();
        }
    }

    public void SpawnStar()
    {
        foreach (GameObject star in pool)
        {
            if (!star.activeInHierarchy)
            {
                star.transform.position = new Vector2(
                    Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                    Random.Range(spawnAreaMin.y, spawnAreaMax.y)
                );

                star.SetActive(true);
                return;
            }
        }
    }

    public void ReturnStar(GameObject star)
    {
        star.SetActive(false);
        SpawnStar();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 center = (spawnAreaMin + spawnAreaMax) / 2;
        Vector3 size = spawnAreaMax - spawnAreaMin;
        Gizmos.DrawWireCube(center, size);
    }
}