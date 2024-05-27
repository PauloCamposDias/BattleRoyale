using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterAnimation))]

public class NPCMovement : MonoBehaviour
{
	[Header("References")]
	[SerializeField] LayerMask whatIsGround;
	[SerializeField] float playerHeight;
	Rigidbody rb;
	CharacterAnimation cAnim;
	
	[Header("Movement")]
	[SerializeField] float groundDrag;
	bool isGrounded;
	
	[SerializeField] NavMeshAgent agent;
    [SerializeField] float time;
    [SerializeField] GameObject[] checkpoints;
    Vector3 goal;
	
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		cAnim = GetComponent<CharacterAnimation>();
		GetComponent<CharacterColorManager>().SetRandomColor();
        Invoke("MoveTowardGoal", time);
	}
	
	void Update()
	{
        agent.SetDestination(goal);
        
		isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight *.5f + .2f, whatIsGround);
		
		if(isGrounded)
		{
			rb.drag = groundDrag;
		}
		else
		{
			rb.drag = 0;
		}
	}

    void MoveTowardGoal()
    {
        int rand = UnityEngine.Random.Range(0, checkpoints.Length);
        goal = checkpoints[rand].transform.position; 
        Invoke("MoveTowardGoal", time);
    }
}
