using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.DAL;
using BL.MODEL;

namespace BL.BL
{
    public class ItemsBL
    {
        public static bool InsertItems(ItemModel objModel)
        {
            return ItemDAL.InsertItems(objModel);
        }

        public static bool InsertInventory(ItemModel objModel,string op)
        {
            try
            {
                if (ItemDAL.InsertInventory(objModel)) {

                   return WSDAL.UpdateStock(objModel.ItemID, objModel.Qiantity, op);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
           
        }

        public static bool UpdateItems(ItemModel objModel)
        {
            return ItemDAL.UpdateItems(objModel);
        }

        public static bool UpdateInventory(ItemModel objModel)
        {
            return ItemDAL.UpdateInventory(objModel);
        }

        public static bool DeleteItems(ItemModel objModel)
        {
            return ItemDAL.DeleteItems(objModel);
        }
        public static bool DeleteInventory(ItemModel objModel,string op)
        {
            try
            {
                if (ItemDAL.DeleteInventory(objModel))
                {

                    return WSDAL.UpdateStock(objModel.ItemID, objModel.Qiantity, op);
                }
                else {

                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataTable SelectItems()
        {
            return ItemDAL.SelectItems();
        }
        public static DataTable selectAllInventory()
        {
            return ItemDAL.SelectAllInventory();
        }

        public static bool UpdateADDTriggerItems(ItemModel objModel)
        {
            return ItemDAL.UpdateADDTriggerItems(objModel);
        }

        public static bool UpdateDeductTriggerItems(ItemModel objModel)
        {
            return ItemDAL.UpdateDeductTriggerItems(objModel);
        }
        public static ReturnObject SelectItemList()
        {

            try
            {
                return new ReturnObject
                {
                    MessageCode = MessageCode.Success,
                    Content = ItemDAL.SelectItemList().Tables[0]
                };
            }
            catch (Exception ex)
            {
                return HELPER.Validation.SystemError(ex);
            }
        }

        public static ReturnObject SelectSearchItems(string quary) {

            try
            {
                return new ReturnObject
                {
                    MessageCode = MessageCode.Success,
                    Content = ItemDAL.SearchFromStock(quary)
                };
            }
            catch (Exception ex)
            {
                return HELPER.Validation.SystemError(ex);
            }
        }
    }
}
