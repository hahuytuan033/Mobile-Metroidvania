using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float acceleration= .1f; //tăng tốc

    void Update()
    {
        speed += acceleration *Time.deltaTime;
        transform.Translate(new Vector2(1f, 0f) * Time.deltaTime * speed);
    }
}
