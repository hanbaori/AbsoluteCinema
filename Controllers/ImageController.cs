using AbsoluteCinema.Models.Domain;
using AbsoluteCinema.Repository;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
    private readonly IImageRepository _imageRepository;
    private readonly ILogger<ImageController> _logger;

    public ImageController(IImageRepository imageRepository,
        ILogger<ImageController> logger)
    {
        _imageRepository = imageRepository;
        _logger = logger;
    }

    [HttpPost, Route("Upload")]
    public async Task<IActionResult> Upload(RequestImageUploadDTO imageDTO)
    {
        _logger.LogInformation($"{nameof(Upload)} called with filename: {imageDTO.FileName}");
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
            _logger.LogInformation($"{nameof(Upload)} uploaded image: {imageDTO.FileName}, size: {imageDTO.File.Length} bytes");
            return Ok(image);
        }

        _logger.LogWarning($"{nameof(Upload)} invalid image upload attempt for file: {imageDTO.FileName}");
        return BadRequest(ModelState);
    }

    private void ValidateImage(RequestImageUploadDTO requestedImage)
    {
        var allowedExtensions = new string[] { ".jpg", ".png" };
        if (!allowedExtensions.Contains(Path.GetExtension(requestedImage.File.FileName)))
            ModelState.AddModelError("file", "Unsupported extension");
        if (requestedImage.File.Length > 10485760)
            ModelState.AddModelError("file", "File size is too large");
    }
}