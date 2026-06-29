using AbsoluteCinema.Models.Domain;
using AbsoluteCinema.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AbsoluteCinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpPost, Route("Upload")]
        public async Task<IActionResult> Upload(RequestImageUploadDTO imageDTO)
        {

            ValidateImage(imageDTO);

            if (ModelState.IsValid)
            {
                var image = new Image
                {
                    FileName = imageDTO.FileName,
                    FileExtension = Path.GetExtension(imageDTO.FileName),
                    File = imageDTO.File,
                    FileSizeInBytes = imageDTO.File.Length
                };

                await _imageRepository.Upload(image);

                return Ok(image);
            }

            return BadRequest(ModelState);
        }
        

        private void ValidateImage(RequestImageUploadDTO requestedImage)
        {
            var allowedExtensions = new string[] {".jpg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(requestedImage.File.FileName)))
                ModelState.AddModelError("file", "Unsupported extension");

            if (requestedImage.File.Length > 10485760)
                ModelState.AddModelError("file", "File size is too large");
        }
    }
}
