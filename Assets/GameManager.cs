using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;

   public void CompleteLevel()
    {
        Debug.Log("Game manager");
        completeLevelUI.SetActive(false);

    }
}