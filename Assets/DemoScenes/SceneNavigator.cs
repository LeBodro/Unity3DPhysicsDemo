using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    int currentSceneIndex;

    int sceneCount { get { return SceneManager.sceneCount; } }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            LoadNextScene();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            LoadPreviousScene();
        }
    }

    void LoadNextScene()
    {
        currentSceneIndex++;
        currentSceneIndex %= sceneCount;

        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadPreviousScene()
    {
        currentSceneIndex--;
        if (currentSceneIndex < 0)
            currentSceneIndex = sceneCount - 1;

        SceneManager.LoadScene(currentSceneIndex);
    }
}
