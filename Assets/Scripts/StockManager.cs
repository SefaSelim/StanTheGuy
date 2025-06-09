using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StockManager : MonoBehaviour
{
    [SerializeField] GameObject CandleParent;

    [SerializeField] GameObject UpArrow;
    [SerializeField] GameObject DownArrow;

    [SerializeField] TextMeshProUGUI CoinPrice;
    [SerializeField] TextMeshProUGUI QuantityText;
    [SerializeField] TextMeshProUGUI MoneyText;

    [SerializeField] TextMeshProUGUI Chos_SliderAmount;
    [SerializeField] Slider slider;

    public TextMeshProUGUI Reachup;

    int ChosenSliderAmount = 0;

    public int Money = 1000;
    int quantity = 0;

    int CandleCount = 0;

    int distance;

    int Origin = 0;

    float timer = 0f;

    int currentVal = 300;

    RectTransform CandleParentTransform;

    private void Start()
    {
        CandleParentTransform = CandleParent.GetComponent<RectTransform>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        ChosenSliderAmount = (int)(slider.value * 10);
        Chos_SliderAmount.text = ChosenSliderAmount.ToString();

        if (timer  >= 1f)
        {
            int rand = UnityEngine.Random.Range(0, 2);

            if (rand == 1)
            {
                int Height = UnityEngine.Random.Range(40, 150);
                UpSpawn(Height);
            }
            else
            {
                int Height = UnityEngine.Random.Range(40, 150);
                DownSpawn(Height);
            }

            if (CandleCount > 30)
            {
                CandleParentTransform.anchoredPosition -= new Vector2(20, 0);
            }


            timer = 0f;
            CoinPrice.text = currentVal.ToString();
        }
        
    }

    private void UpSpawn(int Height)
    {

        if (Origin > 250 - Height)
        {
            distance = Origin - (250 - Height);
            Origin = 250 - Height;
            currentVal = 550;
        }
        else
        {
            distance = 0;
            currentVal = Origin + Height + 300;
        }

        GameObject up = Instantiate(UpArrow, new Vector3(10 + 20 * CandleCount, Origin + distance, 0), Quaternion.identity);
        Destroy(up, 40f);
        RectTransform rectTransform = up.GetComponent<RectTransform>();
        up.transform.SetParent(CandleParent.transform, false);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Height - distance);
        Origin += Convert.ToInt16(Height);

        CandleCount ++;
    }

    private void DownSpawn(int Height)
    {

        if (Origin < -250 + Height)
        {
            distance = -250 + Height - Origin;
            Origin = -250 + Height;
            currentVal = 50;
        }
        else
        {
            distance = 0;
            currentVal = Origin - Height + 300;
        }


        GameObject down = Instantiate(DownArrow, new Vector3(10 + 20 * CandleCount, Origin - distance, 0), Quaternion.identity);
        Destroy(down, 40f);
        RectTransform rectTransform = down.GetComponent<RectTransform>();
        down.transform.SetParent(CandleParent.transform, false);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Height - distance);
        Origin -= Convert.ToInt16(Height);

        CandleCount ++;
    }

    public void Buy()
    {
        int amount = ChosenSliderAmount;
        if (Money >= int.Parse(CoinPrice.text) * amount)
        {
            quantity += amount;
            Money -= int.Parse(CoinPrice.text) * amount;
            QuantityText.text = quantity.ToString();
            MoneyText.text = Money.ToString();

        }
        else
        {
            int needAmount = (int)(Money / int.Parse(CoinPrice.text));
            float placeholder = needAmount;
            placeholder /= 10f;
            slider.value = placeholder;
        }
    }
    public void Sell()
    {
        int amount = ChosenSliderAmount;

        if (quantity >= amount)
        {
            quantity-= amount;
            Money += int.Parse(CoinPrice.text) * amount;
            QuantityText.text =quantity.ToString();
            MoneyText.text = Money.ToString();
        }
        else
        {
            int needAmount = quantity;
            float placeholder = needAmount;
            placeholder /= 10f;
            slider.value = placeholder;
        }
    }
}
