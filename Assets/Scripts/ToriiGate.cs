using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToriiGate : MonoBehaviour
{
    public GameObject butterflies;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "GhostBody")
        {
            Instantiate(butterflies, new Vector3(this.transform.position.x, this.transform.position.y - 0.75f, this.transform.position.z - 1.5f), this.transform.rotation);
            Debug.Log("butterfl");
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }
}
