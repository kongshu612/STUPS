﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/13/2014
 * Time: 2:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
    using System.Management.Automation;
    using Nancy;
    using Nancy.ModelBinding;
	using TMX.Interfaces;
	using Tmx;
	using Tmx.Core;
	using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestResultsModule.
    /// </summary>
    public class TestResultsModule : NancyModule
    {
        public TestResultsModule() : base(UrnList.TestStructure_Root)
        {
            StaticConfiguration.DisableErrorTraces = false;
            
            Post[UrnList.TestStructure_Suites] = parameters => {
                // var testSuite = this.Bind<TestSuite>();
                var testSuite = this.Bind<ITestSuite>();
                TmxHelper.NewTestSuite(testSuite.Name, testSuite.Id, testSuite.PlatformId, testSuite.Description, testSuite.BeforeScenario, testSuite.AfterScenario);
                TestData.SetSuiteStatus(true);
				return TmxHelper.OpenTestSuite(testSuite.Name, testSuite.Id, testSuite.PlatformId) ? HttpStatusCode.Created : HttpStatusCode.InternalServerError;
            };
        	
        	Post[UrnList.TestStructure_Scenarios] = parameters => {
        		// var testScenario = this.Bind<TestScenario>();
        		var testScenario = this.Bind<ITestScenario>();
//        		var cmdletAdd = new AddScenarioCmdletBase {
//        			Name = testScenario.Name,
//        			Id = testScenario.Id,
//        			TestPlatformId = testScenario.PlatformId,
//        			TestSuiteId = testScenario.SuiteId,
//        			Description = testScenario.Description
//        		};
//        		TmxHelper.AddTestScenario(cmdletAdd);
        		var dataObjectAdd = new AddScenarioCmdletBaseDataObject {
        			Name = testScenario.Name,
        			Id = testScenario.Id,
        			TestPlatformId = testScenario.PlatformId,
        			TestSuiteId = testScenario.SuiteId,
        			Description = testScenario.Description
        		};
        		TmxHelper.AddTestScenario(dataObjectAdd);
        		TestData.SetScenarioStatus(true);
        		
//        		var cmdletOpen = new OpenScenarioCmdletBase {
//        			Name = testScenario.Name,
//        			Id = testScenario.Id,
//        			TestPlatformId = testScenario.PlatformId
//        		};
//        		return TmxHelper.OpenTestScenario(cmdletOpen) ? HttpStatusCode.Created : HttpStatusCode.InternalServerError;
        		var dataObjectOpen = new OpenScenarioCmdletBaseDataObject {
        			Name = testScenario.Name,
        			Id = testScenario.Id,
        			TestPlatformId = testScenario.PlatformId
        		};
        		return TmxHelper.OpenTestScenario(dataObjectOpen) ? HttpStatusCode.Created : HttpStatusCode.InternalServerError;
        	};
        }
    }
}
