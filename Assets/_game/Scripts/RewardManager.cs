using System;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [SerializeField] RewardSetSO startingRewardSet;
    [SerializeField] RewardSetSO[] bronzeRewardSets;
    [SerializeField] RewardSetSO silverRewardSet;
    [SerializeField] RewardSetSO goldenRewardSet;


    [SerializeField] Sprite bronzeSpinnerSprite;
    [SerializeField] Sprite silverSpinnerSprite;
    [SerializeField] Sprite goldenSpinnerSprite;

    int _currentLevel = 1;

    public (RewardSetSO rewardSetSo, Sprite spinnerSprite, int multiplier) GetRewardSet(int currentLevel)
    {
        var multiplier = 1;
        if (currentLevel == 1)
        {
            //startingSafeZone
            return (startingRewardSet, silverSpinnerSprite, multiplier);
        }

        if (currentLevel % 30 == 0)
        {
            //superZone
            multiplier = 4 * (currentLevel / 5 + 1);
            return (goldenRewardSet, goldenSpinnerSprite, multiplier);
        }


        //safeZone and remaining regular zones
        multiplier = currentLevel / 5 + 1;
        var modulo = currentLevel % 5;
        var rewardSet = modulo switch
        {
            0 => silverRewardSet,
            1 => bronzeRewardSets[0],
            2 => bronzeRewardSets[1],
            3 => bronzeRewardSets[2],
            4 => bronzeRewardSets[3],
            _ => bronzeRewardSets[0]
        };
        var spinnerSprite = modulo switch
        {
            0 => silverSpinnerSprite,
            _ => bronzeSpinnerSprite,
        };
        return (rewardSet, spinnerSprite, multiplier);
    }
}