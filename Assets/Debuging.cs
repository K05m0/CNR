using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets
{

    public class Debuging : MonoBehaviour
    {
        [SerializeField] private DynamicMoveProvider provider;

        public void asjgasgafas()
        {
            Debug.Log("Dupa");
        }

        public void ChangeToImmidiately()
        {
            provider.useGravity = true;
        }

        public void ChangeToAttempting()
        {
            provider.useGravity = false;
        }
        
    }
}
