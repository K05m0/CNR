using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class PushButtonInterraction : MonoBehaviour
{
    [SerializeField] private DynamicMoveProvider dynamicMoveProvider;

    private void Awake()
    {
        dynamicMoveProvider.moveSpeed = 0;
    }

    public void OnStart()
    {
        dynamicMoveProvider.moveSpeed = 3;
    }
    /*    [SerializeField] List<GameObject> Ui = new List<GameObject>();
        [SerializeField] int index = 0;
        private int objectToChange;
       public void OnPush()
        {
            objectToChange = index;
            switch (objectToChange)
            {
                case 0:
                    Ui[0].SetActive(true);
                    Ui[1].SetActive(false);
                    StartCoroutine(LeaveGame());
                    break;
                case 1:
                    Ui[0].SetActive(false);
                    Ui[1].SetActive(true);
                    break;
            }
        }

        IEnumerator LeaveGame()
        {
            yield return new WaitForSeconds(4);
            Application.Quit();
        }*/
}
