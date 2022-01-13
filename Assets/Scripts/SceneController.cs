using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    // Prefab 參考（供複製使用）
    public GridObject PlayerPF;
    public GridObject WallPF;
    public GridObject CoinPF;

    // 玩家物件實體（遊戲開始時由 PlayerPF 複製產生）
    private GridObject player;

    // 地圖資料陣列
    // 0 = 路
    // 1 = 牆壁
    // 2 = 金幣
    private int[,] Map = new int[10, 10] {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 2, 1 },
        { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
        { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 0, 0, 0, 1, 1, 1, 0, 0, 1 },
        { 1, 1, 1, 0, 1, 0, 0, 0, 0, 1 },
        { 0, 2, 0, 0, 1, 0, 1, 0, 0, 1 },
        { 0, 0, 0, 0, 1, 0, 1, 0, 0, 1 },
        { 1, 1, 1, 1, 1, 2, 1, 1, 1, 1 }
    };


    void Start()
    {
        // 設定此地圖參數（影響所有繼承自 GridObject 的類別）
        GridObject.WorldOffsetX = -50 + 5;
        GridObject.WorldOffsetY = 50 - 5;
        GridObject.WorldRatio = 10;

        // 建立玩家物件實體
        player = Instantiate<GridObject>(PlayerPF);
        player.SetCell(3, 3, true);

        // 產生初始地圖物件
        InitMap();
    }

    void Update()
    {
        // 玩家控制
        ControlPlayer();
    }


    // 建立初始地圖物件
    void InitMap()
    {
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                // 取得格子內編號
                int cellVal = Map[y, x];

                // 1 = 牆壁
                if (cellVal == 1)
                {
                    GridObject wall = Instantiate<GridObject>(WallPF);
                    wall.SetCell(x, y, true);
                }

                // 2 = 錢幣
                if (cellVal == 2)
                {
                    GridObject coin = Instantiate<GridObject>(CoinPF);
                    coin.SetCell(x, y, true);
                    Map[y, x] = 0; // 建立後設為 0 （讓玩家可走過）
                }
            }
        }
    }

    void ControlPlayer()
    {
        // 按下左方向鍵
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // 角色轉向
            player.FaceDir = FaceDirection.Left;

            // 確認玩家往左一格還在陣列之內
            if (player.CellX - 1 >= 0)
            {
                // 取得將要前往的左一格數值
                int cellVal = Map[player.CellY, player.CellX - 1];

                // 判斷是路才走過去
                if (cellVal == 0)
                {
                    player.CellX -= 1;
                }
            }
        }

        // 按下右方向鍵
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.FaceDir = FaceDirection.Right;
            if (player.CellX + 1 < Map.GetLength(1))
            {
                int cellVal = Map[player.CellY, player.CellX + 1];
                if (cellVal == 0)
                {
                    player.CellX += 1;
                }
            }
        }

        // 按下上方向鍵
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.FaceDir = FaceDirection.Up;
            if (player.CellY - 1 >= 0)
            {
                int cellVal = Map[player.CellY - 1, player.CellX];
                if (cellVal == 0)
                {
                    player.CellY -= 1;
                }
            }
        }

        // 按下下方向鍵
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.FaceDir = FaceDirection.Down;
            if (player.CellY + 1 < Map.GetLength(0))
            {
                int cellVal = Map[player.CellY + 1, player.CellX];
                if (cellVal == 0)
                {
                    player.CellY += 1;
                }
            }
        }
    }
}
