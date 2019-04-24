using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinReward : MonoBehaviour
{
    public int amount;

    // Update is called once per frame
    public void Reward()
    {
        MyIAPManager.instance.AddCurrency(amount);
    }
}
