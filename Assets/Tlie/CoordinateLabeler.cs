using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //引用Text Pro 物件
[ExecuteAlways]  //標示此腳本會在edit mode 和 play mode中執行
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultLabelColor = Color.white;
    [SerializeField] Color blockedLabelColor = Color.red;
    TextMeshPro label;  //座標渲染文字標籤
    Vector2Int coordinates = new Vector2Int(); //棋盤格的座標 ( 雖是3D，但棋盤格只會使用到平面座標系統 )
    Tile tile;
    void Awake() //遊戲執行時的最初生命週期
    {
        tile = GetComponentInParent<Tile>(); //獲取父層的Tlie物件
        label = GetComponent<TextMeshPro>(); //獲取label屬性
        RenderCoordinates(); //初始化渲染每個方塊的座標
        if (Application.isPlaying)
        {
            label.enabled = false; // 預設下不開啟Label
        }
    }
    void Update()
    {
        ToogleColorListener();
        if (Application.isPlaying)
        {
            ToogleLabelListener(); //監聽是否開啟Label
        }
        else
        { // 以下代碼 只會於 Edit mode 執行
            RenderCoordinates(); //渲染當下座標
            RenderPartentName(); //更改父層物件名稱，方便於Edit mode中察看!
        }
    }

    private void ToogleColorListener()
    {
        if (tile.IsPlaceable)
        {
            label.color = defaultLabelColor;
        }
        else
        {
            label.color = blockedLabelColor;
        }
    }

    void ToogleLabelListener()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
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