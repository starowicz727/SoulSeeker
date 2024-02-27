using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    public Light thisLight;
    private bool active = true;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            active = !active;
            thisLight.enabled = active;
        }
    }
}
