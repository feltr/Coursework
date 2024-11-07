using Coursework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Core.Abstractions
{
    public interface IPechService
    {
        Task<Guid> CreatePech(Pech book);
        Task<Guid> UpdatePech(Guid id, float tPech, float diametr, float tNach, float kTeplo, float p, float tPov, float kPer);
        Task<Guid> DeletePech(Guid id);
        Task<List<Pech>> GetAllPech();
    }
}
