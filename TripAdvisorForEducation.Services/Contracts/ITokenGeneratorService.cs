using System;
using System.Collections.Generic;
using System.Text;

namespace TripAdvisorForEducation.Services.Contracts
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(int size);
    }
}
