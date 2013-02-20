using UnityEngine;
using System.Collections;

public class Client : MonoBehaviour
{
	float checkRate=5;
	float timer;
	public static string login="";
	public static string password="";
	public static string IPAddress="127.0.0.1:25565";
	public static Users onlineUsers = new Users();
	string loginCode;
	int status;
	
	IEnumerator SendRequest (string request)
	{
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
			if(LoginOKWindow.Draw())
			{
				status = Constants.logining;
				StartCoroutine (SendRequest (PushString.SetTag ("logout") + PushString.SetValue ("loginCode", loginCode)));
				loginCode = null;
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
}
