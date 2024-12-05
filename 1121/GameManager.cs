using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    int coinCount = 0;
    public TextMeshProUGUI coinText;   
    void GetCoin()
    {
        coinCount++;
        coinText.text = coinCount + "";
        Debug.Log("동전 : " + coinCount);

    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    void RedCoinStart(){
        DestroyObstacles();
    }
    void DestroyObstacles()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i]);
        }
    }
}
