using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 用來設定方向的列舉
public enum FaceDirection
{
    Left, Right, Up, Down
}

// GridObject
// 所有在網格上的物件都繼承此類別
// 也定義一些可以共用的 static 成員＆方法
public class GridObject : MonoBehaviour
{
    // 座標中心位移＆比例設定
    // 採用 static，當被修改時，會影響全部 GridObject 物件
    static public float WorldOffsetX;
    static public float WorldOffsetY;
    static public float WorldRatio;

    // 格狀座標的 X, Y
    public int CellX;
    public int CellY;

    // 高度位移
    public float OffsetY;

    // 面向方向
    public FaceDirection FaceDir = FaceDirection.Down;


    // 指定座標
    public void SetCell(int cx, int cy, bool isChangePosition = false)
    {
        // 改變座標參數
        CellX = cx;
        CellY = cy;

        // 是否要把位置也移過去（瞬移）
        if (isChangePosition)
        {
            transform.position = CellToPosition(CellX, CellY, OffsetY);
        }
    }

    // 將 CellX,Y 轉換為場景上的 Position 座標
    static public Vector3 CellToPosition(int cx, int cy, float offsetY = 0)
    {
        float realX = WorldOffsetX + cx * WorldRatio;
        float realZ = WorldOffsetY - cy * WorldRatio;

        return new Vector3(realX, offsetY, realZ);
    }
}

