using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using static UnityEngine.GraphicsBuffer;

public class GhostAI : MonoBehaviour
{
    private Transform startingPosition;

    private Rigidbody rb;
    private float maxSpeed;
    public static float distanceFromPlayer;

    public GameObject player;
    //public bool walk = false;
    //public bool attack = false;
    //public bool idle = true;

    public bool readyToGo = true;
    public bool angerIssues = false;
    public bool followingPlayer = false;
    public bool followingGhost = false;
    public bool escapingGhost = false;
    
    //private GameObject ghostToFollow;
    //private GameObject ghostToRunFrom;

    void Start()
    {
        startingPosition = this.transform;
        rb = GetComponent<Rigidbody>();
        maxSpeed = 5f;
        distanceFromPlayer = 3f;

        //ghostToFollow = null; ghostToRunFrom = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (readyToGo && followingPlayer && !escapingGhost)
        {
            FollowTargetWithRotation(player.transform, distanceFromPlayer, maxSpeed, 0.4f);
        }
        //if (!readyToGo && angerIssues && followingGhost)
        //{
        //    FollowTargetWithRotation(ghostToFollow.transform, 0, 1.5f , 0);
        //}
        //if (escapingGhost)
        //{
        //    EscapeTargetWithRotation(ghostToRunFrom.transform, maxSpeed, 0);
        //}
        //if(!escapingGhost && !followingGhost && !followingPlayer && this.transform!=startingPosition)
        //{
        //    FollowTargetWithRotation( startingPosition , 0, maxSpeed, 0);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && readyToGo && !escapingGhost)
        {
            Debug.Log("found player");
            GetComponent<Animator>().Play("Walk");
            followingPlayer = true;

        }
        //if (other.gameObject.tag == "Ghost" && followingPlayer && other.gameObject.GetComponent<GhostAI>().angerIssues)
        //{
        //    Debug.Log("found ghost");
        //    GetComponent<Animator>().Play("Attack");
        //    followingPlayer = false;
        //    ghostToRunFrom = other.gameObject;
        //    escapingGhost = true;
        //}
        //if (other.gameObject.tag == "Ghost" && other.gameObject.GetComponent<GhostAI>().readyToGo && angerIssues)
        //{
        //    GetComponent<Animator>().Play("Attack");
        //    ghostToFollow = other.gameObject;
        //    followingGhost = true;
        //}
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player && followingPlayer)
        {
            Debug.Log("lost player");
            GetComponent<Animator>().Play("Idle");
            followingPlayer = false;
        }
        //if (other.gameObject.tag == "Ghost" && escapingGhost)
        //{
        //    GetComponent<Animator>().Play("Idle");
        //    escapingGhost = false;
        //}
        //if (other.gameObject.tag == "Ghost" && followingGhost)
        //{
        //    GetComponent<Animator>().Play("Idle");
        //    followingGhost = false;
        //}
    }

    void FollowTargetWithRotation(Transform target, float distanceToStop, float speed, float heighDifference) // difference -0.4 when its player and 0 when its ghost
    {
        //transform.LookAt(target);
        Vector3 directionToTarget = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(directionToTarget.x, 0, directionToTarget.z));

        if (Vector3.Distance(transform.position, target.position) >= distanceToStop )
        {
            //Vector3 directionOfTravel = target.position - transform.position;
            //directionOfTravel.Normalize();
            //rb.MovePosition(transform.position + (directionOfTravel * speed * Time.deltaTime));

            Vector3 directionOfTravel = new Vector3(target.transform.position.x, target.transform.position.y - heighDifference, target.transform.position.z) - transform.position;
            directionOfTravel.Normalize();
            rb.MovePosition(transform.position + (directionOfTravel * speed * Time.deltaTime));

        }
        else
        {
            if ((target.transform.position.y - heighDifference) != transform.position.y) // with -0.4 looks better == closer to the ground 
            {
                float newY = Mathf.Lerp(transform.position.y, target.transform.position.y - heighDifference, speed * Time.fixedDeltaTime);
                rb.MovePosition(new Vector3(transform.position.x, newY, transform.position.z));
            }
        }
    }
    void EscapeTargetWithRotation(Transform target, float speed, float heighDifference)
    {
        //transform.LookAt(target);
        Vector3 directionToTarget = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(directionToTarget.x, 0, directionToTarget.z));

        
        
            Vector3 directionOfTravel = target.position - transform.position;
            directionOfTravel.Normalize();
            rb.MovePosition(transform.position - (directionOfTravel * speed * Time.deltaTime));

            //Vector3 directionOfTravel = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z) - transform.position;
            //directionOfTravel.Normalize();
            //rb.MovePosition(transform.position - (directionOfTravel * speed * Time.deltaTime));

        
       
        
            //if ((target.transform.position.y - heighDifference) != transform.position.y) // with -0.4 looks better == closer to the ground 
            //{
            //    float newY = Mathf.Lerp(transform.position.y, target.transform.position.y - heighDifference, speed * Time.fixedDeltaTime);
            //    rb.MovePosition(new Vector3(transform.position.x, newY, transform.position.z));
            //}
        
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

    //private Vector3 GetRandomPosition()
    //{
    //    Vector3 randomDirection = new Vector3(UnityEngine.Random.Range(-1,1), UnityEngine.Random.Range(-1, 1)).normalized;
    //    return startingPosition+ randomDirection * Random.Range(10f, 70f); // random dir * random distance
    //}
}
