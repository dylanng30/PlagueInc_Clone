using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Refactor_01.Domain.Entities
{
    public class WorldHealthOrganization : Singleton<WorldHealthOrganization>
    {
        public Dictionary<int, List<CountryModel>> dailyReports;
        protected override void Awake()
        {
            base.Awake();
        }

        public void AddReport(CountryReport report)
        {
            if(!dailyReports.ContainsKey(report.day))
            {
                dailyReports[report.day] = new List<CountryModel>();
            }

            dailyReports[report.day].Add(report.country);
        }

        public List<CountryModel> GetReportByDay(int day)
        {
            if(dailyReports.ContainsKey(day))
            {
                return dailyReports[day];
            }
            return new List<CountryModel>();
        }

        public long GetTotalNormalByDay(int day)
        {
            long totalNormal = 0;
            if(dailyReports.ContainsKey(day))
            {
                foreach(var country in dailyReports[day])
                {
                    totalNormal += country.Normal;
                }
            }
            return totalNormal;
        }

        public long GetTotalInfectedByDay(int day)
        {
            long totalInfected = 0;
            if(dailyReports.ContainsKey(day))
            {
                foreach(var country in dailyReports[day])
                {
                    totalInfected += country.Infected;
                }
            }
            return totalInfected;
        }
        public long GetTotalDeadByDay(int day)
        {
            long totalDead = 0;
            if(dailyReports.ContainsKey(day))
            {
                foreach(var country in dailyReports[day])
                {
                    totalDead += country.Dead;
                }
            }
            return totalDead;
        }

    }
}
