using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� �±װ� FPSController���� Ȯ��
        if (other.gameObject.name == "FPSController")
        {
            Destroy(gameObject); // �ڱ� �ڽ� ����
        }
    }
}
