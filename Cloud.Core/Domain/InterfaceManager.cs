using System.Collections.Generic;
using Abp.Domain.Entities;

namespace Cloud.Domain
{
    public class InterfaceManager : Entity<string>
    {
        public sealed override string Id { get; set; }

        public IEnumerable<TestManager> TestManager { get; set; }

        public InterfaceManager()
        {

        }

        public InterfaceManager(string url)
        {
            Id = url;
        }

    }
}