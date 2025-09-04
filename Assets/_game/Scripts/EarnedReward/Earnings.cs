using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earnings : MonoBehaviour
{
    [SerializeField] Transform uiRewardContentTransform;
    [SerializeField] UiEarnedRewardContentItem uiRewardContentItemPrefab;
    public List<UiEarnedRewardContentItem> rewards = new List<UiEarnedRewardContentItem>();

    public void EarnReward(RewardSO rewardSo, int multiplier)
    {
        var exist = RewardExist(rewardSo.id);
        if (exist.exist)
        {
            rewards[exist.listId].AddAmount(multiplier);
            return;
        }
        var content =  Instantiate(uiRewardContentItemPrefab, uiRewardContentTransform);
        content.Init(rewardSo.sprite,multiplier,rewardSo.id);
        rewards.Add(content);
    }

    (bool exist,int listId) RewardExist(uint id)
    {
        for (int i = 0; i < rewards.Count; i++)
        {
            if (rewards[i].id == id) return (true,i);
        }
        return (false,0);
    }
}