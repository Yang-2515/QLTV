using System.Threading.Tasks;

namespace QLTV.Web.Pages
{
    public class IndexModel : QLTVPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}