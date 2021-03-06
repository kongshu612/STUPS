﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/21/2014
 * Time: 12:04 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    // using System.Management.Automation;
    
    /// <summary>
    /// Description of SearchCmdletBaseDataObject.
    /// </summary>
    public class SearchCmdletBaseDataObject : ISearchCmdletBaseDataObject
    {
//        public string Name { get; set; }
//        public string Id { get; set; }
//        public SwitchParameter FilterAll { get; set; }
//        public string FilterNameContains { get; set; }
//        public string FilterIdContains { get; set; }
//        public string FilterDescriptionContains { get; set; }
//        public SwitchParameter FilterPassed { get; set; }
//        public SwitchParameter FilterFailed { get; set; }
//        public SwitchParameter FilterNotTested { get; set; }
//        public SwitchParameter FilterPassedWithBadSmell { get; set; }
//        public SwitchParameter FilterOutAutomaticResults { get; set; }
//        public SwitchParameter FilterOutAutomaticAndTechnicalResults { get; set; }
//        public SwitchParameter OrderByTimeSpent { get; set; }
//        public SwitchParameter OrderByDateTime { get; set; }
//        public SwitchParameter OrderByName { get; set; }
//        public SwitchParameter OrderById { get; set; }
//        public SwitchParameter OrderByPassRate { get; set; }
//        public SwitchParameter OrderByFailRate { get; set; }
//        public SwitchParameter Descending { get; set; }
//        public SwitchParameter FilterNone { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public bool FilterAll { get; set; }
        public string FilterNameContains { get; set; }
        public string FilterIdContains { get; set; }
        public string FilterDescriptionContains { get; set; }
        public bool FilterPassed { get; set; }
        public bool FilterFailed { get; set; }
        public bool FilterNotTested { get; set; }
        public bool FilterPassedWithBadSmell { get; set; }
        public bool FilterOutAutomaticResults { get; set; }
        public bool FilterOutAutomaticAndTechnicalResults { get; set; }
        public bool OrderByTimeSpent { get; set; }
        public bool OrderByDateTime { get; set; }
        public bool OrderByName { get; set; }
        public bool OrderById { get; set; }
        public bool OrderByPassRate { get; set; }
        public bool OrderByFailRate { get; set; }
        public bool Descending { get; set; }
        public bool FilterNone { get; set; }
    }
}
