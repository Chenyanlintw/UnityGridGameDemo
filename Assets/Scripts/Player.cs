using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 繼承自 GridObject 類別
public class Player : GridObject
{
    void Start()
    {

    }

    void Update()
    {
        // 依格子座標移動位置
        UpdatePosition();

        // 依 FaceDir 旋轉方向
        UpdateRotation();
    }


    void UpdatePosition()
    {
        // 轉換格子座標
        Vector3 targetPos = CellToPosition(CellX, CellY, OffsetY);

        // 漸漸移動
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.2f);
    }

    void UpdateRotation()
    {
        // 依 FaceDir 旋轉方向
        if (FaceDir == FaceDirection.Up)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (FaceDir == FaceDirection.Down)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (FaceDir == FaceDirection.Right)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (FaceDir == FaceDirection.Left)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }

}
