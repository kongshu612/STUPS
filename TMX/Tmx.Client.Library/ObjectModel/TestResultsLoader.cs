﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/22/2014
 * Time: 8:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client.Library.ObjectModel
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Xml.Linq;
    using Core;
    using Core.Types.Remoting;
    using Interfaces.Exceptions;
    using Interfaces.Server;
    using Helpers;
    using Spring.Rest.Client;
//using System.Collections.Generic;
    //using System.Linq;

    /// <summary>
    /// Description of TestResultsLoader.
    /// </summary>
    public class TestResultsLoader
    {
        readonly IRestOperations _restTemplate;
        
        //public TestResultsLoader(IRestRequestCreator requestCreator)
        //{
        //    _restTemplate = requestCreator.GetRestTemplate();
        //}

        public TestResultsLoader()
        {
            _restTemplate = RestRequestFactory.GetRestRequestCreator().GetRestTemplate();
        }
        
        public virtual bool LoadTestResults()
        {
            try {
                var url = UrlList.TestResults_Root + "/" + ClientSettings.Instance.CurrentClient.TestRunId + UrlList.TestResultsPostingPoint_forClient_relPath;
                
                // 20141211
                // TODO: AOP
                Trace.TraceInformation("LoadTestResults().1: testRun id = {0}, url = {1}", ClientSettings.Instance.CurrentClient.TestRunId, url);
                
                
                var loadingResultsResponse = _restTemplate.GetForMessage<TestResultsDataObject>(url);
                
                Trace.TraceInformation("LoadTestResults().2: loadingResultsResponse is null?{0}", null == loadingResultsResponse);
                // 20150316
                if (null == loadingResultsResponse)
                    throw  new Exception("Failed to load test resuylts.");
                
                var testResultsImporter = new TestResultsImporter();
                
                Trace.TraceInformation("LoadTestResults().3");
                
                var xDoc = XDocument.Parse(loadingResultsResponse.Body.Data);
                
                Trace.TraceInformation("LoadTestResults().4");
                
                testResultsImporter.MergeTestPlatforms(TestData.TestPlatforms, testResultsImporter.ImportTestPlatformFromXdocument(xDoc));
                
                Trace.TraceInformation("LoadTestResults().5");
                
                testResultsImporter.MergeTestSuites(TestData.TestSuites, testResultsImporter.ImportTestResultsFromXdocument(xDoc));
                
                Trace.TraceInformation("LoadTestResults().6");
                
                // 20141211
                // TODO: AOP
                Trace.TraceInformation("LoadTestResults().7: still okay");
                
                
                return HttpStatusCode.OK == loadingResultsResponse.StatusCode;
            }
            catch (RestClientException eLoadingTestResults) {
                // TODO: AOP
                Trace.TraceError("LoadTestResults()");
                Trace.TraceError(eLoadingTestResults.Message);
                throw new LoadingTestResultsException("Failed to receive test results. " + eLoadingTestResults.Message);
            }
        }
    }
}
