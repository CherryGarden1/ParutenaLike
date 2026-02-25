using UnityEngine;

public class AimAndShot : MonoBehaviour
{
	[Header("References")]
	public Transform shipTransform;
	public GameObject bulletPrefab;
	public GameObject bulustPrefab;
	public Transform firePoint;
	public Camera mainCamera;

	[SerializeField] private PlayerCore core;

	[Header("Settings")]
	public float turnSpeed = 2f;
	public float bulletSpeed = 100f;

	void Start()
	{
		if (mainCamera == null)
			mainCamera = Camera.main;
	}

	void Awake()
	{
		if (core == null)
			core = GetComponentInParent<PlayerCore>();
	}

	void Update()
	{
		if (core == null || core.isTransforming) return;

		Vector3 target = GetCurrentTargetPosition();

		RotateToTarget(target);

		if (Input.GetMouseButtonDown(0))
		{
			ShootNormal();
		}
	}

	// ==============================
	// ▼ 外部から呼ぶのはこれだけ
	// ==============================

	public void ShootAtEx()
	{
		SpawnBullet(bulustPrefab);
	}

	// ==============================
	// ▼ 通常射撃
	// ==============================

	void ShootNormal()
	{
		SpawnBullet(bulletPrefab);
	}

	// ==============================
	// ▼ 弾生成共通処理
	// ==============================

	void SpawnBullet(GameObject prefab)
	{
		if (prefab == null) return;

		Vector3 target = GetCurrentTargetPosition();

		Transform parent = WorldScrollManager.Instance != null
			? WorldScrollManager.Instance.transform
			: null;

		GameObject b = Instantiate(prefab, firePoint.position, firePoint.rotation, parent);

		Rigidbody rb = b.GetComponent<Rigidbody>();
		if (rb != null)
		{
			rb.useGravity = false;

			Vector3 velocityDir = (target - firePoint.position).normalized;
			rb.linearVelocity = velocityDir * bulletSpeed;
		}
	}

	// ==============================
	// ▼ 照準計算
	// ==============================

	Vector3 GetCurrentTargetPosition()
	{
		if (mainCamera == null || core.CrossHair == null)
			return firePoint.position + firePoint.forward * 1000f;

		Vector3 screenPos = core.CrossHair.ScreenPosition;
		Ray ray = mainCamera.ScreenPointToRay(screenPos);

		if (Physics.Raycast(ray, out RaycastHit hit, 1000f))
			return hit.point;
		else
			return ray.origin + ray.direction * 1000f;
	}

	void RotateToTarget(Vector3 target)
	{
		Vector3 dir = (target - shipTransform.position).normalized;

		if (dir.sqrMagnitude > 0.001f)
		{
			Quaternion targetRot = Quaternion.LookRotation(dir);
			shipTransform.rotation =
				Quaternion.Slerp(shipTransform.rotation, targetRot, Time.deltaTime * turnSpeed);
		}
	}
}

