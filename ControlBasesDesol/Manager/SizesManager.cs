using System;
using System.Collections.Generic;
using ControlBasesDesol.Models;
using ControlBasesDesol.Services;

namespace ControlBasesDesol.Manager
{
    internal class SizesManager
    {
        private readonly SizesService _sizesService;

        public SizesManager()
        {
            _sizesService = new SizesService();
        }

        public ResponseBase saveSizesBase(List<DatabaseSizesModelRequest> listSizes)
        {
            var response = new ResponseBase();
            var listModel = new List<DatabaseSizesModel>();

            try
            {
                foreach (var sizes in listSizes)
                {
                    var model = new DatabaseSizesModel();

                    model.Instance = sizes.Instance;
                    model.Base = sizes.Base;
                    model.SizeMB = sizes.SizeMB;
                    model.FreeSpaceMB = sizes.FreeSpaceMB;
                    model.MaxSize = sizes.MaxSize;
                    model.Growth = sizes.Growth;
                    model.IsPercentGrowth = sizes.IsPercentGrowth ? 1 : 0;
                    model.LogicName = sizes.LogicName;
                    model.PhysicName = sizes.PhysicName;
                    model.Type = sizes.Type;
                    model.Fecha = sizes.Fecha;

                    listModel.Add(model);
                }

                _sizesService.saveBasesSizes(listModel);

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return response;
        }

        public ResponseBase saveSizesTable(List<TablesSizesModel> listTables)
        {
            var response = new ResponseBase();

            try
            {
                _sizesService.saveTablesSizes(listTables);

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return response;
        }
    }
}