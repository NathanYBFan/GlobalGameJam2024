using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
	public static CheckpointManager _Instance;

	[SerializeField, ReadOnly, Tooltip("List of checkpoints the player can get to.")]
    public List<GameObject> checkpointGoals;

	private void Awake()
	{
		if (_Instance != null && _Instance != this)
			Destroy(this.gameObject);
		else if (_Instance == null)
			_Instance = this;
	}

}
