using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
	//Á‚·‚Ü‚Å‚ÌŠÔ
	public float time;

	private void Start()
	{
		Destroy(gameObject,time);
	}
}
