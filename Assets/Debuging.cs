using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets
{

    public class Debuging : MonoBehaviour
    {
        [SerializeField] private ClimbProvider climbProvider;
        [SerializeField] private DynamicMoveProvider provider;
        public void ChangeToImmidiately()
        {
            Debug.Log("dupa on");
            
            provider.useGravity = true;
        }

        public void ChangeToAttempting()
        {
            Debug.Log("dupa off");
            provider.useGravity = false;
        }
    }
}
