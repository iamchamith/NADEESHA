using BL.DAL;
using BL.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BL
{
    public class WSBL
    {
        #region job
        public static ReturnObject UpdateVehicle(JobModel objmodel, DBQ dbq)
        {

            ReturnObject validate = null;
            try
            {
                if (dbq == DBQ.Insert)
                {
                    return 
                        (WSDAL.JobInsert(objmodel)) ? new ReturnObject { Message = "Insert is succces", MessageCode = MessageCode.Success } :
                        new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                        ;

                }
                else if (dbq == DBQ.Update)
                {
                    return
                       (WSDAL.JobUpdate(objmodel)) ? new ReturnObject { Message = "Update is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                return HELPER.Validation.SystemError(ex);
            }
        }

        public static ReturnObject SelectVehicle(string vehicleID)
        {

            try
            {
                return new ReturnObject
                {
                    MessageCode = MessageCode.Success,
                    Content = WSDAL.SelectVehicleJob(vehicleID).Tables[0]
                };
            }
            catch (Exception ex)
            {
                return HELPER.Validation.SystemError(ex);
            }
        }

        #endregion

        #region job,vehicle

        public static ReturnObject UpdateVehicleTask(VehicleTaskModel objmodel, DBQ dbq)
        {
            ReturnObject validate = null;
            try
            {
                if (dbq == DBQ.Insert)
                {
                    return //(validate.MessageCode == MessageCode.InputError) ? validate :
                        (WSDAL.InsertVehicleTask(objmodel)) ? new ReturnObject { Message = "Insert is succces", MessageCode = MessageCode.Success } :
                        new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                        ;

                }
                else if (dbq == DBQ.Update)
                {
                    return //(validate.MessageCode == MessageCode.InputError) ? validate :
                       (WSDAL.UpdateVehicleTask(objmodel)) ? new ReturnObject { Message = "Update is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;
                }
                else
                {
                    return
                       (WSDAL.DeleteVehicleTask(objmodel)) ? new ReturnObject { Message = "Delete is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;
                }
            }
            catch (Exception ex)
            {

                return HELPER.Validation.SystemError(ex);
            }
        }

        public static ReturnObject SelectVahicleTasks(int jobID)
        {

            try
            {
                return new ReturnObject
                {
                    MessageCode = MessageCode.Success,
                    Content = WSDAL.SelectVahicleTasks(jobID).Tables[0]
                };
            }
            catch (Exception ex)
            {
                return HELPER.Validation.SystemError(ex);
            }
        }

        #endregion

        #region labours

        public static ReturnObject UpdateTaskLabour(TaskLabour objmodel, DBQ dbq)
        {
            ReturnObject validate = null;
            try
            {
                if (dbq == DBQ.Insert)
                {
                    return //(validate.MessageCode == MessageCode.InputError) ? validate :
                        (WSDAL.InsertTaskLabour(objmodel)) ? new ReturnObject { Message = "Insert is succces", MessageCode = MessageCode.Success } :
                        new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                        ;

                }
                else if (dbq == DBQ.Update)
                {
                    return //(validate.MessageCode == MessageCode.InputError) ? validate :
                       (WSDAL.UpdateTaskLabour(objmodel)) ? new ReturnObject { Message = "Update is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;
                }
                else
                {
                    return
                       (WSDAL.DeleteTaskLabour(objmodel)) ? new ReturnObject { Message = "Delete is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;
                }
            }
            catch (Exception ex)
            {

                return HELPER.Validation.SystemError(ex);
            }
        }

        public static ReturnObject SelectTaskLabour(int TaskID)
        {

            try
            {
                return new ReturnObject
                {
                    MessageCode = MessageCode.Success,
                    Content = WSDAL.SelectTaskLabour(TaskID).Tables[0]
                };
            }
            catch (Exception ex)
            {
                return HELPER.Validation.SystemError(ex);
            }
        }

        public static ReturnObject SelectLabourExists(int TaskID,int LabourId)
        {

            try
            {
                return new ReturnObject
                {
                    MessageCode = MessageCode.Success,
                    Content = WSDAL.SelectLabourExists(TaskID, LabourId).Tables[0]
                };
            }
            catch (Exception ex)
            {
                return HELPER.Validation.SystemError(ex);
            }
        }

        public static ReturnObject SelectVehicleJobExists(int TaskID, int JobId)
        {

            try
            {
                return new ReturnObject
                {
                    MessageCode = MessageCode.Success,
                    Content = WSDAL.SelectVehicleJobExists(TaskID, JobId).Tables[0]
                };
            }
            catch (Exception ex)
            {
                return HELPER.Validation.SystemError(ex);
            }
        }
        public static ReturnObject SelectItemsExists(int TaskID, int itemId)
        {

            try
            {
                return new ReturnObject
                {
                    MessageCode = MessageCode.Success,
                    Content = WSDAL.SelectitemsExists(TaskID, itemId).Tables[0]
                };
            }
            catch (Exception ex)
            {
                return HELPER.Validation.SystemError(ex);
            }
        }
        //public static ReturnObject SelectJobsByEmpId(string empID)
        //{

        //    try
        //    {
        //        return new ReturnObject
        //        {
        //            MessageCode = MessageCode.Success,
        //            Content = WSDAL.SelectJobsByEmpId(empID).Tables[0]
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return HELPER.Validation.SystemError(ex);
        //    }
        //}


        #endregion

        #region  Material

        public static ReturnObject UpdateMaterial(Material objmodel, DBQ dbq)
        {
            ReturnObject validate = null;
            try
            {
                if (dbq == DBQ.Insert)
                {
                    return //(validate.MessageCode == MessageCode.InputError) ? validate :
                        (WSDAL.InsertMaterial(objmodel)) ? new ReturnObject { Message = "Insert is succces", MessageCode = MessageCode.Success } :
                        new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                        ;

                }
                else if (dbq == DBQ.Update)
                {
                    return //(validate.MessageCode == MessageCode.InputError) ? validate :
                       (WSDAL.UpdateMaterial(objmodel)) ? new ReturnObject { Message = "Update is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;
                }
                else
                {
                    return
                       (WSDAL.DeleteMaterial(objmodel)) ? new ReturnObject { Message = "Delete is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;
                }
            }
            catch (Exception ex)
            {

                return HELPER.Validation.SystemError(ex);
            }
        }

        public static ReturnObject SelectMaterials(string taskID)
        {

            try
            {
                return new ReturnObject
                {
                    MessageCode = MessageCode.Success,
                    Content = WSDAL.SelectMaterials(taskID).Tables[0]
                };
            }
            catch (Exception ex)
            {
                return HELPER.Validation.SystemError(ex);
            }
        }

        #endregion

        public static ReturnObject CloseJobTask(int taskID, double taskCost)
        {

            return new ReturnObject
            {
                MessageCode = DAL.TaskDAL.CloseJobTask(taskID, taskCost) ? MessageCode.Success : MessageCode.SystemError
            };
        }
    }
}
