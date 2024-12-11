using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            // GameResult 컴포넌트를 가진 오브젝트를 찾습니다.
            GameResult gameResult = FindObjectOfType<GameResult>();
            
            if (gameResult != null)
            {
                gameResult.AddCoin(); // GameResult의 AddCoin 호출
            }
            else
            {
                Debug.LogError("GameResult 스크립트를 찾을 수 없습니다!");
            }
            
            Destroy(gameObject); // 코인 오브젝트 삭제
        }
    }
}
