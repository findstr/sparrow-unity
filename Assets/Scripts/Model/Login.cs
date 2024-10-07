using System;
using System.Collections.Generic;
using UnityEngine;

namespace Model {

class Login {
	const string NameKey = "authName";
	const string PassKey = "authPasswd";

	public string _authName = "";
	public string _authPass = "";

	public List<proto.server> ServerList = new List<proto.server>();
	public proto.server _selectedServer;
	public proto.server SelectedServer { 
		get{ return _selectedServer; } 
		set {
			_selectedServer = value;
			OnServerSelected();
		}
	}

	public uint ErrorCode = 0;

	public event Action onAuthAck;
	public event Action OnServerSelected;

	public Login() {
		_authName = PlayerPrefs.GetString(NameKey, "");
		_authPass = PlayerPrefs.GetString(PassKey, "");
		Debug.Log("AuthName: " + _authName);
		//注册协议
		Net.Inst.Reg<proto.auth_a>(auth_a);
		Net.Inst.Reg<proto.servers_a>(servers_a);
	}

	public void auth_a(proto.auth_a ack) {
		Debug.Log("XXXXXXXXXXX");
		ErrorCode = ack.code;
		onAuthAck();
	}

	public void servers_a(proto.servers_a ack) {
		ServerList.Clear();
		ServerList.AddRange(ack.list);
		Debug.Log("Servers_a:" + ServerList.Count);
		if (ServerList.Count > 0) {
			SelectedServer = ServerList[0];
		}
	}

	public string AuthName {
		get { return _authName; }
		set {
			_authName = value;
			PlayerPrefs.SetString(NameKey, value);
		}
	}
	public string AuthPass {
		get { return _authPass; }
		set {
			_authPass = value;
			PlayerPrefs.SetString(PassKey, value);
		}
	}
}

}
