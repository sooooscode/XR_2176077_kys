using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW03_VehicleStopper : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[TargetPoint Trigger] 충돌한 오브젝트 이름: {other.name}, 태그: {other.tag}, 전체 경로: {other.transform.root.name}");
        //Debug.Log($"[TargetPoint Trigger] 감지됨: {other.name}");

        if (other.transform.root.CompareTag("Vehicle"))
        {
            Animator animator = other.transform.root.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("isMoving", false);
                Debug.Log("[도착] Vehicle 애니메이션 정지");
            }

            HW03_VehicleController controller = other.transform.root.GetComponentInChildren<HW03_VehicleController>();
            if (controller != null)
            {
                controller.ForceStopAtTarget();
            }
        }
    }

}
