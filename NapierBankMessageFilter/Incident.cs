using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapierBankMessageFilter
{
    /// <summary>
    /// Enum that contains incident - Dev note : Best to try and change this to a string to allow spaces. 
    /// </summary>
    public enum Incident
    {
        Theft,
        StaffAttack,
        ATMTheft,
        Raid,
        CustomerAttack,
        StaffAbuse,
        BombThreat,
        Terrorism,
        SuspiciousIncident,
        Intelligence,
        CashLoss
    }
}
