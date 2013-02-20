using UnityEngine;
using System.Collections;

public class OptionsWindow{
	
	
	
	public static bool Draw()
	{
		GUI.Label(new Rect(Screen.width/2-100,Screen.height/5,200,25),"IP-address:");
		Client.IPAddress=GUI.TextField(new Rect(Screen.width/2-100,Screen.height/5*1.3f,200,25),Client.IPAddress,30);
		if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/5*3,100,25),"Ok"))
		{
			PlayerPrefs.SetString("IPAddress",Client.IPAddress);
			return true;
		}
		return false;
	}
}
