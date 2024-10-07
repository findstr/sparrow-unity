using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace World {

public class Player : MonoBehaviour
{
	public float speed = 10f;
	void Update()
	{
		// 获取输入
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");
		// 计算移动向量
		Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
		// 移动Cube
		transform.Translate(speed * Time.deltaTime * movement);
		Model.Inst.Player.Pos = transform.position;
	} 
}

}