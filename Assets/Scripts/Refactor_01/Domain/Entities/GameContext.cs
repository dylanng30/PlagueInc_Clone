using System.Collections;
using System.Collections.Generic;
using Refactor_01.Enums;
using UnityEngine;

namespace Refactor_01.Domain.Entities
{
    public static class GameContext
    {
        public static string DiseaseName { get; set; }
        public static int InitialCountryId { get; set; } = -1;
        public static DiseaseSO DiseaseData { get; set; }
    }
}

