using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneNavigator : MonoBehaviour
{
    int currentSceneIndex;

    int sceneCount { get { return SceneManager.sceneCountInBuildSettings; } }

    float changeCooldown = 0.1f;
    float timeLeftForChange;

    IDictionary<string, bool> downAxes = new Dictionary<string, bool>();

    void Awake()
    {
        if (FindObjectsOfType<SceneNavigator>().Length == 1)
        {
            DontDestroyOnLoad(this);
            downAxes.Add("Next", Input.GetAxis("Next") > 0.4f);
            downAxes.Add("Previous", Input.GetAxis("Previous") > 0.4f);
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    void Update()
    {
        timeLeftForChange -= Time.deltaTime;
        if (timeLeftForChange > 0)
            return;
        
        if (GetAxisDown("Next"))
        {
            LoadNextScene();
        }
        else if (GetAxisDown("Previous"))
        {
            LoadPreviousScene();
        }

    }

    void LoadNextScene()
    {
        currentSceneIndex++;
        currentSceneIndex %= sceneCount;
        timeLeftForChange = changeCooldown;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadPreviousScene()
    {
        currentSceneIndex--;
        if (currentSceneIndex < 0)
            currentSceneIndex = sceneCount - 1;

        timeLeftForChange = changeCooldown;
        SceneManager.LoadScene(currentSceneIndex);
    }

    bool GetAxisDown(string axis)
    {
        bool currentlyDown = Input.GetAxis(axis) > 0.4f;
        bool justDown = !downAxes[axis] && currentlyDown;
        Debug.Log(currentlyDown + " " + downAxes[axis] + " " + justDown);
        downAxes[axis] = currentlyDown;
        return justDown;
    }
}
