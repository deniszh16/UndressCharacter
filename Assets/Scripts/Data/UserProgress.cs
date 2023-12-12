using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class UserProgress
    {
        public int Locale;

        public UserProgress()
        {
            Locale = Application.systemLanguage == SystemLanguage.Russian ? 0 : 1;
        }
    }
}