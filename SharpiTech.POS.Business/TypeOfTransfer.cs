using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class TypeOfTransfer
    {
        private readonly DataModel.TypeOfTransfer _typeOfTransfer;

        public TypeOfTransfer()
        {
            _typeOfTransfer = new DataModel.TypeOfTransfer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.TypeOfTransfer> GetTransferTypes()
        {
            return _typeOfTransfer.GetTransferTypes();
        }

    }
}
