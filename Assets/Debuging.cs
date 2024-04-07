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

        public void CheckWhatITouch()
        {

            /*            Debug.Log("Objects currently grabbed for climbing:");

            // Użyj refleksji do uzyskania dostępu do prywatnego pola m_GrabbedClimbables
            FieldInfo grabbedClimbablesField = typeof(ClimbProvider).GetField("m_GrabbedClimbables", BindingFlags.NonPublic | BindingFlags.Instance);
            if (grabbedClimbablesField != null)
            {
                List<ClimbInteractable> grabbedClimbables = (List<ClimbInteractable>)grabbedClimbablesField.GetValue(climbProvider);
                if (grabbedClimbables != null)
                {
                    foreach (var climbInteractable in grabbedClimbables)
                    {
                        Debug.Log("huj");
                        Debug.Log(climbInteractable.gameObject.tag);
                    }
                }
            }*/
        }
    }
}
