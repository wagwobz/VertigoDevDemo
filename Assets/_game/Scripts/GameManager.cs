using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] RewardManager rewardManager;
    [SerializeField] Spinner spinner;

    int _currentLevel = 0;
    
    void Awake()
    {
        
        PrepareLevel();
    }

    void PrepareLevel()
    {
        _currentLevel++;
        PrepareSpin(_currentLevel);
    }

    void PrepareSpin(int currentLevel)
    {
        var rewardSet = rewardManager.GetRewardSet(currentLevel);
        spinner.Init(rewardSet.rewardSetSo, rewardSet.multiplier, rewardSet.spinnerSprite);
    }

    public void LevelEnd(RewardSO rewardSo, int multiplier)
    {
        if (rewardSo.id == 666)
        {
            //fail
            print("Fail");
            return;
        }
        ClaimReward(rewardSo, multiplier);
        print("Reward Claimed");
        
    }

    void ClaimReward(RewardSO rewardSo, int multiplier)
    {
        
    }
}