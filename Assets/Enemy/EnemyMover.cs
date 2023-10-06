using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Tile> pathTiles = new List<Tile>(); //儲存移動路徑的所有座標點
    [SerializeField] [Range(0,5)] float moveSpeed = 1f; //移動的速度，只能介於0~5
    void Start()
    {
        LoadPath();
        InitPosition();
        StartCoroutine(FollowPath());  //Invoke的新寫法，可以避免引用字串
    }

    void LoadPath()
    {
        Transform path = GameObject.FindGameObjectWithTag("Path").transform; //找到場景中的Path物件，其下有各個可供移動的path tile

        //迭代將每個tile裝進pathTiles
        foreach (Transform tile in path)
        {
            pathTiles.Add(tile.GetComponent<Tile>());
        }
    }
    void InitPosition()
    {
        gameObject.transform.position = pathTiles[0].transform.position;
    }


    IEnumerator FollowPath()
    {
        foreach (Tile path in pathTiles)
        {
            Vector3 startPosition = transform.position;  //移動起點
            Vector3 endPosition = path.transform.position;  //移動終點
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
        Destroy(gameObject);
    }
}
