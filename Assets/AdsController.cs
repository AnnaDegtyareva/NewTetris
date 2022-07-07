using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
public class AdsController : MonoBehaviour
{
    [SerializeField] public YandexGame YG;
    [SerializeField] ForCanvas ForCanvas;
    void Start()
    {
        YG._FullscreenShow();//обычная реклама
    }

    public void AdsFreeMoney()
    {
        YG._RewardedShow(0);//видео реклама(для награды) 
    }
    public void AdsPrize()
    {
        YG._RewardedShow(1);//видео реклама(для награды)
    }
    public void OnEnable() => YandexGame.CloseVideoEvent += Reward;
    public void OnDisable() => YandexGame.CloseVideoEvent -= Reward;

    public void Reward(int id) //метод для награды(после закрытия рекламы)
    {
        if (id == 0)
        {
            ForCanvas.FreeMoney();
        }
        if (id == 1)
        {
            ForCanvas.Prize();
        }
    }
}
