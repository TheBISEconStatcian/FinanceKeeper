using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceKeeperApp.FKClasses
{
    public class FKSettings
    {
        public string currency { get; internal set; }
        public float desiredMinimumDailyBudget { get; internal set; }
        public DateTime endCurrentPeriod { get; internal set; }
        public DateTime endLastPeriod { get; internal set; }
        public float periodBudget { get; internal set; }
        public int periodLength { get; internal set; } //in days

        public FKSettings(string currency, float desiredMinimumDailyBudget, DateTime endCurrentPeriod,
                          DateTime endLastPeriod, float periodBudget, int periodLength)
        {
            this.currency = currency;
            this.desiredMinimumDailyBudget = desiredMinimumDailyBudget;
            this.endCurrentPeriod = endCurrentPeriod;
            this.endLastPeriod = endLastPeriod;
            this.periodBudget = periodBudget;
            this.periodLength = periodLength;
        }
        public FKSettings() 
        {
            DateTime td = DateTime.Today;
            DateTime _endLastPeriod = Preferences.Get("endOfLastPeriod", new DateTime(td.Year, td.Month, 1).AddDays(-1));
            return new FKSettings { 
                currency = Preferences.Get("currency", "€"),
                desiredMinimumDailyBudget = Preferences.Get("desiredMinimumDailyBudget", 10f),
                endCurrentPeriod = Preferences.Get("endCurrentPeriod", Preferences.Get("endLastPeriod"))
            };
            this.currency = Preferences.Get("currency", "€");
            this.desiredMinimumDailyBudget = Preferences.Get("desiredMinimumDailyBudget", 10f)
        }
    }
}
