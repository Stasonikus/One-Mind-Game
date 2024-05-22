using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject doorObject; // Ссылка на объект двери
    private bool isOpen = false; // Флаг, открыта ли дверь

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (Key.KeySuces == true))
        {
            OpenDoor(); // Открываем дверь
        }
    }

    void OpenDoor()
    {
        // Проверяем, открыта ли дверь
        if (!isOpen)
        {
            // Если дверь еще не открыта, отключаем ее
            doorObject.SetActive(false);
            isOpen = true;
        }
    }
}
