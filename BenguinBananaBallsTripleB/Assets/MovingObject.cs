using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField]
    private Transform stopMovingPoint;
    [SerializeField]
    private float distanceUntilMove = 5;
    [SerializeField]
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(GameManager._Instance.PlayerRootObject.transform.GetChild(0).position.x - transform.position.x) <= distanceUntilMove && transform.position.x < stopMovingPoint.position.x )
        {
			Vector3 velocity = rb.velocity;
			rb.velocity = (transform.right * GameManager._Instance.PlayerRootObject.GetComponent<PlayerController>().MovementDirection.x).normalized * GameManager._Instance.PlayerRootObject.GetComponentInChildren<PlayerBody>().MoveSpeed;
			rb.velocity = new Vector3(rb.velocity.x, velocity.y, 0);

		}
        else { rb.velocity = Vector3.zero; }
    }
}
