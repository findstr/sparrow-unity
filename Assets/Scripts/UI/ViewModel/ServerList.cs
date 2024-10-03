using FairyGUI;
using UI.View.Login;
using UnityEngine;

namespace UI {
namespace ViewModel {
public class ServerList: Base {
        readonly Model.Login model = null;
        readonly View.Login.ServerList view = null;
	
	public override GComponent View() {
		return view;
	}
	public ServerList() {
		model = Model.Inst.Login;
		view = UI.View.Login.ServerList.CreateInstance();
		view.Center();
		view.m_list.itemProvider = (int index) => {
			return ServerEntry.URL;
		};
		view.m_list.itemRenderer = (int index, GObject obj) => {
			ServerEntry item = (ServerEntry)obj;
			item.m_name.text = string.Format("{0} {1}", model.ServerList[index].id, model.ServerList[index].name);
		};
		view.m_list.numItems = model.ServerList.Count;
		view.m_list.onClickItem.Add(OnSelectServer);
		Debug.Log("ServerList:" + model.ServerList.Count);
	}

	void OnSelectServer(EventContext context) {
		var item = (GButton)context.data;
		var index = view.m_list.GetChildIndex(item);
		Debug.Log("OnSelectServer:" + index);
		model.SelectedServer = model.ServerList[index];
		Stack.Close(this);
	}
}


}
}
