using System.Collections.Generic;

namespace Cloud.MonitorAppServices.ExceptionApp.Dtos
{
    public class GetDetailsOutput
    {
        public string Display { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public IEnumerable<GetDetailsOutput> Details { get; set; }

        public GetDetailsOutput(string name, string display, string type)
        {
            Display = display;
            Name = name;
            Type = type;
        }

        public GetDetailsOutput()
        {

        }
    }

    public class TypeState
    {
        public const string MaxText = "MaxText";
        public const string Input = "Input";
        public const string Number = "Number";
        public const string Phone = "Phone";
        public const string DateTime = "DateTime";
        public const string Auto = "Auto";
        public const string DropDownList = "DropDownList";

    }
}