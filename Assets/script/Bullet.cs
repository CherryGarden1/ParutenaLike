using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField]
	private float bulletSpeed;
	[SerializeField]
	private Rigidbody rb;
	[SerializeField]
	private int damage = 1;
	[SerializeField]
	GameObject FirePoint;
	void Start()
	{
		// ”­Ë•ûŒü‚Í¶¬‚³‚ê‚½‚Æ‚«‚Ì forward
		if (rb != null)
		{
		

			rb.linearVelocity = transform.forward * bulletSpeed; // Unity 6Œn
																 // rb.velocity = transform.forward * bulletSpeed;   // Unity 2023ˆÈ‘O
		}


		// 5•bŒã‚É©“®Á–Å
		Destroy(gameObject, 5f);
	}
	private void OnTriggerEnter(Collider other)
	{
		// “G‚ÆÕ“Ë‚µ‚½‚©Šm”F
		if (other.CompareTag("Enemy"))
		{
			// “G‚ÌHPˆ—‚ğŒÄ‚Ô
			EnemyBase enemy = other.GetComponent<EnemyBase>();
			if (enemy != null)
			{
				enemy.TakeDamage(damage);
			}

			// ’e‚ğíœ
			Destroy(gameObject);
		}
	}
}
