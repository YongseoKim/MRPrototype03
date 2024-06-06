using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxMovingManager : MonoBehaviour
{
    public Button buttonToClick; // 클릭하는 버튼
    public Image lightImage; // 흰색<->빨간색 이미지 (버튼이 잘 클릭되었는지 확인하는 용도)
    public GameObject upperCube; // 위 큐브
    public GameObject lowerCube; // 아래 큐브

    public float distance = -0.3f; // upperCube와 lowerCube 사이의 거리

    private bool isRed = false; // lightImage 색 변화 변수
    private Vector3 initialLowerCubePosition; // 초기 아래 큐브 위치
    private bool isLowerCubeMoved = false; // 아래 큐브 움직임 변수

    void Start()
    {
        buttonToClick.onClick.AddListener(HandleButtonClick);
        initialLowerCubePosition = lowerCube.transform.position;
    }

    void Update()
    {
        if (isLowerCubeMoved)
        {
            // upperCube의 y 좌표를 추적해 lowerCube의 y 좌표를 upperCube의 y 좌표 + distance로 유지
            float newYPosition = upperCube.transform.position.y + distance;
            lowerCube.transform.position = new Vector3(lowerCube.transform.position.x, newYPosition, lowerCube.transform.position.z);
        }
    }

    void HandleButtonClick()
    {
        // isRed 변수에 따라 색상 toggle
        lightImage.color = isRed ? Color.white : Color.red;

        // isRed 변수 업데이트
        isRed = !isRed;

        // lowerCube 위치 변경
        MoveLowerCube();
    }

    void MoveLowerCube()
    {
        if (isLowerCubeMoved)
        {
            // lowerCube를 원위치로 이동
            lowerCube.transform.position = initialLowerCubePosition;
            isLowerCubeMoved = false;
        }
        else
        {
            // lowerCube를 upperCube 아래로 distance 위치로 이동
            float newYPosition = upperCube.transform.position.y + distance;
            lowerCube.transform.position = new Vector3(lowerCube.transform.position.x, newYPosition, lowerCube.transform.position.z);
            isLowerCubeMoved = true;
        }
    }
}
