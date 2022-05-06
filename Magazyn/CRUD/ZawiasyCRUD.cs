using FastMember;
using Magazyn.Models;
using System;
using System.Data;
using System.Reflection;
using Magazyn;

namespace Magazyn.CRUD
{
    public class ZawiasyCRUD : EFCRUD
    {
        private static readonly Lazy<ZawiasyCRUD> lazy = 
            new Lazy<ZawiasyCRUD>(() => new ZawiasyCRUD());
        public static ZawiasyCRUD Instance { get { return lazy.Value; } }
        private ZawiasyCRUD()
        {
        }

        public DataTable GetAll()
        {
            DataTable dt = new();
            using (var context = new MagazynDBContext())
            {
                using (var reader = ObjectReader.Create(context.Zawiasy))
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Insert()
        {
            Zawiasy zawias = new();
            AddDialog add = new();
            foreach (var propInfo in zawias.GetType().GetProperties())
            {
                add.AddTextBox(propInfo.Name);
            }
            add.Show();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
