using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	[SerializeField]
	private GameObject fireLocation;
	[SerializeField]
	private GameObject playerBody;
	[SerializeField]
	private GameObject bulletPrefab;


	bool isFiring = false;
	float nextFireTime = 0f;
	float fireRate = 4;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButton("Fire1")) isFiring = true;
		else isFiring = false;

		if (isFiring)
		{
			if (Time.time >= nextFireTime)
			{
				GameObject firedBullet = Instantiate(bulletPrefab, fireLocation.transform.position, Quaternion.identity);
				firedBullet.GetComponent<Bullet>().FiredBullet(playerBody.transform);
				nextFireTime = Time.time + 1f / fireRate;
			}
		}

	}
}
