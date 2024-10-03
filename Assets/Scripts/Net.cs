using UnityEngine;
using MikeSchweitzer.WebSocket;
using System;
using System.Collections.Generic;

[Serializable]
struct Header {
	public string cmd;
};

[Serializable]
struct Packet<T>
{
	public string cmd;
	public T body;
};

public class Net : MonoBehaviour
{
	public static Net Inst = null;
	public delegate void Event();
	public delegate void HandlerX<T>(T args);
	private Event ConnectedCB = null;
	private Event CloseCB = null;
	private Dictionary<string, Action<string>> router = new Dictionary<string, Action<string>>();
	public WebSocketConnection conn;
	public string url = "ws://127.0.0.1:10001";
	public Net() {
		Inst = this;
	}
	public void Awake()
	{
		conn = GetComponent<WebSocketConnection>();
		conn.Connect(url);
		conn.StateChanged += onStateChanged;
		conn.ErrorMessageReceived += onErrorMessageReceived;
		conn.MessageReceived += OnMessageReceived;
	}

	public void OnDestroy()
	{
		conn.StateChanged -= onStateChanged;
		conn.ErrorMessageReceived -= onErrorMessageReceived;
		conn.MessageReceived -= OnMessageReceived;
	}

	public void HookConnected(Event fn) {
		ConnectedCB = fn;
	}

	public void HookClosed(Event fn) {
		CloseCB = fn;
	}

	public void Connect()
	{

	}

	public void Close() 
	{

	}

	public void Reg<T>(Action<T> fn) 
	{
		void xfn(string str)
		{
			var x = JsonUtility.FromJson<Packet<T>>(str);
			Debug.Log("XXX:" + x);
			Debug.Log("YYY:" + x.body.ToString());
			fn(x.body);
		}
		string cmd = typeof(T).Name;
		router[cmd] = xfn;
	}

	public void SendObj(object msg)
	{
		Type msgType = msg.GetType();
		string cmd = msgType.Name; 
		string body = JsonUtility.ToJson(msg);
		string str = string.Format("{{ \"cmd\": \"{0}\", \"body\": {1} }}", cmd, body);
		Debug.Log("XXX" + str);
		conn.AddOutgoingMessage(str);
	}

	private void onStateChanged(WebSocketConnection connection, WebSocketState oldState, WebSocketState newState)
	{
		switch (newState) {
		case WebSocketState.Disconnected:
			CloseCB?.Invoke();
			break;
		case WebSocketState.Connected:
			ConnectedCB?.Invoke();
			break;
		}
		Debug.Log($"OnStateChanged oldState={oldState}|newState={newState}");
	}

	private void onErrorMessageReceived(WebSocketConnection connection, string errorMessage)
	{
		Debug.LogError(errorMessage);
	}
	private void OnMessageReceived(WebSocketConnection connection, WebSocketMessage message)
	{
		Debug.Log(message.String);
		var header = JsonUtility.FromJson<Header>(message.String);
		var fn = router[header.cmd];
		if (fn == null) {
			Debug.LogError("No handler for cmd:" + header.cmd);
			return;
		}
		fn(message.String);
	}
}
