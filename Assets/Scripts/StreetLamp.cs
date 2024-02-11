using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLamp : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Light lampLight;

    private bool switchOff = false;
    private float speed = 3f;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            switchOff = false;
            SwitchON();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            switchOff= true;
        }
    }

    private void Update()
    {
        if(switchOff)
        {
            SwitchOFF();
        }
    }

    void SwitchON()
    {
        if (lampLight.intensity < 4)
        {
            lampLight.intensity += speed * Time.deltaTime;
        }
    }
    void SwitchOFF()
    {
        if (lampLight.intensity > 0)
        {
            lampLight.intensity -= speed * Time.deltaTime;
        }
    }
}
