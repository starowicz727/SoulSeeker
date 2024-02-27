using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUp : MonoBehaviour
{
    private float speed = 1.2f;
    void Update()
    {
        if(this.transform.position.y < 20)
        {

            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
