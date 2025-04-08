using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW03_VehicleController : MonoBehaviour
{
    public Animator animator;            // Vehicle에 연결된 Animator
    public float speed = 3f;

    private Transform rider;             // 탑승 중인 플레이어
    private bool isMoving = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[OnTriggerEnter] {other.name}");

        if (other.CompareTag("Player") && !isMoving)
        {
            Debug.Log("탑승 시작");
            rider = other.transform;

            // 플레이어를 Vehicle 자식으로 설정 (함께 움직이게)
            rider.SetParent(this.transform.parent);  // Vehicle이 parent임

            // 애니메이션 및 이동 시작
            animator.SetBool("isMoving", true);
            isMoving = true;

            // 애니메이션 종료 후 처리 코루틴 시작
            StartCoroutine(ResetAfterAnimation());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"[OnTriggerExit] {other.name} 이탈");

        if (rider != null && other.transform == rider)
        {
            Debug.Log("중간 하차");

            rider.SetParent(null); // 플레이어 하차
            rider = null;

            // 애니메이션 중단
            isMoving = false;
            animator.Play("vehicle_Idle", 0, 0f);
            animator.SetBool("isMoving", false);
        }
    }

    private IEnumerator ResetAfterAnimation()
    {
        yield return new WaitForSeconds(360f); // 필요시 실제 애니메이션 길이로 조정

        isMoving = false;
        animator.SetBool("isMoving", false);

        if (rider != null)
        {
            rider.SetParent(null); // 하차
            rider = null;
        }

        Debug.Log("목적지 도착 및 하차 완료");
    }

    // 외부에서 강제로 멈추는 함수
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

        Debug.Log("강제 정지 및 하차 완료!");
    }
}
