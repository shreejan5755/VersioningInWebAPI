using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

/// <summary>
/// For Query string versioning system creating a custom contorller selector
/// </summary>
namespace URIBasedVersioning.Custom
{
    public class CustomControllerSelector: DefaultHttpControllerSelector
    {
        HttpConfiguration _config;
        public CustomControllerSelector(HttpConfiguration config): base(config) {
            _config = config;
        }

        //for QueryString Versioning
        //public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        //{
        //    //to get all the web api controller in our project we use GetControllerMapping()
        //    var controllers = GetControllerMapping();
        //    var routeData = request.GetRouteData();

        //    //getting the controllerName using routeData value function 
        //    var controllerName = routeData.Values["controller"].ToString();

        //    //create a versionNumber variable and initialize it to 1
        //    //this variable is used to keep track of the current request version number
        //    string versionNumber = "1";

        //    //from the uri taking only the query string parameter
        //    var versionQueryString = HttpUtility.ParseQueryString(request.RequestUri.Query);

        //    //check if the query string v has value or not and storing it in versionNumber variable
        //    if (versionQueryString["v"] != null) {
        //        versionNumber = versionQueryString["v"];
        //    }

        //    //selecting the controller name on basis of the query string parameter
        //    if (versionNumber == "1")
        //    {
        //        // if version number is 1, then append V1 to the controller name.
        //        // So at this point the, controller name will become StudentsV1
        //        controllerName = controllerName + "V1";
        //    }
        //    else
        //    {
        //        // if version number is 2, then append V2 to the controller name.
        //        // So at this point the, controller name will become StudentsV2
        //        controllerName = controllerName + "V2";
        //    }

        //    HttpControllerDescriptor controllerDescriptor;

        //    //using tryGetValue to see if the controller dictionary of our project has that controller
        //    if (controllers.TryGetValue(controllerName, out controllerDescriptor)) {
        //        return controllerDescriptor;
        //    }
        //    return null;
        //}


        //3. Custom Header Versioning
        //public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        //{
        //    //to get all the web api controller in our project we use GetControllerMapping()
        //    var controllers = GetControllerMapping();
        //    var routeData = request.GetRouteData();

        //    //getting the controllerName using routeData value function 
        //    var controllerName = routeData.Values["controller"].ToString();

        //    //create a versionNumber variable and initialize it to 1
        //    //this variable is used to keep track of the current request version number
        //    string versionNumber = "1";

        //    //from the uri taking only the query string parameter
        //    var versionQueryString = HttpUtility.ParseQueryString(request.RequestUri.Query);

        //    //a variable to hold the header name
        //    string customHeader = "X-StudentService-Version";

        //    //checking the request header to see if our customHeader string exist and 
        //    //getting the value form it
        //    if (request.Headers.Contains(customHeader)) {
        //        versionNumber = request.Headers.GetValues(customHeader).FirstOrDefault();

        //        //checking if the version number contains comma seperated value
        //        if (versionNumber.Contains(",")) {
        //            //taking only the first value before the "," comma as the version number
        //            versionNumber = versionNumber.Substring(0, versionNumber.IndexOf(","));
        //        }
        //    }

        //    //selecting the controller name on basis of the query string parameter
        //    if (versionNumber == "1")
        //    {
        //        // if version number is 1, then append V1 to the controller name.
        //        // So at this point the, controller name will become StudentsV1
        //        controllerName = controllerName + "V1";
        //    }
        //    else
        //    {
        //        // if version number is 2, then append V2 to the controller name.
        //        // So at this point the, controller name will become StudentsV2
        //        controllerName = controllerName + "V2";
        //    }

        //    HttpControllerDescriptor controllerDescriptor;

        //    //using tryGetValue to see if the controller dictionary of our project has that controller
        //    if (controllers.TryGetValue(controllerName, out controllerDescriptor))
        //    {
        //        return controllerDescriptor;
        //    }
        //    return null;
        //}


        //4. Accept Header versioning
        //public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        //{
        //    //to get all the web api controller in our project we use GetControllerMapping()
        //    var controllers = GetControllerMapping();
        //    var routeData = request.GetRouteData();

        //    //getting the controllerName using routeData value function 
        //    var controllerName = routeData.Values["controller"].ToString();

        //    //create a versionNumber variable and initialize it to 1
        //    //this variable is used to keep track of the current request version number
        //    string versionNumber = "1";

        //    //from the uri taking only the query string parameter
        //    var versionQueryString = HttpUtility.ParseQueryString(request.RequestUri.Query);

        //    //getting the acceptHeader paramteres that have version in it
        //    var acceptHeader = request.Headers.Accept
        //        .Where(a => a.Parameters.Count(p => p.Name.ToLower() == "version") > 0);

        //    // putting the value of the header parameter with name version in the versionNumber
        //    if (acceptHeader.Any()) {
        //        versionNumber = acceptHeader.First()
        //            .Parameters.First(p => p.Name.ToLower() == "version").Value;


        //    }

        //    //selecting the controller name on basis of the query string parameter
        //    if (versionNumber == "1")
        //    {
        //        // if version number is 1, then append V1 to the controller name.
        //        // So at this point the, controller name will become StudentsV1
        //        controllerName = controllerName + "V1";
        //    }
        //    else
        //    {
        //        // if version number is 2, then append V2 to the controller name.
        //        // So at this point the, controller name will become StudentsV2
        //        controllerName = controllerName + "V2";
        //    }

        //    HttpControllerDescriptor controllerDescriptor;

        //    //using tryGetValue to see if the controller dictionary of our project has that controller
        //    if (controllers.TryGetValue(controllerName, out controllerDescriptor))
        //    {
        //        return controllerDescriptor;
        //    }
        //    return null;
        //}


        // 5. Vendor Specific media type versioning
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            //to get all the web api controller in our project we use GetControllerMapping()
            var controllers = GetControllerMapping();
            var routeData = request.GetRouteData();

            //getting the controllerName using routeData value function 
            var controllerName = routeData.Values["controller"].ToString();

            //create a versionNumber variable and initialize it to 1
            //this variable is used to keep track of the current request version number
            string versionNumber = "1";

            //from the uri taking only the query string parameter
            var versionQueryString = HttpUtility.ParseQueryString(request.RequestUri.Query);

            //regular expression for the custom header parameter
            var regex = @"application\/vnd\.shreejanTech\.([a-z]+)\.v(?<version>[0-9]+)\+([a-z]+)";

            //getting the acceptHeader paramteres that matches with the regular expression
            var acceptHeader = request.Headers.Accept
                .Where(a => Regex.IsMatch(a.MediaType,regex,RegexOptions.IgnoreCase));

            // putting the value of the header parameter with name version in the versionNumber
            if (acceptHeader.Any())
            {
                var match = Regex.Match(acceptHeader.First().MediaType, regex, RegexOptions.IgnoreCase);
                versionNumber = match.Groups["version"].Value;

            }

            //selecting the controller name on basis of the query string parameter
            if (versionNumber == "1")
            {
                // if version number is 1, then append V1 to the controller name.
                // So at this point the, controller name will become StudentsV1
                controllerName = controllerName + "V1";
            }
            else
            {
                // if version number is 2, then append V2 to the controller name.
                // So at this point the, controller name will become StudentsV2
                controllerName = controllerName + "V2";
            }

            HttpControllerDescriptor controllerDescriptor;

            //using tryGetValue to see if the controller dictionary of our project has that controller
            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
            {
                return controllerDescriptor;
            }
            return null;
        }
    }
}