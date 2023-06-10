using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed = 0f;
    public float deactivate = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeactivateGameObject", deactivate);
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        Vector3 temp = transform.position;
        temp.x += bulletSpeed * Time.deltaTime;
        transform.position = temp;
    }

    void DeactivateGameObject()
    {
        Destroy(gameObject);
    }
}
