using UnityEngine;
using System.Collections;

public class LoginOKWindow{
	
	
	
	public static bool Draw()
	{
		GUI.Label(new Rect(Screen.width/2-100,Screen.height/6,200,25),"Online list:");
		for(int i=0; i < Client.onlineUsers.usersList.Count;i++)
		{
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/5+i*30,100,25),Client.onlineUsers.usersList[i].login))
			{
				
			}
		}
		//Client.IPAddress=GUI.TextField(new Rect(Screen.width/2-100,Screen.height/5*1.3f,200,25),Client.IPAddress,30);
		
		if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/5*3,100,25),"Logout"))
		return true;
		return false;
	}
}
