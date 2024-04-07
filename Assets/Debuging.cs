using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets
{

    public class Debuging : MonoBehaviour
    {
        [SerializeField] private ClimbProvider climbProvider;
        [SerializeField] private DynamicMoveProvider provider;
        public void ChangeGravityOn()
        {
            provider.useGravity = true;
        }

        public void ChangeGravityOff()
        {
            provider.useGravity = false;        
        }

    }
}
