using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform topCannon; //砲物件
    Transform target; //要看向的目標
    // Start is called before the first frame update
    void Start()
    {
        target = FindAnyObjectByType<Enemy>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        topCannon.LookAt(target);
    }
}
