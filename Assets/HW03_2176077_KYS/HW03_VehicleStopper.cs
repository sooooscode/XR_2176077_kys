using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW03_VehicleStopper : MonoBehaviour
{
    public string targetName; // room1Target 또는 room2Target 오브젝트 이름



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[Stopper] {gameObject.name} 충돌 대상: {other.transform.root.name}");

        if (other.transform.root.CompareTag("Vehicle"))
        {
            Debug.Log("[Stopper] Vehicle 감지됨 - 애니메이션 정지 시도");

            Animator animator = other.transform.root.GetComponent<Animator>();
            if (animator != null)
                animator.Play("vehicle_Idle");

            HW03_VehicleController controller = other.transform.root.GetComponentInChildren<HW03_VehicleController>();
            if (controller != null)
                controller.ForceStopAtTarget(targetName);
        }
    }
}
