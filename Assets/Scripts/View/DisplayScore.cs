using System;
using UnityEngine.UI;

namespace RollABall
{
    public sealed class DisplayScore
    {
        private Text _scoreText;
        private string _textMessage;
        public DisplayScore()
        {
            _textMessage = $"Your score is {ScoreValue}";
        }

        public int ScoreValue { get; set; }

        public void Display(int value)
        {
            _scoreText.text =_textMessage;

        }
    }
}
