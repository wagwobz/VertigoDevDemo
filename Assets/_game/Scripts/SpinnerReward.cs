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

    public void Init(RewardSO rewardSo, int multiplier)
    {
        UpdateValues(rewardSo, multiplier*rewardSo.baseMultiplier);
    }

    void OnValidate()
    {
        UpdateValues(rewardSo,amount*rewardSo.baseMultiplier);
    }

    void UpdateValues(RewardSO rewardSo,int amount)
    {
        if (rewardSo == null) return;
        rewardImage.sprite = rewardSo.sprite;
        rewardTmpUgui.text = $"x{amount}";
    }
}
