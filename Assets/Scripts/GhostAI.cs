using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class GhostAI : MonoBehaviour
{
    private Vector3 startingPosition;

    private float maxSpeed;

    public GameObject player;
    public bool walk = false;
    public bool attack = false;
    public bool idle = true;

    public bool readyToGo = true;
    public bool angerIssues = false;
    public bool followingPlayer = false;
    void Start()
    {
        startingPosition = this.transform.position;
        maxSpeed = 2f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (readyToGo && followingPlayer)
        {
           FollowTargetWithRotation(player.transform, 3f, 1f);
        }
        else
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("found player");
            GetComponent<Animator>().Play("Walk");
            followingPlayer = true;

        }
        if (other.gameObject.tag == "Ghost")
        {
            Debug.Log("found ghost");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("lost player");
            followingPlayer = false;
        }
    }

    void FollowTargetWithRotation(Transform target, float distanceToStop, float speed)
    {
        transform.LookAt(target);
        if (Vector3.Distance(transform.position, target.position) >= distanceToStop)
        {
            Vector3 directionOfTravel = target.position - transform.position;
            directionOfTravel.Normalize();
            this.GetComponent<Rigidbody>().MovePosition(transform.position + (directionOfTravel * maxSpeed * Time.deltaTime));

        }
    }

    //void AvoidTargetWithRotation(Transform target, float distanceToStop, float speed)
    //{
    //    transform.LookAt(target);
    //    if (Vector3.Distance(transform.position, target.position) >= distanceToStop)
    //    {

    //        //  Vector3 directionOfTravel = target.position - transform.position;
    //        //  directionOfTravel.Normalize();
    //        // this.GetComponent<Rigidbody>().MovePosition(transform.position + (directionOfTravel*maxSpeed*Time.deltaTime));

    //        Vector3 smoothedPosition = Vector3.Lerp(transform.position, target.transform.position, maxSpeed * Time.deltaTime);
    //        transform.position -= smoothedPosition;

    //    }
    //}

    private Vector3 GetRandomPosition()
    {
        Vector3 randomDirection = new Vector3(UnityEngine.Random.Range(-1,1), UnityEngine.Random.Range(-1, 1)).normalized;
        return startingPosition+ randomDirection * Random.Range(10f, 70f); // random dir * random distance
    }
}
