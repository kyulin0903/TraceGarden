using UnityEngine;
using UnityEngine.InputSystem;

public class MyNew : MonoBehaviour
{
    //InputActionAsset inputActions; // 인풋 액션
    void Start()
    {
        Debug.Log("Hi");
        //inputActions = GetComponent<PlayerInput>().actions; // 인풋 액션 연결
    }

    void Update()
    {
        if (Keyboard.current.leftArrowKey.isPressed)
            Debug.Log("왼쪽으로 이동중");
        if (Keyboard.current.rightArrowKey.isPressed)
            Debug.Log("오른쪽으로 이동중");
        if (Keyboard.current.upArrowKey.isPressed)
            Debug.Log("위쪽으로 이동중");
        if (Keyboard.current.downArrowKey.isPressed)
            Debug.Log("아래쪽으로 이동중");
        /* 인풋 액션 사용
        if (inputActions["Jump"].WasPressedThisFrame())
        {
            Debug.Log("점프!");
        }
        */
    }
}