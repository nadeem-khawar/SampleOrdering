using System;
using System.Collections.Generic;
using System.Text;

namespace SampleOrdering.UserService.Domain
{
    public static class UserServiceDbProperties
    {
        public static string DbTablePrefix { get; set; } = "";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "UserService";
    }
}
