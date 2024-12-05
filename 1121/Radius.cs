using UnityEngine;

public class Radius  : MonoBehaviour
{
    SphereCollider myCollider = new SphereCollider();
    
    void Start()
    {
        Rigidbody myRigidbody = GetComponent<Rigidbody>();
        Debug.Log("UseGravity: " + myRigidbody.useGravity);
        myCollider = GetComponent<SphereCollider>();
    }
    
    void Update()
    {
        myCollider.radius = myCollider.radius + 0.01f;
    }

}
