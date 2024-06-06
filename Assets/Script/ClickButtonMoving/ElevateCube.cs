using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevateCube : MonoBehaviour
{
    public Button clickButton; // UI 버튼
    public GameObject elevateCube; // 이동할 게임 오브젝트

    public float moveSpeed = 0.1f; // 이동 속도, 공개 변수로 설정
    public float moveDistanceLimit = 0.2f; // 이동 거리 제한, 공개 변수로 설정

    private bool isMoving = false; // 이동 중인지 여부를 확인하는 플래그
    private float moveDistance = 0f; // 현재 이동한 거리 추적
    private float moveDirection = 1f; // 이동 방향 (1은 위로, -1은 아래로)

    void Start()
    {
        // 버튼에 클릭 이벤트 리스너 추가
        clickButton.onClick.AddListener(MoveBGameObject);
    }

    void Update()
    {
        // 이동 상태일 때 이동 처리
        if (isMoving)
        {
            // elevateCube를 Y축으로 moveDirection 방향으로 moveSpeed의 속도로 이동
            float moveStep = moveSpeed * Time.deltaTime * moveDirection;
            elevateCube.transform.Translate(0, moveStep, 0);

            // 이동한 거리 업데이트
            moveDistance += Mathf.Abs(moveStep); // 이동 거리는 양수로 계산

            // 이동 거리가 moveDistanceLimit 이상이면 이동 중지
            if (moveDistance >= moveDistanceLimit)
            {
                isMoving = false;
                moveDistance = 0f; // 다음 이동을 위해 거리 초기화
                moveDirection *= -1f; // 다음 이동 방향 전환
            }
        }
    }

    void MoveBGameObject()
    {
        if (!isMoving) // 이동 중이 아닐 때만 시작
        {
            moveDistance = 0f; // 이동한 거리 초기화
            isMoving = true;
        }
    }
}
