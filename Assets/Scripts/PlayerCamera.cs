using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	public Transform orientation;
	public Transform Player;
	public Transform Mesh;
	public Rigidbody rb;
	public float rotationSpeed;
	
	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	void Update()
	{
		Vector3 viewDirection = Player.position - new Vector3(transform.position.x, Player.position.y, transform.position.z);
		orientation.forward = viewDirection.normalized;
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");
		Vector3 inputDirection = horizontalInput * orientation.right + orientation.forward * verticalInput;
		
		//RotateMesh
		if(inputDirection != Vector3.zero)
		{
			Mesh.forward = Vector3.Slerp(Mesh.forward, inputDirection.normalized, Time.deltaTime * rotationSpeed);
		}
	}
}
