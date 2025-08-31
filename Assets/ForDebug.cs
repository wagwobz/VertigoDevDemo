using System.Linq;
using UnityEngine;

public class ForDebug : MonoBehaviour
{
#if UNITY_EDITOR
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Space key pressed");
            var rewards = GameObject.FindObjectsOfType<UiSpinnerRewardPreserveRotation>(false);
            var topObject = rewards.OrderByDescending(o => o.transform.position.y).FirstOrDefault();
            print(topObject.gameObject.name);
        }
    } 
#endif
    
}