using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tlie : MonoBehaviour
{
   [SerializeField] bool isPlaceable;
   [SerializeField] GameObject Tower; //砲塔物件藍圖
   public bool IsPlaceable { get{return isPlaceable;} }
    
   void OnMouseDown() {
    if(!isPlaceable){ return; } 
    Instantiate(Tower, transform.position, Quaternion.identity); //放置一個砲台於該Tlie上
    isPlaceable = false;
   }
}
