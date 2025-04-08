using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;  // FPSController 클래스 사용하려면 필요함

public class HW01_2176077_KYS_Button : MonoBehaviour
{
    public FirstPersonController fpsController;  // Inspector에서 연결해야 함

    public void OnClick_Print(GameObject Target)
    {
        // 1. FPS 입력 비활성화
        if (fpsController != null)
        {
            fpsController.enabled = false;
        }

        // 2. 마우스 커서 표시 및 잠금 해제
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // 3. 디버깅 출력
        print(Target.name);

        int rand = Random.Range(1000, 9999);
        print("Scene Reload Attempted: " + rand);

        // 4. 현재 씬 다시 로딩
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
