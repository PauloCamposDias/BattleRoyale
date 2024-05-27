using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Launch : MonoBehaviour
{
    [SerializeField] float force;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")collision.gameObject.GetComponent<Rigidbody>().AddForce((transform.forward + Vector3.up) * force, ForceMode.Impulse);
    }
}
