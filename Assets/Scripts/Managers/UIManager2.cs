using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager2 : MonoBehaviour
{
    [SerializeField] private Text coinText, diamondText,dollarText;
    [SerializeField] private float coinAmount, diamondAmount,dollarAmount;

    private void Awake()
    {
        coinText.text = coinAmount.ToString();
        diamondText.text = diamondAmount.ToString();
        dollarText.text = dollarAmount.ToString();
    }
    private void OnEnable()
    {
        IAP.OnPurchaseConsumableDiamond += IncreaseDiamondAmount;
        IAP.OnPurchaseConsumableItem += IncreaseCoinAmount;
        IAP.OnPurchaseConsumableDollar += IncreaseDollarAmount;
    }

   
    private void IncreaseCoinAmount(float coinToAdd)
    {
        coinAmount += coinToAdd;
        coinText.text = coinAmount.ToString();
    }
    private void IncreaseDiamondAmount(float diamondToAdd)
    {
        diamondAmount += diamondToAdd;
        diamondText.text = diamondAmount.ToString();
    }
    private void IncreaseDollarAmount(float dollarToAdd)
    {
        dollarAmount += dollarToAdd;
        dollarText.text = dollarAmount.ToString();
    }
    private void OnDisable()
    {
        IAP.OnPurchaseConsumableDiamond -= IncreaseDiamondAmount;
        IAP.OnPurchaseConsumableItem -= IncreaseCoinAmount;
        IAP.OnPurchaseConsumableDollar -= IncreaseDollarAmount;
    }
}
