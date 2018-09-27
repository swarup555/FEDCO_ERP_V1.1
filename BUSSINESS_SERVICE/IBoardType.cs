using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE
{
    public interface IBoardType
    {
        IEnumerable<BoardEntities> GetBoardTypeById(int BoardTypeId);
        IEnumerable<BoardEntities> GetAllBoardType();
        int CreateBoardType(BoardEntities BoardTypeEntities);
        bool UpdateBoardType(int BoardTypeId, BoardEntities BoardTypeEntities);
        bool DeleteBoardType(int BoardTypeId); 
    }
}
