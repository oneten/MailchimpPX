using PX.Data;
using PX.Objects.CR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Attributes
/// </summary>
namespace Mailchimp
{
    public class ActivityTypesApplicationAttribute : PXIntListAttribute
    {
        public ActivityTypesApplicationAttribute()
            : base(
                new[] { Portal, Backend, Integration },
                new[] { "Portal", "Backend", "Integration" })
        {
        }
        
        public const int Portal = 0;
        public const int Backend = 1;
        public const int Integration = 2;

        public class portal : Constant<int> { public portal() : base(Portal) { } }
        public class backend : Constant<int> { public backend() : base(Backend) { } }
        public class integration : Constant<int> { public integration() : base(Integration) { } }
    }

}