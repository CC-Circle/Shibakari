using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationSettings : MonoBehaviour
{
    public float moveSpeed = 0.001f;
    public GameObject mainCamera;
    public SerialReceive serialReceive;
    private int leftRightCount = 0;
    private bool wasLeft = false;
    public GameObject M5Stack;
    private float currentRotationY = 0f;
    public float distanceFromCamera = 5f; // カメラからの距離

    void Update()
    {
        SerialHandler SerialHandler;
        GameObject M5Stack = GameObject.Find("M5stack_Evnet");
        SerialHandler = M5Stack.GetComponent<SerialHandler>();

        Vector3 currentPosition = transform.position;

        float rotationSpeed = 90f; // 回転速度
        float moveAmount = 5f * Time.deltaTime;

        if (SerialHandler.Settingsflag)
        { 
            if (serialReceive.Flag == 1)
            {
                transform.rotation = Quaternion.Euler(0, -50, 0);
                if (!wasLeft)
                {
                    leftRightCount++;
                    wasLeft = true;
                }
            }
            else if (serialReceive.Flag == 2)
            {
                transform.rotation = Quaternion.Euler(0, 50, 0);
                if (wasLeft)
                {
                    leftRightCount++;
                    wasLeft = false;
                }
            }
            else
            {
                currentPosition.x = 0;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else if (!SerialHandler.Settingsflag)
        {
            Vector3 mouseViewportPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            float mouseX = mouseViewportPosition.x;

            if (mouseX < 0.4f)
            {
                if (!wasLeft)
                {
                    transform.rotation = Quaternion.Euler(0, -50, 0);
                    leftRightCount++;
                    wasLeft = true;
                }
            }
            else if (mouseX > 0.6f)
            {
                if (wasLeft)
                {
                    transform.rotation = Quaternion.Euler(0, 50, 0);
                    leftRightCount++;
                    wasLeft = false;
                }
            }
            else
            {
                currentPosition.x = 0;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        // 前後移動
        if (leftRightCount >= 2)
        {
            currentPosition.z += 10;
            transform.position = currentPosition;
            leftRightCount = 0;
        }

        // 左右移動と回転
        if (Input.GetKey(KeyCode.A))
        {
            // 左に移動
            currentRotationY += rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, currentRotationY, 0);
            // カメラも回転
            mainCamera.transform.rotation = Quaternion.Euler(0, currentRotationY, 0);
            mainCamera.transform.Translate(Vector3.left * moveAmount);
        }

        if (Input.GetKey(KeyCode.D))
        {
            // 右に移動
            currentRotationY -= rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, currentRotationY, 0);
            // カメラも回転
            mainCamera.transform.rotation = Quaternion.Euler(0, currentRotationY, 0);
            mainCamera.transform.Translate(Vector3.right * moveAmount);
        }
    }
}
