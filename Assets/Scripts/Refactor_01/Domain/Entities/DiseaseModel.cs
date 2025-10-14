using System.Collections;
using System.Collections.Generic;
using Refactor_01.Enums;
using UnityEngine;

namespace Refactor_01.Domain.Entities
{
    public class DiseaseModel
    {
        public string Name { get; private set; }
        public PathogenType Type { get; private set; }
        public int LethalDuration { get; private set; }
        public float Infectivity { get; private set; }
        public float Lethality { get; private set; }

        public int DNA_Points { get; private set; }

        public List<TraitData> Traits {  get; private set; }

        public DiseaseModel(List<TraitData> savedTraits = null)
        {
            Name = GameContext.DiseaseName;
            Type = GameContext.DiseaseData.PathogenType;
            LethalDuration = Random.Range(GameContext.DiseaseData.minDays, GameContext.DiseaseData.maxDays);
            Infectivity = 1f;
            Lethality = 1f;
            LoadTraits(savedTraits);
        }

        public void ApplyDNA(int value)
        {
            DNA_Points += value;
        }
        public void ApplyTrait(TraitData data)
        {
            Traits.Add(data);
            Infectivity += data._infectivityModifier;
            Lethality += data._lethalityModifier;
        }

        #region ---HELPER---
        private void LoadTraits(List<TraitData> savedTraits)
        {
            if(savedTraits == null)
            {
                Traits = new List<TraitData>();
                return;
            }

            Traits = savedTraits;
        }

        #endregion
    }

}

