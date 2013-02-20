using UnityEngine;
using System.Collections;

public class InfoWindow{
	
	
	public static bool Draw(string message)
	{
		GUI.Label(new Rect(Screen.width/2-100,Screen.height/5*2,300,100),message);
		if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/5*3,100,25),"Ok"))
		return true;
		return false;
	}
	
	public static void DrawNoButton(string message)
	{
		GUI.Label(new Rect(Screen.width/2-100,Screen.height/5*2,300,100),message);
	}
}
