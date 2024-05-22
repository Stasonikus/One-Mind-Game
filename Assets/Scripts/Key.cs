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
        // Проверяем, если игрок касается ключа
        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject); // Уничтожаем ключ
            KeySuces = true;
            Debug.Log("Ключ подобран");
            Debug.Log(KeySuces);
        }
    }
}
