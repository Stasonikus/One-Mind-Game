using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float sensitivity = 4f; // ���������������� ����

    private float rotationX = 0f; // �������� �� ���������

    void Update()
    {
        // �������� ���� �� ���� ��� �������� ������
        float mouseX = Input.GetAxis("Mouse X");

        // ������� ��������� ������ �� ��� X
        rotationX += mouseX * sensitivity;

        // ������������ ���� ������
        //rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // ��������� �������� ������ ������ �� ��� X
        transform.localRotation = Quaternion.Euler(0f, rotationX, 0f);
    }
}
