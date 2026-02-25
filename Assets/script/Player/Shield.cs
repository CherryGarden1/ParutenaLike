using UnityEngine;

public class Shield : MonoBehaviour
{
	[SerializeField] public GameObject ShirldMesh;
	[SerializeField] private float invincibleDration = 3f;

	private bool invincible = false;
	private float timer;
	private void Start()
	{
		ShirldMesh.SetActive(false);
	}
	private void Update()
	{
		//‚šƒL[‚Ån“®
		if(Input.GetKeyDown(KeyCode.Z) && !invincible)
		{
			invincible = true;
			timer = invincibleDration;
			ShirldMesh.SetActive(true);
		}
		//–³“G’†
		if (invincible)
		{
			//–³“GŠÔ
			timer -= Time.deltaTime;
			if(timer <= 0f)
			{
				invincible = false;
				ShirldMesh.SetActive(false);
			}

		}
	}
}
