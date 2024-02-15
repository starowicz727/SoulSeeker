using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public bool walk = false;
    public bool attack = false;
    public bool idle = true;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (walk)
        {
            attack = false;
            GetComponent<Animator>().Play("Walk");
        }
        if (attack)
        {
            walk = false;
            GetComponent<Animator>().Play("Attack");
        }
        if (idle)
        {
            attack = false;
            walk = false;
            GetComponent<Animator>().Play("Idle");
        }
    }
}
