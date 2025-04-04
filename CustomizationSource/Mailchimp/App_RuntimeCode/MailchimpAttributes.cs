using PX.Data;
using PX.Data.BQL;
using PX.Objects.CR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Attributes
/// </summary>
/// 
namespace Mailchimp
{
    public class ActivityTypesApplicationAttribute : PXIntListAttribute
    {
        public ActivityTypesApplicationAttribute()
            : base(
                new[] { Portal, Backend, System, Integration },
                new[] { "Portal", "Backend", "System", "Integration" })
        {
        }
        
        public const int Portal = 0;
        public const int Backend = 1;
        //public const int Integration = 2; // Prior to 2024 R2, we used 2 for Integration. In 2024 R2, Acuamtica used 2 for System.
        public const int System = 2;
        public const int Integration = 3;

        public class portal : BqlType<IBqlInt, int>.Constant<portal> { public portal() : base(Portal) { } }
        public class backend : BqlType<IBqlInt, int>.Constant<backend> { public backend() : base(Backend) { } }
        public class system : BqlType<IBqlInt, int>.Constant<system> { public system() : base(System) { } }
        public class integration : BqlType<IBqlInt, int>.Constant<integration> { public integration() : base(Integration) { } }
    }
}