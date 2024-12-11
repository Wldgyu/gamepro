using UnityEngine;  // UnityEngine 네임스페이스를 추가합니다.

public class RedCoin : MonoBehaviour
{
    public static bool goal = false;  // 게임 목표 달성 여부 (전역으로 설정)

    // 목표를 설정하는 메서드
    public void SetGoal()
    {
        goal = true;
    }

    // 목표를 초기화하는 메서드
    public void ResetGoal()
    {
        goal = false;
    }
}
