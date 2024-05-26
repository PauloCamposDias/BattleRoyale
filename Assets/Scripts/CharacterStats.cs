using UnityEngine;

public class CharacterStats : MonoBehaviour
{
	public int currentCheckpointId = 0;
	
	public void SetCheckpoint(int checkpointId)
	{
		currentCheckpointId = checkpointId;
	}
	
	public void ResetCharacter()
	{
		try
		{
			Transform checkpoint = LevelManager.instance.GetCheckpoint(currentCheckpointId);
			transform.position = checkpoint.position;
			TryGetComponent(out Rigidbody rb);
			if(rb != null)
			{
				rb.velocity = Vector3.zero;
			}
		}
		catch (System.Exception) //No checkpoints
		{
			Kill();
		}
	}
	
	void Kill()
	{
		Debug.Log("ded");
	}
}
