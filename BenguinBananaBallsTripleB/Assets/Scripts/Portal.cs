using NaughtyAttributes;
using UnityEngine;

public class Portal : MonoBehaviour
{
	[Foldout("Dependencies"), Tooltip("")]
	[SerializeField]
	private GameObject startGoal;

	[Foldout("Dependencies"), Tooltip("")]
	[SerializeField]
	private GameObject endGoal;


	[Foldout("Dependencies"), Tooltip("")]
	[SerializeField]
	private GameObject player;

	
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player")) GameManager._Instance.PlayerRootObject.transform.position = endGoal.transform.position;
	}
}
