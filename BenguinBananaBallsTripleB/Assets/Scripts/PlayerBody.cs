using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
	[SerializeField]
	private GameObject body;
	private PlayerController controller;
	[Header("Parameters")]
	[SerializeField]
	private int jumpHeight = 100;
	[SerializeField]
	private int moveSpeed = 20;

	private Rigidbody rb;
	private bool isGrounded = true, isJumping = false, hasJumped = false, isDying = false, canMove = true, flip = false;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		controller = GameObject.Find("PlayerController").GetComponent<PlayerController>();
		Debug.Assert(controller != null, "No controller on " + gameObject.name);
	}
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		UpdateRotations();
		if (controller.HasJumped && isGrounded) PerformJump();

	}
	private void FixedUpdate()
	{
		if (canMove)
		{
			Vector3 velocity = rb.velocity;
			rb.velocity = (transform.right * controller.MovementDirection.x).normalized * moveSpeed;
			rb.velocity = new Vector3(rb.velocity.x, velocity.y, 0);


			RaycastHit hit;
			Debug.DrawRay(transform.position + Vector3.up * 0.1f, Vector3.down * 0.2f);
			if (Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, out hit, 1f) && !isJumping)
			{
				isGrounded = true;
				if (hasJumped)
				{
					hasJumped = false;
				}
			}
			else isGrounded = false;
		}

	}
	/// <summary>
	/// This method makes the player jump (called in animationevent).
	/// </summary>
	private void PerformJump()
	{
		isJumping = true;
		rb.AddForce(Vector3.up * jumpHeight * rb.mass, ForceMode.Impulse);
		Invoke("ResetJump", 0.45f);
	}
	/// <summary>
	/// This method reset the jump bools.
	/// </summary>
	private void ResetJump()
	{
		hasJumped = true;
		isJumping = false;
	}
	/// <summary>
	/// Method that updates the player's rotation (which direction they face).
	/// </summary>
	private void UpdateRotations()
	{

		if (controller.MovementDirection.x > 0 && canMove) flip = false;
		else if (controller.MovementDirection.x < 0 && canMove) flip = true;

		if (flip) body.transform.rotation = Quaternion.Euler(0, 180, 0);
		else body.transform.rotation = Quaternion.Euler(0, 0, 0);

	}
}
