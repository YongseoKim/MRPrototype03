using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseButton : MonoBehaviour
{
    public Button aButton;
    public Button bButton;
    public Button cButton;
    public Button dButton;
    public GameObject aGameObject;
    public GameObject bGameObject;
    public GameObject cGameObject;
    public GameObject dGameObject;

    private string lastClickedButton = "";

    void Start()
    {
        // 버튼 클릭 이벤트에 메서드 등록
        aButton.onClick.AddListener(ActivateAGameObject);
        bButton.onClick.AddListener(ActivateBGameObject);
        cButton.onClick.AddListener(ActivateCGameObject);
        dButton.onClick.AddListener(ActivateDGameObject);

        // 처음에는 모든 게임 오브젝트를 비활성화
        aGameObject.SetActive(false);
        bGameObject.SetActive(false);
        cGameObject.SetActive(false);
        dGameObject.SetActive(false);
    }

    void ActivateAGameObject()
    {
        if (lastClickedButton == "A")
        {
            // 모든 게임 오브젝트를 비활성화
            aGameObject.SetActive(false);
            lastClickedButton = "";
        }
        else
        {
            // aGameObject를 활성화
            aGameObject.SetActive(true);
            bGameObject.SetActive(false);
            cGameObject.SetActive(false);
            dGameObject.SetActive(false);
            lastClickedButton = "A";
        }
    }

    void ActivateBGameObject()
    {
        if (lastClickedButton == "B")
        {
            // 모든 게임 오브젝트를 비활성화
            bGameObject.SetActive(false);
            lastClickedButton = "";
        }
        else
        {
            // bGameObject를 활성화
            aGameObject.SetActive(false);
            bGameObject.SetActive(true);
            cGameObject.SetActive(false);
            dGameObject.SetActive(false);
            lastClickedButton = "B";
        }
    }

    void ActivateCGameObject()
    {
        if (lastClickedButton == "C")
        {
            // 모든 게임 오브젝트를 비활성화
            cGameObject.SetActive(false);
            lastClickedButton = "";
        }
        else
        {
            // cGameObject를 활성화
            aGameObject.SetActive(false);
            bGameObject.SetActive(false);
            cGameObject.SetActive(true);
            dGameObject.SetActive(false);
            lastClickedButton = "C";
        }
    }

    void ActivateDGameObject()
    {
        if (lastClickedButton == "D")
        {
            // 모든 게임 오브젝트를 비활성화
            dGameObject.SetActive(false);
            lastClickedButton = "";
        }
        else
        {
            // dGameObject를 활성화
            aGameObject.SetActive(false);
            bGameObject.SetActive(false);
            cGameObject.SetActive(false);
            dGameObject.SetActive(true);
            lastClickedButton = "D";
        }
    }
}
