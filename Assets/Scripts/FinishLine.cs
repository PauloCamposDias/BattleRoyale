using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		other.TryGetComponent(out CharacterStats cs);
		if(cs != null)
		{
			other.TryGetComponent(out PlayerMovement pm);
            if(pm != null) 
            {
                Debug.Log("oieeee");
            }
            
		}
	}
}
