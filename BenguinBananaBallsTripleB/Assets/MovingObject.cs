using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField]
    private Transform stopMovingPoint;
    [SerializeField]
    private Vector3 positionToBeAt;
    [SerializeField]
    private float distanceUntilMove = 5;
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float moveSpeed = 25f;

    // Update is called once per frame
    void Update()
	{
		transform.position = Vector3.Lerp(transform.position, positionToBeAt, Time.deltaTime * moveSpeed);
        if (GameManager._Instance.PlayerRootObject.transform.position.x - transform.position.x <= distanceUntilMove)
        {
			if (positionToBeAt.x < stopMovingPoint.position.x)
            {
				positionToBeAt.x = GameManager._Instance.PlayerRootObject.transform.position.x + 5;
			}       
		}
    }
}
