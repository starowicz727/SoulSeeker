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
            if (this.transform.position.y <= 1.8 || this.transform.position.y >= 49)
            {
                Debug.Log("true ");
                player.GetComponent<FirstPersonController>().enableJump = true;
                player.GetComponent<FirstPersonController>().isGrounded = true;
            }
            else
            {
                Debug.Log("false ");
                player.GetComponent<FirstPersonController>().enableJump = false;
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
