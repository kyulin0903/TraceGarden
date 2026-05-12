using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 캐릭터 오브젝트 드래그
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z); // 캐릭터 위치로 카메라 이동
    }
}
