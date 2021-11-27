using RestSharp;

namespace EAR_CLAIM.Services
{
    public class Class1 : Interface
    {
        public string Name(Models.Class @class,string url)
        {

            var body = @"<?xml version=""1.0"" encoding=""ISO-8859-1""?>
                        " + "\n" +
                        @"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:enc=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" SOAP-ENV:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">
                        " + "\n" +
                        @"        <SOAP-ENV:Header />
                        " + "\n" +
                        @"        <SOAP-ENV:Body>
                        " + "\n" +
                        @"                <swpaep:closeWorksheet xmlns:swpaep=""urn:SicsWsPcAccountingEntryPoint"">
                        " + "\n" +
                        @"                        <genericInput>
                        " + "\n" +
                        @"                                <userIdForLogging>kamlesh.dhakad</userIdForLogging>
                        " + "\n" +
                        @"                        </genericInput>
                        " + "\n" +
                        @"                        <closeWorksheet>
                        " + "\n" +
                        @"                                <worksheetReference>
                        " + "\n" +
                        @"                                        <identifier>AC0199</identifier>
                        " + "\n" +
                        @"                                </worksheetReference>
                        " + "\n" +
                        @"                                <worksheet>
                        " + "\n" +
                        @"                                        <changeStatus />
                        " + "\n" +
                        @"                                        <statusChangeTo>
                        " + "\n" +
                        @"                                                <code>C</code>
                        " + "\n" +
                        @"                                                <subclassNumber>168</subclassNumber>
                        " + "\n" +
                        @"                                        </statusChangeTo>
                        " + "\n" +
                        @"                                        <reasonForStatusChange>Test reasonForStatusChange</reasonForStatusChange>
                        " + "\n" +
                        @"                                </worksheet>
                        " + "\n" +
                        @"                        </closeWorksheet>
                        " + "\n" +
                        @"                </swpaep:closeWorksheet>
                        " + "\n" +
                        @"        </SOAP-ENV:Body>
                        " + "\n" +
                        @"</SOAP-ENV:Envelope>";

            if(body.Contains("<userIdForLogging>kamlesh.dhakad</userIdForLogging>"))
            {
                string userid = "<userIdForLogging>" + @class.userId + "</userIdForLogging>";
                body = body.Replace("<userIdForLogging>kamlesh.dhakad</userIdForLogging>", userid);
            }

            if (body.Contains("<identifier>AC0199</identifier>"))
            {
                string userid = "<identifier>" + @class.worksheetReference + "</identifier>";
                body = body.Replace("<identifier>AC0199</identifier>", userid);
            }

            if (body.Contains("<subclassNumber>168</subclassNumber>"))
            {
                string userid = "<subclassNumber>" + @class.subclassNumber + "</subclassNumber>";
                body = body.Replace("<subclassNumber>168</subclassNumber>", userid);
            }

            if (body.Contains("<reasonForStatusChange>Test reasonForStatusChange</reasonForStatusChange>"))
            {
                string userid = "<reasonForStatusChange>" + @class.reasonForStatusChange + "</reasonForStatusChange>";
                body = body.Replace("<reasonForStatusChange>Test reasonForStatusChange</reasonForStatusChange>", userid);
            }


            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/xml");
            request.AddParameter("text/xml", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);


            return response.Content;
        }
    }
}
