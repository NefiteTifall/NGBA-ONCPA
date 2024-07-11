using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class BrewingStandController : MonoBehaviour
{
    public CustomSocketInteractor netherWartSocket;
    public CustomSocketInteractor blazePowderSocket;
    public CustomSocketInteractor magmaCreamSocket;
    public CustomSocketInteractor potionSocket;
    public GameObject fireResistancePotion;
    public BoxCollider lavaWallCollider;

    protected void Start()
    {
        netherWartSocket.selectEntered.AddListener(CreatePotion);
        blazePowderSocket.selectEntered.AddListener(CreatePotion);
        magmaCreamSocket.selectEntered.AddListener(CreatePotion);
        potionSocket.selectEntered.AddListener(CreatePotion);
    }

    private void CreatePotion(SelectEnterEventArgs args)
    {
        Debug.Log("Creating potion");
        if (potionSocket.IsPlaced)
        {
            fireResistancePotion.SetActive(true);

            netherWartSocket.DestroyObject();
            blazePowderSocket.DestroyObject();
            magmaCreamSocket.DestroyObject();

            potionSocket.DestroyObject();
        }
    }
}
