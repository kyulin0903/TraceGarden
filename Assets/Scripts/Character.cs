using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    
    private float moveSpeed = 4f;
    void Start()
    {
        
    }

    void Update()
    {
        if (Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
        if (Keyboard.current.downArrowKey.isPressed || Keyboard.current.sKey.isPressed)
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            
        }
        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}
