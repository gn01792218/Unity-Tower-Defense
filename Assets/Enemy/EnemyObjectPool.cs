using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] float enemyGenerateWaitTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateEnemy());
    }

    IEnumerator GenerateEnemy()
    {
        while (true)
        {
            Instantiate(enemyPrefab, transform); //第二個參數表示實體化於parent物件底下
            yield return new WaitForSeconds(enemyGenerateWaitTime);
        }
    }

}
