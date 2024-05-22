using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject doorObject; // ������ �� ������ �����
    private bool isOpen = false; // ����, ������� �� �����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (Key.KeySuces == true))
        {
            OpenDoor(); // ��������� �����
        }
    }

    void OpenDoor()
    {
        // ���������, ������� �� �����
        if (!isOpen)
        {
            // ���� ����� ��� �� �������, ��������� ��
            doorObject.SetActive(false);
            isOpen = true;
        }
    }
}
