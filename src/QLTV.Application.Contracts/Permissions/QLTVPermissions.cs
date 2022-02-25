namespace QLTV.Permissions
{
    public static class QLTVPermissions
    {
        public const string GroupName = "QLTV";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public class Example
        {
            public const string Default = GroupName + ".Example";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Category
        {
            public const string Default = GroupName + ".Category";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Search = Default + ".Search";
        }

        public class Author
        {
            public const string Default = GroupName + ".Author";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Search = Default + ".Search";
        }

        public class Reader
        {
            public const string Default = GroupName + ".Reader";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Search = Default + ".Search";
        }

        public class Block
        {
            public const string Default = GroupName + ".Block";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Search = Default + ".Search";
        }

        public class Borrow
        {
            public const string Default = GroupName + ".Borrow";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Search = Default + ".Search";
        }

        public class Book
        {
            public const string Default = GroupName + ".Book";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Search = Default + ".Search";
        }
    }
}
