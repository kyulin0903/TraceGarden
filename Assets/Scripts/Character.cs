using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    // 캐릭터 좌우
    public Sprite leftSprite;
    public Sprite rightSprite;

    SpriteRenderer sr;

    private float moveSpeed = 3f; // 캐릭터 이동 속도
    // 캐릭터 이동범위 제한
    public SpriteRenderer background;
    float bgMinX, bgMaxX, bgMinY, bgMaxY;
    float minX, maxX, minY, maxY;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        bgMinX = background.bounds.min.x;
        bgMaxX = background.bounds.max.x;
        bgMinY = background.bounds.min.y;
        bgMaxY = background.bounds.max.y;

        float halfW = sr.bounds.extents.x;
        float halfH = sr.bounds.extents.y;

        minX = bgMinX + halfW;
        maxX = bgMaxX - halfW;
        minY = bgMinY + halfH;
        maxY = bgMaxY - halfH;
    }

    void Update()
    {
        if (Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed)
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        if (Keyboard.current.downArrowKey.isPressed || Keyboard.current.sKey.isPressed)
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
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