using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForCanvas : MonoBehaviour
{
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
    [SerializeField] public int money;
    public int countMoney = 1;
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

    public void BoardsSwitcher(int index, int price)
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
        money += price;
        PlayerPrefs.SetInt("Money", money);
    }
    public void BuySkins(int index, int price, int CountMoney)
    {
        if (money>=price)
        {
            BoardsSwitcher(index, -price);
            ButtonsForBuySkins[index].SetActive(false);
            ButtonsForDressSkins[index].SetActive(true);
            countSkins++;
            countMoney = CountMoney;
            PlayerPrefs.SetInt(index + "shop", 1);
        }

    }
    public void PrintSaveSkins()
    {
        for (int i = 0; i < Boards.Count; i++)
        {
            if (PlayerPrefs.GetInt(i + "shop", 0) == 1)
            {
                BoardsSwitcher(i, 0);
                ButtonsForBuySkins[i].SetActive(false);
                ButtonsForDressSkins[i].SetActive(true);
            }
        }
    }

    void Start()
    {
        //On start canvas and off others canvas
        StartCanvas.SetActive(true);
        SkinsCanvas.SetActive(false);
        ShopCanvas.SetActive(false);
        //on and off boards
        BoardsSwitcher(0,0);
        //money
        money = PlayerPrefs.GetInt("Money");
        Debug.Log("Get" + money.ToString());
        MoneyText.text = money.ToString();
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
        MoneyText.text = money.ToString();
        MoneyTextForShop.text = money.ToString();
        SkinsTextForSkins.text = countSkins.ToString();
    }
    public void Help()
    {
        HelpCanvas.SetActive(true);
    }
    public void Skins()
    {
        SkinsCanvas.SetActive(true);
    }
    public void Shop()
    {
        ShopCanvas.SetActive(true);
    }
    public void FreeMoney()
    {
        //On AD
        //Give random quantity money
        int xx = money += Random.Range(10, 50);
        Debug.Log("Set" + money.ToString());
        PlayerPrefs.SetInt("Money", xx);
        Update();
    }
    public void Exit()
    {
        StartCanvas.SetActive(true);
        SkinsCanvas.SetActive(false);
        ShopCanvas.SetActive(false);
        HelpCanvas.SetActive(false);
    }
   
    //functions for dress skins
    public void dressClassic()
    {
        //dress skin
        BoardsSwitcher(0,0);
    }
    public void dressStars()
    {
        //dress skin
        BoardsSwitcher(1, 0);
    }
    public void dressFood()
    {
        //dress skin
        BoardsSwitcher(2, 0);
    }
    public void dressLego()
    {
        //dress skin
        BoardsSwitcher(3, 0);
    }
    public void dressFlowers()
    {
        //dress skin
        BoardsSwitcher(4, 0);
    }
    public void dressHearts()
    {
        //dress skin
        BoardsSwitcher(5, 0);
    }
    public void dressHelloKitty()
    {
        //dress skin
        BoardsSwitcher(6, 0);
    }
    public void dressCrystal()
    {
        //dress skin
        BoardsSwitcher(7, 0);
    }
    public void dressMeme()
    {
        //dress skin
        BoardsSwitcher(8, 0);
    }
    public void dressGradient()
    {
        //dress skin
        BoardsSwitcher(10, 0);
    }
    public void dressGradientHeart()
    {
        //dress skin
        BoardsSwitcher(9, 0);
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
        BuySkins(9, 1234567890,  500);
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
            int xx = money += Random.Range(10, 50);
            PlayerPrefs.SetInt("Money", xx);
            Update();
        }
    }

    public void pause()
    {
        CanvasForPause.SetActive(true);
        Time.timeScale = 0f;
        Resume.SetActive(true);
        Pause.SetActive(false);
    }
    public void resume()
    {
        CanvasForPause.SetActive(false);
        Time.timeScale = 1f;
        Resume.SetActive(false);
        Pause.SetActive(true);
    }

}


