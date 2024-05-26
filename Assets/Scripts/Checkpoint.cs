using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	int checkpointId;
	
	void Start()
	{
		checkpointId = LevelManager.instance.SetCheckpoint(transform);
	}
	
	void OnTriggerEnter(Collider other)
	{
		other.TryGetComponent(out CharacterStats cs);
		if(cs != null)
		{
			cs.SetCheckpoint(checkpointId);
		}
	}
}
