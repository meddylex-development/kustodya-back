using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces.AI
{
    public interface ITextAnalytics
    {
        Task<IEntitiesResult> ExtractEntitiesAsync(string text);

        public interface IEntitiesResult
        {
            public IList<string> Entities { get; }
            public string ErrorMessage { get; }
        }
    }
}
