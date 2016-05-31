using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.MODEL;
using System.Data;
namespace BL.DAL
{
    public class ItemDAL
    {
        public static bool InsertItems(ItemModel objModel)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" INSERT INTO TB_ITEMS  (CATEGORY_ID, NAME, DISCRIPTION, PRICE_IN, PRICE_OUT,QUANTITY,BIN_LOCATION,REORDER_LEVEL) ");
            sql.Append(" VALUES  (@CATEGORY_ID, @NAME, @DISCRIPTION, @PRICE_IN, @PRICE_OUT,0,@BIN_LOCATION,@REORDER_LEVEL)");
            var dic = new Dictionary<string, string>
            {
                {"CATEGORY_ID", objModel.Category.ToString()},
                {"NAME", objModel.Name},
                {"DISCRIPTION", objModel.Discription},
                {"PRICE_IN", objModel.PriceIn.ToString()},
                {"PRICE_OUT", objModel.PriceOut.ToString()},
                {"QUANTITY", "0"},
                {"BIN_LOCATION", objModel.BinLocation.ToString()},
                {"REORDER_LEVEL", objModel.ReorderPoint.ToString()}
            };
            return DBAccess.Update(new DataObject
            {
                KeyValue = dic,
                Sql = sql.ToString()
            });
        }

        public static bool UpdateItems(ItemModel objModel)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE    TB_ITEMS ");
            sql.Append(" SET   CATEGORY_ID =@CATEGORY_ID, NAME =@NAME, DISCRIPTION =@DISCRIPTION, ");
            sql.Append(" PRICE_IN =@PRICE_IN, PRICE_OUT = @PRICE_OUT, BIN_LOCATION = @BIN_LOCATION,REORDER_LEVEL=@REORDER_LEVEL");
            sql.Append(" WHERE     (ID =@ID)");
            var dic = new Dictionary<string, string>
            {
                {"ID", objModel.ItemID.ToString()},
                {"CATEGORY_ID", objModel.Category.ToString()},
                {"NAME", objModel.Name},
                {"DISCRIPTION", objModel.Discription},
                {"PRICE_IN", objModel.PriceIn.ToString()},
                {"PRICE_OUT", objModel.PriceOut.ToString()},
                {"BIN_LOCATION", objModel.BinLocation.ToString()},
                {"REORDER_LEVEL", objModel.ReorderPoint.ToString()}
            };
            return DBAccess.Update(new DataObject
            {
                KeyValue = dic,
                Sql = sql.ToString()
            });
        }

        public static bool DeleteItems(ItemModel objModel)
        {

            StringBuilder sql = new StringBuilder();
            sql.Append(" DELETE FROM TB_ITEMS WHERE (ID = @ID)");
            var dic = new Dictionary<string, string>
            {
                {"ID", objModel.ItemID.ToString()},
                {"CATEGORY_ID", objModel.Category.ToString()},
             
            };
            return DBAccess.Update(new DataObject
            {
                KeyValue = dic,
                Sql = sql.ToString()
            });
        }

        public static DataTable SelectItems()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ID, CATEGORY_ID, NAME, DISCRIPTION, PRICE_IN, PRICE_OUT, QUANTITY,BIN_LOCATION,REORDER_LEVEL FROM  TB_ITEMS");

            return DBAccess.Select(new DataObject
            {
                KeyValue = new Dictionary<string, string>(),
                Sql = sql.ToString()
            }).Tables[0];
        }

        public static DataSet SelectItemList()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT  ID, CATEGORY_ID, NAME, DISCRIPTION, PRICE_IN, PRICE_OUT, QUANTITY,BIN_LOCATION,REORDER_LEVEL FROM  TB_ITEMS");

            return DBAccess.Select(new DataObject
            {
                KeyValue = new Dictionary<string, string>(),
                Sql = sql.ToString()
            });
        }


        public static bool InsertInventory(ItemModel objModel)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO INVENTORY_PROCESS  (ITEM_ID, QTY, TYPE,USERNAME) ");
                sql.Append(" VALUES  (@ITEM_ID, @QTY, @TYPE,@USERNAME)");
                var dic = new Dictionary<string, string>
            {
                {"ITEM_ID", objModel.ItemID.ToString()},
                {"QTY", objModel.Qiantity.ToString()},
                {"TYPE",((int)objModel.InventoryType).ToString()},
                {"USERNAME", objModel.UserName},
             
            };
             
             var x= DBAccess.Update(new DataObject
                {
                    KeyValue = dic,
                    Sql = sql.ToString()
                });

             if (objModel.InventoryType == InventoryType.stockIn)
             {
                 UpdateADDTriggerItems(objModel);
                 return true;
             }
             else
             {
                 try
                 {
                     UpdateDeductTriggerItems(objModel);
                     return true;
                 }
                 catch (Exception ex)
                 {

                     throw new MyException("Qty cannot be minus value");
                 }

             }
            }
            catch (Exception ex)
            {
                
                //throw new MyException("Qty cannot be minus value");
                throw ex;
                
            }
        }


        

        public static bool UpdateInventory(ItemModel objModel)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE  INVENTORY_PROCESS  SET ITEM_ID=@ITEM_ID, QTY=@QTY, TYPE=@TYPE ");
            sql.Append(" WHERE ID=@ID");
            var dic = new Dictionary<string, string>
            {
                {"ID", objModel.ID.ToString()},
                {"ITEM_ID", objModel.ItemID.ToString()},
                {"QTY", objModel.Qiantity.ToString()},
                {"TYPE", ((int)objModel.InventoryType).ToString()},
              
             
            };

           
            return DBAccess.Update(new DataObject
            {
                KeyValue = dic,
                Sql = sql.ToString()
            });
        }

        public static bool DeleteInventory(ItemModel objModel)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" DELETE FROM INVENTORY_PROCESS  ");
            sql.Append(" WHERE ID=@ID");
            var dic = new Dictionary<string, string>
            {
                {"ID", objModel.ID.ToString()},
                {"QTY", objModel.Qiantity.ToString()},
                {"TYPE", objModel.InventoryType.ToString()},
              
             
            };
            var x= DBAccess.Update(new DataObject
            {
                KeyValue = dic,
                Sql = sql.ToString()
            });
            if (objModel.InventoryType == InventoryType.stockIn)
            {
               // UpdateADDTriggerItems(objModel);
                UpdateDeductTriggerItems(objModel);
                return true;
            }
            else
            {
                try
                {
                   // UpdateDeductTriggerItems(objModel);
                     UpdateADDTriggerItems(objModel);
                     return true;
                }
                catch (Exception ex)
                {

                    throw new MyException("Qty cannot be minus value");
                }

            }
           
        }

        public static DataTable SelectAllInventory()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT INVENTORY_PROCESS.ID AS ID,ITEM_ID, QTY, TYPE,REG_DATE,USERNAME,TB_ITEMS.NAME AS NAME FROM  INVENTORY_PROCESS INNER JOIN TB_ITEMS ON INVENTORY_PROCESS.ITEM_ID=TB_ITEMS.ID order by INVENTORY_PROCESS.ID desc");

            return DBAccess.Select(new DataObject
            {
                KeyValue = new Dictionary<string, string>(),
                Sql = sql.ToString()
            }).Tables[0];
        }


        public static bool UpdateADDTriggerItems(ItemModel objModel)
        {
           // UPDATE  TB_ITEMS  SET QUANTITY=(SELECT QTY FROM INVENTORY_PROCESS WHERE ITEM_ID=3 AND TYPE='1')+QUANTITY WHERE ID=3
            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE  TB_ITEMS  SET QUANTITY=(SELECT QUANTITY FROM TB_ITEMS WHERE ID=@ID)+QUANTITY  WHERE ID=@ID");
            //sql.Append("");
            var dic = new Dictionary<string, string>
            {
                {"ID", objModel.ItemID.ToString()},
                {"ITEM_ID", objModel.ItemID.ToString()},
                {"QUANTITY", objModel.Qiantity.ToString()},
                {"TYPE", ((int)objModel.InventoryType).ToString()},
              
             
            };
            return DBAccess.Update(new DataObject
            {
                KeyValue = dic,
                Sql = sql.ToString()
            });
        }


        public static bool UpdateDeductTriggerItems(ItemModel objModel)
        {
            
            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE TB_ITEMS  SET QUANTITY=(SELECT QUANTITY FROM TB_ITEMS WHERE ID=@ID)-@QUANTITY  WHERE ID=@ID ");
            //sql.Append(" WHERE ID=@ID");
            var dic = new Dictionary<string, string>
            {
                {"ID", objModel.ID.ToString()},
                {"ITEM_ID", objModel.ItemID.ToString()},
                {"QUANTITY", objModel.Qiantity.ToString()},
                {"TYPE", ((int)objModel.InventoryType).ToString()},
              
             
            };
            return DBAccess.Update(new DataObject
            {
                KeyValue = dic,
                Sql = sql.ToString()
            });
        }


        public static DataTable SearchFromStock(string searchQuary) {

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT INVENTORY_PROCESS.ID AS ID,ITEM_ID, QTY, TYPE,REG_DATE,USERNAME,TB_ITEMS.NAME AS NAME FROM  INVENTORY_PROCESS INNER JOIN TB_ITEMS ON INVENTORY_PROCESS.ITEM_ID=TB_ITEMS.ID "+searchQuary);
  

            return DBAccess.Select(new DataObject
            {
                KeyValue = new Dictionary<string, string>(),
                Sql = sql.ToString()
            }).Tables[0];
        }

       
    }

    public class MyException : Exception
    {
        
       public MyException(string message):base(message){}
   
             


    }
}
