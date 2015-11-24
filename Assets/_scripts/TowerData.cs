using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]

public class TowerLevel
{
    public int _cost;
    public GameObject _visualization;
}

public class TowerData : MonoBehaviour {
    public List<TowerLevel> levels;
    private TowerLevel currentLevel;

    

    void OnEnable() //Sets tower level to 0 on placement
    {
        CurrentLevel = levels[0];
    }

    public TowerLevel CurrentLevel
    {
        get
        {
            return currentLevel; // gets towers current level
        }
        set
        {
            currentLevel = value;
            int currentLevelIndex = levels.IndexOf(currentLevel);

            GameObject levelVisualization = levels[currentLevelIndex]._visualization;
            for (int i = 0; i < levels.Count; i++)
            {
                if (levelVisualization != null)
                {
                    if (i == currentLevelIndex)
                    {
                        levels[i]._visualization.SetActive(true); //turns the sprite of the matching level active
                    }
                    else
                    {
                        levels[i]._visualization.SetActive(false); // turns the sprite of other levels inactive
                    }
                }
            }
        }
    }

    public TowerLevel getNextLevel()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        int maxLevelIndex = levels.Count - 1;
        if (currentLevelIndex < maxLevelIndex)
        {
            return levels[currentLevelIndex + 1];
        }
        else
        {
            return null; //If tower is max level returns null
        }
    }

    public void increaseLevel()//goes to the next level
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        if (currentLevelIndex < levels.Count - 1)
        {
            CurrentLevel = levels[currentLevelIndex + 1];
        }
    }
}




