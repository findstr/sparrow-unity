using FairyGUI;
using UnityEngine;

namespace UI {
namespace ViewModel {
public class GameEnter: Base {
        readonly Model.Login model = null;
       readonly View.Login.GameEnter view = null;
	
	public override GComponent View() {
		return view;
	}
	public override void OnClose()
	{
		model.OnServerSelected -= OnServerSelected;
	}
	public GameEnter() {
		model = Model.Inst.Login;
		view = UI.View.Login.GameEnter.CreateInstance();
		view.m_enter.onClick.Add(OnBtnEnter);
		view.m_select.onClick.Add(OnBtnSelect);
		model.OnServerSelected += OnServerSelected;
		Net.Inst.SendObj(new proto.servers_r());
		//TODO: show loading
	}
	void OnBtnEnter() {

	}

	void OnBtnSelect() {
		Stack.SingleTop<ServerList>();
	}

	void OnServerSelected() {
		view.m_select.m_name.text = model.SelectedServer.name;
	}

}


}
}
