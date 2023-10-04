using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //引用Text Pro 物件
[ExecuteAlways]  //標示此腳本會在edit mode 和 play mode中執行
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;  //座標渲染文字標籤
    Vector2Int coordinates = new Vector2Int(); //棋盤格的座標 ( 雖是3D，但棋盤格只會使用到平面座標系統 )
    void Awake() //遊戲執行時的最初生命週期
    {
        label = GetComponent<TextMeshPro>(); //獲取label屬性
        RenderCoordinates(); //初始化渲染每個方塊的座標
    }
    void Update()
    {
        if(!Application.isPlaying)
        {
            // 以下代碼 只會於 Edit mode 執行
            RenderCoordinates(); //渲染當下座標
            RenderPartentName(); //更改父層物件名稱，方便於Edit mode中察看!
        }
    }

    void RenderPartentName()
    {
        transform.parent.name = label.text;
    }

    void RenderCoordinates()
    {
        //注意 : 由於我們的棋盤格有設置snaping的值，所以獲取遊戲世界座標後，必須要除以snapping設定值，才是正卻座標唷~
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z); //注意 : 我們的棋盤格是在D世界中，3D世界的Y軸是由Z軸表現
        label.text = coordinates.x + "," + coordinates.y;
    }
}