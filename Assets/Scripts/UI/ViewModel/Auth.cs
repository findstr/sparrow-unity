using FairyGUI;
using UnityEngine;

namespace UI {
namespace ViewModel {


public class Auth : Base {
	Model.Login model = null;
	View.Login.Auth view = null;
	
	public override GComponent View() {
		return view;
	}
	public override void OnClose()
	{
		model.onAuthAck -= OnAuthAck;
	}
	public Auth() {
		model = Model.Inst.Login;
		view = UI.View.Login.Auth.CreateInstance();
		view.m_user.m_input.text = model.AuthName;
		view.m_passwd.m_input.text = model.AuthPass;
		view.m_auth.onClick.Add(OnBtnAuth);
		
		model.onAuthAck += OnAuthAck;
	}
	void OnBtnAuth() {
		Model.Inst.Login.AuthName = view.m_user.m_input.text;
		Model.Inst.Login.AuthPass = view.m_passwd.m_input.text;
		Debug.Log("Click" + view.m_user.m_input.text + ":" + view.m_passwd.m_input.text);
		var req = new proto.auth_r {
			account = Model.Inst.Login.AuthName,
			password = Model.Inst.Login.AuthPass,
		};
		Net.Inst.SendObj(req);
	}
	void OnAuthAck() {
		Debug.Log("Login Ret:" + model.ErrorCode);
		if (model.ErrorCode == 0) {
			Stack.SingleTop<GameEnter>();
		} else {
			Debug.Log("Login Failed");
		}
	}

}


}
}
