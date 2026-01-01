using UnityEngine;

public class Endtrigger : MonoBehaviour
{
    public GameManager gameManager;


    void OnTriggerEnter2D(Collider2D col)
    {
            Debug.Log("Finish line");
            gameManager.CompleteLevel();
    }
}