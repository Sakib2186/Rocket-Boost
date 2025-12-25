using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            loadNextLevel();
        }
    }

    private void loadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextSceneNumber = currentScene + 1;
        if (nextSceneNumber == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneNumber = 0;
        }
        SceneManager.LoadScene(nextSceneNumber);
    }

}
