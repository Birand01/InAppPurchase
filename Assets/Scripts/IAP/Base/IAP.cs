using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
using System;

public abstract class IAP : MonoBehaviour
{
    #region EVENTS
    public static event Action<float> OnPurchaseConsumableItem;
    public static event Action<float> OnPurchaseConsumableDiamond;
    public static event Action<float> OnPurchaseConsumableDollar;
    public static event Action OnPurchaseNonConsumable;
    #endregion

    protected IAPButton ýAPButton;
    [SerializeField] protected float consumablePurchaseAmount;

    protected virtual void Awake()
    {
        ýAPButton = GetComponent<IAPButton>();
    }


    #region CONSUMABLE VIRTUAL METHODS
    public virtual void OnConsumablePurchaseCoinComplete(Product product)
    {
        Debug.Log(consumablePurchaseAmount + " coins are received");
        OnPurchaseConsumableItem?.Invoke(consumablePurchaseAmount);
        ApplyProductID(ýAPButton.productId, product);

    }
    public virtual void OnConsumablePurchaseDiamondComplete(Product product)
    {
        Debug.Log(consumablePurchaseAmount + " diamonds are received");
        OnPurchaseConsumableDiamond?.Invoke(consumablePurchaseAmount);
        ApplyProductID(ýAPButton.productId, product);
       
    }
    public virtual void OnConsumablePurchaseDollarComplete(Product product)
    {
        Debug.Log(consumablePurchaseAmount + " dollars are received");
        OnPurchaseConsumableDollar?.Invoke(consumablePurchaseAmount);
        ApplyProductID(ýAPButton.productId, product);

    }

    #endregion

    #region NONCONSUMABLE VIRTUAL METHODS
    public virtual void OnNonConsumablePurchaseComplete(Product product)
    {
        Debug.Log("All advertisements are removed");
        OnPurchaseNonConsumable?.Invoke();
        ApplyProductID(ýAPButton.productId, product);     
    }
    public virtual void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(product.definition.id + "failed because " + failureReason);
    }
    #endregion

    private string ApplyProductID(string ID, Product product)
    {
        Debug.Log("Your productID is : " + ýAPButton.productId);
       
        return ID = product.definition.id;
    }




    #region EVERY INHERITED CLASS MUST IMPLEMENT THIS ABSTRACT METHOD
    /* 
    <summary>
    /// This method is abstract due to necessity. Product ID must matched with the consumable/nonconsumable ID
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="product"></param>
    
    protected abstract string ApplyProductID(string ID, Product product);
    */
    #endregion


}
