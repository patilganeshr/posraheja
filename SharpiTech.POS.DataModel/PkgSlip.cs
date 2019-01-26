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
    public class PkgSlip
    {
        private readonly Database database;

        public PkgSlip()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// Add Pkg Slip
        /// </summary>
        /// <param name="pkgSlip"></param>
        /// <returns></returns>
        private Int32 AddPkgSlip(Entities.PkgSlip pkgSlip)
        {
            var pkgSlipId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertPkgSlip))
                {
                    database.AddInParameter(dbCommand, "@pkg_slip_id", DbType.Int32, pkgSlip.PkgSlipId);
                    database.AddInParameter(dbCommand, "@pkg_slip_no", DbType.Int32, pkgSlip.PkgSlipNo);
                    database.AddInParameter(dbCommand, "@pkg_slip_date", DbType.String, pkgSlip.PkgSlipDate);
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, pkgSlip.PurchaseBillId);
                    database.AddInParameter(dbCommand, "@from_location_id", DbType.Int32, pkgSlip.FromLocationId);
                    database.AddInParameter(dbCommand, "@to_location_id", DbType.Int32, pkgSlip.ToLocationId);
                    database.AddInParameter(dbCommand, "@type_of_transfer_id", DbType.Int32, pkgSlip.TypeOfTransferId);
                    database.AddInParameter(dbCommand, "@karagir_id", DbType.Int32, pkgSlip.KaragirId);
                    database.AddInParameter(dbCommand, "@reference_no", DbType.String, pkgSlip.ReferenceNo);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, pkgSlip.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, pkgSlip.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, pkgSlip.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, pkgSlip.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    pkgSlipId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        pkgSlipId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                dbCommand = null;
            }

            return pkgSlipId;
        }

        /// <summary>
        /// Add Pkg Slip
        /// </summary>
        /// <param name="pkgSlip"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 AddPkgSlip(Entities.PkgSlip pkgSlip, DbTransaction transaction)
        {
            var pkgSlipId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertPkgSlip))
                {
                    database.AddInParameter(dbCommand, "@pkg_slip_id", DbType.Int32, pkgSlip.PkgSlipId);
                    database.AddInParameter(dbCommand, "@pkg_slip_no", DbType.Int32, pkgSlip.PkgSlipNo);
                    database.AddInParameter(dbCommand, "@pkg_slip_date", DbType.String, pkgSlip.PkgSlipDate);
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, pkgSlip.PurchaseBillId);
                    database.AddInParameter(dbCommand, "@from_location_id", DbType.Int32, pkgSlip.FromLocationId);
                    database.AddInParameter(dbCommand, "@to_location_id", DbType.Int32, pkgSlip.ToLocationId);
                    database.AddInParameter(dbCommand, "@type_of_transfer_id", DbType.Int32, pkgSlip.TypeOfTransferId);
                    database.AddInParameter(dbCommand, "@karagir_id", DbType.Int32, pkgSlip.KaragirId);
                    database.AddInParameter(dbCommand, "@reference_no", DbType.String, pkgSlip.ReferenceNo);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, pkgSlip.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, pkgSlip.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, pkgSlip.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, pkgSlip.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    pkgSlipId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        pkgSlipId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                dbCommand = null;
            }

            return pkgSlipId;
        }

        /// <summary>
        /// Delete Pkg Slip
        /// </summary>
        /// <param name="pkgSlip"></param>
        /// <returns></returns>
        private bool DeletePkgSlip(Entities.PkgSlip pkgSlip)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeletePkgSlip))
                {
                    database.AddInParameter(dbCommand, "@pkg_slip_id", DbType.Int32, pkgSlip.PkgSlipId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, pkgSlip.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, pkgSlip.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var pkgSlipId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        isDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                dbCommand = null;
            }

            return isDeleted;
        }

        /// <summary>
        /// Delete Pkg Slip
        /// </summary>
        /// <param name="pkgSlip"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool DeletePkgSlip(Entities.PkgSlip pkgSlip, DbTransaction transaction)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeletePkgSlip))
                {
                    database.AddInParameter(dbCommand, "@pkg_slip_id", DbType.Int32, pkgSlip.PkgSlipId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, pkgSlip.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, pkgSlip.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var pkgSlipId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        isDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                dbCommand = null;
            }

            return isDeleted;
        }

        public List<Entities.PkgSlip> GetVendors()
        {
            var vendors = new List<Entities.PkgSlip>();

            DbCommand dbCommand = null;

            try
            {
                using(dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetVendorsForPkgSlip))
                {
                    using(IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var vendor = new Entities.PkgSlip()
                            {
                                VendorId = DRE.GetNullableInt32(reader, "vendor_id", null),
                                VendorName = DRE.GetNullableString(reader, "vendor_name")
                            };

                            vendors.Add(vendor);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbCommand = null;
            }

            return vendors;
        }

        public List<Entities.PkgSlip> GetPurchaseBillNosByVendorId(Int32 vendorId)
        {
            var purchaseBillNos = new List<Entities.PkgSlip>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPurchaseBillNosByVendorId))
                {
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, vendorId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var purchaseBillNo = new Entities.PkgSlip()
                            {
                                PurchaseBillId = DRE.GetNullableInt32(reader, "purchase_bill_id", null),
                                PurchaseBillNo = DRE.GetNullableString(reader, "purchase_bill_no", null)
                            };

                            purchaseBillNos.Add(purchaseBillNo);
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

            return purchaseBillNos;
        }

        public List<Entities.PkgSlip> GetBaleNosByVendorId(Int32 vendorId)
        {

            var baleNos = new List<Entities.PkgSlip>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetBaleNosByVendorId))
                {
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, vendorId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var baleNo = new Entities.PkgSlip()
                            {
                                PurchaseBillId = DRE.GetNullableInt32(reader, "purchase_bill_id", null),
                                BaleNo = DRE.GetNullableString(reader, "bale_no", null)
                            };

                            baleNos.Add(baleNo);
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

            return baleNos;
        }

        public List<Entities.PkgSlip> GetFromLocationsByPurchaseBillid(Int32 purchaseBillId)
        {
            var fromLocations = new List<Entities.PkgSlip>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetFromLocationByPurchaseBillId))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBillId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var fromLocation = new Entities.PkgSlip()
                            {
                                FromLocationId = DRE.GetNullableInt32(reader, "location_id", null),
                                FromLocation = DRE.GetNullableString(reader, "location_name", null)
                            };

                            fromLocations.Add(fromLocation);
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

            return fromLocations;
        }

        /// <summary>
        /// Get all pkg slips
        /// </summary>
        /// <returns></returns>
        public List<Entities.PkgSlip> GetAllPkgSlips()
        {
            var pkgSlips = new List<Entities.PkgSlip>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllPkgSlips))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var pkgSlipItem = new PkgSlipItem();

                            var pkgSlip = new Entities.PkgSlip
                            {
                                PkgSlipId = DRE.GetNullableInt32(reader, "pkg_slip_id", null),
                                PkgSlipNo = DRE.GetNullableInt32(reader, "pkg_slip_no", null),
                                PkgSlipDate = DRE.GetNullableString(reader, "pkg_slip_date", null),
                                PurchaseBillId = DRE.GetNullableInt32(reader, "purchase_bill_id", null),
                                PurchaseBillNo = DRE.GetNullableString(reader, "purchase_bill_no", null),
                                VendorName = DRE.GetNullableString(reader, "vendor_name", null),
                                VendorId = DRE.GetNullableInt32(reader, "vendor_id", null),                                
                                FromLocation = DRE.GetNullableString(reader, "from_location", null),
                                FromLocationId = DRE.GetNullableInt32(reader, "from_location_id", null),
                                ToLocation = DRE.GetNullableString(reader, "to_location", null),
                                ToLocationId = DRE.GetNullableInt32(reader, "to_location_id", null),
                                TransferType = DRE.GetNullableString(reader, "transfer_type", null),
                                TypeOfTransferId = DRE.GetNullableInt32(reader, "type_of_transfer_id", null),
                                KaragirId = DRE.GetNullableInt32(reader, "karagir_id", null),
                                KaragirName = DRE.GetNullableString(reader, "karagir_name", null),
                                ReferenceNo = DRE.GetNullableString(reader, "reference_no", null),
                                TotalPkgSlipQty = DRE.GetNullableDecimal(reader, "total_pkg_slip_qty", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                CompanyId = DRE.GetNullableInt32(reader, "company_id", null),
                                CompanyName = DRE.GetNullableString(reader, "company_name" ,null),
                                WorkingPeriodId  = DRE.GetNullableInt32(reader, "working_period_id", null),
                                FinancialYear = DRE.GetNullableString(reader, "financial_year", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null),
                                PkgSlipItems = pkgSlipItem.GetPkgSlipItemsByPkgSlipId(DRE.GetInt32(reader, "pkg_slip_id"))
                            };

                            pkgSlips.Add(pkgSlip);
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

            return pkgSlips;
        }
        
        /// <summary>
        /// Update Pkg Slip
        /// </summary>
        /// <param name="pkgSlip"></param>
        /// <returns></returns>
        private Int32 UpdatePkgSlip(Entities.PkgSlip pkgSlip)
        {
            var pkgSlipId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdatePkgSlip))
                {
                    database.AddInParameter(dbCommand, "@pkg_slip_id", DbType.Int32, pkgSlip.PkgSlipId);
                    database.AddInParameter(dbCommand, "@pkg_slip_date", DbType.String, pkgSlip.PkgSlipDate);                    
                    database.AddInParameter(dbCommand, "@from_location_id", DbType.Int32, pkgSlip.FromLocationId);
                    database.AddInParameter(dbCommand, "@to_location_id", DbType.Int32, pkgSlip.ToLocationId);
                    database.AddInParameter(dbCommand, "@type_of_transfer_id", DbType.Int32, pkgSlip.TypeOfTransferId);
                    database.AddInParameter(dbCommand, "@karagir_id", DbType.Int32, pkgSlip.KaragirId);
                    database.AddInParameter(dbCommand, "@reference_no", DbType.String, pkgSlip.ReferenceNo);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, pkgSlip.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, pkgSlip.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    pkgSlipId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        pkgSlipId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                dbCommand = null;
            }

            return pkgSlipId;
        }

        /// <summary>
        /// Update Pkg Slip
        /// </summary>
        /// <param name="pkgSlip"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 UpdatePkgSlip(Entities.PkgSlip pkgSlip,DbTransaction transaction)
        {
            var pkgSlipId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdatePkgSlip))
                {
                    database.AddInParameter(dbCommand, "@pkg_slip_id", DbType.Int32, pkgSlip.PkgSlipId);
                    database.AddInParameter(dbCommand, "@pkg_slip_date", DbType.String, pkgSlip.PkgSlipDate);
                    database.AddInParameter(dbCommand, "@from_location_id", DbType.Int32, pkgSlip.FromLocationId);
                    database.AddInParameter(dbCommand, "@to_location_id", DbType.Int32, pkgSlip.ToLocationId);
                    database.AddInParameter(dbCommand, "@type_of_transfer_id", DbType.Int32, pkgSlip.TypeOfTransferId);
                    database.AddInParameter(dbCommand, "@karagir_id", DbType.Int32, pkgSlip.KaragirId);
                    database.AddInParameter(dbCommand, "@reference_no", DbType.String, pkgSlip.ReferenceNo);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, pkgSlip.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, pkgSlip.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    pkgSlipId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        pkgSlipId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                dbCommand = null;
            }

            return pkgSlipId;
        }

        /// <summary>
        /// Save Pkg Slip
        /// </summary>
        /// <param name="pkgSlip"></param>
        /// <returns></returns>
        public Int32 SavePkgSlip(Entities.PkgSlip pkgSlip)
        {
            var pkgSlipId = 0;

            var db = DBConnect.getDBConnection();

            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();

                using (DbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var pkgSlipItemId = 0;

                        if (pkgSlip != null)
                        {
                            if (pkgSlip.PkgSlipId == null || pkgSlip.PkgSlipId == 0)
                            {
                                pkgSlipId = AddPkgSlip(pkgSlip, transaction);
                            }
                            else
                            {
                                if (pkgSlip.IsDeleted == true)
                                {
                                    var result = DeletePkgSlip(pkgSlip, transaction);

                                    if (result)
                                    {
                                        pkgSlipId = Convert.ToInt32(pkgSlip.PkgSlipId);
                                    }
                                }
                                else
                                {
                                    if (pkgSlip.ModifiedBy > 0 || pkgSlip.ModifiedBy != null)
                                    {
                                        pkgSlipId = UpdatePkgSlip(pkgSlip, transaction);
                                    }
                                }
                            }

                            if (pkgSlipId > 0)
                            {
                                foreach (Entities.PkgSlipItem pkgSlipItem in pkgSlip.PkgSlipItems)
                                {
                                    pkgSlipItem.PkgSlipId = pkgSlipId;

                                    PkgSlipItem pkgSlipItemDL = new PkgSlipItem();

                                    pkgSlipItemId = pkgSlipItemDL.SavePkgSlipItem(pkgSlipItem, transaction);
                                }
                            }

                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        db = null;
                    }
                }
            }

            return pkgSlipId;
        }

    }
}
