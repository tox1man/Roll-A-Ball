using System;
using UnityEngine;
using UnityEngine.UI;

namespace RollABall
{
    public sealed class DisplayEndGame
    {
        private Text _endGameText;

        public DisplayEndGame()
        {
        }

        public void GameOver(string name, Color color)
        {
            _endGameText.text = $"You were killed by {name} of {color} color";
        }
    }
}
