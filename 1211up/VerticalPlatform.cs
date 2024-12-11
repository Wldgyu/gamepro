using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    public float speed = 1.5f;      // 이동 속도
    public float limit = 2f;        // 이동 범위 (최대 높이)
    public bool randomStart = false; // 시작 위치를 랜덤으로 설정할지 여부
    private float random = 0;

    private Vector3 startPosition;  // 시작 위치

    // Start is called before the first frame update
    void Awake()
    {
        startPosition = transform.position;  // 초기 위치 저장

        // 랜덤 시작 위치 설정 (randomStart가 true일 경우)
        if (randomStart)
            random = Random.Range(0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        // y축을 기준으로 sin 파형을 이용하여 위아래로 움직이도록 설정
        float offset = limit * Mathf.Sin((Time.time + random) * speed);
        
        // 이동된 위치 계산 후, x와 z는 그대로 두고 y값만 변경
        transform.position = new Vector3(startPosition.x, startPosition.y + offset, startPosition.z);
    }
}
