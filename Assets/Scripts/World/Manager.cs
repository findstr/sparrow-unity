using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace World {

public class Manager : MonoBehaviour
{	
	PlayerCamera PlayerCamera;
        // Start is called before the first frame update
	void Awake() {
		PlayerCamera = Camera.main.GetComponent<PlayerCamera>();
	}
        void Start() {
		//SceneManager.SetActiveScene(SceneManager.GetSceneByName("World"));
		if (Model.Inst.Player.UID == 0) {
			Model.Inst.Player.onLoginSuccess -= OnLoginSuccess;
			Model.Inst.Player.onLoginSuccess += OnLoginSuccess;
		} else {
			OnLoginSuccess();
		}
        }
	void Update() {

	}
	void OnLoginSuccess() {
		Debug.Log("Login:" + Resources.Load("Prefab/Player"));
		Debug.Log("OnLoginSuccess:" + Model.Inst.Player.UID);
		UI.Stack.Clear();
		var go = Instantiate(Resources.Load("Prefab/Player"), Model.Inst.Player.Pos, Quaternion.identity) as GameObject;
		PlayerCamera.Follow(go.transform);

		//SceneManager.SetActiveScene(SceneManager.GetSceneByName("Main"));
	}
}

}