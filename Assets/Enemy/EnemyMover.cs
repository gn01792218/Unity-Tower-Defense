using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> movePaths = new List<WayPoint>(); //儲存移動路徑的所有座標點
    [SerializeField] [Range(0,5)] float moveSpeed = 1f; //移動的速度，只能介於0~5
    void Start()
    {
        StartCoroutine(FollowPath());  //Invoke的新寫法，可以避免引用字串
    }

    IEnumerator FollowPath()
    {
        foreach (WayPoint wayPoint in movePaths)
        {
            Vector3 startPosition = transform.position;  //移動起點
            Vector3 endPosition = wayPoint.transform.position;  //移動終點
            float travelPercentage = 0f; //值介於0(起點)-1(終點)之間，根據time.deltaTime刷新

            transform.LookAt(endPosition); //讓物件面朝終點方向

            //進行"過間"動畫
            while(travelPercentage < 1f)
            {
                travelPercentage += Time.deltaTime * moveSpeed; //更新travelPercentage
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercentage); //使用Lerp方法製作出過間動畫
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
