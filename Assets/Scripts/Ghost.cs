using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Ghost : MonoBehaviour
{
    public bool walk = false;
    public bool attack = false;
    public bool idle = true;

    public bool readyToGo = true;
    public bool angerIssues = false;
    public bool followingPlayer = false;

    public Vector3 velocity;
    public Vector3 move;
    public Vector3 steeringForce;
    public Vector3 acceleration;
    public float maxSpeed;
    public float maxForce;
    public float mass;

    public GameObject player;
    public SkinnedMeshRenderer look;
    public Material standardMaterial;
    public Material attackedMaterial;

    private void Start()
    {
        maxSpeed = 0.01f;
        maxForce = 1;
        mass = 0.2f;
        idle = true; walk = false; attack = false;
        GetComponent<Animator>().Play("Idle");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("found player");

            if (readyToGo)
            {
                followingPlayer = true;
                Pursuit(player);
                GetComponent<Animator>().Play("Walk");
            }
            
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

    private void Update()
    {
        if (followingPlayer)
        {
            steeringForce = Pursuit(player);
        }
        else
        {
            steeringForce = Vector3.zero;
        }

        acceleration = steeringForce/ mass;

        if (!float.IsNaN(acceleration.x))
            velocity += acceleration * Time.deltaTime;

        if (acceleration.magnitude < Mathf.Epsilon)
            velocity -= velocity.normalized * velocity.magnitude / 2f * Time.deltaTime;

        move = Vector3.ClampMagnitude(velocity, maxSpeed);
        
        transform.Translate(move, Space.World);
        transform.up = velocity.normalized;
    }

    public Vector3 Seek(Vector3 TargetPos) 
    {
        Vector3 desiredVelocity = (TargetPos - (Vector3)this.transform.position).normalized * maxSpeed;
        return desiredVelocity - velocity;
    }
    public Vector3 Pursuit(GameObject evader) 
    {
        Vector3 ToEvader = evader.transform.position - this.transform.position;
        Vector3 evaderHeading = evader.GetComponent<Rigidbody>().rotation * Vector3.forward; // player movement direction
        Vector3 selfHeading = velocity.normalized;
        float relativeHeading = Vector3.Dot(evaderHeading, selfHeading);

        if (Vector3.Dot(ToEvader, selfHeading) > 0 && (relativeHeading < -0.95))
        {
            return Seek(evader.transform.position);
        }

        float lookAheadTime = ToEvader.magnitude / (maxSpeed + evader.GetComponent<Rigidbody>().velocity.magnitude);

        return Seek((Vector3)evader.transform.position + evader.GetComponent<Rigidbody>().rotation * Vector3.forward * lookAheadTime);
    }


    // Update is called once per frame
    //void Update()
    //{
    //    if (walk)
    //    {
    //        attack = false;
    //        GetComponent<Animator>().Play("Walk");
    //    }
    //    if (attack)
    //    {
    //        walk = false;
    //        GetComponent<Animator>().Play("Attack");
    //        look.material = attackedMaterial;
    //    };
    //    if (idle)
    //    {
    //        attack = false;
    //        walk = false;
    //        GetComponent<Animator>().Play("Idle");
    //    }
    //}
}
