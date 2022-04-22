using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    public float rotation;
    public float lifeTime;
    float timer; //time left until bullet is destroyed

    void Start()
    {
        timer = lifeTime;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void ResetTimer()
    {
        timer = lifeTime;
    }
}
