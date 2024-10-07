using System;
using UnityEngine;

namespace Model {

public class Player {
	public string Name = "";
	public ulong UID = 0;
	Vector3 pos = Vector3.zero;
	Vector3 syncPos = Vector3.zero;
	public Vector3 Pos {
		get { return pos; }
		set {
			pos = value;
			if (Vector3.Distance(syncPos, pos) > 1) {
				syncPos = pos;
				proto.move_r req = new proto.move_r {
					x = (long)pos.x,
					z = (long)pos.z,
				};
				Net.Inst.Send(req);
			}
		}
	}

	public Action onLoginSuccess;
	public Player() {
		Net.Inst.Reg<proto.login_a>(OnLoginAck);
		Net.Inst.Reg<proto.create_a>(OnCreateAck);
	}

	public void Login() {
		proto.login_r req = new proto.login_r();
		req.server_id = Inst.Login.SelectedServer.id;
		if (req.server_id == 0) {
			Debug.LogError("No Server Selected");
			return;
		}
		Net.Inst.Send(req);
	}
	public void OnLoginAck(proto.login_a ack) {
		Debug.Log("LoginAck:" + ack.code);
		if (ack.code != 0) {
			proto.create_r req = new proto.create_r {
				server_id = Inst.Login.SelectedServer.id,
				name = "路人甲",
			};
			Net.Inst.Send(req);
			return;
		}
		UID = ack.uid;
		Name = ack.name;
		pos = new Vector3(ack.x, 0, ack.z);
		syncPos = pos;
		onLoginSuccess();
	}

	public void OnCreateAck(proto.create_a ack) {
		Debug.Log("CreateAck:" + ack.code);
		if (ack.code != 0) {
			Debug.LogError("Create Failed");
			return;
		}
		UID = ack.uid;
		Name = ack.name;
		onLoginSuccess();
	}

}

}
