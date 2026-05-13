using UnityEngine;
//using static UnityEngine.InputSystem.Controls.AxisControl;

public class FKey : MonoBehaviour
{
    public Transform target;

    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(target.position.x + 0.7f, target.position.y + 0.5f, transform.position.z);
    }
}
