﻿using System;
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
    public class Brand
    {
        private readonly Database database;

        public Brand()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// Add brand names
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public Int32 AddBrand(Entities.Brand brand)
        {
            var brandId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertBrand))
                {
                    database.AddInParameter(dbCommand, "@brand_id", DbType.Int32, brand.BrandId);
                    database.AddInParameter(dbCommand, "@brand_name", DbType.String, brand.BrandName);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, brand.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, brand.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    brandId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        brandId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return brandId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public bool DeleteBrand(Entities.Brand brand)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteBrand))
                {
                    database.AddInParameter(dbCommand, "@brand_id", DbType.Int32, brand.BrandId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, brand.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, brand.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

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
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public Int32 UpdateBrand(Entities.Brand brand)
        {
            var brandId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateBrand))
                {
                    database.AddInParameter(dbCommand, "@brand_id", DbType.Int32, brand.BrandId);
                    database.AddInParameter(dbCommand, "@brand_name", DbType.String, brand.BrandName);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, brand.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, brand.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    brandId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        brandId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return brandId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.Brand> GetAllBrands()
        {
            var brands = new List<Entities.Brand>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllBrands))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var brand = new Entities.Brand
                            {
                                BrandId = DRE.GetNullableInt32(reader, "brand_id", 0),
                                BrandName = DRE.GetNullableString(reader, "brand_name", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null)
                            };

                            brands.Add(brand);
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

            return brands;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public Entities.Brand GetBrandById(Int32 brandId)
        {
            var brand = new Entities.Brand();

            DbCommand dbCommand = null;

            using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetBrandById))
            {
                database.AddInParameter(dbCommand, "@brand_id", DbType.Int32, brandId);

                using (IDataReader reader = database.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        var _brand = new Entities.Brand
                        {
                            BrandId = DRE.GetNullableInt32(reader, "brand_id", 0),
                            BrandName = DRE.GetNullableString(reader, "brand_name", null),
                            guid = DRE.GetNullableGuid(reader, "row_guid", null)
                        };

                        brand = _brand;
                    }
                }
            }

            return brand;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brandName"></param>
        /// <returns></returns>
        public Entities.Brand GetBrandByName(string brandName)
        {
            var brand = new Entities.Brand();

            DbCommand dbCommand = null;

            using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetBrandByName))
            {
                database.AddInParameter(dbCommand, "@brand_name", DbType.String, brandName);

                using (IDataReader reader = database.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        var _brand = new Entities.Brand
                        {
                            BrandId = DRE.GetNullableInt32(reader, "brand_id", 0),
                            BrandName = DRE.GetNullableString(reader, "brand_name", null),
                            guid = DRE.GetNullableGuid(reader, "row_guid", null)
                        };

                        brand = _brand;
                    }
                }
            }

            return brand;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public Int32 SaveBrand(Entities.Brand brand)
        {
            if (brand.BrandId == null || brand.BrandId == 0)
            {
                return AddBrand(brand);
            }
            else
            {
                return UpdateBrand(brand);
            }
        }
    }

}