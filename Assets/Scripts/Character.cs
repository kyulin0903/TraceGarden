using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    public Sprite leftSprite;  // 왼쪽 이미지
    public Sprite rightSprite; // 오른쪽 이미지

    SpriteRenderer sr;

    private float moveSpeed = 3f;
    float minX, maxX, minY, maxY; // 이동 가능한 범위

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Camera cam = Camera.main;

        float bgHalfW = 9.6f; // 1920 / 100 / 2
        float bgHalfH = 5.4f; // 1080 / 100 / 2

        // 캐릭터 크기 절반만큼 여백
        float halfW = sr.bounds.extents.x;
        float halfH = sr.bounds.extents.y;

        minX = -bgHalfW + halfW;
        maxX = bgHalfW - halfW;
        minY = -bgHalfH + halfH;
        maxY = bgHalfH - halfH;

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
            sr.sprite = leftSprite;
        }
        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            sr.sprite = rightSprite;
        }

        float clampX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampX, clampY, transform.position.z);
    }
}
