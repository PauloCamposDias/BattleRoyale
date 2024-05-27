using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    [SerializeField] float time;
    bool canFall = false;

    void Start()
    {
        LevelManager.instance.OnMatchStart += StartFalling;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(!canFall) return;
        if(collision.gameObject.tag == "Player")
        {
            Invoke("Fall", time);
        }
    }

    void OnDestroy()
    {
        LevelManager.instance.OnMatchStart -= StartFalling;
    }

    void StartFalling()
    {
        canFall = true;
    }

    void Fall()
    {
        gameObject.SetActive(false);
    }
}
