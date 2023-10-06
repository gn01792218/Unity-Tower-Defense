using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
   [SerializeField] bool isPlaceable;
   [SerializeField] GameObject tower; //砲塔物件藍圖
   public bool IsPlaceable { get{return isPlaceable;} }
    
   void OnMouseDown() {
    if(!isPlaceable){ return; } 
    Instantiate(tower, transform.position, Quaternion.identity); //放置一個砲台於該Tlie上
    isPlaceable = false;
   }
}
