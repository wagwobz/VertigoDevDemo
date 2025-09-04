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

    [SerializeField] Sprite bronzePinSprite;
    [SerializeField] Sprite silverPinSprite;
    [SerializeField] Sprite goldenPinSprite;

    int _currentLevel = 1;

    public (RewardSetSO rewardSetSo, Sprite spinnerSprite, Sprite pinSprite, int multiplier) GetRewardSet(int currentLevel)
    {
        print(currentLevel);
        var multiplier = 1;
        if (currentLevel == 1)
        {
            //startingSafeZone
            return (startingRewardSet, silverSpinnerSprite, silverPinSprite, multiplier);
        }

        if (currentLevel % 30 == 0)
        {
            //superZone
            multiplier = 2 * (currentLevel / 5 + 1);
            return (goldenRewardSet, goldenSpinnerSprite, goldenPinSprite ,multiplier);
        }


        //safeZone and remaining regular zones
        multiplier = currentLevel / 5 + 1;
        var modulo = currentLevel % 5;
        var rewardSet = modulo switch
        {
            1 => bronzeRewardSets[0],
            2 => bronzeRewardSets[1],
            3 => bronzeRewardSets[2],
            4 => bronzeRewardSets[3],
            _ => silverRewardSet
        };
        var spinnerSprite = modulo switch
        {
            0 => silverSpinnerSprite,
            _ => bronzeSpinnerSprite,
        };
        var pinSprite = modulo switch
        {
            0 => silverPinSprite,
            _ => bronzePinSprite
        };
        return (rewardSet, spinnerSprite, pinSprite, multiplier);
    }
}