using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator animator;
    private int FIRST_SCENE_INDEX;
    private const string ACTIVE_SCENE_INDEX_KEY = "activeSceneIndex";
    private const string START_TRIGGER_KEY = "Start";
    private const string FIRST_SCENE_NAME = "MazeScene1";

    public void Awake()
    {
        FIRST_SCENE_INDEX = SceneManager.GetSceneByName(FIRST_SCENE_NAME).buildIndex;
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevelCoroutine(SceneManager.GetActiveScene().buildIndex + 1));

    }

    public void LoadActiveLevel()
    {
        int activeLevelIndex = FIRST_SCENE_INDEX;
        if (PlayerPrefs.HasKey(ACTIVE_SCENE_INDEX_KEY))
        {
            activeLevelIndex = PlayerPrefs.GetInt(ACTIVE_SCENE_INDEX_KEY);
            Debug.Log("GET scene: " + PlayerPrefs.GetInt(ACTIVE_SCENE_INDEX_KEY));
        }
        Debug.Log("GET scene: " + PlayerPrefs.GetInt(ACTIVE_SCENE_INDEX_KEY));

        StartCoroutine(LoadLevelCoroutine(activeLevelIndex));

    }

    public void RestartCurrentLevel()
    {
        StartCoroutine(LoadLevelCoroutine(SceneManager.GetActiveScene().buildIndex));
    }

    public void ResetGame()
    {
        StartCoroutine(LoadLevelCoroutine(FIRST_SCENE_INDEX));
    }

    private IEnumerator LoadLevelCoroutine(int levelIndex)
    {
        animator.SetTrigger(START_TRIGGER_KEY);

        yield return new WaitForSeconds(1);

        PlayerPrefs.SetInt(ACTIVE_SCENE_INDEX_KEY, levelIndex);
        Debug.Log("Save scene: " + PlayerPrefs.GetInt(ACTIVE_SCENE_INDEX_KEY));
        SceneManager.LoadScene(levelIndex);
    }


}
