using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ForCanvas : MonoBehaviour
{
    public static bool IsPause = false;

    //Canvas
    [SerializeField] GameObject StartCanvas;
    [SerializeField] GameObject SkinsCanvas;
    [SerializeField] GameObject ShopCanvas;
    //Buttons for dress skins
    [SerializeField] List<GameObject> ButtonsForDressSkins;

    //Buttons for buy skins
    [SerializeField] List<GameObject> ButtonsForBuySkins;
    //Ghost
    [SerializeField] Ghost Ghost;
    //Boards
    [SerializeField] Board Board;
    [SerializeField] List<GameObject> Boards = new List<GameObject>();
    [SerializeField] List<Board> boards = new List<Board>();
    [SerializeField] List<Piece> trackingPieces = new List<Piece>();
    //Money
    [SerializeField] public Text MoneyText;
    public int countMoney = 1;
    [SerializeField] public int money
    {
        get { return _money; }
        set
        {
            _money = value;
            MoneyText.text = _money.ToString();
            MoneyTextForShop.text = _money.ToString();
        }
    }
    private int _money;
    //FinishText
    [SerializeField] public Text MoneyTextForShop;
    //TextQuantityMoneyForShop
    [SerializeField] public Text SkinsTextForSkins;
    //TextQuantitySkin
    public int countSkins = 0;
    //helpCanvas
    [SerializeField] GameObject HelpCanvas;
    //number for prize
    int number;
    //PauseAndResume
    [SerializeField] GameObject Pause;
    [SerializeField] GameObject Resume;
    [SerializeField] GameObject CanvasForPause;
    //music
    [SerializeField] Music Music;
    //Score
    [SerializeField] GameObject ScoreScreen;
    [SerializeField] public Text scoreText;
    [SerializeField] public int score;


    //cloud saves (load)
    private void Awake()
    {
        YandexGame.GetDataEvent += LoadSaves;
    }
    public void LoadSaves()
    {
        money = YandexGame.savesData.money;
        MoneyText.text = money.ToString();

        score = YandexGame.savesData.score;
        scoreText.text = score.ToString();

        PrintSaveSkins();

        if (YandexGame.savesData.IsMusic)
        {
            Music.musicON();
        }
        else
        {
            Music.musicOFF();
        }
    }

    public void BoardsSwitcher(int index)
    {
        for (int i = 0; i < Boards.Count; i++)
        {
            //off all boards
            Boards[i].SetActive(false);
        }
        Boards[index].SetActive(true);//on board
        Ghost.Clear();
        Ghost.board = boards[index];
        Ghost.trackingPiece = trackingPieces[index];
    }
    public void BuySkins(int index, int price, int CountMoney)
    {
        if (money >= price)
        {
            BoardsSwitcher(index);
            ButtonsForBuySkins[index].SetActive(false);
            ButtonsForDressSkins[index].SetActive(true);
            countSkins++;
            countMoney = CountMoney;
            money -= price;
            YandexGame.savesData.shop[index] = 1;
            YandexGame.savesData.money = money;

            YandexGame.SaveProgress();
            //PlayerPrefs.SetInt(index + "shop", 1);
            //PlayerPrefs.SetInt("Money", money);
        }

    }
    public void PrintSaveSkins()
    {
        for (int i = 0; i < Boards.Count; i++)
        {
            if (YandexGame.savesData.shop[i] == 1)
            {
                BoardsSwitcher(i);
                ButtonsForBuySkins[i].SetActive(false);
                ButtonsForDressSkins[i].SetActive(true);
                countSkins++;
            }
        }
    }

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        //On start canvas and off others canvas
        StartCanvas.SetActive(true);
        SkinsCanvas.SetActive(false);
        ShopCanvas.SetActive(false);
        //on and off boards
        BoardsSwitcher(0);
        //money
        //money = PlayerPrefs.GetInt("Money");
        //MoneyText.text = money.ToString();
        //off and on buttons for dress skins
        for (int i = 0; i < ButtonsForDressSkins.Count; i++)
        {
            //off all boards
            ButtonsForDressSkins[i].SetActive(false);
        }
        //on buttons for buy skins
        for (int i = 0; i < ButtonsForBuySkins.Count; i++)
        {
            //off all boards
            ButtonsForBuySkins[i].SetActive(true);
        }
        //Skins
        countSkins = 1;
        //Help
        HelpCanvas.SetActive(false);
        //PauseAndResume
        Resume.SetActive(false);
        Pause.SetActive(true);
        CanvasForPause.SetActive(false);
        PrintSaveSkins();

    }
    private void Update()
    {
        //MoneyText.text = money.ToString();
        //MoneyTextForShop.text = money.ToString();
        //SkinsTextForSkins.text = countSkins.ToString(); 
    }
    public void Help()
    {
        HelpCanvas.SetActive(true);

        SetPause(true);
        Time.timeScale = 0f;
    }
    public void Skins()
    {
        SkinsCanvas.SetActive(true);

        SetPause(true);
        Time.timeScale = 0f;
    }
    public void Shop()
    {
        ShopCanvas.SetActive(true);

        SetPause(true);
        Time.timeScale = 0f;
    }
    public void FreeMoney()
    {
        //On AD
        //Give random quantity money
        money += Random.Range(10, 50);

        YandexGame.savesData.money = money;

        YandexGame.SaveProgress();
        //PlayerPrefs.SetInt("Money", money);
        Update();
    }
    public void Exit()
    {
        StartCanvas.SetActive(true);
        SkinsCanvas.SetActive(false);
        ShopCanvas.SetActive(false);
        HelpCanvas.SetActive(false);

        SetPause(false);
        Time.timeScale = 1f;
    }

    //functions for dress skins
    public void dressClassic()
    {
        //dress skin
        BoardsSwitcher(0);
    }
    public void dressStars()
    {
        //dress skin
        BoardsSwitcher(1);
    }
    public void dressFood()
    {
        //dress skin
        BoardsSwitcher(2);
    }
    public void dressLego()
    {
        //dress skin
        BoardsSwitcher(3);
    }
    public void dressFlowers()
    {
        //dress skin
        BoardsSwitcher(4);
    }
    public void dressHearts()
    {
        //dress skin
        BoardsSwitcher(5);
    }
    public void dressHelloKitty()
    {
        //dress skin
        BoardsSwitcher(6);
    }
    public void dressCrystal()
    {
        //dress skin
        BoardsSwitcher(7);
    }
    public void dressMeme()
    {
        //dress skin
        BoardsSwitcher(8);
    }    public void dressGradientHeart()
    {
        //dress skin
        BoardsSwitcher(9);
    }
    public void dressGradient()
    {
        //dress skin
        BoardsSwitcher(10);
    }
    //functions for buy skins
    public void buyStars()
    {
        //buy skin
        BuySkins(1, 42, 10);
    }
    public void buyFood()
    {
        //buy skin
        BuySkins(2, 271, 100);
    }
    public void buyLego()
    {
        //buy skin
        BuySkins(3, 1618, 150);
    }
    public void buyFlowers()
    {
        //buy skin
        BuySkins(4, 2500, 200);
    }
    public void buyHearts()
    {
        //buy skin
        BuySkins(5, 10000, 250);
    }
    public void buyHelloKitty()
    {
        //buy skin
        BuySkins(6, 15555, 300);
    }
    public void buyCrystal()
    {
        //buy skin
        BuySkins(7, 31415, 350);
    }
    public void buyMeme()
    {
        //buy skin
        BuySkins(8, 7777777, 400);
    }
    public void buyGradient()
    {
        //buy skin
        BuySkins(10, 88888888, 450);
    }
    public void buyGradientHearts()
    {
        //buy skin
        BuySkins(9, 1234567890, 500);
    }
    public void Prize()
    {
        //On AD
        //Give random skin
        number = Random.Range(1, 15);
        if (number == 1)
        {
            BuySkins(1, 0, 5);
        }
        if (number == 2)
        {
            BuySkins(2, 0, 10);
        }
        if (number == 3)
        {
            BuySkins(3, 0, 15);
        }
        if (number == 4)
        {
            BuySkins(4, 0, 20);
        }
        if (number == 5)
        {
            BuySkins(5, 0, 25);
        }
        if (number == 6)
        {
            BuySkins(6, 0, 30);
        }
        if (number == 7)
        {
            BuySkins(7, 0, 35);
        }
        else if (number > 7)
        {
            money += Random.Range(10, 50);

            YandexGame.savesData.money = money;

            YandexGame.SaveProgress();
            //PlayerPrefs.SetInt("Money", money);
            Update();
        }
    }

    public void pause()
    {
        CanvasForPause.SetActive(true);
        Time.timeScale = 0f;
        Resume.SetActive(true);
        Pause.SetActive(false);
        Music.PauseMusic(true);

        SetPause(true);
    }
    public void resume()
    {
        CanvasForPause.SetActive(false);
        Time.timeScale = 1f;
        Resume.SetActive(false);
        Pause.SetActive(true);
        Music.PauseMusic(false);

        SetPause(false);
    }
    public void SetPause(bool value)
    {
        IsPause = value;
    }
}


