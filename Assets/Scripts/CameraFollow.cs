using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public SpriteRenderer background;
    public FarmMode farmMode; // FarmMode 드래그

    float bgMinX, bgMaxX, bgMinY, bgMaxY;
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        bgMinX = background.bounds.min.x;
        bgMaxX = background.bounds.max.x;
        bgMinY = background.bounds.min.y;
        bgMaxY = background.bounds.max.y;
    }

    void LateUpdate() //Update()
    {
        // 농사모드 중이면 카메라 따라가기 비활성화
        if (farmMode.farmMode) return;

        float camH = cam.orthographicSize;
        float camW = camH * cam.aspect;

        float minX = bgMinX + camW;
        float maxX = bgMaxX - camW;
        float minY = bgMinY + camH;
        float maxY = bgMaxY - camH;

        float clampX = Mathf.Clamp(target.position.x, minX, maxX);
        float clampY = Mathf.Clamp(target.position.y, minY, maxY);
        transform.position = new Vector3(clampX, clampY, transform.position.z);
    }
}