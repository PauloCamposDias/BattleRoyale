using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Killzone : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		other.TryGetComponent(out CharacterStats cs);
		if(cs != null)
		{
			cs.ResetCharacter();
		}
	}
}
