using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameResult : MonoBehaviour
{
    private int highScore; // 최고 점수 (코인 개수 기준)
    public TextMeshProUGUI resultCoinCount;  // 획득 코인 개수 표시
    public TextMeshProUGUI bestCoinCount;    // 최고 기록 표시
    public GameObject parts; // 게임 결과 패널

    public GameObject redCoin; // 레드코인 오브젝트 참조
    private int coincount = 0; // 플레이어가 먹은 코인 개수

    void Start()
    {
        // 하이 스코어 불러오기 (코인 기준)
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }    
        else
        {
            highScore = 0;  // 기본값 설정
        }
    }

    public void AddCoin()
    {
        coincount++; // 코인 획득 시 카운터 증가
    }

    void Update()
    {
        // RedCoin이 null이면 게임 종료로 판단
        if (redCoin == null)
        {
            parts.SetActive(true);  // 결과 패널 활성화
            resultCoinCount.text = "Coins Collected: " + coincount;  // 획득 코인 개수 표시
            bestCoinCount.text = "Best Record: " + highScore;

            // 새로운 기록 저장
            if (highScore < coincount)
            {
                highScore = coincount;
                PlayerPrefs.SetInt("HighScore", highScore);  // 새 최고 기록 저장
            }
        }
    }

    public void OnRetry()
    {
        // 메인 씬으로 재시작
        SceneManager.LoadScene("Main");
    }
}
