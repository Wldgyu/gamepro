using UnityEngine;

public class HiyokoCreater : MonoBehaviour
{
    public GameObject obj;
    public float interval = 3.0f;
    public float time;

    void Update()
    {
        if(DeathZone.dead == false)
        {
            time += Time.deltaTime;
            if(time >= interval)
            {
                time = 0;
                GameObject hiyoko = Instantiate(obj) as GameObject;
                hiyoko.transform.localPosition = new Vector3(
                    Random.Range(-3.0f, 3.0f),
                    Random.Range(1.0f, 5.0f),
                    Random.Range(17.0f, 20.0f)
                );
                Score.score++;
            }
        }
    }
}
