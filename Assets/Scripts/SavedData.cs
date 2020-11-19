using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    [Serializable]
    public sealed class SavedData
    {
        public Coin[] _coinsList;
        public Buff[] _buffsList;
        public Trap[] _trapsList;

        public SavedData()
        {
            _coinsList = GameObject.FindObjectsOfType<Coin>();
            Debug.Log(_coinsList.Length);
            _buffsList = GameObject.FindObjectsOfType<Buff>();
            _trapsList = GameObject.FindObjectsOfType<Trap>();
        }

        public override string ToString()
        {
            foreach(Coin coin in _coinsList)
            {
                Debug.Log($"X = {coin.transform.position.x}, Y = {coin.transform.position.y}, Z = {coin.transform.position.z}");
            }            
            foreach(Buff buff in _buffsList)
            {
                Debug.Log($"X = {buff.transform.position.x}, Y = {buff.transform.position.y}, Z = {buff.transform.position.z}");
            }            
            foreach(Trap trap in _trapsList)
            {
                Debug.Log($"X = {trap.transform.position.x}, Y = {trap.transform.position.y}, Z = {trap.transform.position.z}");
            }
            return "=================";
        }
    }
}
