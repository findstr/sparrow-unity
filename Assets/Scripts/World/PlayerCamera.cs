using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World {

public class PlayerCamera : MonoBehaviour
{
	public Vector3 offset;
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
		Vector3 targetPosition = target.position + offset;
		transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);
	}
}


}