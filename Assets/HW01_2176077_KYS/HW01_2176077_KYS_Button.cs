using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;  // FPSController Ŭ���� ����Ϸ��� �ʿ���

public class HW01_2176077_KYS_Button : MonoBehaviour
{
    public FirstPersonController fpsController;  // Inspector���� �����ؾ� ��

    public void OnClick_Print(GameObject Target)
    {
        // 1. FPS �Է� ��Ȱ��ȭ
        if (fpsController != null)
        {
            fpsController.enabled = false;
        }

        // 2. ���콺 Ŀ�� ǥ�� �� ��� ����
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // 3. ����� ���
        print(Target.name);

        int rand = Random.Range(1000, 9999);
        print("Scene Reload Attempted: " + rand);

        // 4. ���� �� �ٽ� �ε�
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
