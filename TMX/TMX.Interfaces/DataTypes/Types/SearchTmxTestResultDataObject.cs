﻿/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/21/2014
 * Time: 1:44 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Interfaces
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SearchTmxTestResultDataObject.
    /// </summary>
    public class SearchTmxTestResultDataObject : ISearchTmxTestResultDataObject
    {
//        public SwitchParameter OrderByPassRate { get; set; }
//        public SwitchParameter OrderByFailRate { get; set; }
//        
        public string Name { get; set; }
        public string Id { get; set; }
        public SwitchParameter FilterAll { get; set; }
        public string FilterNameContains { get; set; }
        public string FilterIdContains { get; set; }
        public string FilterDescriptionContains { get; set; }
        public SwitchParameter FilterPassed { get; set; }
        public SwitchParameter FilterFailed { get; set; }
        public SwitchParameter FilterNotTested { get; set; }
        public SwitchParameter FilterPassedWithBadSmell { get; set; }
        public SwitchParameter FilterOutAutomaticResults { get; set; }
        public SwitchParameter FilterOutAutomaticAndTechnicalResults { get; set; }
        public SwitchParameter OrderByTimeSpent { get; set; }
        public SwitchParameter OrderByDateTime { get; set; }
        public SwitchParameter OrderByName { get; set; }
        public SwitchParameter OrderById { get; set; }
        public SwitchParameter OrderByPassRate { get; set; }
        public SwitchParameter OrderByFailRate { get; set; }
        public SwitchParameter Descending { get; set; }
        public SwitchParameter FilterNone { get; set; }
    }
}
