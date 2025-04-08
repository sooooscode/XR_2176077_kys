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

    // 방향 기억 (초기값: Room1 → Room2)
    private bool isMovingDirectionToRoom2 = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isMoving)
        {
            Debug.Log("[탑승] FPSController 탑승");

            rider = other.transform;
            rider.SetParent(this.transform.parent);

            // 현재 방향에 맞는 애니메이션 재생
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
            Debug.Log("[중간 하차]");
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

        Debug.Log("도착 후 정지 완료");
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

        // 도착한 위치가 room2Target이라면 → 다음 이동은 room2 → room1
        if (targetName == room2Target.name)
        {
            isMovingDirectionToRoom2 = false;
            Debug.Log("Room2 도착 → 다음 이동은 Room1으로");
        }
        else if (targetName == room1Target.name)
        {
            isMovingDirectionToRoom2 = true;
            Debug.Log("Room1 도착 → 다음 이동은 Room2로");
        }
    }
}
