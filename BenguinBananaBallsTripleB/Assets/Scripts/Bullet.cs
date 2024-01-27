using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField]
	float lifeTime = 5f;
	[SerializeField]
	float movementSpeed = 10f;
    // Start is called before the first frame update
    void Awake()
    {
		StartCoroutine(LifetimeClock());
	}
	private IEnumerator LifetimeClock()
	{
		yield return new WaitForSeconds(lifeTime);
		Destroy(gameObject);
		yield break;
	}
	// Update is called once per frame
	void Update()
    {
		transform.position += transform.right * movementSpeed * Time.deltaTime;
	}
    public void FiredBullet(Transform playerRotation)
    {
		Vector3 bulletRot = transform.rotation.eulerAngles;
		bulletRot.y = playerRotation.rotation.eulerAngles.y;
		transform.rotation = Quaternion.Euler(bulletRot);
	}
}
