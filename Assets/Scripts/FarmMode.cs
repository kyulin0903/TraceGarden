using UnityEngine;
using UnityEngine.InputSystem;

public class FarmMode : MonoBehaviour
{
    public Interaction interaction;

    public Camera cam;
    public GameObject character;
    public GameObject fKeyObject;
    public GameObject hoe;

    float normalSize;
    public float farmSize = 1.5f; // 더 확대된 크기

    public bool farmMode = false;
    bool transitioning = false; // 전환 중인지

    Vector3 targetCamPos;
    float targetSize;
    Vector3 normalCamPos; // 원래 카메라 위치

    public float zoomSpeed = 3f; // 줌 속도

    void Start()
    {
        hoe.SetActive(false);
        normalSize = cam.orthographicSize;
    }

    void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            if (!farmMode && interaction.farmnear && interaction.nearField != null)
            {
                // 농사모드 진입
                farmMode = true;
                transitioning = true;
                character.SetActive(false);
                fKeyObject.SetActive(false);

                // 원래 카메라 위치 저장
                normalCamPos = cam.transform.position;

                // 밭 한가운데로 타겟 설정
                Vector3 fieldPos = interaction.nearField.transform.position;
                targetCamPos = new Vector3(fieldPos.x, fieldPos.y, cam.transform.position.z);
                targetSize = farmSize;

                //농사
                Vector3 fieldHoePos = new Vector3(interaction.nearField.transform.position.x, interaction.nearField.transform.position.y, interaction.nearField.transform.position.z);
                hoe.transform.position = fieldHoePos;
                hoe.SetActive(true);

            }
            else if (farmMode)
            {
                // 농사모드 종료
                farmMode = false;
                transitioning = true;

                // 원래 위치로 복귀
                targetCamPos = normalCamPos;
                targetSize = normalSize;
            }
        }

        // 부드러운 줌 전환
        if (transitioning)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
            cam.transform.position = Vector3.Lerp(cam.transform.position, targetCamPos, Time.deltaTime * zoomSpeed);

            // 목표에 충분히 가까워지면 전환 완료
            if (Mathf.Abs(cam.orthographicSize - targetSize) < 0.01f)
            {
                cam.orthographicSize = targetSize;
                cam.transform.position = targetCamPos;
                transitioning = false;

                // 줌아웃 완료 후 캐릭터 다시 표시
                if (!farmMode)
                    character.SetActive(true);
            }
        }
    }
}