using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] UiButton spinButton;
    [SerializeField] UiButton claimAllButton;
    [SerializeField] UiButton restartButton;
    
    public UiButton SpinButton => spinButton;
    public UiButton ClaimAllButton => claimAllButton;
    public UiButton RestartButton => restartButton;
    
    
    
}