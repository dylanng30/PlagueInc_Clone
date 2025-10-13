using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Refactor_01.Data.StaticData
{
    [CreateAssetMenu(fileName = "CountryData")]
    public class CountryData : ScriptableObject
    {
        public Sprite CountryIMG;
        public int CountryID;
        public string CountryName;
        public long Population;
    }
}


