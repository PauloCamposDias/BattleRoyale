using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	enum LevelState {PREP, MATCH, END}
	public static LevelManager instance;
	LevelState state;
	
	[SerializeField] float prepTime;
	public Action OnMatchStart, OnMatchEnd;
	[SerializeField] float matchTime;
	
	public List<Transform> checkpoints;
	
	void Awake()
	{
		if(instance == null && instance != this) instance = this;
		else Destroy(gameObject);
	}
	
	public int SetCheckpoint(Transform checkpoint)
	{
		checkpoints.Add(checkpoint);
		return checkpoints.Count-1;
	}
	
	public Transform GetCheckpoint(int checkpointId)
	{
		if(checkpoints != null && checkpoints.Count > 0)
		{
			return checkpoints[checkpointId];
		}
		else throw new Exception("No Checkpoints");
	}
	
	void Update()
	{
		switch (state)
		{
			case LevelState.PREP: Prep(); break;
			case LevelState.MATCH: Match(); break;
			case LevelState.END: End(); break;
		}
	}
	
	void ChangeState(LevelState state)
	{
		this.state = state;
	}
	
	void Prep()
	{
		prepTime -= Time.deltaTime;
		if(prepTime <= 0)
		{
			ChangeState(LevelState.MATCH);
			OnMatchStart();
		}
	}
	void Match()
	{
		matchTime -= Time.deltaTime;
		if(matchTime <= 0)
		{
			ChangeState(LevelState.END);
			OnMatchEnd();	
		}
	}
	
	void End()
	{
		Debug.Log("Match Ended");
	}
}
