using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트의 태그가 FPSController인지 확인
        if (other.gameObject.name == "FPSController")
        {
            Destroy(gameObject); // 자기 자신 제거
        }
    }
}
