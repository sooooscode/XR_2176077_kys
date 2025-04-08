using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW03_VehicleStopper : MonoBehaviour
{
    public string targetName; // room1Target �Ǵ� room2Target ������Ʈ �̸�



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[Stopper] {gameObject.name} �浹 ���: {other.transform.root.name}");

        if (other.transform.root.CompareTag("Vehicle"))
        {
            Debug.Log("[Stopper] Vehicle ������ - �ִϸ��̼� ���� �õ�");

            Animator animator = other.transform.root.GetComponent<Animator>();
            if (animator != null)
                animator.Play("vehicle_Idle");

            HW03_VehicleController controller = other.transform.root.GetComponentInChildren<HW03_VehicleController>();
            if (controller != null)
                controller.ForceStopAtTarget(targetName);
        }
    }
}
