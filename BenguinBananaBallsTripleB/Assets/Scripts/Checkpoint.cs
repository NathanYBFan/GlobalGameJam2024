using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	[SerializeField]
	[Foldout("Dependencies"), Tooltip("")]
	private Material disableMat, enableMat;
	[SerializeField]
	[Foldout("Dependencies"), Tooltip("")]
	private MeshRenderer mesh;

	private void Start()
	{
		CheckpointManager._Instance.checkpointGoals.Add(gameObject);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			mesh.material = enableMat;
			PlayerBody body = other.GetComponent<PlayerBody>();
			if (body != null )
			{
				body.LastCheckpoint = this.transform.parent.position;
			}
		}
	}
	public void OnReset()
	{
		mesh.material = disableMat;
	}
}
