using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterAnimation))]
public class PlayerMovement : MonoBehaviour
{
	[Header("References")]
	[SerializeField] Transform orientation;
	[SerializeField] LayerMask whatIsGround;
	[SerializeField] float playerHeight;
	Rigidbody rb;
	CharacterAnimation cAnim;
	
	[Header("Movement")]
	[SerializeField] float moveSpeed;
	[SerializeField] float groundDrag;
	Vector3 moveDirection;
	bool isGrounded;
	
	[Header("Jump")]
	[SerializeField] float jumpForce;
	[SerializeField] float jumpCooldown;
	[SerializeField] float airMultiplier;
	bool canJump = true;
	
	[Header("Slope")]
	[SerializeField] float maxSlopeAngle;
	RaycastHit slopeHit;
		
	float horizontalInput;
	float verticalInput;
	
	
	
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		cAnim = GetComponent<CharacterAnimation>();
		GetComponent<CharacterColorManager>().SetColor(PlayerStatsManager.instance.GetPlayerColor());
	}
	
	void Update()
	{
		isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight *.5f + .2f, whatIsGround);
		
		if(!cAnim.canMove) return;
		
		GetInputs();
		SpeedControl();
		
		if(isGrounded)
		{
			rb.drag = groundDrag;
		}
		else
		{
			rb.drag = 0;
		}
		
	}
	
	void FixedUpdate()
	{
		if(!cAnim.canMove) return;
		MovePlayer();
	}
	
	void GetInputs()
	{
		horizontalInput = Input.GetAxisRaw("Horizontal");
		verticalInput = Input.GetAxisRaw("Vertical");
		
		if(Input.GetKey(KeyCode.Space) && canJump && (isGrounded || OnSlope()))
		{
			canJump = false;
			Jump();
			Invoke(nameof(ResetJump), jumpCooldown);
		}
	}
	
	void MovePlayer()
	{
		moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
		if(!canJump) cAnim.ChangeState(CharacterAnimation.State.JUMPING);
		else if(moveDirection == Vector3.zero) cAnim.ChangeState(CharacterAnimation.State.IDLE);
		else cAnim.ChangeState(CharacterAnimation.State.RUNNING);
		
		if(OnSlope())
		{
			rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 10f, ForceMode.Force);
		}
		
		else if(isGrounded)
		{
			rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
		}
		else
		{
			rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
		}
	}
	
	void SpeedControl()
	{
		if(rb.velocity.magnitude > moveSpeed)
		{
			Vector2 velocity = new Vector2(rb.velocity.x, rb.velocity.z);
			velocity = Vector2.ClampMagnitude(velocity, moveSpeed);
			rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.y);
		}
	}
	
	void Jump()
	{		
		rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
		rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
	}
	
	void ResetJump()
	{
		canJump = true;
	}
	
	bool OnSlope()
	{
		if(Physics.Raycast(transform.position,Vector3.down, out slopeHit, playerHeight * .5f + .3f))
		{
			float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
			return angle <= maxSlopeAngle && angle != 0;
		}
		
		return false;
	}
	
	private Vector3 GetSlopeMoveDirection()
	{
		return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
	}
}
