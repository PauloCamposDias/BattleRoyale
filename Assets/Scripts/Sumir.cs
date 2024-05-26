using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sumir : MonoBehaviour
{
    [SerializeField] float tempo;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    
    void OnCollisionEnter()
    {
        rend.material.color = Color.Lerp(Color.blue, Color.clear, tempo);
        //Invoke("Desligar", tempo);
    }

    void Desligar()
    {
        gameObject.SetActive(false);
    }

    /*IEnumerator MudarCor()
    {

    }*/
}
