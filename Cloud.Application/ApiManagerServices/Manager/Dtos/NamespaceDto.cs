using System.Collections.Generic;

namespace Cloud.ApiManagerServices.Manager.Dtos
{
    public class NamespaceDto
    {
        public string Name { get; set; }

        public string Display { get; set; }

        public string Url { get; set; }

        public IEnumerable<NamespaceDto> Children { get; set; }

        public NamespaceDto()
        {

        }
        public NamespaceDto(string name, string display, string url)
        {
            Name = name;
            Display = display;
            Url = url;
        }

    }
}