using FairyGUI;
using UnityEngine;
using System.Collections.Generic;

namespace UI {

public class Stack {
	static List<ViewModel.Base> stack = new List<ViewModel.Base>();
	static GObject first = null;
	static GObject second = null;
	static GObject loading = null;
	static public void Init() {
		UIPackage.AddPackage("UI/Common");
		UIPackage.AddPackage("UI/Login");
		View.Login.LoginBinder.BindAll();
	}

	
	static int Find<T>() {
		for (int i = stack.Count - 1 ; i >= 0; i--) {
			var obj = stack[i];
			if (obj.GetType() == typeof(T)) {
				return i;
			}
		}
		return -1;
	}

	static void Remove(int i) {
		var c = stack[i];
		c.OnClose();
		stack.RemoveAt(i);
		GRoot.inst.RemoveChild(c.View(), true);
	}

	static public T Standard<T>()  where T : ViewModel.Base, new() {
		var t = new T();
		GRoot.inst.AddChild(t.View());
		stack.Add(t);
		return t;
	}

	static public T SingleTop<T>() where T : ViewModel.Base, new() {
		var i = Find<T>();
		if (i == -1) {
			return Standard<T>();
		}
		for (int j = stack.Count - 1; j > i; j--) {
			Remove(j);
		}
		return stack[i] as T;
	}
	
	static public T SingleInstance<T>() where T : ViewModel.Base, new() {
		var i = Find<T>();
		if (i != -1) {
			var stk = stack[i];
			stack.RemoveAt(i);
			stack.Add(stk);
			GRoot.inst.RemoveChild(stk.View());
			GRoot.inst.AddChild(stk.View());
			return stk as T;
		}
		return Standard<T>();
	}

	static public void Close<T>() where T : ViewModel.Base, new() {
		var i = Find<T>();
		if (i == -1) {
			Debug.LogError("[UIStack] remove view package:" + typeof(T));
			return ;
		}
		Remove(i);
	}

	static public void Close(ViewModel.Base c) {
		for (int i = stack.Count - 1; i >= 0; i--) {
			if (stack[i] == c) {
				Remove(i);
				return;
			}
		}
	}

	static public void Clear() {
		for (int i = stack.Count - 1; i >=　0; i--) {
			Remove(i);
		}
	}
}

}
