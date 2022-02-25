using Microsoft.AspNetCore.Mvc.Rendering;
using QLTV.Web.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLTV.Web.Pages.ThuVien.Block
{
    public class IndexModel : QLTVPageModel
    {

    public List<SelectListItem> Option { get; set; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "None", Text = "None"},
        new SelectListItem { Value = "Chua", Text = "Chưa có sách"},
        new SelectListItem { Value = "Day", Text = "Đã đầy"},
        new SelectListItem { Value = "Trong", Text = "Còn trống"}
    };
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }


    }
}
