using UnityEngine;

public class RedCoinItem : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        // 씬에서 GameManager를 찾습니다.
        gameManager = Object.FindFirstObjectByType<GameManager>();

        // GameManager가 없을 경우 경고 로그를 출력합니다.
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        // 충돌한 객체가 "Player"일 경우
        if (collider.gameObject.name == "Player")
        {
            Debug.Log("Player has collided with Red Coin");

            if (gameManager != null)
            {
                Debug.Log("Calling RedCoinStart...");
                gameManager.RedCoinStart(); // 장애물 제거 메서드 호출
            }

            // 빨간 코인 삭제
            Destroy(gameObject); // 레드코인 아이템을 삭제
        }
    }
}
