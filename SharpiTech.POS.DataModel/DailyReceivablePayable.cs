using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DRE = DataRecordExtensions.DataRecordExtensions;

namespace SharpiTech.POS.DataModel
{
    public class DailyReceivablePayable
    {
        private readonly Database database;

        public DailyReceivablePayable()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddDailyReceivablePayable(Entities.DailyReceivablePayable dailyRecPay)
        {
            var dailyRecPayId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertDailyReceivablePayable))
                {
                    database.AddInParameter(dbCommand, "@daily_rec_pay_id", DbType.Int32, dailyRecPay.DailyRecPayId);
                    database.AddInParameter(dbCommand, "@entry_date", DbType.String, dailyRecPay.EntryDate);
                    database.AddInParameter(dbCommand, "@particulars", DbType.String, dailyRecPay.Particulars);
                    database.AddInParameter(dbCommand, "@amount", DbType.Decimal, dailyRecPay.Amount);
                    database.AddInParameter(dbCommand, "@comments", DbType.String, dailyRecPay.Comments);
                    database.AddInParameter(dbCommand, "@receivable_payable", DbType.String, dailyRecPay.ReceivablePayable);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, dailyRecPay.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, dailyRecPay.CreatedByIP);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, dailyRecPay.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, dailyRecPay.BranchId);
                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    dailyRecPayId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        dailyRecPayId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbCommand = null;
            }

            return dailyRecPayId;
        }
        
        private bool DeleteDailyReceivablePayable(Entities.DailyReceivablePayable dailyRecPay)
        {
            var isRecPayDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteDailyReceivablePayable))
                {
                    database.AddInParameter(dbCommand, "@daily_rec_pay_id", DbType.Int32, dailyRecPay.DailyRecPayId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, dailyRecPay.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, dailyRecPay.DeletedByIP);
                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        isRecPayDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbCommand = null;
            }

            return isRecPayDeleted;
        }

        private Int32 UpdateDailyReceivablePayable(Entities.DailyReceivablePayable dailyRecPay)
        {
            var dailyRecPayId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateDailyReceivablePayable))
                {
                    database.AddInParameter(dbCommand, "@daily_rec_pay_id", DbType.Int32, dailyRecPay.DailyRecPayId);
                    database.AddInParameter(dbCommand, "@entry_date", DbType.String, dailyRecPay.EntryDate);
                    database.AddInParameter(dbCommand, "@particulars", DbType.String, dailyRecPay.Particulars);
                    database.AddInParameter(dbCommand, "@amount", DbType.Decimal, dailyRecPay.Amount);
                    database.AddInParameter(dbCommand, "@comments", DbType.String, dailyRecPay.Comments);
                    database.AddInParameter(dbCommand, "@receivable_payable", DbType.String, dailyRecPay.ReceivablePayable);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, dailyRecPay.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, dailyRecPay.ModifiedByIP);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, dailyRecPay.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, dailyRecPay.BranchId);
                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    dailyRecPayId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        dailyRecPayId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbCommand = null;
            }

            return dailyRecPayId;
        }

        public Int32 SaveDailyReceivablePayable(Entities.DailyReceivablePayable dailyRecPay)
        {
            var dailyRecPayId = 0;

            if (dailyRecPay.DailyRecPayId == null || dailyRecPay.DailyRecPayId == 0)
            {
                dailyRecPayId = AddDailyReceivablePayable(dailyRecPay);
            }
            else if (dailyRecPay.IsDeleted == true)
            {
                dailyRecPayId = Convert.ToInt32(DeleteDailyReceivablePayable(dailyRecPay));
            }
            else if (dailyRecPay.ModifiedBy > 0 || dailyRecPay.ModifiedBy != null)
            {
                dailyRecPayId = UpdateDailyReceivablePayable(dailyRecPay);
            }

            return dailyRecPayId;
        }

        public List<Entities.DailyReceivablePayable> GetDailyReceivablePaybleData(Entities.DailyReceivablePayable dailyRecPay)
        {
            var dailyRecPayList = new List<Entities.DailyReceivablePayable>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetBranchwiseSalesTypeWiseModeOfPaymentwiseDailySalesBiillValueDatewise))
                {
                    database.AddInParameter(dbCommand, "@entry_date", DbType.String, dailyRecPay.EntryDate);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var dailyReceivablePayable = new Entities.DailyReceivablePayable()
                            {
                                DailyRecPayId = DRE.GetNullableInt32(reader, "daily_rec_pay_id", null),
                                Particulars = DRE.GetNullableString(reader, "particulars", null),
                                ReceivableAmount = DRE.GetNullableDecimal(reader, "receivable_amount", null),
                                PayableAmount = DRE.GetNullableDecimal(reader, "payable_amount", null),
                                Comments = DRE.GetNullableString(reader, "comments", null),
                                ReceivablePayable = DRE.GetNullableString(reader, "receivable_payable", null),
                                Flag = DRE.GetNullableString(reader, "flag", null)
                            };

                            dailyRecPayList.Add(dailyReceivablePayable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbCommand = null;
            }

            return dailyRecPayList;
        }

    }
}
