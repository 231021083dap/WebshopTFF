using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.Authorization
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AnonymousAttribute : Attribute
    {
       
    }
}
