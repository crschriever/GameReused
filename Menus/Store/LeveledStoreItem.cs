using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LeveledStoreItem
{
    public string ID;
    public Level[] levels;
    public float DEFAULT_VALUE;

    [System.Serializable]
    public class Level
    {
        public string label;
        public float value;
        public int cost;
    }

    public Level GetCurrentLevel()
    {
        int index = PlayerPrefs.GetInt(ID);
        return levels[index - 1];
    }

    public Level GetNextLevel()
    {
        if (MaxedOut())
        {
            return null;
        }

        int index = PlayerPrefs.GetInt(ID);
        return levels[index];
    }

    public void PurchaseNextLevel()
    {
        int index = PlayerPrefs.GetInt(ID);
        PlayerPrefs.SetInt(ID, index + 1);
    }

    public bool MaxedOut()
    {
        return PlayerPrefs.GetInt(ID) >= levels.Length;
    }

    public float GetCurrentValue()
    {
        int index = PlayerPrefs.GetInt(ID);
        if (index == 0)
        {
            return DEFAULT_VALUE;
        }

        return GetCurrentLevel().value;
    }
}
