using UnityEngine;
using System.Collections;

public class Fps : MonoBehaviour
{
	float timer;
	public TextMesh fpsText;
	int frameCount = 0;
	int fps=0;
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		frameCount++;
		if (timer <= Time.realtimeSinceStartup) {
			timer = Time.realtimeSinceStartup + 1;
			fps=frameCount;
			fpsText.text=fps.ToString();
			frameCount = 0;
		}
	}
}