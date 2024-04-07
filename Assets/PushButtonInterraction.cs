using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class PushButtonInterraction : MonoBehaviour
{
    [SerializeField] private DynamicMoveProvider dynamicMoveProvider;
    [SerializeField] private List<GameObject> elementsToRemove;

    private void Awake()
    {
        dynamicMoveProvider.moveSpeed = 0f;
    }

    public void PushButton()
    {
        dynamicMoveProvider.moveSpeed = 3f;
        foreach (var element in elementsToRemove)
        {
            Destroy(element);
        }
    }

}
