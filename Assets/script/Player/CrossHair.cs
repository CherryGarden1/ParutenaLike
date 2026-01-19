using UnityEngine;

public class CrossHair : MonoBehaviour
{
    [SerializeField]
    public RectTransform crosshairRect;
    [SerializeField] 
    public Camera uiCamera;
    [SerializeField]
    public bool clampToScreen= true;
    //—]”’
    [SerializeField]
    public Vector2 margin = new Vector2(5f, 5f);
    //’x‰„‚È‚µ‚Å’Ç]
    [SerializeField]
    public float smoothSpeed = 0f;
	//‰æ–Ê“à‚Å§ŒÀ


    Vector3 velocity;

	void Update()
	{
		Vector3 targetPos = Input.mousePosition;

		if (clampToScreen)
		{
			targetPos.x = Mathf.Clamp(
				targetPos.x,
				margin.x,
				Screen.width - margin.x
			);
			targetPos.y = Mathf.Clamp(
				targetPos.y,
				margin.y,
				Screen.height - margin.y
			);
		}

		if (smoothSpeed > 0f)
		{
			crosshairRect.position =
				Vector3.SmoothDamp(crosshairRect.position, targetPos, ref velocity, smoothSpeed);
		}
		else
		{
			crosshairRect.position = targetPos;
		}
	}
	public Vector3 ScreenPosition => crosshairRect.position;
}
