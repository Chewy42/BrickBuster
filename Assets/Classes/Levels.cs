using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public Readouts Readouts;
    public List<GameObject> levels;
    private int currentLevel = 0;
    private GameObject levelGameObject;
    void Start()
    {
        levelGameObject = CreateLevel();
        UpdateLevelReadout();
    }

    public void GoToNextLevel(){
        currentLevel++;
        if(IsGameOver())
            return;
        LoadNextLevel();
    }

    public bool IsGameOver(){
        if (currentLevel == levels.Count)
            return true;
        return false;
    }

    private void LoadNextLevel()
    {
        if (levelGameObject != null)
        {
            Destroy(levelGameObject);
        }
        levelGameObject = CreateLevel();
        UpdateLevelReadout();
    }

    private GameObject CreateLevel()
    {
        return Instantiate(levels[currentLevel], levels[currentLevel].transform.position, Quaternion.identity);
    }

    private void UpdateLevelReadout(){
        Readouts.ShowLevel(currentLevel + 1);
    }

}
