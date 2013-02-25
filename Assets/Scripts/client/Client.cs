using UnityEngine;
using System.Collections;

public class Client : MonoBehaviour
{
	float checkRate=4;
	float timer;
	public static string login="";
	public static string password="";
	public static string IPAddress="127.0.0.1:25565";
	public static Users onlineUsers = new Users();
	string loginCode;
	public static int status;
	
	IEnumerator SendRequest (string request)
	{
		timer=0;
		print(request);
		WWW www = new WWW (string.Format("http://{0}/",IPAddress) + request);
		yield return www;
		Receiver (www.text);
	}

	void Receiver (string response)
	{
		string tempString;
		Debug.Log (response);
		
		status = PushString.GetInt ("status", response);
		if (status == 0)
			return;
		if((tempString=PushString.GetString ("onlineList", response))!=null)
		{
			onlineUsers = (Users) Serialize.Deserialization(onlineUsers, tempString);
		}
		if (response.Contains ("[loginCode:")) {
			loginCode = PushString.GetString ("loginCode", response);
		}
		
	}
	
	void Start ()
	{
		login = PlayerPrefs.GetString("login");
		IPAddress = PlayerPrefs.GetString("IPAddress","127.0.0.1:25565");
		//StartCoroutine(SendRequest(PushString.SetTag("login")+ PushString.SetValue("login","Mark")+PushString.SetValue("password","123321")));
	}
	
	void OnGUI ()
	{
		GUI.enabled = true;
		if (status == 0) {
			loginCode = null;
			if (GUI.Button (new Rect (10, 10, 100, 25), "Options")) {
				status = Constants.optionsMenu;
			}
			if (GUI.Button (new Rect (Screen.width-110, 10, 100, 25), "Registr")) {
				status = Constants.registrMenu;
			}
			if (LoginWindow.Draw ()) {
				status = Constants.logining;
				StartCoroutine (SendRequest (PushString.SetTag ("login") + PushString.SetValue ("login", login) + PushString.SetValue ("password", password)));
			
				}
		}
		
		if (status == Constants.doubleLogining) {
			if (InfoWindow.Draw ("Double logining")) {
				status = 0;
			}
		}
		
		if (status == Constants.loginNotFound || status == Constants.incorrectPassword) {
			if (InfoWindow.Draw ("Login not found or incorrect password")) {
				status = 0;
			}
		}
		
		if (status == Constants.logining) {
			InfoWindow.DrawNoButton ("Logining...");
		}
		
		if(status == Constants.optionsMenu)
		{
			if(OptionsWindow.Draw())
			{
				status = 0;
			}
		}
		
		if (status == Constants.registrMenu) {
			if (RegistrWindow.Draw ()) {
				status = Constants.logining;
				StartCoroutine (SendRequest (PushString.SetTag ("registr") + PushString.SetValue ("login", login) + PushString.SetValue ("password", password)));
			}
		}
		
		if(status == Constants.accountCreateSuccess)
		{
			if (InfoWindow.Draw ("Account created"))
			{
				status = 0;
			}
		}
		
		if(status == Constants.loginOccupied)
		{
			if (InfoWindow.Draw ("Login occupied"))
			{
				status = 0;
			}
		}
		
		if (status == Constants.loginOk) {
			if(loginOkWindow())
			{
				status = Constants.logining;
				StartCoroutine (SendRequest (PushString.SetTag ("logout") + PushString.SetValue ("loginCode", loginCode)));
				loginCode = null;
			}
		}
		
		if (status == Constants.waitInviteResponse) {
			InfoWindow.DrawNoButton ("Wait invite responce");
		}
		if (status == Constants.receivedInvite) {
			switch (InfoWindow.Draw2Button ("Invite you to play")) {
			case 1: status = Constants.logining;
			break;
			case 2: status = Constants.logining;
			StartCoroutine (SendRequest (PushString.SetTag ("inviteAbort") + PushString.SetValue ("loginCode", loginCode)));	
			break;
			default:
			break;
			}
		}
	}
	
	void Update ()
	{
		if(!string.IsNullOrEmpty(loginCode))
		{
			timer+=Time.deltaTime;
			if(timer>=checkRate)
			{
				timer=0;
				StartCoroutine (SendRequest (PushString.SetTag ("check") + PushString.SetValue ("loginCode", loginCode)));
			}
		}
	}
	bool loginOkWindow()
	{
		GUI.Label(new Rect(Screen.width/2-100,Screen.height/6,200,25),"Online list:");
		for(int i=0; i < Client.onlineUsers.usersList.Count;i++)
		{
			if(Client.onlineUsers.usersList[i].login!=Client.login)
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/5+i*30,100,25),Client.onlineUsers.usersList[i].login))
			{
				StartCoroutine (SendRequest (PushString.SetTag ("invite")+ PushString.SetValue ("login", Client.onlineUsers.usersList[i].login) + PushString.SetValue ("loginCode", loginCode)));
				status = Constants.logining;
			}
		}
		//Client.IPAddress=GUI.TextField(new Rect(Screen.width/2-100,Screen.height/5*1.3f,200,25),Client.IPAddress,30);
		
		if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/5*3,100,25),"Logout"))
		return true;
		return false;
	}
}
