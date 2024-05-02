using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    private float xAxis;
    private float yAxis;

    float xAxisTurnRate = 360f;
    float yAxisTurnRate = 360f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {

        Quaternion newRotation = Quaternion.Euler(xAxis, yAxis, 0f);

        Camera.main.transform.rotation = newRotation;
    }

    private void OnDisable()
    {
        Cursor.lockState= CursorLockMode.None;
    }

    public void AddXAxisInput(float input)
    {
        xAxis -= input * xAxisTurnRate;
        xAxis = Mathf.Clamp(xAxis, -80f, 80f);
        
    }

    public void AddYAxisInput(float input)
    {
        yAxis += input * yAxisTurnRate;
    }
}
