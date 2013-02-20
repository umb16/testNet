using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour
{
	public Camera interfaceCamera;
	public static MouseOrbit thisClass;
	public static string downObjName;
	public static string upObjName;
	public static string onceDownObjName;
	public static GameObject downObj;
	public static GameObject upObj;
	public static GameObject onceDownObj;
	public static string trueUpObjName;
	public static GameObject trueUpObj;
	bool once = true;
	public static bool rayShooting = true;
	public static short timerState = 1;
	public static Transform cameraTransform;
	public static bool isMouseMoved = false;
	public static bool isMouseMoved2 = false;
	public static bool isMouseButtonDown = false;
	public static bool isMouseButtonUp = false;
	public static Vector2 worldMousePosition;
	public static float startMousePositionX = 0.0f;
	public static float startMousePositionY = 0.0f;
	public static float curentMousePositionX = 0.0f;
	public static float curentMousePositionY = 0.0f;
	public static float deltaClickMousePositionX = 0.0f;
	public static float deltaClickMousePositionY = 0.0f;
	public static float deltaFrameMousePositionX = 0.0f;
	public static float deltaFrameMousePositionY = 0.0f;

	void Awake ()
	{
		thisClass = this;
		cameraTransform = this.transform;
	}

	void Start ()
	{		
	}
	
	void Update ()
	{
		isMouseButtonUp = false;
		if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXWebPlayer || Application.platform == RuntimePlatform.WindowsWebPlayer) {
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				isMouseButtonDown = true;
				isMouseButtonUp = false;
				startMousePositionX = Input.mousePosition.x;
				startMousePositionY = Input.mousePosition.y;
			} else if (Input.GetKeyUp (KeyCode.Mouse0)) {
				isMouseButtonDown = false;
				isMouseButtonUp = true;
				isMouseMoved = false;
			}
			curentMousePositionX = Input.mousePosition.x;
			curentMousePositionY = Input.mousePosition.y;
			
		} else if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android) {
			if (Input.touchCount > 0) {
				if (Input.GetTouch (0).phase == TouchPhase.Began) {
					isMouseButtonDown = true;
					isMouseButtonUp = false;
					startMousePositionX = Input.GetTouch (0).position.x;
					startMousePositionY = Input.GetTouch (0).position.y;
				}
				if (Input.GetTouch (0).phase == TouchPhase.Ended) {
					isMouseButtonDown = false;
					isMouseButtonUp = true;
					isMouseMoved = false;
				} else if (isMouseMoved || isMouseButtonDown) {
					curentMousePositionX = Input.GetTouch (0).position.x;
					curentMousePositionY = Input.GetTouch (0).position.y;
				}
			}
		}
		if (isMouseButtonUp) {
			deltaClickMousePositionX = 0.0f;
			deltaClickMousePositionY = 0.0f;
			deltaFrameMousePositionX = 0.0f;
			deltaFrameMousePositionY = 0.0f;
		}
		if (isMouseButtonDown) {
			if (startMousePositionX != curentMousePositionX && isMouseMoved == false || startMousePositionY != curentMousePositionY && isMouseMoved == false) {
				isMouseMoved = true;
				deltaClickMousePositionX = 0.0f;
				deltaClickMousePositionY = 0.0f;
				deltaFrameMousePositionX = 0.0f;
				deltaFrameMousePositionY = 0.0f;
			}
		}
		if (isMouseMoved) {
			deltaFrameMousePositionX = (curentMousePositionX - startMousePositionX - deltaClickMousePositionX);
			deltaFrameMousePositionY = (curentMousePositionY - startMousePositionY - deltaClickMousePositionY);
			
			deltaClickMousePositionX = (curentMousePositionX - startMousePositionX);
			deltaClickMousePositionY = (curentMousePositionY - startMousePositionY);
		}
		
		worldMousePosition = Camera.main.ScreenToWorldPoint (new Vector3 (curentMousePositionX, curentMousePositionY, 0));
			
		if (isMouseButtonDown && rayShooting) {
			upObj = null;
			upObjName = "null";
			trueUpObjName = "null";
			trueUpObj = null;
			RaycastHit hit;
			Ray ray = interfaceCamera.ScreenPointToRay (new Vector3 (curentMousePositionX, curentMousePositionY, -10f));
			Physics.Raycast (ray, out hit, 1000);
			if (hit.transform) {
				downObj = hit.transform.gameObject;
				downObjName = downObj.name;
			} else {
				downObjName = "null";
				downObj = null;
			}
			if (once) {
				if (hit.transform)
					onceDownObj = hit.transform.gameObject;
				else
					onceDownObj = null;
				onceDownObjName = downObjName;
			}
			once = false;
		} else {
			downObj = null;
		}
		if (once)
			trueUpObjName = "null";
			trueUpObj = null;
		if (isMouseButtonUp && rayShooting) {
			RaycastHit hit;
			Ray ray = interfaceCamera.ScreenPointToRay (new Vector3 (curentMousePositionX, curentMousePositionY, -10f));
			Physics.Raycast (ray, out hit, 1000);
			if (hit.transform) {
				upObj = hit.transform.gameObject;
				upObjName = upObj.name;
				if (upObjName == onceDownObjName) {
					onceDownObjName = "null";
					trueUpObjName = upObjName;
					trueUpObj = hit.transform.gameObject;
				}
			} else {
				upObj = null;
				upObjName = "null";
			}
			once = true;
		} else {
		}
	}
}