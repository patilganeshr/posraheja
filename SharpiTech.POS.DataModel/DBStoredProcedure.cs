using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.DataModel
{
    public static class DBStoredProcedure
    {
        public static string GetAllClientAddressess { get { return "usp_client_addressess_get_all_client_addressess"; } }
        public static string GetAllAddressessByClientId { get { return "usp_client_addressess_get_all_addressess_by_client_id"; } }
        public static string GetClientAddressNamesByClientTypeId { get { return "usp_client_addressess_get_client_address_names_by_client_type_id"; } }
        public static string SearchClientAddressNameByClientAddressName { get { return "usp_client_addressess_search_by_client_address_name"; } }
        public static string InsertClientAddress { get { return "usp_client_addressess_insert_client_address"; } }
        public static string UpdateClientAddress { get { return "usp_client_addressess_update_client_address"; } }
        public static string DeleteClientAddress { get { return "usp_client_addressess_delete_client_address"; } }
        public static string GetAllClientAddressByClientId { get { return "usp_client_addressess_get_all_client_addressess_by_client_id"; } }
        public static string GetClientAddressById { get { return "usp_client_addressess_get_client_address_by_id"; } }
        public static string GetClientAddressByName { get { return "usp_client_addressess_get_client_address_by_name"; } }
        public static string CheckClientAddressNameIsExists { get { return "usp_client_addressess_check_client_addressee_name_is_exists"; } }

        public static string InsertClientAddressContact { get { return "usp_client_address_contacts_insert_client_address_contact"; } }
        public static string UpdateClientAddressContact { get { return "usp_client_address_contacts_update_client_address_contact"; } }
        public static string DeleteClientAddressContactByClientAddressId { get { return "usp_client_address_contacts_delete_by_client_address_id"; } }
        public static string DeleteClientAddressContactByContactId { get { return "usp_client_address_contacts_delete_by_contact_id"; } }
        public static string GetAllClientAddressContactsByClientAddressId { get { return "usp_client_address_contacts_get_all_contacts_by_client_address_id"; } }
        public static string GetClientAddressContactById { get { return "usp_client_address_contacts_get_contact_by_id"; } }

        public static string InsertCustomerAndTransporterMapping { get { return "usp_customer_transporter_mapping_insert_customer_transporter_mapping"; } }
        public static string UpdateCustomerAndTransporterMapping { get { return "usp_customer_transporter_mapping_update_customer_transporter_mapping"; } }
        public static string DeleteCustomerAndTransporterMapping { get { return "usp_customer_transporter_mapping_delete_customer_transporter_mapping"; } }
        public static string GetTransportersListByCustomerAddressId { get { return "usp_customer_transporter_mapping_get_transporters_list_by_customer_address_id"; } }
        public static string GetAllCustomerTransporterMapping { get { return "usp_customer_transporter_mapping_get_all_customer_transporter_mapping_list"; } }

        public static string DeleteClientById { get { return "usp_client_addressess_delete_by_client_id"; } }
        public static string InsertClient { get { return "usp_clients_insert_client"; } }
        public static string UpdateClient { get { return "usp_clients_update_client"; } }
        public static string DeleteClient { get { return "usp_clients_delete_client"; } }
        public static string GetAllClients { get { return "usp_clients_get_all_clients"; } }
        public static string GetClientById { get { return "usp_clients_get_client_by_id"; } }
        public static string GetClientByName { get { return "usp_clients_get_client_by_name"; } }
        public static string CheckClientNameIsExists { get { return "usp_clients_check_client_name_is_exists"; } }

        public static string InsertClientType { get { return "usp_client_types_insert_client_type"; } }
        public static string UpdateClientType { get { return "usp_client_types_update_client_type"; } }
        public static string DeleteClientType { get { return "usp_client_types_delete_client_type"; } }
        public static string GetAllClientTypes { get { return "usp_client_types_get_all_client_type"; } }
        public static string GetClientTypeById { get { return "usp_client_types_get_client_type_by_id"; } }
        public static string GetClientTypeByName { get { return "usp_clients_get_client_type_by_name"; } }

        public static string InsertDepartment { get { return "usp_departments_insert_department"; } }
        public static string UpdateDepartment { get { return "usp_departments_update_department"; } }
        public static string DeleteDepartment { get { return "usp_departments_delete_department"; } }
        public static string GetAllDepartments { get { return "usp_departments_get_all_departments"; } }
        public static string GetDepartmentByName { get { return "usp_departments_get_department_by_name"; } }
        public static string GetDepartmentById { get { return "usp_departments_get_department_by_id"; } }

        public static string InsertDesignation { get { return "usp_designations_insert_designation"; } }
        public static string UpdateDesignation { get { return "usp_designations_update_designation"; } }
        public static string Deletedesignation { get { return "usp_designations_delete_designation"; } }
        public static string GetAllDesignations { get { return "usp_designations_get_all_designations"; } }
        public static string GetDesignationByName { get { return "usp_designations_get_designation_by_name"; } }
        public static string GetDesignationById { get { return "usp_designations_get_designation_by_id"; } }

        public static string InsertEmployee { get { return "usp_employees_insert_employee"; } }
        public static string UpdateEmployee { get { return "usp_employees_update_employee"; } }
        public static string DeleteEmployee { get { return "usp_employees_delete_employee"; } }
        public static string GetAllEmployees { get { return "usp_employees_get_all_employees"; } }
        public static string GetEmployeeById { get { return "usp_employees_get_employee_by_id"; } }
        public static string GetAllEmployeesByEmployer { get { return "usp_employees_get_all_employees_by_employer"; } }
        public static string GetEmployeesByDepartmentId { get { return "usp_employees_get_employees_by_department_id"; } }

        public static string InsertEmployer { get { return "usp_employers_insert_employer"; } }
        public static string UpdateEmployer { get { return "usp_employers_update_employer"; } }
        public static string DeleteEmployer { get { return "usp_employers_delete_employer"; } }
        public static string GetAllEmployers { get { return "usp_employers_get_all_employers"; } }
        public static string GetEmployerById { get { return "usp_employers_get_employer_by_id"; } }
        public static string GetEmployerByName { get { return "usp_employers_get_employer_by_name"; } }

        public static string GetUserByUserId { get { return "usp_users_get_user_by_user_id"; } }

        public static string GetUserRolesByUserId { get { return "usp_user_roles_get_role_by_user_id"; } }
        public static string GetAllUserRoles { get { return "usp_user_roles_get_all_user_roles"; } }

        public static string InsertFabricColor { get { return "usp_fabric_colors_insert_fabric_color"; } }
        public static string UpdateFabricColor { get { return "usp_fabric_colors_update_fabric_color"; } }
        public static string DeleteFabricColor { get { return "usp_fabric_colors_delete_fabric_color"; } }
        public static string GetAllFabricColors { get { return "usp_fabric_colors_get_all_fabric_colors"; } }
        public static string GetFabricColorByName { get { return "usp_fabric_colors_get_fabric_color_by_name"; } }
        public static string GetFabricColorById { get { return "usp_fabric_colors_get_fabric_color_by_id"; } }

        public static string InsertGender { get { return "usp_genders_insert_gender"; } }
        public static string UpdateGender { get { return "usp_genders_update_gender"; } }
        public static string DeleteGender { get { return "usp_genders_delete_gender"; } }
        public static string GetAllGenders { get { return "usp_genders_get_all_genders"; } }
        public static string GetGenderById { get { return "usp_genders_get_gender_by_id"; } }
        public static string GetGenderByName { get { return "usp_genders_get_gender_by_name"; } }

        public static string InsertItemQuality { get { return "usp_item_qualities_insert_item_quality"; } }
        public static string UpdateItemQuality { get { return "usp_item_qualities_update_item_quality"; } }
        public static string DeleteItemQuality { get { return "usp_item_qualities_delete_item_quality"; } }
        public static string GetallItemQualities { get { return "usp_item_qualities_get_all_item_qualities"; } }
        public static string GetItemQualityById { get { return "usp_item_qualities_get_by_item_quality_id"; } }
        public static string GetItemQualityByName { get { return "usp_item_qualities_get_by_quality_name"; } }

        public static string InsertItemShape { get { return "usp_item_shapes_insert_item_shape"; } }
        public static string UpdateItemShape { get { return "usp_item_shapes_update_item_shape"; } }
        public static string DeleteItemShape { get { return "usp_item_shapes_delete_item_shape"; } }
        public static string GetAllItemShapes { get { return "usp_item_shapes_get_all_item_shapes"; } }
        public static string GetItemShapeByName { get { return "usp_item_shapes_get_by_item_shape_name"; } }
        public static string GetItemShapeById { get { return "usp_item_shapes_get_by_item_shape_id"; } }

        public static string GetMenusByRoleId { get { return "usp_menus_get_menus_by_role_id"; } }
        public static string GetMenusByMenuGroupId { get { return "usp_menus_get_menus_by_menu_group_id"; } }
        public static string GetAllMenusGroup { get { return "usp_menus_group_get_all_menus_group"; } }

        public static string InsertRolePermissions { get { return "usp_role_permissions_insert_role_permissions"; } }
        public static string UpdateRolePermissions { get { return "usp_role_permissions_update_role_permissions"; } }
        public static string DeleteRolePermissions { get { return "usp_role_permissions_delete_role_permissions"; } }

        public static string InsertRole { get { return "usp_roles_insert_role"; } }
        public static string UpdateRole { get { return "usp_roles_update_role"; } }
        public static string DeleteRole { get { return "usp_roles_delete_role"; } }
        public static string GetAllRoles { get { return "usp_roles_get_all_roles"; } }
        public static string GetRoleByName { get { return "usp_roles_get_role_by_name"; } }
        public static string GetRoleById { get { return "usp_roles_get_role_by_id"; } }

        public static string DeleteStyleSize { get { return "usp_style_sizes_delete_style_size"; } }
        public static string GetAllstyleSizes { get { return "usp_style_sizes_get_all_style_sizes"; } }
        public static string GetStyleSizeById { get { return "usp_style_sizes_get_style_size_by_id"; } }
        public static string InsertStyleSize { get { return "usp_style_sizes_insert_style_size"; } }
        public static string UpdateStyleSize { get { return "usp_style_sizes_update_style_size"; } }
        public static string GetStyleSizeBySize { get { return "usp_style_sizes_get_style_size_by_size"; } }

        public static string UpdateStyleType { get { return "usp_style_types_update_style_type"; } }
        public static string InsertStyleType { get { return "usp_style_types_insert_style_type"; } }
        public static string GetStyleTypeById { get { return "usp_style_types_get_by_style_type_id"; } }
        public static string GetStyleTypeByName { get { return "usp_style_types_get_by_style_type_name"; } }
        public static string DeleteStyleType { get { return "usp_style_types_delete_style_type"; } }
        public static string GetAllStyleTypes { get { return "usp_style_types_get_all_style_types"; } }

        public static string InsertUserRole { get { return "usp_user_roles_insert_user_role"; } }
        public static string UpdateUserRole { get { return "usp_user_roles_update_user_role"; } }
        public static string DeleteUserRole { get { return "usp_user_roles_delete_user_role"; } }

        public static string InsertUser { get { return "usp_users_insert_user"; } }
        public static string UpdateUser { get { return "usp_users_update_user"; } }
        public static string DeleteUser { get { return "usp_users_delete_user"; } }

        public static string InsertWorkingPeriod { get { return "usp_working_periods_insert_working_period"; } }
        public static string UpdateWorkingPeriod { get { return "usp_working_periods_update_working_period"; } }
        public static string DeleteWorkingPeriod { get { return "usp_working_periods_delete_working_period"; } }
        public static string GetAllWorkingPeriods { get { return "usp_working_periods_get_all_working_periods"; } }
        public static string GetFinancialYearById { get { return "usp_working_periods_get_financial_year_by_id"; } }

        public static string GetRolePermissionByRoleId { get { return "usp_role_permissions_get_role_permission_by_role_id"; } }
        public static string GetRolePermissionByRoleAndMenuGroupId { get { return "usp_role_permissions_get_permission_by_role_and_menu_group_id"; } }
        public static string GetRolePermissionByRoleAndMenuId { get { return "usp_role_permissions_get_permission_by_role_and_menu_id"; } }

        public static string InsertItemCategory { get { return "usp_item_categories_insert_item_category"; } }
        public static string UpdateItemCategory { get { return "usp_item_categories_update_item_category"; } }
        public static string DeleteItemCategory { get { return "usp_item_categories_delete_item_category"; } }
        public static string GetAllItemCategories { get { return "usp_item_categories_get_all_item_categories"; } }
        public static string GetItemCategoryById { get { return "usp_item_categories_get_item_category_by_id"; } }
        public static string GetItemCategoryByName { get { return "usp_item_categories_get_item_category_by_name"; } }
        
        public static string GetLocationAndLocationType { get { return "usp_locations_get_all_location_and_location_type"; } }

        public static string InsertItem { get { return "usp_items_insert_item"; } }
        public static string UpdateItem { get { return "usp_items_update_item"; } }
        public static string DeleteItem { get { return "usp_items_delete_item"; } }
        public static string CheckItemNameIsExists { get { return "usp_items_check_item_is_exists"; } }
        public static string GetAllItems { get { return "usp_items_get_all_items"; } }
        public static string GetAllItemsByItemCategoryId { get { return "usp_items_get_items_by_categor_id"; } }
        public static string GetItemsByBrandCategoryAndQuality { get { return "usp_items_get_items_by_brand_category_and_quality"; } }
        public static string GetItemById { get { return "usp_items_get_item_by_id"; } }
        public static string GetItemByName { get { return "usp_items_get_item_by_name"; } }
        public static string SearchItemsByItemName { get { return "usp_items_search_items_by_item_name"; } }
        public static string GetItemsByBrandAndItemCategory {  get { return "usp_items_get_items_by_brand_and_item_category"; } }

        public static string InsertAddressType { get { return "usp_address_types_insert_address_type"; } }
        public static string UpdateAddressType { get { return "usp_address_types_update_address_type"; } }
        public static string DeleteAddressType { get { return "usp_address_types_delete_address_type"; } }
        public static string GetAllAddressTypes { get { return "usp_address_types_get_all_address_type"; } }
        public static string GetAddressTypeById { get { return "usp_address_types_get_address_type_by_id"; } }
        public static string GetAddressTypeByName { get { return "usp_address_types_get_address_type_by_name"; } }
        public static string GetAllCountries { get { return "usp_countries_get_all_countries"; } }
        public static string GetStatesByCountryId { get { return "usp_states_get_state_by_country_id"; } }
        public static string GetCitiesByStateId { get { return "usp_cities_get_city_by_state_id"; } }

        public static string InsertGSTCategory { get { return "usp_gst_categories_insert_gst_category"; } }
        public static string UpdateGSTCategory { get { return "usp_gst_categories_update_gst_category"; } }
        public static string DeleteGSTCategory { get { return "usp_gst_categories_delete_gst_category"; } }
        public static string GetAllGSTCategories { get { return "usp_gst_categories_get_all_categories"; } }

        public static string InsertGSTRate { get { return "usp_gst_rates_insert_gst_rate"; } }
        public static string UpdateGSTRate { get { return "usp_gst_rates_update_gst_rate"; } }
        public static string DeleteGSTRate { get { return "usp_gst_rates_delete_gst_rate"; } }
        public static string GetGSTRatesByGSTCategoryId { get { return "usp_gst_rates_get_gst_rates_by_gst_category_id"; } }
        public static string GetGSTDetailsByGSTCategoryIdGSTAppicableAndEffectiveDate { get { return "usp_gst_rates_get_gst_details_by_gst_category_id_gst_applicable_and_effective_date"; } }

        public static string GetAllUnitsOfMeasurement { get { return "usp_units_of_measurements_get_all_units"; } }

        public static string GetStyeTypeStyleSizeMapping { get { return "usp_style_type_style_size_mapping_get_by_style_type_id"; } }

        public static string InsertEnquiry { get { return "usp_enquiries_insert_enquiry"; } }
        public static string UpdateEnquiry { get { return "usp_enquiries_update_enquiry"; } }
        public static string DeleteEnquiry { get { return "usp_enquiries_delete_enquiry"; } }
        public static string GetAllEnquiries { get { return "usp_enquiries_get_all_enquiries"; } }
        public static string GetEnquiryById { get { return "usp_enquiries_get_enquiry_by_id"; } }
        public static string GetEnquiryByEnquiryNo { get { return "usp_enquiries_get_enquiry_by_enquiry_no"; } }

        public static string InsertEnquiryStyle { get { return "usp_enquiry_styles_insert_enquiry_style"; } }
        public static string UpdateEnquiryStyle { get { return "usp_enquiry_styles_update_enquiry_style"; } }
        public static string DeleteEnquiryStyle { get { return "usp_enquiry_styles_delete_enquiry_style"; } }
        public static string GetEnquiryStylesByEnquiryId { get { return "usp_enquiry_styles_get_enquiry_style_by_enquiry_id"; } }
        public static string GetEnquiryStylesByEnquiryNo { get { return "usp_enquiry_styles_get_enquiry_style_by_enquiry_no"; } }

        public static string InsertEnquiryStyleSizeRequirement { get { return "usp_enquiry_style_sizes_requirement_insert_size_requirement"; } }
        public static string UpdateEnquiryStyleSizeRequirement { get { return "usp_enquiry_style_sizes_requirement_update_size_requirement"; } }
        public static string DeleteEnquiryStyleSizeRequirement { get { return "usp_enquiry_style_sizes_requirement_delete_size_requirement"; } }
        public static string GetEnquiryStyleSizeRequirementByEnquiryStyleId { get { return "usp_enquiry_style_sizes_requirement_get_size_requirement_by_enquiry_style_id"; } }

        public static string InsertEnquiryStyleItemsRequirement { get { return "usp_enquiry_style_items_requirement_insert_item_requirement"; } }
        public static string UpdateEnquiryStyleItemsRequirement { get { return "usp_enquiry_style_items_requirement_update_item_requirement"; } }
        public static string DeleteEnquiryStyleItemsRequirement { get { return "usp_enquiry_style_items_requirement_delete_item_requirement"; } }
        public static string GetEnquiryStyleItemsRequirementByEnquiryStyleId { get { return "usp_enquiry_style_items_requirement_get_item_requirement_by_enquiry_style_id"; } }

        public static string InsertBrand { get { return "usp_brands_insert_brand"; } }
        public static string UpdateBrand { get { return "usp_brands_update_brand"; } }
        public static string DeleteBrand { get { return "usp_brands_delete_brand"; } }
        public static string GetAllBrands { get { return "usp_brands_get_all_brand_names"; } }
        public static string GetBrandByName { get { return "usp_brands_get_brand_by_name"; } }
        public static string GetBrandById { get { return "usp_brands_get_brand_by_id"; } }

        public static string InsertPurchaseBill { get { return "usp_purchase_bills_insert_bill_details"; } }
        public static string UpdatePurchaseBill { get { return "usp_purchase_bills_update_bill_details"; } }
        public static string DeletePurchaseBill { get { return "usp_purchase_bills_delete_bill_details"; } }
        public static string DeleteGoodsReceiptAndInwardByPurchaseBillId { get { return "usp_purchase_bills_delete_goods_receipts_and_inward_by_purchase_bill_id"; } }
        public static string CheckPurchaseBillExistsInSalesBill { get { return "usp_purchase_bills_exists_in_sales_bill_check"; } }
        public static string CheckPurchaseBillExistsInGoodsReceiptsAndInward { get { return "usp_purchase_bills_exists_in_goods_receipts_and_inwards_check"; } }
        public static string CheckPurchaseBillNoIsExists { get { return "usp_purchase_bills_check_purchase_bill_no_is_exists"; } }
        public static string GetAllPurchaseBills { get { return "usp_purchase_bills_get_all_bills"; } }
        public static string GetPurchaseBillsByVendorId { get { return "usp_purchase_bills_get_bills_by_vendor_id"; } }
        public static string GetPurchaseBillByBillId { get { return "usp_purchase_bills_get_bill_details_by_id"; } }
        public static string GetPurchaseBillByBillNoAndWorkingPeriod { get { return "usp_purchase_bills_get_bill_details_by_purchase_bill_no_and_working_period"; } }
        public static string GetPurchaseBillByBillNoVendorIdAndWorkingPeriod { get { return "usp_purchase_bills_get_bill_details_by_purchase_bill_no_vendor_id_and_working_period"; } }
        public static string GetVendorsByPurchaseBillNo { get { return "usp_purchase_bills_get_vendors_by_purchase_bill_no"; } }

        public static string InsertPurchaseBillChargesDetails { get { return "usp_purchase_bill_charges_details_insert_charges"; } }
        public static string UpdatePurchaseBillChargesDetails { get { return "usp_purchase_bill_charges_details_update_charges"; } }
        public static string DeletePurchaseBillChargesDetails { get { return "usp_purchase_bill_charges_details_delete_charges"; } }
        public static string GetPurchaseBillChargesDetails { get { return "usp_purchase_bill_charges_details_get_bill_charges_details"; } }
        public static string CheckPurchaseBillChargeNameIsExists { get { return "usp_purchase_bill_charges_check_bill_charge_name_is_exists"; } }

        public static string InsertPurchaseBillItem { get { return "usp_purchase_bill_items_insert_bill_item"; } }
        public static string UpdatePurchaseBillItem { get { return "usp_purchase_bill_items_update_bill_item"; } }
        public static string DeletePurchaseBillItem { get { return "usp_purchase_bill_items_delete_bill_item"; } }
        public static string GetPurchaseBillItemsByPurchaseBillId { get { return "usp_purchase_bill_items_get_bill_items_by_purchase_bill_id"; } }

        public static string InsertGoodsReceipt { get { return "usp_goods_receipts_insert_goods_receipt"; } }
        public static string UpdateGoodsReceipt { get { return "usp_goods_receipts_update_goods_receipt"; } }
        public static string DeleteGoodsReceipt { get { return "usp_goods_receipts_delete_goods_receipt"; } }
        public static string GetAllGoodsReceipts { get { return "usp_goods_receipts_get_all_goods_receipts"; } }
        public static string GetGoodsReceiptByPurchaseBillId { get { return "usp_goods_receipts_get_goods_receipt_by_purchase_bill_id"; } }
        public static string GetGoodsReceiptByVendorId { get { return "usp_goods_receipts_get_goods_receipt_by_vendor_id"; } }
        public static string GetGoodsReceiptDetailsById { get { return "usp_goods_receipts_get_receipt_details_by_id"; } }
        public static string CheckGoodsReceiptExistsInSalesBill { get { return "usp_goods_receipts_exists_in_sales_bill_check"; } }
        public static string GetVendorsForGoodsReceipt { get { return "usp_goods_receipts_get_vendors"; } }

        public static string InsertGoodsReceiptItems { get { return "usp_goods_receipt_items_insert_goods_receipt_item"; } }
        public static string UpdateGoodsReceiptItems { get { return "usp_goods_receipt_items_update_goods_receipt_item"; } }
        public static string DeleteGoodsReceiptItems { get { return "usp_goods_receipt_items_delete_goods_receipt_item"; } }
        public static string GetGoodsReceiptItemsByGoodsReceiptId { get { return "usp_goods_receipt_items_get_goods_receipt_item_by_goods_receipt_id"; } }
        public static string GetPendingPurchaseBills { get { return "usp_goods_receipts_get_pending_purchase_bills_by_vendor_id"; } }
        public static string GetPurchaseBillItemsForGoodsReceipts { get { return "usp_goods_receipts_get_purchase_bill_items_by_purchase_bill_id"; } }
        
        public static string GetAllCompanies { get { return "usp_companies_get_all_companies"; } }
        public static string GetCompanyDetailsByCompanyId { get { return "ups_companies_get_company_details_by_id"; } }

        public static string GetAllBranchNames { get { return "usp_branches_get_all_branch_names"; } }
        public static string GetBranchesByCompanyId { get { return "usp_branches_get_branches_by_company_id"; } }

        public static string InsertPkgSlip { get { return "usp_pkg_slips_insert_pkg_slip"; } }
        public static string UpdatePkgSlip { get { return "usp_pkg_slips_update_pkg_slip"; } }
        public static string DeletePkgSlip { get { return "usp_pkg_slips_delete_pkg_slip"; } }
        public static string GetAllPkgSlips { get { return "usp_pkg_slips_get_all_pkg_slips"; } }
        public static string GetGoodsReceivedItemsForPkgSlip { get { return "usp_pkg_slips_get_goods_received_items"; } }
        public static string GetVendorsForPkgSlip { get { return "usp_pkg_slips_get_vendors"; } }
        public static string GetBaleNosByVendorId { get { return "usp_pkg_slips_get_bale_nos_by_vendor_id"; } }
        public static string GetPurchaseBillNosByVendorId { get { return "usp_pkg_slips_get_purchase_bill_nos_by_vendor_id"; } }
        public static string GetPkgSlipItemsByPurchaseBillIdBaleNoAndLocationId { get { return "usp_pkg_slips_get_items_by_purchase_bill_id_bale_no_and_location_id"; } }
        public static string GetFromLocationByPurchaseBillId { get { return "usp_pkg_slips_get_from_location_by_purchase_bill_id"; } }
        public static string GetBaleItemsByPurchaseBillIdAndLocationId { get { return "usp_pkg_slips_get_bale_items_by_purchase_bill_id"; } }
        public static string GetBaleNosByPurchaseBillId { get { return "usp_pkg_slips_get_bale_nos_by_purchase_bill_id"; } }

        public static string InsertPkgSlipItem { get { return "usp_pkg_slip_items_insert_item"; } }
        public static string UpdatePkgSlipItem { get { return "usp_pkg_slip_items_update_item"; } }
        public static string DeletePkgSlipItem { get { return "usp_pkg_slip_items_delete_item"; } }
        public static string GetPkgSlipItemByPkgSlipId { get { return "usp_pkg_slip_items_get_by_pkg_slip_id"; } }

        public static string InsertOutwardDetails { get { return "usp_outwards_insert_outward"; } }
        public static string UpdateOutwardDetails { get { return "usp_outwards_update_outward"; } }
        public static string DeleteOutwardDetails { get { return "usp_outwards_delete_outward"; } }
        public static string GetAllOutwardDetails { get { return "usp_outwards_get_all_outward_details"; } }
        public static string GetOutwardDetailsByOutwardId { get { return "usp_outwards_get_outward_details_by_id"; } }

        public static string InsertOutwardGoodsDetails { get { return "usp_outward_goods_details_insert_outward_goods"; } }
        public static string UpdateOutwardGoodsDetails { get { return "usp_outward_goods_details_update_outward_goods"; } }
        public static string DeleteOutwardGoodsDetails { get { return "usp_outward_goods_details_delete_outward_goods"; } }
        public static string GetOutwardGoodsDetailsByOutwardId { get { return "usp_outward_goods_details_get_goods_details_by_outward_id"; } }
        public static string GetBaleNosForOutward { get { return "usp_outwards_get_bale_no_from_pkg_slip"; } }
        public static string GetPkgSlipAdditionalDetailsByPkgSlipId { get { return "usp_outward_get_pkg_slip_additional_details_by_pkg_slip_id"; } }
        public static string GetPkgSlipItemsForOutwardByPkgSlipId { get { return "usp_outward_goods_details_get_pkg_slip_items_by_pkg_slip_id"; } }

        public static string InsertCustomerCategory { get { return "usp_customer_categories_insert_customer_category"; } }
        public static string UpdateCustomerCategory { get { return "usp_customer_categories_update_customer_category"; } }
        public static string DeleteCustomerCategory { get { return "usp_customer_categories_delete_customer_category"; } }
        public static string GetAllCustomerCategories { get { return "usp_customer_categories_get_all_customer_categories"; } }
        public static string GetCustomerCategoryById { get { return "usp_customer_categories_get_customer_category_by_id"; } }

        public static string InsertItemRate { get { return "usp_item_rates_insert_item_rate"; } }
        public static string UpdateItemRate { get { return "usp_item_rates_update_item_rate"; } }
        public static string DeleteItemRate { get { return "usp_item_rates_delete_item_rate"; } }
        public static string GetAllItemRates { get { return "usp_item_rates_get_all_items_rates"; } }
        public static string GetItemsRatesByItemId { get { return "usp_item_rates_get_items_rates_by_item_id"; } }
        public static string GetItemRateByItemRateId { get { return "usp_item_rates_get_items_rates_by_item_rate_id"; } }
        public static string InsertItemRatesForCustomerCategory { get { return "usp_item_rates_for_customer_categories_insert_item_rate"; } }
        public static string UpdateItemRatesForCustomerCategory { get { return "usp_item_rates_for_customer_categories_update_item_rate"; } }
        public static string DeleteItemRatesForCustomerCategory { get { return "usp_item_rates_for_customer_categories_delete_item_rate"; } }
        public static string GetItemRatesForCustomerCategoryByItemId { get { return "usp_item_rates_for_customer_categories_get_item_rate_by_item_id"; } }
        public static string GetItemRatesForCustomerCategoriesGetCustomerCategories { get { return "usp_item_rates_for_customer_categories_get_customer_categories"; } }
        public static string GetItemRatesForCustomerCategoriesByItemRateId { get { return "usp_item_rates_for_customer_categories_get_item_rates_by_item_rate_id"; } }
        public static string GetWholesaleAndRetailItemRatesByItemId { get { return "usp_item_rates_get_wholesale_and_retail_rates_for_item_by_item_id"; } }
        public static string GetWholesaleAndRetailItemRateForAllItems{ get { return "usp_item_rates_get_wholesale_and_retail_rates_for_all_items"; } }
        public static string GetWholesaleAndRetailItemRatesBySalesBillId{ get { return "usp_item_rates_get_wholesale_and_retail_rates_for_sales_bill_item"; } }
        public static string SearchItemRatesByItemNameAndQuality { get { return "usp_item_rates_search_item_rates_by_item_name_and_quality"; } }

        public static string InsertSalesOrder { get { return "usp_sales_orders_insert_sales_order"; } }
        public static string UpdateSalesOrder { get { return "usp_sales_orders_update_sales_order"; } }
        public static string DeleteSalesOrder { get { return "usp_sales_orders_delete_sales_order"; } }
        public static string GetAllSalesOrders { get { return "usp_sales_orders_get_all_sales_orders"; } }
        public static string GetSalesOrdersBySalesOrderId { get { return "usp_sales_orders_get_sales_order_details_by_id"; } }
        public static string GetSalesOrdersByCustomerId { get { return "usp_sales_orders_get_sales_orders_by_customer_id"; } }

        public static string InsertSalesOrderItem { get { return "usp_sales_orders_items_insert_sales_order_items"; } }
        public static string UpdateSalesOrderItem { get { return "usp_sales_orders_items_update_sales_order_items"; } }
        public static string DeleteSalesOrderItem { get { return "usp_sales_orders_items_delete_sales_order_items"; } }
        public static string GetSalesOrderItemsBySalesOrderId { get { return "usp_sales_orders_items_get_items_by_sales_order_id"; } }

        public static string InsertSalesBill { get { return "usp_sales_bills_insert_sales_bill"; } }
        public static string UpdateSalesBill { get { return "usp_sales_bills_update_sales_bill"; } }
        public static string DeleteSalesBill { get { return "usp_sales_bills_delete_sales_bill"; } }
        public static string CancelSalesBill { get { return "usp_sales_bills_cancel_sales_bill"; } }
        public static string CheckSalesBillNoIsExists { get { return "usp_sales_bills_check_sales_bill_no_is_exists"; } }
        public static string GetSalesBillsByBranchId { get { return "usp_sales_bills_get_sales_bills_by_branch_id"; } }
        public static string GetSalesBillsByCustomerId { get { return "usp_sales_bills_get_sales_bills_by_customer_id"; } }
        public static string GetSalesBillsBySaleType { get { return "usp_sales_bills_get_sales_bills_by_sale_type"; } }
        public static string GetSalesBillDetailsById { get { return "usp_sales_bills_get_sales_bill_details_by_id"; } }
        public static string GetSalesBillDetailsByWorkingPeriodSaleTypeAndSalesBillNo { get { return "usp_sales_bills_get_sales_bill_details_by_working_period_sale_type_and_sales_bill_no"; } }
        public static string GetTypeOfSales { get { return "usp_sale_types_get_type_of_sales"; } }
        public static string GetItemsListByGoodsReceiptBarcode { get { return "usp_items_get_item_details_by_goods_receipt_item_id"; } }
        public static string GetItemsListByGoodsReceiptAndInwardGoodsBarcode {  get { return "usp_items_get_item_details_by_goods_receipt_item_id_and_inward_goods_id"; } }
        public static string GetItemDetailsByItemId { get { return "usp_items_get_item_details_by_item_id"; } }
        public static string GetSaleRateHistoryByCustomerAndItem { get { return "usp_sales_bills_get_sale_rate_history_by_customer_id_and_item_id"; } }

        public static string InsertSalesBillsDeliveryDetails { get { return "usp_sales_bills_delivery_details_insert_delivery_details"; } }
        public static string UpdateSalesBillsDeliveryDetails { get { return "usp_sales_bills_delivery_details_update_delivery_details"; } }
        public static string DeleteSalesBillsDeliveryDetails { get { return "usp_sales_bills_delivery_details_delete_delivery_details"; } }
        public static string GetSalesBillsDeliveryDetails { get { return "usp_sales_bills_delivery_details_get_delivery_details"; } }

        public static string InsertSalesBillsPaymentDetails { get { return "usp_sales_bills_payment_details_insert_payment_details"; } }
        public static string UpdateSalesBillsPaymentDetails { get { return "usp_sales_bills_payment_details_update_payment_details"; } }
        public static string DeleteSalesBillsPaymentDetails { get { return "usp_sales_bills_payment_details_delete_payment_details"; } }
        public static string GetSalesBillsPaymentDetails { get { return "usp_sales_bills_payment_details_get_payment_details"; } }

        public static string InsertSalesBillChargesDetails { get { return "usp_sales_bills_charges_details_insert_charges"; } }
        public static string UpdateSalesBillChargesDetails { get { return "usp_sales_bills_charges_details_update_charges"; } }
        public static string DeleteSalesBillChargesDetails { get { return "usp_sales_bills_charges_details_delete_charges"; } }
        public static string GetSalesBillChargesDetails { get { return "usp_sales_bills_charges_details_get_bill_charges_details"; } }
        public static string CheckSalesBillChargeNameIsExists{ get{ return "usp_sales_bills_charges_check_bill_charge_name_is_exists"; } }

        public static string InsertSalesBillsItem { get { return "usp_sales_bills_items_insert_sales_bill_items"; } }
        public static string UpdateSalesBillsItem { get { return "usp_sales_bills_items_update_sales_bill_items"; } }
        public static string DeleteSalesBillsItem { get { return "usp_sales_bills_items_delete_sales_bill_items"; } }
        public static string GetSalesBillsItemsBySalesBillId { get { return "usp_sales_bills_items_get_items_by_sales_bill_id"; } }
        public static string SearchSaleItemsByItemName { get { return "usp_sales_bill_items_search_by_item"; } }
        public static string GetItemRateHistoryFromSalesBill { get { return "usp_sales_bill_items_get_item_rate_history"; } }

        public static string InsertSalesBillItemChargesDetails { get { return "usp_sales_bills_item_charges_details_insert_item_charges"; } }
        public static string UpdateSalesBillItemChargesDetails { get { return "usp_sales_bills_item_charges_details_update_item_charges"; } }
        public static string DeleteSalesBillItemChargesDetails { get { return "usp_sales_bills_item_charges_details_delete_item_charges"; } }
        public static string GetSalesBillItemChargesDetails { get { return "usp_sales_bills_items_charges_details_get_item_charges"; } }
        public static string CheckSalesBillItemChargeNameIsExists { get { return "usp_sales_bills_charges_check_bill_item_charge_name_is_exists"; } }

        public static string InsertSalesReturnBill { get { return "usp_sales_return_bills_insert"; } }
        public static string UpdateSalesReturnBill { get { return "usp_sales_return_bills_update"; } }
        public static string DeleteSalesReturnBill { get { return "usp_sales_return_bills_delete"; } }
        public static string CheckSalesReturnBillNoIsExists { get { return "usp_sales_return_bills_check_sales_return_bill_no_is_exists"; } }
        public static string GetSalesReturnBillBySalesBillId { get { return "usp_sales_return_bills_get_sales_return_by_sales_bill_id"; } }
        public static string GetAllSalesReturnBills { get { return "usp_sales_return_bills_get_all_sales_return_bills"; } }
        public static string GetSalesReturnBillsBySalesType { get { return "usp_sales_return_bills_get_bills_by_sales_type"; }}
        public static string GetSalesReturnBillsByBranchWorkingPeriodAndSalesType { get { return "usp_sales_return_bills_get_bills_by_branch_working_period_and_sales_type"; } }
        public static string GetConsigneeFromSalesBills{ get { return "usp_sales_return_bills_get_consignee_from_sales_bills"; } }

        public static string InsertSalesReturnBillItem { get { return "usp_sales_return_bill_items_insert"; } }
        public static string UpdateSalesReturnBillItem { get { return "usp_sales_return_bill_items_update"; } }
        public static string DeleteSalesReturnBillItem { get { return "usp_sales_return_bill_items_delete"; } }
        public static string GetSalesReturnBillItemsBySalesBillId { get { return "usp_sales_return_bill_items_get_items_by_sales_bill_id"; } }
        public static string GetSalesReturnBillItemBySalesBillReturnId { get { return "usp_sales_return_bill_items_get_items_by_sales_return_bill_id"; } }
        public static string GetSalesReturnBillAdjustmentBySalesBillReturnId { get { return "usp_sales_return_bill_adjustment_get_sales_bills_by_sales_return_bill_id"; } }
        public static string GetAllSalesReturnBillItems { get { return "usp_sales_bill_return_items_get_all_sales_bill_return_items"; } }
        public static string GetSalesBillAdditaionalDetails { get { return "usp_sales_return_bills_get_sales_bill_details"; } }
        public static string GetSalesReturnBillItemsByItemName { get { return "usp_items_search_items_by_item_name"; } }
        public static string GetSalesReturnBillItemsByBarcode { get { return "usp_items_get_item_details_by_goods_receipt_item_id"; } }
        public static string GetSalesReturnBillItemsByConsignee { get { return "usp_sales_return_bill_items_get_items_by_consignee"; } }
        public static string GetSalesBillsByConsignee { get { return "usp_sales_return_bill_items_get_sales_bills_by_consignee"; } }

        public static string GetGSTRateByItemIdGSTApplicableAndSaleRate { get { return "usp_gst_rate_get_by_item_id_gst_applicable_and_sale_rate"; } }
        public static string GetGSTRateByItemCategoryIdGSTApplicableAndPurchaseRate { get { return "usp_gst_rate_get_by_item_category_id_gst_applicable_and_purchase_rate"; } }
        public static string GetGSTRateByItemId { get { return ""; } }
        public static string GetGSTApplicable { get { return "usp_gst_applicable_by_client_address_id"; } }

        public static string InsertStockDetails { get { return "usp_stock_details_insert_stock_item"; } }
        public static string UpdateStockDetails { get { return "usp_stock_details_update_stock_item"; } }
        public static string DeleteStockDetails { get { return "usp_stock_details_delete_stock_item"; } }
        public static string GetStockDetails { get { return "usp_stock_details_get_item_wise_stock"; } }

        public static string InsertTaxSlab { get { return "usp_tax_slabs_insert_tax_slab"; } }
        public static string UpdateTaxSlab { get { return "usp_tax_slabs_update_tax_slab"; } }
        public static string DeleteTaxSlab { get { return "usp_tax_slabs_delete_tax_slab"; } }
        public static string GetAllTaxSlabs { get { return "usp_tax_slabs_get_tax_slabs"; } }

        public static string InsertTaxSlabSubHead { get { return "usp_tax_slabs_sub_heads_insert_tax_slab_sub_head"; } }
        public static string UpdateTaxSlabSubHead { get { return "usp_tax_slabs_sub_heads_update_tax_slab_sub_head"; } }
        public static string DeleteTaxSlabSubHead { get { return "usp_tax_slabs_sub_heads_delete_tax_slab_sub_head"; } }
        public static string GetAllTaxSlabsSubHead { get { return "usp_tax_slabs_sub_heads_get_tax_slab_sub_heads"; } }

        public static string InsertBarcodeDetails { get { return "usp_barcode_insert_barcode_details"; } }
        public static string DeleteBarcodeDetails { get { return "usp_barcode_delete_barcode_details"; } }
        public static string GetVendorsForBarcode { get { return "usp_barcode_get_vendors"; } }
        public static string GetItemsForBarcode { get { return "usp_barcode_get_items"; } }
        public static string GetItemsForBarcodeAsPerGoodsReceived { get { return "usp_barcode_get_items_as_per_goods_receipt"; } }
        public static string GetItemsForBarcodeAsPerInwardOutward { get { return "usp_barcode_get_items_by_inward_outward"; } }
        public static string CheckInwardExistsInSalesBill { get { return "usp_inwards_exists_in_sales_bill_check"; } }
        public static string SearchInwardNo { get { return "usp_barcode_get_inward_nos_by_search"; } }
        public static string GetItemsForBarcodeByInwardId { get { return "usp_barcode_get_inward_goods_details_by_inward_id"; } }

        public static string InsertCity { get { return "usp_cities_insert_city"; } }
        public static string UpdateCity { get { return "usp_cities_update_city"; } }
        public static string DeleteCity { get { return "usp_cities_delete_city"; } }
        public static string CheckCityNameIsExists { get { return "usp_city_check_city_name_is_exists"; } }

        public static string InsertItemSetSubItem { get { return "usp_item_sets_sub_items_insert_set_sub_items"; } }
        public static string UpdateItemSetSubItem { get { return "usp_item_sets_sub_items_update_set_sub_items"; } }
        public static string DeleteItemSetSubItem { get { return "usp_item_sets_sub_items_delete_set_sub_items"; } }
        public static string DeleteItemSetSubItemsByItemId { get { return "usp_item_sets_sub_items_delete_set_sub_items_by_item_id"; } }
        public static string GetSetSubItems { get { return "usp_item_sets_sub_items_get_set_sub_items"; } }
        public static string GetSetItemsByItemId { get { return "usp_item_sets_sub_items_get_set_items_by_item_id"; } }
        public static string GetTypeOfTransfers { get { return "usp_type_of_transfers_get_transfer_types"; } }

        public static string InsertCharge { get { return "usp_charges_insert_charges"; } }
        public static string UpdateCharge { get { return "usp_charges_update_charges"; } }
        public static string DeleteCharge { get { return "usp_charges_delete_charges"; } }
        public static string GetAllCharges { get { return "usp_charges_get_all_charges"; } }
        public static string CheckChargeNameIsExists { get { return "usp_charges_check_charge_name_is_exists"; } }

        public static string GetModeOfPayments { get { return "usp_mode_of_payments_get"; } }
        public static string GetPaymentSettlement { get { return "usp_payment_settlement_get"; } }

        public static string InsertInwardDetails { get { return "usp_inwards_insert_inward_details"; } }
        public static string UpdateInwardDetails { get { return "usp_inwards_update_inward_details"; } }
        public static string DeleteInwardDetails { get { return "usp_inwards_delete_inward_details"; } }
        public static string GetAllInwardDetails { get { return "usp_inwards_get_all_inward_details"; } }
        public static string GetInwardReferenceNosFromGoodsReceipts { get { return "usp_inwards_get_inward_reference_nos_from_goods_receipts"; } }
        public static string GetInwardReferenceNosFromOutwards   { get { return "usp_inwards_get_inward_reference_nos_from_outwards"; } }
        public static string GetInwardReferenceNosFromJobWorks { get { return "usp_inwards_get_inward_reference_nos_from_job_works"; } }
        public static string GetInwardReferenceNoFromInward { get { return "usp_inwards_get_inward_reference_no_from_inward"; } }
        public static string GetInwardReferenceNoDetailsByGoodsReceiptId { get { return "usp_inwards_get_reference_no_details_by_goods_receipt_id"; } }
        public static string GetInwardReferenceNoDetailsByOutwardId { get { return "usp_inwards_get_reference_no_details_by_outward_id"; } }
        public static string GetInwardReferenceNoDetailsByJobWorkId { get { return "usp_inwards_get_reference_no_details_by_job_work_id"; } }

        public static string InsertInwardGoodsDetails { get { return "usp_inward_goods_details_insert_inward_goods"; } }
        public static string UpdateInwardGoodsDetails { get { return "usp_inward_goods_details_update_inward_goods"; } }
        public static string DeleteInwardGoodsDetails { get { return "usp_inward_goods_details_delete_inward_goods"; } }
        public static string GetInwardGoodsDetailsByInwardId { get { return "usp_inward_goods_details_get_goods_details_by_inward_id"; } }
        public static string GetInwardGoodsDetailsByGoodsReceiptId { get { return "usp_inwards_get_inward_goods_details_by_goods_receipt_id"; } }
        public static string GetInwardGoodsDetailsByOutwardId { get { return "usp_inwards_get_inward_goods_details_by_outward_id"; } }

        public static string GetStockReportAsOnDate { get { return "usp_stock_as_on_date"; } }        
        public static string GetStockReportAsOnDateByItemWiseWithPurchaseCost { get { return "usp_stock_report_get_as_on_date_item_wise_qty_with_purchase_cost"; } }
        public static string GetStockAsOnDate { get { return "usp_stock_report_get_stock_as_on_date"; } }
        public static string GetStockByItemId { get { return "usp_stock_report_get_stock_by_item_id"; } }
        public static string GetStockByItemName { get { return "usp_stock_report_get_stock_by_item_name"; } }
        public static string GetStockItemCategoryWise { get { return "usp_stock_report_get_stock_item_category_wise"; } }
        public static string GetStockItemCategoryWiseByItemCategoryId { get { return "usp_stock_report_get_stock_item_category_wise_by_item_category_id"; } }
        public static string GetStockItemCategorWiseAndItemQualityWise{ get { return "usp_stock_report_get_stock_item_category_wise_and_item_quality_wise"; } }
        public static string GetStockLocationWiseAndItemWiseByLocationId{ get { return "usp_stock_report_get_stock_location_wise_and_item_wise_by_location_id"; } }
        public static string GetStockLocationWiseItemWiseByItemId{ get { return "usp_stock_report_get_stock_location_wise_item_wise_by_item_id"; } }
        public static string GetStockLocationWiseItemQualityWiseAndItemWise { get { return "usp_stock_report_get_stock_location_wise_item_quality_wise_and_item_wise"; } }

        public static string GetPurchaseBillRegisterComplete { get { return "usp_purchase_bills_print_purchase_bill_register_complete"; } }
        public static string GetPurchaseBillRegisterByWorkingPeriod{ get { return "usp_purchase_bills_print_purchase_bill_register_by_working_period"; } }
        public static string GetPurchaseBillRegisterByVendor { get { return "usp_purchase_bills_print_purchase_bill_register_by_vendor"; } }
        public static string GetPurchaseBillRegisterByPeriod { get { return "usp_purchase_bills_print_purchase_bill_register_by_period"; } }
        public static string GetPurchaseBillRegisterByWorkingPeriodAndVendor { get { return "usp_purchase_bills_print_purchase_bill_register_by_working_period_and_vendor"; } }
        public static string GetPurchaseBillRegisterByVendorAndFromToDate { get { return "usp_purchase_bills_print_purchase_bill_register_by_vendor_and_from_to_date"; } }

        public static string InsertSalesReturnBillAdjustment { get { return "usp_sales_return_bill_adjustment_insert"; } }
        public static string DeleteSalesReturnBillAdjustment { get { return "usp_sales_return_bill_adjustment_delete"; } }
        public static string UpdateSalesReturnBillAdjustment { get { return "usp_sales_return_bill_adjustment_update"; } }
        
        public static string GetStockInTransitDetails { get { return "usp_stock_in_transit_report"; } }

        public static string GetSalesBillRegisterComplete { get { return "usp_sales_bills_print_sales_bill_register_complete"; } }
        public static string GetSalesBillRegisterByWorkingPeriod { get { return "usp_sales_bills_print_sales_bill_register_by_working_period_id"; } }
        public static string GetSalesBillRegisterByCustomer { get { return "usp_sales_bills_print_sales_bill_register_by_customer"; } }
        public static string GetSalesBillRegisterByCustomerAndFromToDate { get { return "usp_sales_bills_print_sales_bill_register_by_customer_id_and_from_to_date"; } }
        public static string GetSalesBillRegisterByCustomerAndWorkingPeriod{ get { return "usp_sales_bills_print_sales_bill_register_by_customer_id_and_working_period_id"; } }
        public static string GetSalesBillRegisterByFromToDate { get { return "usp_sales_bills_print_sales_bill_register_by_from_to_date"; } }
        public static string GetSalesBillRegisterBySalesTypeId { get { return "usp_sales_bills_print_sales_bill_register_by_sale_type_id"; } }

        public static string GetSalesBillItemsRegisterComplete { get { return "usp_sales_bills_items_print_sales_bill_item_wise_register_complete"; } }
        public static string GetSalesBillItemsRegisterByWorkingPeriod { get { return "usp_sales_bills_items_print_sales_bill_item_wise_register_by_working_period"; } }
        public static string GetSalesBillItemsRegisterByCustomer { get { return "usp_sales_bills_items_print_sales_bill_item_wise_register_by_customer"; } }
        public static string GetSalesBillItemsRegisterByFromToDate { get { return "usp_sales_bills_items_print_sales_bill_item_wise_register_by_from_to_date"; } }
        public static string GetSalesBillItemsRegisterByCustomerAndWorkingPeriod { get { return "usp_sales_bills_items_print_sales_bill_item_wise_register_by_customer_id_and_from_to_date"; } }
        public static string GetSalesBillItemsRegisterByCustomerAndFromToDate { get { return "usp_sales_bills_items_print_sales_bill_item_wise_register_by_customer_id_and_from_to_date"; } }
        public static string GetSalesBillItemsRegisterBySalesTypeId { get { return "usp_sales_bills_print_sales_bill_item_wise_register_by_sale_type_id"; } }

        public static string GetItemRateRegisterComplete { get { return "usp_item_rates_print_item_rates"; } }


        public static string GetSaleQtyOfAllItemCategories { get { return "usp_sales_qty_report_get_by_company_branch_saletype_monthly_itemcategorywise"; } }

        public static string GetSaleQtyOfAllItemCategoriesAndItemQualities { get { return "usp_sales_qty_report_get_by_company_branch_saletype_monthly_itemcategorywise_itemqualitywise"; } }

        public static string GetSaleQtyOfAllItemCategoriesItemQualitiesAndItems { get { return "usp_sales_qty_report_get_by_company_branch_saletype_monthly_itemcategorywise_itemqualitywise_itemwise"; } }

        public static string GetAllJobWorkDetails { get { return "usp_job_works_get_all_job_work_details"; } }
        public static string GetJobWorkPurchaseBillNos { get { return "usp_job_works_get_purchase_bills"; } }
        public static string GetJobWorkKaragirList { get { return "usp_job_works_get_karagir_details"; } }
        public static string GetJobWorkPurchaseBillItems { get { return "usp_job_works_get_purchase_bill_items_details"; } }
        public static string GetJobWorkItemsByInward { get { return "usp_job_work_items_get_job_work_items_from_inward"; } }
        public static string GetJobWorkKaragirDetails { get { return "usp_job_works_get_karagir_and_additional_details"; } }
        public static string InsertJobWorkDetails { get { return "usp_job_works_insert_job_work_details"; } }
        public static string UpdateJobWorkDetails { get { return "usp_job_works_update_job_work_details"; } }
        public static string DeleteJobWorkDetails { get { return "usp_job_works_delete_job_work_details"; } }
        public static string GetJobWorkItemsByJobWorkId { get { return "usp_job_work_items_get_job_work_item_by_job_work_id"; } }

        public static string GetJobWorkItemMtrAdjustmentDetails { get { return "usp_job_work_items_get_mtr_adjustment_details"; } }
            
        public static string InsertJobWorkItemsDetails { get { return "usp_job_work_items_insert_job_work_item_details"; } }
        public static string UpdateJobWorkItemsDetails { get { return "usp_job_work_items_update_job_work_item_details"; } }
        public static string DeleteJobWorkItemsDetails { get { return "usp_job_work_items_delete_job_work_item_details"; } }

        public static string InsertJobWorkItemMtrAdjustmentDetails { get { return "usp_job_work_items_mtr_adjustment_insert"; } }
        public static string UpdateJobWorkItemMtrAdjustmentsDetails { get { return "usp_job_work_items_mtr_adjustment_update"; } }
        public static string DeleteJobWorkItemMtrAdjustmentsDetails { get { return "usp_job_work_items_mtr_adjustment_delete"; } }

        public static string GetJobWorkItemsBalanceQty { get { return "usp_job_works_get_balance_items_qty_report"; } }
        public static string GetJobWorkItemsSentToKaragir { get { return "usp_job_works_get_goods_sent_to_job_work_report"; } }

        public static string GetSalesmanwiseDailySalesQtyReport { get { return "usp_sales_qty_report_get_salesmanwise_daily_sales_report"; } }
        public static string GetSalesmanwiseDailySalesQtyReportWithSaleRateAndPurchaseRate { get { return "usp_sales_qty_report_get_salesmanwise_daily_sales_with_sale_rate_and_purchase_rate"; } }
        public static string GetSalesmanwiseItemwiseDailySalesValueReport { get { return "usp_sales_value_report_get_by_salesmanwise_datewise_itemwise_sales_value"; } }

        public static string InsertDailyReceivablePayable { get { return "usp_daily_receivable_payable_insert"; } }
        public static string UpdateDailyReceivablePayable { get { return "usp_daily_receivable_payable_update"; } }
        public static string DeleteDailyReceivablePayable { get { return "usp_daily_receivable_payable_delete"; } }
        public static string GetBranchwiseSalesTypeWiseModeOfPaymentwiseDailySalesBiillValueDatewise { get { return "usp_daily_receivable_payable_get_data_by_entry_date"; } }

        public static string VoucherTallyTransfer { get { return "usp_voucher_tally_transfer"; }}

        public static string GetVoucherType { get { return "usp_voucher_types_get_all_voucher_type"; } }

        public static string InsertPurchaseOrder { get { return "usp_purchase_orders_insert_purchase_order"; } }
        public static string UpdatePurchaseOrder { get { return "usp_purchase_orders_update_purchase_order"; } }
        public static string DeletePurchaseOrder { get { return "usp_purchase_orders_delete_purchase_order"; } }
        public static string CheckPurchaseOrderNoIsExists { get { return "usp_purchase_orders_check_purchase_order_no_is_exists"; } }
        public static string GetAllPurchaseOrders { get { return "usp_purchase_orders_get_all_purchase_orders"; } }
        public static string GetPurchaseOrdersByVendorId { get { return "usp_purchase_orders_get_orders_by_vendor_id"; } }
        public static string GetPurchaseOrdersByVendorName { get { return "usp_purchase_orders_get_orders_by_vendor_name"; } }
        public static string GetPurchaseOrderDetailsByOrderId { get { return "usp_purchase_orders_get_order_details_by_order_id"; } }
        public static string GetPurchaseOrderDetailsByOrderNoAndWorkingPeriod { get { return "usp_purchase_orders_get_order_details_by_purchase_order_no_and_working_period"; } }        
        public static string GetVendorsByPurchaseOrderNo { get { return "usp_purchase_orders_get_vendors_by_purchase_order_no"; } }

        public static string InsertPurchaseOrderItem { get { return "usp_purchase_order_items_insert_purchase_order_item"; } }
        public static string UpdatePurchaseOrderItem { get { return "usp_purchase_order_items_update_purchase_order_item"; } }
        public static string DeletePurchaseOrderItem { get { return "usp_purchase_order_items_delete_purchase_order_item"; } }
        public static string GetPurchaseOrderItemsByPurchaseOrderId { get { return "usp_purchase_order_items_get_order_items_by_purchase_order_id"; } }

        public static string GetAllOrdersStatus { get { return "usp_orders_status_get_all_orders_status_codes"; } }

        public static string InsertPaymentTerms { get { return "usp_payment_terms_insert"; } }
        public static string UpdatePaymentTerms { get { return "usp_payment_terms_update"; } }
        public static string DeletePaymentTerms { get { return "usp_payment_terms_delete"; } }
        public static string GetAllPaymentTerms { get { return "usp_payment_terms_get_all_payment_terms"; } }

        public static string GetItemMarginReportByCategorywiseQualitywiseCostwise { get { return "usp_item_margin_report_by_categorywise_qualitywise_costwise"; } }
        
        public static string InsertSalesScheme { get { return "usp_sales_schemes_insert_sales_scheme"; } }
        public static string UpdateSalesScheme { get { return "usp_sales_schemes_update_sales_scheme"; } }
        public static string DeleteSalesScheme { get { return "usp_sales_schemes_delete_sales_scheme"; } }
        public static string GetAllSalesSchemes { get { return "usp_sales_schemes_get_all_sales_schemes"; } }
        public static string GetSalesSchemeDetailsByItem { get { return "usp_sales_schemes_get_scheme_details_by_item"; } }

        public static string GetSalesSchemesRegister { get { return "usp_sales_schemes_get_register"; } }

    }


}
