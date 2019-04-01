using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RadioStoreItem
{
    public string ID;
    public int[] COST;
    public int DEFAULT;

    public bool IndexUnlocked(int index)
    {
        if (!PlayerPrefs.HasKey(ID + "_" + index))
        {
            return false;
        }
        return PlayerPrefs.GetInt(ID + "_" + index) >= 1;
    }

    public void UnlockIndex(int index)
    {
        PlayerPrefs.SetInt(ID + "_" + index, 1);
    }

    public int GetCurrentValue()
    {
        return PlayerPrefs.GetInt(ID);
    }

    public void SetIndex(int index)
    {
        PlayerPrefs.SetInt(ID, index);
    }
}
