using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject prefab;
    public float power;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = LoadBullet();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 dir = ray.direction.normalized;

            bullet.GetComponent<Rigidbody>().linearVelocity = dir * power;
        }
    }

    GameObject LoadBullet()
    {
        GameObject bullet = GameObject.Instantiate(prefab) as GameObject;

        bullet.transform.parent = transform;
        bullet.transform.localPosition = Vector3.zero;

        return bullet;
    }
}
