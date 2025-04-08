using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW03_SmartDoor : MonoBehaviour
{
    public Animator animator;
    public Transform doorForward;

    private bool isEntered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isEntered && other.CompareTag("Player"))
        {
            isEntered = true;
            Debug.Log("SmartDoor Trigger Enter!");

            Vector3 toPlayer = other.transform.position - transform.position;
            float dot = Vector3.Dot(toPlayer.normalized, doorForward.forward);

            if (dot < 0)
            {
                animator.SetInteger("status", 1); // 실내 → 실외 (y: -90)
                Debug.Log("→ 실내로 열기 (status = 1)");
            }
            else
            {
                animator.SetInteger("status", 2); // 실외 → 실내 (y: +90)
                Debug.Log("→ 실외로 열기 (status = 1)");
            }


            StartCoroutine(ResetStatus());
        }
    }

    private IEnumerator ResetStatus()
    {
        yield return new WaitForSeconds(3f);
        animator.SetInteger("status", 0);
        isEntered = false;
        Debug.Log("status = 0 (reset)");
    }
}
