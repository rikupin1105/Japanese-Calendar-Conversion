namespace Japanese_calendar_conversion
{

    public class DialogFlowRequest
    {
        public string responseId { get; set; }
        public Queryresult queryResult { get; set; }
        public Originaldetectintentrequest originalDetectIntentRequest { get; set; }
        public string session { get; set; }
    }

    public class Queryresult
    {
        public string queryText { get; set; }
        public Parameters parameters { get; set; }
        public bool allRequiredParamsPresent { get; set; }
        public Fulfillmentmessage[] fulfillmentMessages { get; set; }
        public Outputcontext[] outputContexts { get; set; }
        public Intent intent { get; set; }
        public float intentDetectionConfidence { get; set; }
        public string languageCode { get; set; }
    }

    public class Parameters
    {
        public float number { get; set; }
    }

    public class Intent
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public bool endInteraction { get; set; }
    }

    public class Fulfillmentmessage
    {
        public Text text { get; set; }
    }

    public class Text
    {
        public string[] text { get; set; }
    }

    public class Outputcontext
    {
        public string name { get; set; }
        public Parameters1 parameters { get; set; }
    }

    public class Parameters1
    {
        public float noinput { get; set; }
        public float nomatch { get; set; }
        public float number { get; set; }
        public string numberoriginal { get; set; }
    }

    public class Originaldetectintentrequest
    {
        public string source { get; set; }
        public Payload payload { get; set; }
    }

    public class Payload
    {
    }

}
