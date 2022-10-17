using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text coinText, diamondText;

    [SerializeField] private Image advertisementImage;

    [SerializeField] private float coinAmount,diamondAmount;

    private void OnEnable()
    {
       
        IAP.OnPurchaseNonConsumable += RemoveAdvertisementImage;
        IAP.OnPurchaseConsumableDiamond += IncreaseDiamondAmount;
        IAP.OnPurchaseConsumableItem += IncreaseCoinAmount;

    }
    private void Awake()
    {
        coinText.text = coinAmount.ToString();
        diamondText.text = diamondAmount.ToString();
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
    private void RemoveAdvertisementImage()
    {
        advertisementImage.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        IAP.OnPurchaseConsumableDiamond -= IncreaseDiamondAmount;
        IAP.OnPurchaseConsumableItem -= IncreaseCoinAmount;
        IAP.OnPurchaseNonConsumable -= RemoveAdvertisementImage;

    }
}
