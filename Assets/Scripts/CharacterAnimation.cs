using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
	Animator animator;
	public enum State {IDLE, RUNNING, JUMPING, STRETCH, VICTORY, DEFEAT, NONE}
	public State state = State.STRETCH;
	State currentState = State.NONE;
	public bool canMove {get; private set;}
	
	void Start()
	{
		animator = GetComponent<Animator>();
		LevelManager.instance.OnMatchStart += ResetAnimations;
	}
	
	void OnDestroy()
	{
		LevelManager.instance.OnMatchStart -= ResetAnimations;
	}
	
	void FixedUpdate()
	{
		if(state != currentState)
		{
			currentState = state;
			switch(currentState)
			{
				case State.IDLE: Idle(); break;
				case State.RUNNING: Running(); break;
				case State.JUMPING: Jumping(); break;
				case State.STRETCH: Stretch(); break;
				case State.VICTORY: Victory(); break;
				case State.DEFEAT: Defeat(); break;
			}
		}
	}
	
	public void ChangeState(State state)
	{
		this.state = state;
	}
	
	void ResetAnimations()
	{
		animator.SetBool("Stretching", false);
		animator.SetBool("Victory", false);
		animator.SetBool("Defeat", false);
		ChangeState(State.IDLE);
	}
	
	void Idle()
	{
		animator.SetFloat("Speed", 0);
		canMove = true;
	}
	void Running()
	{
		animator.SetFloat("Speed", 1);
		canMove = true;
	}
	void Jumping()
	{
		animator.SetTrigger("Jump");
		canMove = true;
	}
	void Stretch()
	{
		canMove = false;
		animator.SetBool("Stretching", true);
	}
	void Victory()
	{
		canMove = false;
		animator.SetBool("Victory", true);
		
	}
	void Defeat()
	{
		canMove = false;
		animator.SetBool("Defeat", true);
		
	}
}
