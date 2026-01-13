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

    Vector3 velocity;
	void Update()
	{
		Vector3 targetPos = Input.mousePosition;
        if(uiCamera = null)
        {
			// ScreenSpace-Camera ‚Ìê‡ARectTransform‚Ìposition‚É“n‚·‘O‚É•ÏŠ·
			// RectTransform.position expects world pos when canvas is ScreenSpace-Camera
			RectTransformUtility.ScreenPointToWorldPointInRectangle(
				crosshairRect, targetPos, uiCamera, out Vector3 worldPos);
			if (smoothSpeed > 0f)
				crosshairRect.position = Vector3.SmoothDamp(crosshairRect.position, worldPos, ref velocity, smoothSpeed);
			else
				crosshairRect.position = worldPos;
		}
		else
		{
			// Overlay: RectTransform.position = screen pos (in pixels)
			Vector3 pos = targetPos;
			if (clampToScreen)
			{
				float w = Screen.width, h = Screen.height;
				pos.x = Mathf.Clamp(pos.x, margin.x, w - margin.x);
				pos.y = Mathf.Clamp(pos.y, margin.y, h - margin.y);
			}
			if (smoothSpeed > 0f)
				crosshairRect.position = Vector3.SmoothDamp(crosshairRect.position, pos, ref velocity, smoothSpeed);
			else
				crosshairRect.position = pos;
		}

	}
}
