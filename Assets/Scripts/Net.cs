using UnityEngine;
using MikeSchweitzer.WebSocket;
using System;
using System.Collections.Generic;
using System.Reflection;

[Serializable]
struct Packet
{
	public string cmd;
	public object body;
};

public class Net : MonoBehaviour
{
	public delegate void Event();
	public delegate void HandlerX<T>(T args);
	private Event connected_cb = null;
	private Event closed_cb = null;
	private Dictionary<string, Action<object>> router = new Dictionary<string, Action<object>>();
	public WebSocketConnection conn;
	public string url = "ws://127.0.0.1:10001";
	public void Awake()
	{
		conn = GetComponent<WebSocketConnection>();
		conn.Connect(url);
		conn.StateChanged += this.onStateChanged;
		conn.ErrorMessageReceived += this.onErrorMessageReceived;
		conn.MessageReceived += this.OnMessageReceived;
	}

	public void OnDestroy()
	{
		conn.StateChanged -= this.onStateChanged;
		conn.ErrorMessageReceived -= this.onErrorMessageReceived;
		conn.MessageReceived -= this.OnMessageReceived;
	}

	public void HookConnected(Event fn) {
		connected_cb = fn;
	}

	public void HookClosed(Event fn) {
		closed_cb = fn;
	}

	public void Connect()
	{

	}

	public void Close() 
	{

	}

	public void Reg<T>(Action<T> fn) 
	{
		void xfn(object obj)
		{
			var x = (T)obj;
			fn(x);
		}
		string cmd = typeof(T).Name;
		router[cmd] = xfn;
	}

	public void SendObj(System.Object msg)
	{
		// 获取实际的类型名作为命令名
		Type msgType = msg.GetType();
		string cmd = msgType.Name; // 获取类名作为cmd
		string body = JsonUtility.ToJson(msg);
		string str = string.Format("{{ \"cmd\": \"{0}\", \"body\": {1} }}", cmd, body);
		Debug.Log("XXX" + str);
		/*
		conn.AddOutgoingMessage("hello");
		*/
	}

	private void onStateChanged(WebSocketConnection connection, WebSocketState oldState, WebSocketState newState)
	{
		switch (newState) {
		case WebSocketState.Disconnected:
			if (this.closed_cb != null)
				this.closed_cb();
			break;
		case WebSocketState.Connected:
			if (this.connected_cb != null) {
				this.connected_cb();
			}
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
	}
}
