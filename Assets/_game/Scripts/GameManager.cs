using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] RewardManager rewardManager;
    [SerializeField] Spinner spinner;
    [SerializeField] ButtonManager buttonManager;
    [SerializeField] UiFailPanel uiFailPanel;

    int _currentLevel = 0;
    
    void Awake()
    {
        PrepareButtons();
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
        buttonManager.SpinButton.gameObject.SetActive(true);
        buttonManager.ClaimAllButton.gameObject.SetActive(true);
        
        //activate spin button and claim all button
    }

    public void LevelEnd(RewardSO rewardSo, int multiplier)
    {
        if (rewardSo.id == 666)
        {
            Fail();
            //fail panel
            print("Fail");
            return;
        }
        ClaimReward(rewardSo, multiplier);
        PrepareLevel();
        print("Reward Claimed");
        
    }

    void Fail()
    {
        uiFailPanel.gameObject.SetActive(true);
    }

    void PrepareButtons()
    {
        buttonManager.SpinButton.Button.onClick.AddListener(Spin);
        buttonManager.ClaimAllButton.Button.onClick.AddListener(ClaimAllRewards);
        buttonManager.RestartButton.Button.onClick.AddListener(Restart);
    }

    void ClaimReward(RewardSO rewardSo, int multiplier)
    {
        print("Claiming reward");
    }

    void ClaimAllRewards()
    {
        print("Claim all rewards");
    }

    void Spin()
    {
        buttonManager.SpinButton.gameObject.SetActive(false);
        buttonManager.ClaimAllButton.gameObject.SetActive(false);
        //deactivate spin button and claim rewards button
        spinner.Spin();
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}