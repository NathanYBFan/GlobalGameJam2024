using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField, ReadOnly, Tooltip("List of checkpoints the player can get to.")]
    public GameObject[] checkpointGoals;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PopulateList()
    {
        checkpointGoals = null;
		checkpointGoals = GameObject.FindGameObjectsWithTag("Checkpoint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
