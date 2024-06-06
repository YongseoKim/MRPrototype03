using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioGraphyCollide : MonoBehaviour
{
    public GameObject radioGraphyOutPanel; // Table�� ���� �г�
    public GameObject radioGraphyInPanel; // �ȿ� ���� �г�
    public GameObject shelf;

    private void Start()
    {
        radioGraphyOutPanel.SetActive(true);
        radioGraphyInPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Shelf�� BoxCollider�� �浹�ߴ��� Ȯ��
        if (other.gameObject == shelf)
        {
            radioGraphyOutPanel.SetActive(false);
            radioGraphyInPanel.SetActive(true);
        }
    }
}
