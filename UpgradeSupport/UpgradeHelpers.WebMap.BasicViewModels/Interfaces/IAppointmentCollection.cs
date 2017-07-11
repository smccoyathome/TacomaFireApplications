// *************************************************************************************
//  <copyright  company="Mobilize" file="IAppointmentCollection.cs">
//     Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
//  </copyright>
// <summary></summary>
//  *************************************************************************************
namespace UpgradeHelpers.BasicViewModels.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Collection used to identify an AppointmentCollectionViewModel
    /// </summary>
    public interface IAppointmentCollection
    {
        /// <summary>
        /// Gets the flatted items.
        /// </summary>
        /// <value>
        /// The flatted items.
        /// </value>
        object FlatItems { get; }

        /// <summary>
        /// Creates the appointment.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="description">The description.</param>
        /// <param name="isAllDay">if set to <c>true</c> [is all day].</param>
        /// <param name="location">The location of the appointment.</param>
        /// <returns>the new Appointment object in its flatten state</returns>
        object CreateAppointment(string subject, string start, string end, string description, bool isAllDay, string location);

        /// <summary>
        /// Removes the appointment.
        /// </summary>
        /// <param name="appointmentId">The appointment identifier.</param>
        void RemoveAppointment(string appointmentId);

        /// <summary>
        /// Updates the element.
        /// </summary>
        /// <param name="elementId">The element identifier.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="description">The description.</param>
        /// <param name="isAllDay">if set to <c>true</c> [is all day].</param>
        /// <param name="location">The new location of the appointment.</param>
        /// <returns>The updated element in its flatten state</returns>
        object UpdateElement(string elementId, string subject, string start, string end, string description, bool isAllDay, string location);

    }
}