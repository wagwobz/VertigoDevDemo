using System;
using System.Collections;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] RewardManager rewardManager;
    [SerializeField] Spinner spinner;
    [SerializeField] ButtonManager buttonManager;
    [SerializeField] UiFailPanel uiFailPanel;
    [SerializeField] Earnings earnings;
    [SerializeField] UiLevelScrollView levelScrollView;

    int _currentLevel = 0;
    
    void Awake()
    {
        Application.targetFrameRate = 60;
        PrepareButtons();
        PrepareLevel();
    }

    void Start()
    {
        levelScrollView.Init(_currentLevel);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            PrepareLevel();
        }
    }

    void PrepareLevel()
    {
        
        _currentLevel++;
        levelScrollView.UpdateAnchorPosition(_currentLevel);
        StartCoroutine(PrepareSpin(_currentLevel));
    }

    IEnumerator PrepareSpin(int currentLevel)
    {
        var rewardSet = rewardManager.GetRewardSet(currentLevel);
        spinner.Init(rewardSet.rewardSetSo, rewardSet.multiplier, rewardSet.spinnerSprite, rewardSet.pinSprite);
        
        yield return new WaitForSeconds(1f);
        
        buttonManager.SpinButton.gameObject.SetActive(true);
        if (currentLevel > 1) buttonManager.ClaimAllButton.gameObject.SetActive(true);
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
        earnings.EarnReward(rewardSo, multiplier);
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

    void ClaimAllRewards()
    {
        Application.Quit();
        Restart();
    }

    void Spin()
    {
        buttonManager.SpinButton.gameObject.SetActive(false);
        buttonManager.ClaimAllButton.gameObject.SetActive(false);
        levelScrollView.SnapBackOnSpin();
        spinner.Spin();
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}