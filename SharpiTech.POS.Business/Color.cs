using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class Color
    {
        private readonly DataModel.Color _color;

        public Color()
        {
            _color = new DataModel.Color();
        }

        public List<Entities.Color> GetAllColorsName()
        {
            return _color.GetAllColorsName();
        }

    }
}
