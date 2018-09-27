using DATA_LAYER.HRMSOUW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;
using DATA_LAYER;
using System.Transactions;

namespace BUSSINESS_SERVICE
{
    public class BoardTypeService:IBoardType
    {
         private readonly UOW _UOW;
         public BoardTypeService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<BoardEntities> GetBoardTypeById(int BoardTypeId)
        {
            var data = (from bo in _UOW.BOARD_UNIVERSITYRepository.GetAll()
                        where bo.ID == BoardTypeId
                        select new BoardEntities
                        {
                            ID = bo.ID,
                            BOARD_UNIVERSITY_NAME = bo.BOARD_UNIVERSITY_NAME
                        }).ToList();
            return data;
        }

        public IEnumerable<BoardEntities> GetAllBoardType()
        {
            var data = (from bo in _UOW.BOARD_UNIVERSITYRepository.GetAll()
                        select new BoardEntities
                        {
                            ID = bo.ID,
                            BOARD_UNIVERSITY_NAME = bo.BOARD_UNIVERSITY_NAME
                        }).ToList();
            return data;
        }

        public int CreateBoardType(BoardEntities BoardTypeEntities)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBoardType(int BoardTypeId, BoardEntities BoardTypeEntities)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBoardType(int BoardTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
