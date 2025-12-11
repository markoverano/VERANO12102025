using Microsoft.Extensions.Logging;

namespace VideoStore.Backend.Services
{
    public class FileValidationService : IFileValidationService
    {
        private readonly ILogger<FileValidationService> _logger;
        private readonly HashSet<string> _allowedExtensions;
        private readonly HashSet<string> _allowedMimeTypes;
        private readonly long _maxFileSizeBytes;

        public FileValidationService(ILogger<FileValidationService> logger, IConfiguration configuration)
        {
            _logger = logger;

            _allowedExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                ".mp4",
                ".avi",
                ".mov"
            };

            _allowedMimeTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "video/mp4",
                "video/x-msvideo",
                "video/avi",
                "video/quicktime",
                "video/x-quicktime"
            };

            var maxSizeMB = configuration.GetValue<int>("FileUpload:MaxFileSizeMB", 100);
            _maxFileSizeBytes = maxSizeMB * 1024L * 1024L;
        }

        public bool IsValidFileType(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                _logger.LogWarning("File validation failed: empty filename");
                return false;
            }

            var extension = Path.GetExtension(fileName);

            if (string.IsNullOrEmpty(extension))
            {
                _logger.LogWarning("File validation failed: no extension found for file {FileName}", fileName);
                return false;
            }

            var isValid = _allowedExtensions.Contains(extension);

            if (!isValid)
            {
                _logger.LogWarning("File validation failed: invalid extension {Extension} for file {FileName}", extension, fileName);
            }

            return isValid;
        }

        public bool IsValidFileSize(long fileSize)
        {
            if (fileSize <= 0)
            {
                _logger.LogWarning("File validation failed: file size is zero or negative ({FileSize} bytes)", fileSize);
                return false;
            }

            var isValid = fileSize <= _maxFileSizeBytes;

            if (!isValid)
            {
                _logger.LogWarning("File validation failed: file size {FileSize} bytes exceeds maximum {MaxSize} bytes",
                    fileSize, _maxFileSizeBytes);
            }

            return isValid;
        }

        public bool ValidateMimeType(string contentType)
        {
            if (string.IsNullOrWhiteSpace(contentType))
            {
                _logger.LogWarning("File validation failed: empty content type");
                return false;
            }

            var isValid = _allowedMimeTypes.Contains(contentType);

            if (!isValid)
            {
                _logger.LogWarning("File validation failed: invalid MIME type {ContentType}", contentType);
            }

            return isValid;
        }

        public string GetAllowedExtensions()
        {
            return string.Join(", ", _allowedExtensions.Select(e => e.TrimStart('.').ToUpperInvariant()));
        }

        public long GetMaxFileSizeInBytes()
        {
            return _maxFileSizeBytes;
        }

        public string GetMaxFileSizeFormatted()
        {
            return $"{_maxFileSizeBytes / (1024 * 1024)} MB";
        }
    }
}
