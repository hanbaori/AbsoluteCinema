using AbsoluteCinema.Models.Domain;

namespace AbsoluteCinema.Repository
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
