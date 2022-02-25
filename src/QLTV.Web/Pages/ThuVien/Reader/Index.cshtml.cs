using QLTV.Web.Pages;
using System.Threading.Tasks;

namespace QLTV.Web.Pages.ThuVien.Reader
{
    public class IndexModel : QLTVPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
