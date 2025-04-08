using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW03_VehicleController : MonoBehaviour
{
    public Animator animator;
    public float stopAfterSeconds = 10f;

    public Transform room1Target;
    public Transform room2Target;

    private Transform rider;
    private bool isMoving = false;

    // ���� ��� (�ʱⰪ: Room1 �� Room2)
    private bool isMovingDirectionToRoom2 = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isMoving)
        {
            Debug.Log("[ž��] FPSController ž��");

            rider = other.transform;
            rider.SetParent(this.transform.parent);

            // ���� ���⿡ �´� �ִϸ��̼� ���
            if (isMovingDirectionToRoom2)
                animator.Play("vehicle_Move");
            else
                animator.Play("vehicle_Move_Back");

            isMoving = true;

            StartCoroutine(ResetAfterAnimation());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (rider != null && other.transform == rider)
        {
            Debug.Log("[�߰� ����]");
            rider.SetParent(null);
            rider = null;

            isMoving = false;
            animator.Play("vehicle_Idle", 0, 0f);
        }
    }

    private IEnumerator ResetAfterAnimation()
    {
        yield return new WaitForSeconds(stopAfterSeconds);

        isMoving = false;
        animator.Play("vehicle_Idle", 0, 0f);

        if (rider != null)
        {
            rider.SetParent(null);
            rider = null;
        }

        Debug.Log("���� �� ���� �Ϸ�");
    }

    public void ForceStopAtTarget(string targetName)
    {
        isMoving = false;
        animator.Play("vehicle_Idle", 0, 0f);

        if (rider != null)
        {
            rider.SetParent(null);
            rider = null;
        }

        // ������ ��ġ�� room2Target�̶�� �� ���� �̵��� room2 �� room1
        if (targetName == room2Target.name)
        {
            isMovingDirectionToRoom2 = false;
            Debug.Log("Room2 ���� �� ���� �̵��� Room1����");
        }
        else if (targetName == room1Target.name)
        {
            isMovingDirectionToRoom2 = true;
            Debug.Log("Room1 ���� �� ���� �̵��� Room2��");
        }
    }
}
