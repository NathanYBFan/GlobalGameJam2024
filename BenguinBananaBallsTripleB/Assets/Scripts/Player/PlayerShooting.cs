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
	[SerializeField]
	private Animator anim;

	bool isFiring = false;
	float nextFireTime = 0f;
	float fireRate = 4;

	// Update is called once per frame
	void Update()
	{
		isFiring = Input.GetButton("Fire1");

		if (!isFiring) return;
		if (Time.time < nextFireTime) return;
	
		anim.SetTrigger("IsShooting");
		GameObject firedBullet = Instantiate(bulletPrefab, fireLocation.transform.position, Quaternion.identity);
		firedBullet.GetComponentInChildren<Bullet>().FiredBullet(playerBody.transform);
		nextFireTime = Time.time + 1f / fireRate;
	}
}
