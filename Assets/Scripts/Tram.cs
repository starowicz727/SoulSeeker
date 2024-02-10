using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tram : MonoBehaviour
{
    [SerializeField] GameObject player;
    bool isColliding = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            Transform playerTrans = player.transform;

            // player.transform.parent = this.transform;
            //player.transform.SetParent(this.transform, true);
            // player.transform.rotation *= Quaternion.Euler(0f, playerTrans.rotation.y, 0f);
            isColliding = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == player)
        {
            //player.transform.parent = null;
            isColliding = false;
        }
    }

    public void Update()
    {
        if (isColliding)
        {
            player.transform.localPosition = this.transform.position;
        }
    }

    //private void OnCollisionStay(Collision collision)
    //{

    //}


    //private void Update()
    //{
    //    if (this.transform.position.x == 100 || this.transform.position.x == -57)
    //    {
    //        player.transform.parent = null;
    //    }
    //}
}
