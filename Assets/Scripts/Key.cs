using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static bool KeySuces;

    private void Start()
    {
        KeySuces = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        // ���������, ���� ����� �������� �����
        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject); // ���������� ����
            KeySuces = true;
            Debug.Log("���� ��������");
            Debug.Log(KeySuces);
        }
    }
}
