using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
internal class RewardSetSO : ScriptableObject
{
    public int Level;
    public List<RewardSO> Rewards;
}