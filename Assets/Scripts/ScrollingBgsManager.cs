using System;
using RunTime.Controllers;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

namespace RunTime.Managers
{
    public class ScrollingBGsManager : MonoBehaviour
    {
        [SerializeField] private ScrollingBackgroundController[] bgs;

        private float bg_1_Speed = .1f;

        private void OnStartMove(float2 value)
        {
            SetAllBGsDir(value.x);
        }

        private void OnStopMove()
        {
            SetAllBGsDir(0);
        }

        private void Start()
        {
            SetAllBGsSpeed();
        }

        private void SetAllBGsSpeed()
        {
            for (int i = 0; i < bgs.Length; i++)
            {
                bgs[i].SetScrollSpeed(bg_1_Speed);
            }
        }

        private void SetAllBGsDir(float x)
        {
            foreach (var item in bgs)
            {
                item.SetDir(x);
            }
        }

    }
}