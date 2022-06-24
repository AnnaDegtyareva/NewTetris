using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public Tilemap tilemap { get; private set; }
    public Piece activePiece { get; private set; }

    public TetrominoData[] tetrominoes;
    public Vector2Int boardSize = new Vector2Int(10, 20);
    public Vector3Int spawnPosition = new Vector3Int(-1, 8, 0);

    [SerializeField] Text MoneyText;
    [SerializeField] public int money;

    int count = 1;

    //Skins for tetris

    [SerializeField] List<TetrominoData> Classic = new List<TetrominoData>();
    [SerializeField] List<TetrominoData> Stars = new List<TetrominoData>();
    [SerializeField] List<TetrominoData> Food = new List<TetrominoData>();
    [SerializeField] List<TetrominoData> Lego = new List<TetrominoData>();
    [SerializeField] List<TetrominoData> Flowers = new List<TetrominoData>();
    [SerializeField] List<TetrominoData> Hearts = new List<TetrominoData>();
    [SerializeField] List<TetrominoData> HelloKitty = new List<TetrominoData>();
    [SerializeField] List<TetrominoData> Crystals = new List<TetrominoData>();
    [SerializeField] List<TetrominoData> Meme = new List<TetrominoData>();


    public RectInt Bounds
    {
        get
        {
            Vector2Int position = new Vector2Int(-boardSize.x / 2, -boardSize.y / 2);
            return new RectInt(position, boardSize);
        }
    }

    private void Awake()
    {
        tilemap = GetComponentInChildren<Tilemap>();
        activePiece = GetComponentInChildren<Piece>();

        for (int i = 0; i < tetrominoes.Length; i++)
        {
            tetrominoes[i].Initialize();
        }
    }

    private void Start()
    {
        SpawnPiece();
        MoneyText.text = money.ToString();
    }

    public void SpawnPiece()
    {
        int random = Random.Range(0, tetrominoes.Length);
        TetrominoData data = tetrominoes[random];

        activePiece.Initialize(this, spawnPosition, data);

        if (IsValidPosition(this.activePiece, this.spawnPosition))
        {
            Set(this.activePiece);
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        this.tilemap.ClearAllTiles();
    }


    public void Set(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            tilemap.SetTile(tilePosition, piece.data.tile);
        }
    }

    public void Clear(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            tilemap.SetTile(tilePosition, null);
        }
    }

    public bool IsValidPosition(Piece piece, Vector3Int position)
    {
        RectInt bounds = this.Bounds;

        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + position;

            if (!bounds.Contains((Vector2Int)(tilePosition)))
            {
                return false; 
            }

            if (this.tilemap.HasTile(tilePosition))
            {
                return false;
            }
        }

        return true;
    }

    public void ClearLines()
    {
        RectInt bounds = this.Bounds;
        int row = bounds.yMin;

        while(row < bounds.yMax)
        {
            if (IsLineFull(row))
            {
                LineClear(row);
            }
            else
            {
                row++;
            }
        }
    }

    private bool IsLineFull(int row)
    {
        RectInt bounds = this.Bounds;

        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);

            if (!this.tilemap.HasTile(position))
            {
                return false;
            }
        }

        return true;
    }

    private void LineClear(int row)
    {
        RectInt bounds = this.Bounds;

        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);
            this.tilemap.SetTile(position, null);
        }
        money += count;
        MoneyText.text = money.ToString();

        while (row < bounds.yMax)
        {
            for (int col = bounds.xMin; col < bounds.xMax; col++)
            {
                Vector3Int position = new Vector3Int(col, row + 1, 0);
                TileBase above = this.tilemap.GetTile(position);

                position = new Vector3Int(col, row, 0);
                this.tilemap.SetTile(position, above);
            }

            row++;
        }
    }
    public void BuyAndDressSkins(string skins, int price)
    {
        //change skins
        if (skins == "Classic")
        {
            tetrominoes = new TetrominoData[Classic.Count];
            for (int i = 0; i < Classic.Count; i++)
            {
                tetrominoes[i] = Classic[i];
            }
            money += price;
            MoneyText.text = money.ToString();
        }
        if (skins == "Stars")
        {
            tetrominoes = new TetrominoData[Stars.Count];
            for (int i = 0; i < Stars.Count; i++)
            {
                tetrominoes[i] = Stars[i];
            }
            money += price;
            MoneyText.text = money.ToString();
        }
        if (skins == "Food")
        {
            tetrominoes = new TetrominoData[Food.Count];
            for (int i = 0; i < Food.Count; i++)
            {
                tetrominoes[i] = Food[i];
            }
            money += price;
            MoneyText.text = money.ToString();
        }
        if (skins == "Lego")
        {
            tetrominoes = new TetrominoData[Lego.Count];
            for (int i = 0; i < Lego.Count; i++)
            {
                tetrominoes[i] = Lego[i];
            }
            money += price;
            MoneyText.text = money.ToString();
        }
        if (skins == "Flowers")
        {
            tetrominoes = new TetrominoData[Flowers.Count];
            for (int i = 0; i < Flowers.Count; i++)
            {
                tetrominoes[i] = Flowers[i];
            }
            money += price;
            MoneyText.text = money.ToString();
        }
        if (skins == "Hearts")
        {
            tetrominoes = new TetrominoData[Hearts.Count];
            for (int i = 0; i < Hearts.Count; i++)
            {
                tetrominoes[i] = Hearts[i];
            }
            money += price;
            MoneyText.text = money.ToString();
        }
        if (skins == "HelloKitty")
        {
            tetrominoes = new TetrominoData[HelloKitty.Count];
            for (int i = 0; i < HelloKitty.Count; i++)
            {
                tetrominoes[i] = HelloKitty[i];
            }
            money += price;
            MoneyText.text = money.ToString();
        }
        if (skins == "Crystals")
        {
            tetrominoes = new TetrominoData[Crystals.Count];
            for (int i = 0; i < Crystals.Count; i++)
            {
                tetrominoes[i] = Crystals[i];
            }
            money += price;
            MoneyText.text = money.ToString();
        }
        if (skins == "Meme")
        {
            tetrominoes = new TetrominoData[Meme.Count];
            for (int i = 0; i < Meme.Count; i++)
            {
                tetrominoes[i] = Meme[i];
            }
            money += price;
            MoneyText.text = money.ToString();
        }

    }

}