using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpinnerReward : MonoBehaviour
{
    public RewardSO rewardSo;
    public Image rewardImage;
    public TextMeshProUGUI rewardTmpUgui;

    [SerializeField] bool fromScriptableObject;
    void Awake()
    {
        UpdateValues(rewardSo);
    }

    void OnValidate()
    {
        UpdateValues(rewardSo);
    }

    void UpdateValues(RewardSO rewardSo, int amount = 1)
    {
        if (rewardSo == null || !fromScriptableObject) return;
        rewardImage.sprite = rewardSo.sprite;
        rewardTmpUgui.text = $"x{amount}";
    }
}
