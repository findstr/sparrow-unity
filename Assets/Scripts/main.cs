using UnityEngine;

public class main : MonoBehaviour
{
	private void Awake()
	{
		Net.Inst.HookConnected(this.OnConnected);
		Net.Inst.HookClosed(this.OnClosed);
		Net.Inst.Connect();
		Model.Inst.Init();
		UI.Stack.Init();
		UI.Stack.SingleInstance<UI.ViewModel.Auth>();
	}

	private void OnConnected()
	{
		Debug.Log("Connected");
	}

	private void OnClosed() 
	{
		Net.Inst.Connect();
		UI.Stack.Clear();
		UI.Stack.SingleInstance<UI.ViewModel.Auth>();
	}

}
