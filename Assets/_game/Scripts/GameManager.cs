using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] RewardManager rewardManager;
    [SerializeField] Spinner spinner;

    int _currentLevel = 1;
    
    void Awake()
    {
        
        PrepareSpin(_currentLevel);
    }

    void PrepareSpin(int currentLevel)
    {
        var rewardSet = rewardManager.GetRewardSet(_currentLevel);
        spinner.Init(rewardSet.rewardSetSo, rewardSet.multiplier, rewardSet.spinnerSprite);
    }
}