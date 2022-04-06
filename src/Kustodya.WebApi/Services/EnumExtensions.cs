using Kustodya.WebApi.Models;
using Kustodya.WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.WebApi.Services
{
    public class EnumExtensions: IEnumExtensions
    {
        public List<EnumValueModel> GetValues<T>()
        {
            List<EnumValueModel> values = new List<EnumValueModel>();
            foreach (var itemType in Enum.GetValues(typeof(T)))
            {
                values.Add(new EnumValueModel()
                {
                    Name = Enum.GetName(typeof(T), itemType),
                    Value = Convert.ToInt32(itemType)
                });
            }
            return values;
        }
    }
}
