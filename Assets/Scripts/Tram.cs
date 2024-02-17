using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tram : MonoBehaviour
{
    [SerializeField] GameObject player;
    private float closerToPlayer = 1.7f; // smaller ghost distance to player while on tram
    private float standardDistanceToPlayer;

    private void Start()
    {
        standardDistanceToPlayer = GhostAI.distanceFromPlayer;
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject == player)
    //    {
    //        player.transform.parent = this.transform;
    //        player.GetComponent<FirstPersonController>().enableJump = false;
    //        GhostAI.distanceFromPlayer = closerToPlayer;
    //    }
    //}


    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject == player)
    //    {
    //        player.transform.parent = null;
    //        player.GetComponent<FirstPersonController>().enableJump = true;
    //        GhostAI.distanceFromPlayer = standardDistanceToPlayer;
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = this.transform;
            player.GetComponent<FirstPersonController>().enableJump = false;
            GhostAI.distanceFromPlayer = closerToPlayer;
        }

        if (GhostAI.distanceFromPlayer == closerToPlayer && other.gameObject.tag == "Ghost") 
        {
            other.transform.parent = this.transform;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (GhostAI.distanceFromPlayer == standardDistanceToPlayer && other.gameObject.tag == "Ghost")
        {
            other.transform.parent = null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
            player.GetComponent<FirstPersonController>().enableJump = true;
            GhostAI.distanceFromPlayer = standardDistanceToPlayer; Debug.Log(GhostAI.distanceFromPlayer);
        }
    }
}
