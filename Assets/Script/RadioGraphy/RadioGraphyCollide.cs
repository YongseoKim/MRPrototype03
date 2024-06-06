using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioGraphyCollide : MonoBehaviour
{
    public GameObject radioGraphyOutPanel; // Table에 놓인 패널
    public GameObject radioGraphyInPanel; // 안에 넣은 패널
    public GameObject shelf;

    private void Start()
    {
        radioGraphyOutPanel.SetActive(true);
        radioGraphyInPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Shelf의 BoxCollider와 충돌했는지 확인
        if (other.gameObject == shelf)
        {
            radioGraphyOutPanel.SetActive(false);
            radioGraphyInPanel.SetActive(true);
        }
    }
}
