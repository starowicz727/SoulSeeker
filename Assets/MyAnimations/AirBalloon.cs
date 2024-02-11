using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBalloon : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] AnimationClip animationClip;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.transform.parent = this.transform;
            GetComponent<Animator>().Play("balloonUp");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == player)
        {
            if (this.transform.position.y == 1.7 || this.transform.position.y == 50)
            {
                //player.GetComponent<FirstPersonController>().playerCanMove = true;
                player.GetComponent<FirstPersonController>().isGrounded = true;
            }
            else
            {
                player.GetComponent<FirstPersonController>().isGrounded = false;
                //player.GetComponent<FirstPersonController>().playerCanMove = false;
            }
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
