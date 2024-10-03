using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public Transform cameraTransform; // 你的相机的Transform组件

    void Update()
    {
        // 获取输入
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 计算移动向量
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        // 移动Cube
        transform.Translate(movement * speed * Time.deltaTime);

        // 相机跟随
        Vector3 targetPosition = transform.position;
        targetPosition.y += 2; // 相机稍微高于Cube一些
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetPosition, 0.1f);
    } 
}
