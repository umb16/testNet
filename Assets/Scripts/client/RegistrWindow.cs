using UnityEngine;
using System.Collections;

public class RegistrWindow{
		
	static string repeatPassword="";
	public static bool Draw()
	{
		GUI.Label(new Rect(Screen.width/2-100,Screen.height/5,200,25),"Login:");
		Client.login=GUI.TextField(new Rect(Screen.width/2-100,Screen.height/5*1.3f,200,25),Client.login,10);
		GUI.Label(new Rect(Screen.width/2-100,Screen.height/5*1.7f,200,25),"Password:");
		Client.password=GUI.PasswordField(new Rect(Screen.width/2-100,Screen.height/5*2,200,25),Client.password,'*',10);
		GUI.Label(new Rect(Screen.width/2-100,Screen.height/5*2.3f,200,25),"Repeat password:");
		repeatPassword=GUI.PasswordField(new Rect(Screen.width/2-100,Screen.height/5*2.5f,200,25),repeatPassword,'*',10);
		if(GUI.Button(new Rect(Screen.width/2,Screen.height/5*3,100,25),"Cancel"))
		{
			Client.status = Constants.zero;
		}
		if(Client.password.Length<1||Client.login.Length<1||Client.password!=repeatPassword)
		GUI.enabled=false;
		if(GUI.Button(new Rect(Screen.width/2-100,Screen.height/5*3,100,25),"Registr"))
		return true;
		
		return false;
	}
}
