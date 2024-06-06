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
        // ��ư Ŭ�� �̺�Ʈ�� �޼��� ���
        aButton.onClick.AddListener(ActivateAGameObject);
        bButton.onClick.AddListener(ActivateBGameObject);
        cButton.onClick.AddListener(ActivateCGameObject);
        dButton.onClick.AddListener(ActivateDGameObject);

        // ó������ ��� ���� ������Ʈ�� ��Ȱ��ȭ
        aGameObject.SetActive(false);
        bGameObject.SetActive(false);
        cGameObject.SetActive(false);
        dGameObject.SetActive(false);
    }

    void ActivateAGameObject()
    {
        if (lastClickedButton == "A")
        {
            // ��� ���� ������Ʈ�� ��Ȱ��ȭ
            aGameObject.SetActive(false);
            lastClickedButton = "";
        }
        else
        {
            // aGameObject�� Ȱ��ȭ
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
            // ��� ���� ������Ʈ�� ��Ȱ��ȭ
            bGameObject.SetActive(false);
            lastClickedButton = "";
        }
        else
        {
            // bGameObject�� Ȱ��ȭ
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
            // ��� ���� ������Ʈ�� ��Ȱ��ȭ
            cGameObject.SetActive(false);
            lastClickedButton = "";
        }
        else
        {
            // cGameObject�� Ȱ��ȭ
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
            // ��� ���� ������Ʈ�� ��Ȱ��ȭ
            dGameObject.SetActive(false);
            lastClickedButton = "";
        }
        else
        {
            // dGameObject�� Ȱ��ȭ
            aGameObject.SetActive(false);
            bGameObject.SetActive(false);
            cGameObject.SetActive(false);
            dGameObject.SetActive(true);
            lastClickedButton = "D";
        }
    }
}
