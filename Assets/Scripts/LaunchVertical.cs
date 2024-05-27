using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchVertical : MonoBehaviour
{
    [SerializeField] float force;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.right * force, ForceMode.Impulse);
    }
}
