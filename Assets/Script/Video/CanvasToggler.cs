using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CanvasToggler : MonoBehaviour
{
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch; // ���� �� = ���� ��Ʈ�ѷ�
    public GameObject canvasGameObject; // ĵ����
    public GameObject xrRig; // �÷��̾� ��ǥ (���� ī�޶� ���� xrRig ��ǥ�� �����)
    public Canvas canvasComponent; // canvasGameObject�� ���� ��
    public float canvasDistanceForward = 0.6f; // �÷��̾�κ��� ���� 0.6f(���ǿ����� �� 60cm ����)�� ĵ���� Ȱ��ȭ
    public float height = 1.3f; // ĵ���� ���� = 1.3m

    private bool isCanvasVisible = false; // ó������ ĵ���� ��Ȱ��ȭ
    private float lastXButtonTime = 0f; // ĵ���� Ȱ��ȭ ����� ���� Ŭ������ �� -> ����Ŭ���� ���� ����
    public float doubleClickThreshold = 0.3f;

    void Start()
    {
        canvasGameObject.SetActive(false);
    }

    void Update()
    {
        // ���� ��� �޼��� ������ ������ �ι� �΋H���� �� = ��Ʈ�ѷ��� ��� ���� ��Ʈ�ѷ��� ù��° ��ư(OVRInput.Button.One)�� ���� Ŭ���ϴ� ��
        if (OVRInput.GetDown(OVRInput.Button.One, leftController))
        {
            float currentTime = Time.time;
            if (currentTime - lastXButtonTime <= doubleClickThreshold)
            {
                ToggleMainCanvas();
            }
            lastXButtonTime = currentTime;
        }
    }

    private void ToggleMainCanvas()
    {
        isCanvasVisible = !isCanvasVisible;
        canvasGameObject.SetActive(isCanvasVisible);

        // ĵ���� Ȱ��ȭ ��ǥ
        if (isCanvasVisible && xrRig != null)
        {
            // � �������ε� ���� 60cm �տ� ĵ������ ��Ÿ���� �� -> Quarternion ����� ���� ���
            Quaternion rotation = Quaternion.Euler(0, xrRig.transform.eulerAngles.y, 0);
            Vector3 forwardDirection = rotation * Vector3.forward;

            // ĵ���� Ȱ��ȭ ��ǥ ���
            Vector3 canvasPosition = xrRig.transform.position + forwardDirection * canvasDistanceForward;
            canvasPosition.y = height;

            canvasGameObject.transform.position = canvasPosition;

            // ĵ������ �÷��̾ ��� ����(�� ������ �޶�) �׻� �÷��̾� �þ� ���鿡 ��Ÿ���� ĵ���� ���� ����
            canvasGameObject.transform.rotation = rotation;

            // ĵ������ 40���� ȸ����Ŵ (x�� ���� ȸ��)
            canvasGameObject.transform.Rotate(40, 0, 0);
        }
    }
}
