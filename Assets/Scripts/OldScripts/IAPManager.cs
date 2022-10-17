using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    public delegate void OnPurchaseCoinEventHandler(float coinToAdd);
    public delegate void OnAdvertisementRemoveEventHandler();
    public static event OnAdvertisementRemoveEventHandler OnRemoveAdvertisement;
    public static event OnPurchaseCoinEventHandler OnPurchaseCoin;



   

    private string coin500 = "com.clapgames.xcop.coin500";
    private string removeAds = "com.clapgames.xcop.removeads";
    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id==coin500)
        {
           // OnPurchaseCoin?.Invoke(purchaseCoin);
            Debug.Log("Gained 500 coins");
        }
        if(product.definition.id==removeAds)
        {
           // OnRemoveAdvertisement?.Invoke();
            Debug.Log("All ads are removed");
        }
    }

    //public void OnPurchaseFailed(Product product,PurchaseFailureReason failureReason)
    //{
    //    Debug.Log(product.definition.id + "failed because " + failureReason);
    //}
}
