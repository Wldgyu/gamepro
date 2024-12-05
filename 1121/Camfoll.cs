using UnityEngine;

public class Camfoll : MonoBehaviour
{
    GameObject ball;

    void Start()
    {
        // 공(Ball) 오브젝트 찾기
        ball = GameObject.Find("Ball");
        if (ball == null)
        {
            Debug.LogError("Ball 오브젝트를 찾을 수 없습니다. 'Ball' 이름을 확인하세요.");
            return;
        }

        // 태그가 Coin인 모든 오브젝트 찾기
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        for (int i = 0; i < coins.Length; i++)
        {
            Debug.Log(coins[i].name);
        }
    }

    void Update()
    {
        // Ball 오브젝트가 존재할 때만 카메라가 이동하도록 설정
        if (ball != null)
        {
            // 카메라 위치를 Ball 오브젝트를 기준으로 설정
            transform.position = new Vector3(
                ball.transform.position.x,           // 공의 X 위치 따라가기
                ball.transform.position.y + 3,       // 공보다 위로 3만큼 띄움
                ball.transform.position.z - 14       // 공보다 뒤로 14만큼 이동
            );
        }
    }
}

