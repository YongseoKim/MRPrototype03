using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class BoxSpeedMoving : MonoBehaviour
{
    public Button buttonToClick; // 클릭하는 버튼
    public Image lightImage; // 흰색<->빨간색 이미지 (버튼이 잘 클릭되었는지 확인하는 용도)
    public GameObject upperCube; // 위 큐브
    public GameObject lowerCube; // 아래 큐브
    public float speed = 0.1f; // lowerCube의 이동 속도
    public float distance = -0.3f; // upperCube와 lowerCube 사이의 거리

    private bool isGreen = false; // lightImage 색 변화 변수
    private Vector3 initialLowerCubePosition; // 초기 아래 큐브 위치
    private bool isLowerCubeMoved = false; // 아래 큐브 움직임 변수

    void Start()
    {
        buttonToClick.onClick.AddListener(HandleButtonClick);
        initialLowerCubePosition = lowerCube.transform.position;

        // 초기 색상을 빨간색으로 설정
        lightImage.color = Color.red;
    }

    void Update()
    {
        if (isLowerCubeMoved)
        {
            Vector3 targetPosition = new Vector3(lowerCube.transform.position.x, upperCube.transform.position.y + distance, lowerCube.transform.position.z);

            // lowerCube를 목표 위치로 speed 속도로 이동
            lowerCube.transform.position = Vector3.MoveTowards(lowerCube.transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    void HandleButtonClick()
    {
        // isGreen 변수에 따라 색상 toggle
        lightImage.color = isGreen ? Color.red : Color.green;
        isGreen = !isGreen;

        // lowerCube 이동 상태 토글
        isLowerCubeMoved = !isLowerCubeMoved;
    }
}
