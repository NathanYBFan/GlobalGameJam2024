using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
	[Foldout("Dependencies"), Tooltip("Owner of this hurtbox (if exists).")]
	[SerializeField]
	private GameObject owner;

	[Foldout("Parameters"), Tooltip("")]
	[SerializeField]
	private int damage = 1;

	private void OnTriggerEnter(Collider other)
	{
		if (owner != null)
		{
			if (other.gameObject != owner)
			{
				Damage damageComponent = other.GetComponent<Damage>();
				if (damageComponent != null)
				{
					damageComponent.TakeDamage(damage);
				}
			}
		}
		else
		{
			Damage damageComponent = other.GetComponent<Damage>();
			if (damageComponent != null)
			{
				damageComponent.TakeDamage(damage);
			}

		}
	}
}
