using UnityEngine;

public class KunaiShooting : MonoBehaviour
{
    public KunaiPool kunaiPool;
    public Transform firePoint;
    public float kunaiSpeed = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject kunai = kunaiPool.GetObject();
        kunai.transform.position = firePoint.position;
        Rigidbody2D rb = kunai.GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * kunaiSpeed;
    }
}
