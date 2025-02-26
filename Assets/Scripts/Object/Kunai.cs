using UnityEngine;

public class Kunai : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindFirstObjectByType<KunaiPool>().ReturnObject(gameObject);
    }
}
