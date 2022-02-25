using System.Threading.Tasks;
using QLTV.Permissions;
using QLTV.Localization;
using QLTV.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Authorization.Permissions;
using System;

namespace QLTV.Web.Menus
{
    public class QLTVMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var administration = context.Menu.GetAdministration();

            var l = context.GetLocalizer<QLTVResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    QLTVMenus.Home,
                    l["Menu:Home"],
                    "~/",
                    icon: "fas fa-home",
                    order: 0
                )
            );

            if (MultiTenancyConsts.IsEnabled)
            {
                administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
            }
            else
            {
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
            administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

            //context.Menu.AddItem(
            //        new ApplicationMenuItem(QLTVMenus.Example, l["Menu:Example"], "/ThuVien/Example")
            //    );

            context.Menu.AddItem(new ApplicationMenuItem("Category", l["Category"], order: 1, icon: "fa fa-th", url: "/ThuVien/Category").RequirePermissions(QLTVPermissions.Category.Default));
            context.Menu.AddItem(new ApplicationMenuItem("Author", l["Author"], order: 2, icon: "fa fa-user-edit", url: "/ThuVien/Author").RequirePermissions(QLTVPermissions.Author.Default));
            context.Menu.AddItem(new ApplicationMenuItem("Reader", l["Reader"], order: 3, icon: "fa fa-book-reader", url: "/ThuVien/Reader").RequirePermissions(QLTVPermissions.Reader.Default));
            context.Menu.AddItem(new ApplicationMenuItem("Block", l["Block"], order: 4, icon: "fas fa-archive", url: "/ThuVien/Block").RequirePermissions(QLTVPermissions.Block.Default));
            context.Menu.AddItem(new ApplicationMenuItem("Borrow", l["Borrow"], order: 5, icon: "fas fa-hands-helping", url: "/ThuVien/Borrow").RequirePermissions(QLTVPermissions.Borrow.Default));
            context.Menu.AddItem(new ApplicationMenuItem("Book", l["Book"], order: 6, icon: "fas fa-book", url: "/ThuVien/Book").RequirePermissions(QLTVPermissions.Book.Default));
        }
    }
}
