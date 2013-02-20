using UnityEngine;
using System.Collections;

public class LoginWindow{
	
	
	
	public static bool Draw()
	{
		GUI.Label(new Rect(Screen.width/2-100,Screen.height/5,200,25),"Login:");
		Client.login=GUI.TextField(new Rect(Screen.width/2-100,Screen.height/5*1.3f,200,25),Client.login,10);
		GUI.Label(new Rect(Screen.width/2-100,Screen.height/5*1.7f,200,25),"Password:");
		Client.password=GUI.PasswordField(new Rect(Screen.width/2-100,Screen.height/5*2,200,25),Client.password,'*',10);
		if(Client.password.Length<1||Client.login.Length<1)
		GUI.enabled=false;
		if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/5*3,100,25),"Login"))
		{
			PlayerPrefs.SetString("login",Client.login);
			return true;
		}
		return false;
	}
}
