using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.MODEL;
using BL.DAL;
using System.Data;

namespace BL.BL
{
    public class BrandBL
    {
        public static ReturnObject UpdateBrands(BrandsModel objmodel,DBQ dbq){

            ReturnObject validate = null;
            try
            {
                if (dbq == DBQ.Insert)
                {
       
                    return  
                        (BrandDAL.InsertBrand(objmodel)) ? new ReturnObject { Message = "Insert is succces", MessageCode = MessageCode.Success } :
                        new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                        ;

                }
                else if (dbq == DBQ.Update)
                {
 
                    return 
                       (BrandDAL.UpdateBrand(objmodel)) ? new ReturnObject { Message = "Update is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;
                }
                else
                {

                    return 
                       (BrandDAL.DeleteBrand(objmodel)) ? new ReturnObject { Message = "Delete is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;
                }
            }
            catch (Exception ex) {

                return HELPER.Validation.SystemError(ex);
            }
        }
 
        public static ReturnObject SelectBrands()
        {

            try
            {
                return new ReturnObject
                {
                    MessageCode = MessageCode.Success,
                    Content =  BrandDAL.SelectBrands().Tables[0]
                };
            }
            catch (Exception ex)
            {
                return HELPER.Validation.SystemError(ex);
            }
        }

        
    }
}
