using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoMenuButton : MonoBehaviour
{
    public Button videoButton; // 메뉴캔버스의 비디오 버튼
    public Button quitButton; // 비디오 캔버스의 종료 버튼
    public GameObject canvasGameObject; // 캔버스
    public GameObject xrRig; // 플레이어 좌표 (메인 카메라를 보통 xrRig 좌표로 사용함)
    public Canvas canvasComponent; // canvasGameObject와 같은 것
    public float canvasDistanceForward = 0.4f; // 플레이어로부터 전방 0.4f(현실에서는 약 40cm 정도)에 캔버스 활성화
    public float height = 1.3f; // 캔버스 높이 = 1.3m
    public VideoPlayer videoPlayer; // VideoPlayer 컴포넌트

    private bool isCanvasVisible = false; // 처음에는 캔버스 비활성화

    void Start()
    {
        canvasGameObject.SetActive(false);
        videoButton.onClick.AddListener(ToggleMainCanvas); // Video 버튼 클릭 이벤트 추가
        quitButton.onClick.AddListener(HideCanvas); // Quit 버튼 클릭 이벤트 추가
    }

    private void ToggleMainCanvas()
    {
        isCanvasVisible = !isCanvasVisible;
        canvasGameObject.SetActive(isCanvasVisible);

        // 캔버스 활성화 좌표
        if (isCanvasVisible && xrRig != null)
        {
            // 어떤 방향으로든 전방 40cm 앞에 캔버스가 나타나게 함 -> Quarternion 사용해 방향 계산
            Quaternion rotation = Quaternion.Euler(0, xrRig.transform.eulerAngles.y, 0);
            Vector3 forwardDirection = rotation * Vector3.forward;

            // 캔버스 활성화 좌표 계산
            Vector3 canvasPosition = xrRig.transform.position + forwardDirection * canvasDistanceForward;
            canvasPosition.y = height;

            canvasGameObject.transform.position = canvasPosition;
            // 캔버스가 플레이어가 어딜 보든(고개 각도가 달라도) 항상 플레이어 시야 정면에 나타나게 캔버스 각도 조절
            canvasGameObject.transform.rotation = rotation;
        }
    }

    private void HideCanvas()
    {
        isCanvasVisible = false;
        canvasGameObject.SetActive(false);

        // 비디오 초기화
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
            videoPlayer.time = 0;
        }
    }
}
