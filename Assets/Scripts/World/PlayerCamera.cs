using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World {

public class PlayerCamera : MonoBehaviour
{
	public Transform target; 
	public void Follow(Transform target)
	{
		this.target = target;
		transform.position = target.position;
	}
	void Update()
	{
		if (target == null) {
			return;
		}
		// 相机跟随
		Vector3 targetPosition = target.position;
		targetPosition.y += 2; // 相机稍微高于Cube一些
		targetPosition.z -= 3; // 相机稍微在Cube的后面一些
		transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);
	} 
}


}