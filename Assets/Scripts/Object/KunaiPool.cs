using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiPool : MonoBehaviour
{
    public GameObject kunaiPrefab;
    // kích thước của pool
    public int poolSize = 6;
    private Queue<GameObject> pool;

    void Awake()
    {
        pool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject kunai = Instantiate(kunaiPrefab);
            kunai.SetActive(false);
            pool.Enqueue(kunai);
        }
    }

    public GameObject GetObject()
    {
        if (pool.Count > 0)
        {
            GameObject kunai = pool.Dequeue();
            kunai.SetActive(true);
            return kunai;
        }
        else
        {
            GameObject kunai = Instantiate(kunaiPrefab);
            return kunai;
        }
    }

    public void ReturnObject(GameObject kunai)
    {
        kunai.SetActive(false);
        pool.Enqueue(kunai);
    }
}
