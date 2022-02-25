using QLTV.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace QLTV.Permissions
{
    public class QLTVPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(QLTVPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(QLTVPermissions.MyPermission1, L("Permission:MyPermission1"));

            //var examplePermission = myGroup.AddPermission(QLTVPermissions.Example.Default, L("Permission:Example"));
            //examplePermission.AddChild(QLTVPermissions.Example.Create, L("Permission:Create"));
            //examplePermission.AddChild(QLTVPermissions.Example.Update, L("Permission:Update"));
            //examplePermission.AddChild(QLTVPermissions.Example.Delete, L("Permission:Delete"));

            var CategoryPermission = myGroup.AddPermission(QLTVPermissions.Category.Default, L("Permission:Category"));
            CategoryPermission.AddChild(QLTVPermissions.Category.Create, L("Permission:Create"));
            CategoryPermission.AddChild(QLTVPermissions.Category.Update, L("Permission:Update"));
            CategoryPermission.AddChild(QLTVPermissions.Category.Delete, L("Permission:Delete"));
            CategoryPermission.AddChild(QLTVPermissions.Category.Search, L("Permission:Search"));

            var AuthorPermission = myGroup.AddPermission(QLTVPermissions.Author.Default, L("Permission:Author"));
            AuthorPermission.AddChild(QLTVPermissions.Author.Create, L("Permission:Create"));
            AuthorPermission.AddChild(QLTVPermissions.Author.Update, L("Permission:Update"));
            AuthorPermission.AddChild(QLTVPermissions.Author.Delete, L("Permission:Delete"));
            AuthorPermission.AddChild(QLTVPermissions.Author.Search, L("Permission:Search"));

            var ReaderPermission = myGroup.AddPermission(QLTVPermissions.Reader.Default, L("Permission:Reader"));
            ReaderPermission.AddChild(QLTVPermissions.Reader.Create, L("Permission:Create"));
            ReaderPermission.AddChild(QLTVPermissions.Reader.Update, L("Permission:Update"));
            ReaderPermission.AddChild(QLTVPermissions.Reader.Delete, L("Permission:Delete"));
            ReaderPermission.AddChild(QLTVPermissions.Reader.Search, L("Permission:Search"));

            var BlockPermission = myGroup.AddPermission(QLTVPermissions.Block.Default, L("Permission:Block"));
            BlockPermission.AddChild(QLTVPermissions.Block.Create, L("Permission:Create"));
            BlockPermission.AddChild(QLTVPermissions.Block.Update, L("Permission:Update"));
            BlockPermission.AddChild(QLTVPermissions.Block.Delete, L("Permission:Delete"));
            BlockPermission.AddChild(QLTVPermissions.Block.Search, L("Permission:Search"));

            var BorrowPermission = myGroup.AddPermission(QLTVPermissions.Borrow.Default, L("Permission:Borrow"));
            BorrowPermission.AddChild(QLTVPermissions.Borrow.Create, L("Permission:Create"));
            BorrowPermission.AddChild(QLTVPermissions.Borrow.Update, L("Permission:Update"));
            BorrowPermission.AddChild(QLTVPermissions.Borrow.Delete, L("Permission:Delete"));
            BorrowPermission.AddChild(QLTVPermissions.Borrow.Search, L("Permission:Search"));

            var BookPermission = myGroup.AddPermission(QLTVPermissions.Book.Default, L("Permission:Book"));
            BookPermission.AddChild(QLTVPermissions.Book.Create, L("Permission:Create"));
            BookPermission.AddChild(QLTVPermissions.Book.Update, L("Permission:Update"));
            BookPermission.AddChild(QLTVPermissions.Book.Delete, L("Permission:Delete"));
            BookPermission.AddChild(QLTVPermissions.Book.Search, L("Permission:Search"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<QLTVResource>(name);
        }
    }
}
