using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Module {
	public void Foo(proto.auth_a ack) {
		Debug.Log("XXX:" + ack);
	}
}

public class main : MonoBehaviour
{
	Net net;
	UI.Login.UI_Auth ui_auth = null;
	UI.Login.UI_GameEnter ui_enter = null;
	UI.Login.UI_ServerList ui_servers = null;
	private void Awake()
	{
		var m = new Module();
		net = GetComponent<Net>();
		net.HookConnected(this.onConnected);
		net.HookClosed(this.onClosed);
		net.Connect();
		net.Reg<proto.auth_a>(m.Foo);
		UIPackage.AddPackage("UI/Common");
		UIPackage.AddPackage("UI/Login");
		UI.Login.LoginBinder.BindAll();
		ui_auth = UI.Login.UI_Auth.CreateInstance();
		GRoot.inst.AddChild(ui_auth);
		ui_auth.onClick.Add(() => {
			ui_auth.Dispose();
			ui_auth = null;
			ui_enter = UI.Login.UI_GameEnter.CreateInstance();
			GRoot.inst.AddChild(ui_enter);
			ui_enter.m_selected.onClick.Add(()=>{
				ui_servers = UI.Login.UI_ServerList.CreateInstance();
				var server_entry = UI.Login.UI_ServerEntry.CreateInstance();
				server_entry.m_name.text = "1Çø ÅÌ¹Å¿ªÌì";
				server_entry.serverID = 3;
				ui_servers.m_list.AddChild(server_entry);
				GRoot.inst.ShowPopup(ui_servers);
				ui_servers.Center();
				ui_servers.m_list.onClickItem.Add((EventContext context) => {
					var server = context.data as UI.Login.UI_ServerEntry;
					Debug.Log("ServerID:" + server.serverID);
				});
			});
		});
	}

	private void onConnected()
	{
		Debug.Log("Connected");
	}

	private void onClosed() 
	{
		Debug.Log("Closed");
		net.Connect();
	}

}
