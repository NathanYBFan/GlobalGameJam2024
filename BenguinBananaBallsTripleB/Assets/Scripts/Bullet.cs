using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField]
	float lifeTime = 5f;
	[SerializeField]
	float movementSpeed = 10f;
	[SerializeField]
	private int damage = 1;
	[SerializeField]
	private GameObject parent;
    // Start is called before the first frame update
    void Awake()
    {
		StartCoroutine(LifetimeClock());
	}
	private IEnumerator LifetimeClock()
	{
		yield return new WaitForSeconds(lifeTime);
		Destroy(transform.parent.gameObject);
		yield break;
	}
	// Update is called once per frame
	void Update()
    {
		parent.transform.position += transform.right * movementSpeed * Time.deltaTime;
	}
    public void FiredBullet(Transform playerRotation)
    {
		Vector3 bulletRot = parent.transform.rotation.eulerAngles;
		bulletRot.y = playerRotation.rotation.eulerAngles.y;
		parent.transform.rotation = Quaternion.Euler(bulletRot);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player")) return;
		
		if (other.CompareTag("UIInteractable"))
            other.GetComponent<ExpandUISingle>().ExpandUI();

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
