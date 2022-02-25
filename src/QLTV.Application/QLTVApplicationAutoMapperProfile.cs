
using QLTV.ThuVien.Dtos.Categories;
using QLTV.ThuVien.Dtos.Books;
using AutoMapper;
using QLTV.ThuVien;
using QLTV.ThuVien.Dtos;

using QLTV.ThuVien.Dtos.Author;
using QLTV.ThuVien.Dtos.Borrow;
using QLTV.ThuVien.Dtos.Reader;
using QLTV.ThuVien.Dtos.Block;

namespace QLTV
{
    public class QLTVApplicationAutoMapperProfile : Profile
    {
        public QLTVApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Example, ExampleDto>();
            CreateMap<CreateUpdateExampleDto, Example>(MemberList.Source);

            CreateMap<Category, CategoryResponse>();
            CreateMap<CategoryRequest, Category>();
            CreateMap<CategoryResponse, CategoryRequest>();

            CreateMap<Book, BookResponse>();
            CreateMap<BookRequest, Book>();
            CreateMap<BookResponse, BookRequest>();

            CreateMap <Reader,ReaderResponse>();
            CreateMap<ReaderRequest, Reader>();
            CreateMap<ReaderResponse, ReaderRequest>();

            CreateMap<Block, BlockResponse>();
            CreateMap<BlockRequest, Block >();
            CreateMap<BlockResponse, BlockRequest>();


            CreateMap<Author, AuthorResponse>();
            CreateMap<AuthorRequest, Author>();
            CreateMap<AuthorResponse, AuthorRequest>();

            CreateMap<Borrow, BorrowResponse>();
            CreateMap<BorrowRequest, Borrow>();
            CreateMap<BorrowResponse, BorrowRequest>();
        }
    }
}
