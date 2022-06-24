using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForCanvas : MonoBehaviour
{
    //Canvas
    [SerializeField] GameObject StartCanvas;
    [SerializeField] GameObject SkinsCanvas;
    [SerializeField] GameObject ShopCanvas;
    //Buttons for music
    [SerializeField] GameObject MusicOFF;
    [SerializeField] GameObject MusicON;
    //Buttons for dress skins
    [SerializeField] GameObject ClassicSkinButton;
    [SerializeField] GameObject StarsSkinButton;
    [SerializeField] GameObject FoodSkinButton;
    [SerializeField] GameObject LegoSkinButton;
    [SerializeField] GameObject FlowersSkinButton;
    [SerializeField] GameObject HeartsSkinButton;
    [SerializeField] GameObject HelloKittySkinButton;
    [SerializeField] GameObject CrystalsSkinButton;
    [SerializeField] GameObject MemeSkinButton;
    //Buttons for buy skins
    [SerializeField] GameObject StarsBuyButton;
    [SerializeField] GameObject FoodBuyButton;
    [SerializeField] GameObject LegoBuyButton;
    [SerializeField] GameObject FlowersBuyButton;
    [SerializeField] GameObject HeartsBuyButton;
    [SerializeField] GameObject HelloKittyBuyButton;
    [SerializeField] GameObject CrystalsBuyButton;
    [SerializeField] GameObject MemeBuyButton;


    void Start()
    {
        //On start canvas and off others canvas
        StartCanvas.SetActive(true);
        SkinsCanvas.SetActive(false);
        ShopCanvas.SetActive(false);
        //on and off music
        MusicOFF.SetActive(false);
        MusicON.SetActive(true);
    }

    public void Skins()
    {
        SkinsCanvas.SetActive(true);
        StartCanvas.SetActive(false);
        ShopCanvas.SetActive(false);
    }
    public void Shop()
    {
        SkinsCanvas.SetActive(false);
        StartCanvas.SetActive(false);
        ShopCanvas.SetActive(true);
    }
    public void FreeMoney()
    {
        //показ рекламы
        //выдача монет
    }
    public void Exit()
    {
        StartCanvas.SetActive(true);
        SkinsCanvas.SetActive(false);
        ShopCanvas.SetActive(false);
    }
    public void musicOFF()
    {
        MusicON.SetActive(false);
        MusicOFF.SetActive(true);
        //выкл музыки
    }
    public void musicON()
    {
        MusicON.SetActive(true);
        MusicOFF.SetActive(false);
        //вкл музыки
    }
    //functions for dress skins
    public void dressClassic()
    {
        //dress skin
        GetComponent<Board>().BuyAndDressSkins("Classic", 0);
    }
    public void dressStars()
    {
        //dress skin
        GetComponent<Board>().BuyAndDressSkins("Stars", 0);
    }
    public void dressFood()
    {
        //dress skin
        GetComponent<Board>().BuyAndDressSkins("Food", 0);
    }
    public void dressLego()
    {
        //dress skin
        GetComponent<Board>().BuyAndDressSkins("Lego", 0);
    }
    public void dressFlowers()
    {
        //dress skin
        GetComponent<Board>().BuyAndDressSkins("Flowers", 0);
    }
    public void dressHearts()
    {
        //dress skin
        GetComponent<Board>().BuyAndDressSkins("Hearts", 0);
    }
    public void dressHelloKitty()
    {
        //dress skin
        GetComponent<Board>().BuyAndDressSkins("HelloKitty", 0);
    }
    public void dressCrystal()
    {
        //dress skin
        GetComponent<Board>().BuyAndDressSkins("Crystals", 0);
    }
    public void dressMeme()
    {
        //dress skin
        GetComponent<Board>().BuyAndDressSkins("Meme", 0);
    }

    //functions for buy skins
    public void buyClassic()
    {
        //buy skin
        //delete button "buy" and add in Skins button "dress"
    }
    public void buyStars()
    {
        //buy skin
    }
    public void buyFood()
    {
        //buy skin
    }
    public void buyLego()
    {
        //buy skin
    }
    public void buyFlowers()
    {
        //buy skin
    }
    public void buyHearts()
    {
        //buy skin
    }
    public void buyHelloKitty()
    {
        //buy skin
    }
    public void buyCrystal()
    {
        //buy skin
    }
    public void buyMeme()
    {
        //buy skin
    }

}


