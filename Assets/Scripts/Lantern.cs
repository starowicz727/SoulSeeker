using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<Animator>().Play("lantern", -1, Random.Range(0.0f, 10.0f));
    }

}
