using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW03_VehicleStopper : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[TargetPoint Trigger] �浹�� ������Ʈ �̸�: {other.name}, �±�: {other.tag}, ��ü ���: {other.transform.root.name}");
        //Debug.Log($"[TargetPoint Trigger] ������: {other.name}");

        if (other.transform.root.CompareTag("Vehicle"))
        {
            Animator animator = other.transform.root.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("isMoving", false);
                Debug.Log("[����] Vehicle �ִϸ��̼� ����");
            }

            HW03_VehicleController controller = other.transform.root.GetComponentInChildren<HW03_VehicleController>();
            if (controller != null)
            {
                controller.ForceStopAtTarget();
            }
        }
    }

}
