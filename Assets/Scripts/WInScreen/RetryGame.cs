using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
{
   public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }
}
