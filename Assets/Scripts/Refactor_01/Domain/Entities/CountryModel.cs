using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Refactor_01.Domain.Entities
{
    public class CountryModel
    {
        //Static
        public Sprite Img {  get; set; }
        public int ID { get; private set; }
        public string Name { get; private set; }
        public long Population { get; private set; }

        //Dynamic
        public long Normal { get; private set; }
        public long Infected { get; private set; }
        public long Dead { get; private set; }

        public CountryModel(Sprite img, int id, string name, long population)
        {
            Img = img;
            ID = id;
            Name = name;
            Population = population;
            Normal = population;
        }

        public void AddInfected(long value)
        {
            Normal -= value;
            Infected += value;
        }
        public void AddDead(long value)
        {
            Infected -= value;
            Dead += value;
        }

        public void Reset()
        {
            Normal = Population;
            Infected = 0;
            Dead = 0;
        }
    }
}