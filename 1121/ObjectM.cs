using UnityEngine;

public class ObjectM : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Vector3 direction = transform.position - collision.gameObject.transform.position;
        direction = direction.normalized * 1000; 
        collision.gameObject.GetComponent<Rigidbody>().AddForce(direction);
    }

    float delta = 0f;

    void Start()
    {
    }
    float timeCount = 0;
    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount > 3)
        {
            Debug.Log("돌을 던져라");
            timeCount = 0;
        }
        float newXPosition = transform.localPosition.x + delta;
        transform.localPosition = new Vector3(
            newXPosition,
            transform.localPosition.y,
            transform.localPosition.z
        );

        if (transform.position.x < -9) 
        {
            delta = 0.01f;
        }
        else if (transform.position.x > 9) 
        {
            delta = -0.01f;
        }
    }

    void TestMethod(string objectName, int value)
    {
        Debug.Log($"TestMethod called with objectName: {objectName}, value: {value}");
    }
}
