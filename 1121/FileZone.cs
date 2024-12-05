using UnityEngine;
using UnityEngine.SceneManagement;
public class FileZone : MonoBehaviour

{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Ball")
        {
            GameObject.Find("GameManager").SendMessage("RestartGame");
        }   
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
