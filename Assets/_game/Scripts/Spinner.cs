using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spinner : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Spin();
        }
    }

    [SerializeField] int numberOfTurns = 7;
    [SerializeField] float spinDuration = 7;
    [SerializeField] Ease ease = Ease.InOutQuart;
    [Range(0, 22.4f)] [SerializeField] float overShootAngleMax = 20f;
    [Range(0, 22.3f)] [SerializeField] float overShootAngleMin = 10f;


    void Spin()
    {
        var overShootAngleAbsolute = Random.Range(overShootAngleMin, overShootAngleMax);
        var positiveNegativeRandom = Random.Range(0, 2);
        var overShootAngle = positiveNegativeRandom == 0 ? -overShootAngleAbsolute: overShootAngleAbsolute;
        
        var rewardIndex = Random.Range(0, 8);
        print($"reward:{rewardIndex},overShoot:{overShootAngle}");
        var targetRotationAngle = numberOfTurns * 360f - rewardIndex * 45f + overShootAngle; 
        print($"targetRotationAngle:{targetRotationAngle}");
        var targetRotationVector = new Vector3(0, 0, -targetRotationAngle);
        var targetOverShootCorrection = new Vector3(0, 0, overShootAngle);
        
        transform.DORotate(targetRotationVector, 7f, RotateMode.FastBeyond360).SetEase(ease).OnComplete(() =>
        {
            transform.DORotate(targetOverShootCorrection, 1f, RotateMode.WorldAxisAdd).SetEase(Ease.OutBounce);
        });
    }
}