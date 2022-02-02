using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretProject.Web.Infrastructure.Providers
{
    public class ResourceProvider : IContentTypeProvider
    {
        public bool TryGetContentType(string subpath, out string contentType)
        {
            throw new NotImplementedException();
        }
    }
}
