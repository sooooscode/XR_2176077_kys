using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW03_VehicleController : MonoBehaviour
{
    public Animator animator;            // Vehicle�� ����� Animator
    public float speed = 3f;

    private Transform rider;             // ž�� ���� �÷��̾�
    private bool isMoving = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[OnTriggerEnter] {other.name}");

        if (other.CompareTag("Player") && !isMoving)
        {
            Debug.Log("ž�� ����");
            rider = other.transform;

            // �÷��̾ Vehicle �ڽ����� ���� (�Բ� �����̰�)
            rider.SetParent(this.transform.parent);  // Vehicle�� parent��

            // �ִϸ��̼� �� �̵� ����
            animator.SetBool("isMoving", true);
            isMoving = true;

            // �ִϸ��̼� ���� �� ó�� �ڷ�ƾ ����
            StartCoroutine(ResetAfterAnimation());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"[OnTriggerExit] {other.name} ��Ż");

        if (rider != null && other.transform == rider)
        {
            Debug.Log("�߰� ����");

            rider.SetParent(null); // �÷��̾� ����
            rider = null;

            // �ִϸ��̼� �ߴ�
            isMoving = false;
            animator.Play("vehicle_Idle", 0, 0f);
            animator.SetBool("isMoving", false);
        }
    }

    private IEnumerator ResetAfterAnimation()
    {
        yield return new WaitForSeconds(360f); // �ʿ�� ���� �ִϸ��̼� ���̷� ����

        isMoving = false;
        animator.SetBool("isMoving", false);

        if (rider != null)
        {
            rider.SetParent(null); // ����
            rider = null;
        }

        Debug.Log("������ ���� �� ���� �Ϸ�");
    }

    // �ܺο��� ������ ���ߴ� �Լ�
    public void ForceStopAtTarget()
    {
        isMoving = false;
        animator.SetBool("isMoving", false);
        animator.Play("vehicle_Idle", 0, 0f);

        if (rider != null)
        {
            rider.SetParent(null);
            rider = null;
        }

        Debug.Log("���� ���� �� ���� �Ϸ�!");
    }
}
