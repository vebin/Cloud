﻿using System.Collections.Generic;

namespace Cloud.ApiManagerServices.Manager.Dtos
{
    public class NamespaceDto
    {
        public string Name { get; set; }

        public string Display { get; set; }

        public string Url { get; set; }

        public IEnumerable<NamespaceDto> Children { get; set; }

    }
}