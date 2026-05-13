using UnityEngine;

public class Interaction : MonoBehaviour
{
    public bool farmnear = false; // F키 뜨고 안뜨고, true일때 F 누르면 농사모드 전환, 
    public bool farmin = false; // 농사모드 전환

    public GameObject nearField; // 현재 닿은 밭 저장
    public GameObject fKeyObject;
    public FarmMode farmMode;

    void Start()
    {
        fKeyObject.SetActive(false); // 시작할 때 안보이게
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Field"))
        {
            farmnear = true;
            nearField = other.gameObject; // 닿은 밭 저장
            fKeyObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Field"))
        {
            farmnear = false;
            fKeyObject.SetActive(false);

            // 농사모드 중이 아닐 때만 nearField 초기화
            if (!farmMode.farmMode)
            {
                nearField = null;
            }
        }
    }

    void Update()
    {

    }
    
}
