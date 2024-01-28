using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Vector3 movementDirection; //A directional vector that maps WASD input to a Vector3 model.
	public Vector3 MovementDirection { get { return movementDirection; } }
	private bool hasJumped = false;
	public bool HasJumped { get { return hasJumped; } }
	public Animator anim;

	void Update()
	{
		CheckMovementVector();
	}
	/// <summary>
	/// Helper method that checks movement inputs.
	/// </summary>
	private void CheckMovementVector()
	{
		movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        if (Input.GetButtonDown("Jump")) hasJumped = true;
		else hasJumped = false;
	}
}
