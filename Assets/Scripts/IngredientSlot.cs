// using UnityEngine;

// public class IngredientSlot : MonoBehaviour
// {
//     private GameObject placedIngredient = null;

//     private void OnTriggerEnter(Collider other)
//     {
//         if (placedIngredient == null) // Ensure the slot is empty
//         {
//             PotionIngredient ingredient = other.GetComponent<PotionIngredient>();
//             if (ingredient != null)
//             {
//                 PlaceIngredient(ingredient.gameObject);
//             }
//         }
//     }

//     private void PlaceIngredient(GameObject ingredient)
//     {
//         // Place the ingredient in the slot
//         ingredient.transform.position = transform.position;
//         ingredient.transform.rotation = transform.rotation;
//         placedIngredient = ingredient;

//         // Disable XRGrabInteractable to make it unmovable
//         UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable = ingredient.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
//         if (grabInteractable != null)
//         {
//             grabInteractable.enabled = false;
//         }
//     }
// }
