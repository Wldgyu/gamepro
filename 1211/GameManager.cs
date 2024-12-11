using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI 관련

public class GameManager : MonoBehaviour
{
    private int coinCount = 0;

    // UI 팝업을 나타내는 Panel을 public으로 선언
    public GameObject restartPopup; // UI Panel을 연결할 변수

    private void Start()
    {
        // 게임 시작 시, restartPopup을 비활성화
        if (restartPopup != null)
        {
            restartPopup.SetActive(false); // 처음에는 비활성화
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0); // 첫 번째 씬을 로드합니다.
    }

    public void RedCoinStart()
    {
        DestroyObstacles(); // 장애물을 제거합니다.
    }

    private void DestroyObstacles()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i]);
        }
    }

    public void GetCoin()
    {
        coinCount++;
        Debug.Log("동전 : " + coinCount);
    }

    // 재시작 팝업 표시
    public void ShowRestartPopup()
    {
        if (restartPopup != null)
        {
            restartPopup.SetActive(true); // 팝업 활성화
        }
    }

    // 팝업에서 "재시작" 버튼 클릭 시 호출
    public void OnRestartButtonClicked()
    {
        Time.timeScale = 1; // 게임 다시 실행
        RestartGame();
    }

    // 팝업에서 "취소" 버튼 클릭 시 호출
    public void OnCancelButtonClicked()
    {
        Time.timeScale = 1; // 게임 다시 실행
        if (restartPopup != null)
        {
            restartPopup.SetActive(false); // 팝업 비활성화
        }
    }
}
