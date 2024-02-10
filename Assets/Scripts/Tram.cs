using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tram : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.transform.parent = this.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
