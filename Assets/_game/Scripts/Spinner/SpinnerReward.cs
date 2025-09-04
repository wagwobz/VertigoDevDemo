using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpinnerReward : MonoBehaviour
{
    [SerializeField] RewardSO rewardSo;
    [SerializeField] Image rewardImage;
    [SerializeField] TextMeshProUGUI rewardTmpUgui;
    [SerializeField] int amount = 1;
    [SerializeField] int currentMultiplier = 0;
    public void Init(RewardSO rewardSo, int multiplier)
    {
        currentMultiplier = multiplier*rewardSo.baseMultiplier;
        UpdateValues(rewardSo, currentMultiplier);
    }

    public (RewardSO rewardSo, int multiplier) GetRewardInfo()
    {
        return (rewardSo,currentMultiplier);
    }

    void OnValidate()
    {
        UpdateValues(rewardSo,amount*rewardSo.baseMultiplier);
    }

    void UpdateValues(RewardSO rewardSo,int amount)
    {
        if (rewardSo == null) return;
        this.rewardSo = rewardSo;
        rewardImage.sprite = rewardSo.sprite;
        rewardTmpUgui.text = $"x{amount}";
    }
}
