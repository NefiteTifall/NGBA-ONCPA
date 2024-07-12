using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BrewingStandController : MonoBehaviour
{
    public CustomSocketInteractor netherWartSocket;
    public CustomSocketInteractor blazePowderSocket;
    public CustomSocketInteractor magmaCreamSocket;
    public CustomSocketInteractor potionSocket;
    public GameObject fireResistancePotion;

    protected void Start()
    {
        netherWartSocket.selectEntered.AddListener(TryCreatePotion);
        blazePowderSocket.selectEntered.AddListener(TryCreatePotion);
        magmaCreamSocket.selectEntered.AddListener(TryCreatePotion);
        potionSocket.selectEntered.AddListener(TryCreatePotion);
    }

    private void TryCreatePotion(SelectEnterEventArgs args)
    {
        if (netherWartSocket.IsPlaced && blazePowderSocket.IsPlaced && magmaCreamSocket.IsPlaced && potionSocket.IsPlaced)
        {
            fireResistancePotion.SetActive(true);

            netherWartSocket.DestroyObject();
            blazePowderSocket.DestroyObject();
            magmaCreamSocket.DestroyObject();

            potionSocket.DestroyObject();
        }
    }
}
