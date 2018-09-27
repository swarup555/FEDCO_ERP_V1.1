using BUSSINESS_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_SERVICE
{
    public interface ITransferDetails
    {
        IEnumerable<TransferdetailsEntities> GetTransferDetailsById(int AssetDetailsId);
        IEnumerable<TransferdetailsEntities> GetAllTransferDetails();
        int CreateTransferDetails(TransferdetailsEntities TransferDetailEntities);
        bool UpdateTransferDetails(int TransferDetailsId, TransferdetailsEntities TransferDetailEntities);
        bool DeleteTransferDetails(int TransferDetailsId);
    }
}
