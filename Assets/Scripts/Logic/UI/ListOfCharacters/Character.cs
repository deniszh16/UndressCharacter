using System;
using UnityEngine;

namespace Logic.UI.ListOfCharacters
{
    [Serializable]
    public class Character
    {
        [Header("Варианты одежды")]
        [SerializeField] private Sprite[] _clothes;

        public Sprite[] Clothes => _clothes;
    }
}