using GameScenes.Balance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Physikef.Assets.Scripts.GameScenes.Balance
{
    class BalanceSwing : MonoBehaviour
    {
        public GameObject seesaw;
        public GameObject leftWeight;
        public GameObject rightWeight;

        private void Update()
        {
            if (this.enabled)
            {
                seesaw.GetComponent<Rigidbody>().isKinematic = true;
                leftWeight.GetComponent<Rigidbody>().isKinematic = true;
                rightWeight.GetComponent<Rigidbody>().isKinematic = true;
                leftWeight.SetActive(true);
                rightWeight.SetActive(true);
            }
        }
    }
}
