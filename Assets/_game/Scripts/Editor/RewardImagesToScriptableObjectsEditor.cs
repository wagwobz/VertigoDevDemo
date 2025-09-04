using System;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

[CustomEditor(typeof(RewardImagesToScriptableObjects))]
public class RewardImagesToScriptableObjectsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        RewardImagesToScriptableObjects ritso = (RewardImagesToScriptableObjects)target;
        if (GUILayout.Button("Create Scriptable Objects"))
        {
            CreateScriptableObjects(ritso.sprites);
        }
    }

    void CreateScriptableObjects(Sprite[] sprites)
    {
        var baseMultiplier = 1;
        var startingIdIndex = (uint) Random.Range(110, 140);
        for (uint i = 0; i < sprites.Length; i++)
        {
            var reward = ScriptableObject.CreateInstance<RewardSO>();
            var rewardName = sprites[i].name;
            reward.id = startingIdIndex + i;
            reward.sprite = sprites[i];
            reward.baseMultiplier = baseMultiplier;
            
            AssetDatabase.CreateAsset(reward, $"Assets/_game/Rewards/RewardSOs/{rewardName}.asset");
            AssetDatabase.SaveAssets();
            Debug.Log($"Created Asset: Assets/_game/Rewards/RewardSOs/{rewardName}.asset");
        }
    }
}