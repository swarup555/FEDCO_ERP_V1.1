﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE
{
    public interface IExcelUpload
    {
        int CreateExcelupload(ExcelUploadEntities ExcelUploadEntity);
    }
}
