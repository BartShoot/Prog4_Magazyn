using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Models;

namespace Magazyn
{
    public interface EFCRUD
    {
        DataTable GetAll();
        void Insert();
        void Delete();
        void Update();
    }
}
