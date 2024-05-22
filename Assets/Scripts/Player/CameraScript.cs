using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float sensitivity = 4f; // Чувствительность мыши

    private float rotationX = 0f; // Вращение по вертикали

    void Update()
    {
        // Получаем ввод от мыши для вращения камеры
        float mouseX = Input.GetAxis("Mouse X");

        // Вращаем персонажа только по оси X
        rotationX += mouseX * sensitivity;

        // Ограничиваем угол обзора
        //rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Применяем вращение камеры только по оси X
        transform.localRotation = Quaternion.Euler(0f, rotationX, 0f);
    }
}
