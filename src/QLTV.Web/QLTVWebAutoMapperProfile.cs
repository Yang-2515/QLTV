using QLTV.ThuVien.Dtos;
using QLTV.Web.Pages.ThuVien.Example.ViewModels;
using AutoMapper;
using static QLTV.Web.Pages.ThuVien.Book.EditModalModel;
using QLTV.ThuVien.Dtos.Books;
using QLTV.ThuVien.Dtos.Borrow;
using static QLTV.Web.Pages.ThuVien.Borrow.EditModalModel;
using QLTV.Web.Pages.ThuVien.Author.ViewModels;
using QLTV.ThuVien.Dtos.Author;
using QLTV.ThuVien.Dtos.Categories;
using QLTV.Web.Pages.ThuVien.Category.ViewModels;

namespace QLTV.Web
{
    public class QLTVWebAutoMapperProfile : Profile
    {
        public QLTVWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.
            CreateMap<ExampleDto, CreateEditExampleViewModel>();
            CreateMap<CreateEditExampleViewModel, CreateUpdateExampleDto>();

            CreateMap<BorrowResponse, BorrowModel>();

            CreateMap<CategoryResponse, CreateEditCategoryViewModel>();
            CreateMap<CreateEditCategoryViewModel, CategoryRequest>();

            CreateMap<BookResponse, BookModel>();
            CreateMap< BookModel, BookRequest>();

            CreateMap<CreateEditAuthorViewModel, AuthorRequest>();
            CreateMap<AuthorResponse, CreateEditAuthorViewModel>();
        }
    }
}
