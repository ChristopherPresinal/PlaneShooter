using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patterns : MonoBehaviour
{
    float sinStartY;
    public float amplitude = 2f;
    public float frecuency = 2f;

    public bool inverted;

    // Start is called before the first frame update
    void Start()
    {
        sinStartY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 temp = transform.position;

        float sin = Mathf.Sin(temp.x * frecuency) * amplitude;
        if (inverted == true)
        {
            sin *= -1;
        }

        temp.y = sinStartY + sin;

        transform.position = temp;
    }

}
