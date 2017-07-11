// *************************************************************************************
//  <copyright  company="Mobilize" file="ICalendarInfo.cs">
//     Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
//  </copyright>
// <summary></summary>
//  *************************************************************************************
using System;

namespace UpgradeHelpers.BasicViewModels.Interfaces
{
    /// <summary>
    /// Interface used by the UltraMonthCalendarController to Trigger
    /// different Event of the CalendarInfo 
    /// </summary>
    public interface ICalendarInfo
    {
        /// <summary>
        /// Triggers the after active day changed.
        /// </summary>
        /// <param name="currentDate">The current date.</param>
        void TriggerAfterActiveDayChanged(DateTime currentDate);

        /// <summary>
        /// Triggers the before appointment display dialog.
        /// </summary>
        /// <param name="appointmentId">The appointment identifier.</param>
        void TriggerBeforeAppointmentDisplayDialog(string appointmentId);
    }
}