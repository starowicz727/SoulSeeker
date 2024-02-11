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
          //  player.GetComponent<FirstPersonController>().isGrounded = true;
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
