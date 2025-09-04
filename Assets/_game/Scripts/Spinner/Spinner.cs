using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Spinner : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] SpinnerReward[]  rewards;
    [SerializeField] Image spinnerBackground;
    [SerializeField] Image pinImage;
    [SerializeField] int numberOfTurns = 7;
    [SerializeField] float spinDuration = 7;
    [SerializeField] Ease ease = Ease.InOutQuart;
    [Range(0, 22.4f)] [SerializeField] float overShootAngleMax = 20f;
    [Range(0, 22.3f)] [SerializeField] float overShootAngleMin = 10f;
    bool _spinning;
    int _currentRewardIndex;
    public void Init(RewardSetSO rewardSetSO,int multiplier,Sprite spinnerSprite, Sprite pinSprite)
    {
        rewards = GetComponentsInChildren<SpinnerReward>();
        for (int i = 0; i < rewards.Length; i++)
        {
            rewards[i].Init(rewardSetSO.rewards[i], multiplier);
        }
        spinnerBackground.sprite = spinnerSprite;
        pinImage.sprite = pinSprite;
    }
    
    public void Spin()
    {
        if (_spinning) return;
        _spinning = true;
        var overShootAngleAbsolute = Random.Range(overShootAngleMin, overShootAngleMax);
        var positiveNegativeRandom = Random.Range(0, 2);
        var overShootAngle = positiveNegativeRandom == 0 ? -overShootAngleAbsolute: overShootAngleAbsolute;
        
        var rewardIndex = Random.Range(0, 8);
        _currentRewardIndex = rewardIndex;
        print($"reward:{rewardIndex},overShoot:{overShootAngle}");
        var targetRotationAngle = numberOfTurns * 360f - rewardIndex * 45f + overShootAngle; 
        print($"targetRotationAngle:{targetRotationAngle}");
        var targetRotationVector = new Vector3(0, 0, -targetRotationAngle);
        var targetOverShootCorrection = new Vector3(0, 0, overShootAngle);
        
        transform.DORotate(targetRotationVector, 7f, RotateMode.FastBeyond360).SetEase(ease).OnComplete(() =>
        {
            transform.DORotate(targetOverShootCorrection, 1f, RotateMode.WorldAxisAdd).SetEase(Ease.OutBounce).onComplete += Result;
        });
    }

    void Result()
    {
        StartCoroutine(EndWait());
    }

    IEnumerator EndWait()
    {
        yield return new WaitForSeconds(1);
        _spinning = false;
        var currentReward = rewards[_currentRewardIndex];
        var (rewardSo, rewardMultiplier) = currentReward.GetRewardInfo();
        gameManager.LevelEnd(rewardSo, rewardMultiplier);
    }
}