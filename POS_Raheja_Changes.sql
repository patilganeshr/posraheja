
use POS_Raheja_Dev

alter table outwards add location_id int
go

alter table pkg_slip_items
add goods_receipt_item_id	int
go

alter table pkg_slips
add from_location_id int
go

alter table pkg_slips
add type_of_transfer nvarchar(50)
go

alter table clients alter column client_name nvarchar(100)
go

alter table client_addressess alter column client_address_name nvarchar(100)
go

exec sp_rename 'role_permissions.rowguid', 'row_guid'

alter table role_permissions add constraint [DF_role_permissions_row_guid] default(newid()) for[row_guid]
go

alter table items add is_set bit
go

alter table items add constraint [DF_items_is_set] default(0) for[is_set]
go

create table item_sets_sub_items
(
item_set_sub_item_id		int	identity(1,1)	not null,
item_id						int	not null,
sub_item_id					int	not null,
sub_item_net_qty			int	not null,
is_deleted					bit	not null,
created_by					int	not null,
created_by_ip				nvarchar(25) not null,
created_datetime			datetime	not null,
modified_by					int	null,
modified_by_ip				nvarchar(25)	null,
modified_datetime			datetime	null,
deleted_by					int	null,
deleted_by_ip				nvarchar(25)	null,
deleted_datetime			datetime	null,
row_guid					uniqueidentifier	not null,
constraint [pk_item_sets_sub_items_item_set_sub_item_id] primary key clustered
	(
		[item_set_sub_item_id] ASC 
	)
) ON [PRIMARY]
GO

alter table dbo.item_sets_sub_items add constraint [DF_item_sets_sub_items_is_deleted] default(0) for[is_deleted]
go

alter table dbo.item_sets_sub_items add constraint [DF_item_sets_sub_items_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.item_sets_sub_items add constraint [DF_item_sets_sub_items_row_guid] default(newid()) for[row_guid]
go

create table type_of_transfers
(
type_of_transfer_id	int	identity(1,1) not null,
transfer_type		nvarchar(200)	not null,
is_deleted			bit	not null,
created_by			int	not null,
created_by_ip		nvarchar(25) not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime	null,
deleted_by			int	null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime	null,
row_guid			uniqueidentifier	not null,
constraint [pk_type_of_transfers_type_of_transfer_id] primary key clustered
	(
		[type_of_transfer_id] ASC 
	)
) ON [PRIMARY]
GO

alter table dbo.type_of_transfers add constraint [DF_type_of_transfers_is_deleted] default(0) for[is_deleted]
go

alter table dbo.type_of_transfers add constraint [DF_type_of_transfers_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.type_of_transfers add constraint [DF_type_of_transfers_row_guid] default(newid()) for[row_guid]
go

insert into dbo.type_of_transfers
(transer_type, created_by, created_by_ip)
values
('Stock Transfer', 1, '::1'),
('Job Work', 1, '::1')

exec sp_rename 'pkg_slips.type_of_transfer', 'type_of_transfer_id','column'

alter table dbo.client_addressess alter column area nvarchar(50)
go

alter table purchase_bill_items
add 
type_of_discount nvarchar(25),
cash_discount_percent decimal(18,2),
discount_amount decimal(18,2)
go

alter table purchase_bills
add is_tax_round_off	bit
go

alter table purchase_bills add constraint [DF_purchase_bills_is_tax_round_off] default(0) for[is_tax_round_off]
go

alter table sales_bills_items
add goods_receipt_item_id int null,
rate_adjustment	nvarchar(5) null,
rate_adjustment_remarks nvarchar(500) null
go

CREATE TABLE sales_bills_delivery_details
(
sales_bill_delivery_id	int	identity(1,1)	not null,
sales_bill_id	int	not null,
transporter_id int not null,
lr_no	nvarchar(25) not null,
lr_date	date not null,
delivery_date date not null,
is_delivery_pending	bit not null,
is_deleted		bit not null,
created_by		int		not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int		null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [pk_sales_bills_delivery_details_sales_bill_delivery_id] primary key clustered
	(
		[sales_bill_delivery_id] ASC
	)	 
)ON [PRIMARY]
GO

alter table dbo.sales_bills_delivery_details add constraint [DF_sales_bills_delivery_details_is_delivery_pending] default(0) for[is_delivery_pending]
go

alter table dbo.sales_bills_delivery_details add constraint [DF_sales_bills_delivery_details_is_deleted] default(0) for[is_deleted]
go

alter table dbo.sales_bills_delivery_details add constraint [DF_sales_bills_delivery_details_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.sales_bills_delivery_details add constraint [DF_sales_bills_delivery_details_row_guid] default(newid()) for[row_guid]
go

create table sales_bills_payment_details
(
sales_bill_payment_id	int	identity(1,1)	not null,
sales_bill_id	int	not null,
payment_settelment_id	int not null,
mode_of_payment_id	int not null,
payment_reference_no	nvarchar(50) null,
remarks	nvarchar(500) null,
is_deleted		bit not null,
created_by		int		not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int		null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [pk_sales_bills_payment_details_sales_bill_payment_id] primary key clustered
	(
		[sales_bill_payment_id] ASC
	)	 
)ON [PRIMARY]
GO

alter table dbo.sales_bills_payment_details add constraint [DF_sales_bills_payment_details_is_deleted] default(0) for[is_deleted]
go

alter table dbo.sales_bills_payment_details add constraint [DF_sales_bills_payment_details_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.sales_bills_payment_details add constraint [DF_sales_bills_payment_details_row_guid] default(newid()) for[row_guid]
go

create table mode_of_payments
(
mode_of_payment_id	int	identity(1,1) not null,
mode_of_payment		nvarchar(25) not null,
is_deleted		bit not null,
created_by		int		not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int		null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [pk_mode_of_payments_mode_of_payment_id] primary key clustered
	(
		[mode_of_payment_id] ASC
	)	 
)ON [PRIMARY]
GO

alter table dbo.mode_of_payments add constraint [DF_mode_of_payemnts_is_deleted] default(0) for[is_deleted]
go

alter table dbo.mode_of_payments add constraint [DF_mode_of_payemnts_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.mode_of_payments add constraint [DF_mode_of_payemnts_row_guid] default(newid()) for[row_guid]
go

insert into dbo.mode_of_payments 
(mode_of_payment, is_deleted, created_by, created_by_ip)
values
('Cash', 0, 1, '::1'),
('Cheque', 0, 1, '::1'),
('Credit Card', 0, 1, '::1'),
('NEFT/RTGS', 0, 1, '::1'),
('Other', 0, 1, '::1')

create table payment_settlement
(
payment_settlement_id	int identity(1,1)	not null,
payment_settlement	nvarchar(25)	not null,
is_deleted		bit not null,
created_by		int		not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int		null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [pk_payment_settelment_payment_settlement_id] primary key clustered
	(
		[payment_settlement_id] ASC
	)	 
)ON [PRIMARY]
GO

alter table dbo.payment_settlement add constraint [DF_payment_settlement_is_deleted] default(0) for[is_deleted]
go

alter table dbo.payment_settlement add constraint [DF_payment_settlement_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.payment_settlement add constraint [DF_payment_settlement_row_guid] default(newid()) for[row_guid]
go

insert into dbo.payment_settlement
(payment_settlement, is_deleted, created_by, created_by_ip)
values
('Full Payment', 0, 1, '::1'),
('Part Payment', 0, 1, '::1')

create table charges
(
charge_id		int identity(1,1)	not null,
charge_name		nvarchar(200)	not null,
charge_desc		nvarchar(200)	not null,
gst_category_id	int	not null,
is_deleted		bit not null,
created_by		int		not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int		null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [pk_charges_charge_id] primary key clustered
	(
		[charge_id] ASC
	)	 
)ON [PRIMARY]
GO

alter table dbo.charges add constraint [DF_charges_is_deleted] default(0) for[is_deleted]
go

alter table dbo.charges add constraint [DF_charges_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.charges add constraint [DF_charges_row_guid] default(newid()) for[row_guid]
go

create table sales_bills_charges_details
(
sales_bill_charge_id	int identity(1,1)	not null,
sales_bill_id		int	 not null,
charge_id			int	 not null,
charge_amount		decimal(18,2)	not null,
is_tax_inclusive		bit not null
gst_rate_id			int		not null,
tax_id				int		not null,
remarks				nvarchar(500) null,
is_deleted		bit not null,
created_by		int		not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int		null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [pk_sales_bills_charges_details_sales_bill_charge_id] primary key clustered
	(
		[sales_bill_charge_id] ASC
	)	 
)ON [PRIMARY]
GO

alter table dbo.sales_bills_charges_details add constraint [DF_sales_bills_charges_details_is_deleted] default(0) for[is_deleted]
go

alter table dbo.sales_bills_charges_details add constraint [DF_sales_bills_charges_details_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.sales_bills_charges_details add constraint [DF_sales_bills_charges_details_row_guid] default(newid()) for[row_guid]
go

alter table dbo.sales_bills_charges_details add constraint [DF_sales_bills_charges_details_is_tax_inclusive] default(0) for[is_tax_inclusive]
go

create table sales_bills_items_charges_details
(
sales_bill_item_charge_id	int identity(1,1)	not null,
sales_bill_item_id		int	 not null,
charge_id			int	 not null,
charge_amount		decimal(18,2)	not null,
is_tax_inclusive		bit not null
gst_rate_id			int		not null,
tax_id				int		not null,
remarks				nvarchar(500) null,
is_deleted		bit not null,
created_by		int		not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int		null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [pk_sales_bills_items_charges_details_sales_bill_item_charge_id] primary key clustered
	(
		[sales_bill_item_charge_id] ASC
	)	 
)ON [PRIMARY]
GO

alter table dbo.sales_bills_items_charges_details add constraint [DF_sales_bills_items_charges_details_is_tax_inclusive] default(0) for[is_tax_inclusive]
go

alter table dbo.sales_bills_items_charges_details add constraint [DF_sales_bills_items_charges_details_is_deleted] default(0) for[is_deleted]
go

alter table dbo.sales_bills_items_charges_details add constraint [DF_sales_bills_items_charges_details_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.sales_bills_items_charges_details add constraint [DF_sales_bills_items_charges_details_row_guid] default(newid()) for[row_guid]
go

alter table dbo.sales_bills add remarks nvarchar(500) null
go

alter table dbo.sales_bills_delivery_details add remarks nvarchar(500) null
go

alter table dbo.sales_bills_items add remarks nvarchar(500) null
go

-- -- NEW CHANGES FROM 02/FEB/2018

alter table dbo.outward_goods_details add goods_receipt_item_id	int not null
go

create table inwards
(
inward_id			int		identity(1,1) not null,
inward_no			int		not null,
inward_date			date	not	null,
reference_id		int		not null,
from_location_id	int		not null,
to_location_id		int		not null,
reference_type		nvarchar(50) not null,
remarks				nvarchar(500) null,
is_deleted		bit not null,
created_by		int		not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int		null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [pk_inwards_inward_id] primary key clustered
	(
		[inward_id] ASC
	)	 
)ON [PRIMARY]
GO

alter table dbo.inwards add constraint [DF_inwards_is_deleted] default(0) for[is_deleted]
go

alter table dbo.inwards add constraint [DF_inwards_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.inwards add constraint [DF_inwards_row_guid] default(newid()) for[row_guid]
go

create table inward_goods_details
(
inward_goods_id			int	identity(1,1)	not null,
inward_id				int	not null,
goods_receipt_item_id	int	not null,
item_id					int null,
qty_in_pcs				decimal(18,2)	not null,
qty_in_mtrs				decimal(18,2)	not null,
inward_status			nvarchar(25)	not null,
remarks					nvarchar(500) null,
is_deleted		bit not null,
created_by		int		not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int		null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [pk_inward_goods_details_inward_goods_id] primary key clustered
	(
		[inward_goods_id] ASC
	)	 
)ON [PRIMARY]
GO

alter table dbo.inward_goods_details add constraint [DF_inward_goods_details_is_deleted] default(0) for[is_deleted]
go

alter table dbo.inward_goods_details add constraint [DF_inward_goods_details_created_datetime] default(getdate()) for[created_datetime]
go

alter table dbo.inward_goods_details add constraint [DF_inward_goods_details_row_guid] default(newid()) for[row_guid]
go


use pos_raheja_Dev
alter table outwards alter column truck_no nvarchar(25) null
go

-- POS STOCK DETAILS ENTRY FOR OLD STOCK OF NTC
-- use pos_raheja_live

--insert into dbo.purchase_bills
--(vendor_id, transporter_id, purchase_bill_no, challan_no, purchase_bill_date, truck_no, total_weight,
--branch_id, working_period_id, is_deleted, created_by, created_by_ip, created_datetime, row_guid,
--gst_applicable, is_tax_inclusive)

--SELECT
--	sd.vendor_id, 0 AS transporter_id, sd.lot_no AS  purchase_bill_no, sd.lot_no AS challan_no, 
--	sd.stock_date AS purchase_bill_date, null AS truck_no, 0 AS total_weight, 1 AS branch_id, 1 AS working_period_id,
--	0 AS  is_deleted, 1 AS created_by, '182.70.126.203' AS created_by_ip, GETDATE() AS created_datetime,
--	NEWID(), CASE WHEN s.state_code = 'MH' THEN 'SGST' ELSE 'IGST' END AS gst_applicable, 1 AS is_tax_inclusive
--FROM
--	dbo.stock_details sd
--INNER JOIN
--	dbo.client_addressess v ON sd.vendor_id = v.client_address_id
--INNER JOIN
--	dbo.states s ON v.state_id = s.state_id
--GROUP BY
--	sd.vendor_id,
--	sd.lot_no,
--	sd.stock_date,
--	s.state_code
--ORDER BY
--	sd.stock_date,
--	sd.lot_no


--	select * from dbo.purchase_bills p
--	where p.challan_no = 2269


--insert into dbo.purchase_bill_items
--(purchase_bill_id, item_id, bale_no, lr_no, purchase_qty_in_pcs, purchase_qty_in_mtrs, purchase_rate, gst_rate_id,
--tax_id, is_deleted, created_by, created_by_ip, created_datetime, row_guid)
--select  pb.purchase_bill_id, sd.item_id, sd.bale_no, sd.lot_no as lr_no, sd.received_qty_in_pcs, 
--sd.received_qty_in_mtrs, sd.purchase_rate, case when sd.purchase_rate <= 1000 then 5 else 6 end as gst_rate_id,
--1 as tax_id, 0 as is_deleted, 1 created_by, '182.70.126.203' as created_by_ip, getdate() as created_datetime, NEWID()
--from dbo.stock_details sd
--inner join dbo.purchase_bills pb ON sd.lot_no = pb.challan_no
--and sd.vendor_id = pb.vendor_id
----and sd.stock_date = pb.purchase_bill_date
----where pb.challan_no = '2240'
--group by 
--	pb.purchase_bill_id, sd.item_id, sd.bale_no, sd.received_qty_in_pcs, 
--sd.received_qty_in_mtrs, sd.purchase_rate, case when sd.purchase_rate <= 1000 then 5 else 6 end,
--sd.stock_date, sd.vendor_id, sd.lot_no
--order by purchase_bill_id, sd.stock_date, sd.vendor_id, sd.bale_no, sd.lot_no


--- INSERT RECORDS IN GOODS RECEIPT ITEMS
--insert into dbo.goods_receipts
--(purchase_bill_id, goods_receipt_no, goods_receipt_date, goods_received_location_id, branch_id, working_period_id,
--created_by, created_by_ip, created_datetime, row_guid)

--select pb.purchase_bill_id, ROW_NUMBER () OVER (ORDER by pb.purchase_bill_no) as goods_receipt_no,
--pb.purchase_bill_date, 3, 1, 1, 1, '182.70.126.203', GETDATE(), NEWID()
--from dbo.purchase_bills pb


--insert into dbo.goods_receipt_items
--(goods_receipt_id, purchase_bill_item_id, received_qty_in_pcs, received_qty_in_mtrs, is_deleted, created_by, created_by_ip,
--created_datetime, row_guid)
--select gr.goods_receipt_id, pbi.purchase_bill_item_id, pbi.purchase_qty_in_pcs, pbi.purchase_qty_in_mtrs,
--0, 1, '182.70.126.203', GETDATE(), NEWID() 
--from dbo.purchase_bill_items pbi
--inner join dbo.goods_receipts gr on pbi.purchase_bill_id = gr.purchase_bill_id


--insert into dbo.pkg_slips
--INSERT INTO dbo.pkg_slips
--(pkg_slip_no, pkg_slip_date, bale_no, working_period_id, is_deleted, created_by, created_by_ip, created_datetime,
--branch_id, from_location_id, type_of_transfer_id)
--SELECT ROW_NUMBER() OVER (ORDER BY gr.goods_receipt_date) AS pkg_slip_no, gr.goods_receipt_date,
--pbi.bale_no, 1 as working_period_id, 0 as is_deleted, 1 as created_by, '::1' as created_by_ip, 
--GETDATE(), 1 branch_id, 1 as from_location_id, 1 as type_of_transfer_id
--FROM dbo.goods_receipts gr
--INNER JOIN dbo.goods_receipt_items gri ON gr.goods_receipt_id = gri.goods_receipt_id
--INNER JOIN dbo.purchase_bill_items pbi ON gri.purchase_bill_item_id = pbi.purchase_bill_item_id
--GROUP BY pbi.bale_no, gr.goods_receipt_date
--ORDER BY gr.goods_receipt_date

--INSERT INTO dbo.pkg_slip_items
--(pkg_slip_id, item_id, pkg_qty_in_pcs, pkg_qty_in_mtrs, is_deleted, created_by, created_by_ip, goods_receipt_item_id)
--select ps.pkg_slip_id, pbi.item_id, gri.received_qty_in_pcs, gri.received_qty_in_mtrs,
--0 as is_deleted, 1 as created_by, '::1' as created_by_ip, gri.goods_receipt_item_id
--from dbo.pkg_slips ps
--inner join dbo.purchase_bill_items pbi ON ps.bale_no = pbi.bale_no
--inner join dbo.goods_receipt_items gri ON pbi.purchase_bill_item_id = gri.purchase_bill_item_id
--ORDER BY ps.pkg_slip_id

--INSERT INTO dbo.outwards
--(outward_no, outward_date, transporter_id, truck_no, branch_id, created_by, created_by_ip, working_period_id, location_id)
--select ROW_NUMBER() OVER (ORDER BY ps.pkg_slip_no) AS outward_no,
--ps.pkg_slip_date, 64 as transporter_id, null, 1, 1, '::1', 1, 3 as location_id
--from dbo.pkg_slips ps
--order by ps.pkg_slip_no

--INSERT INTO dbo.outward_goods_details
--(outward_id, pkg_slip_item_id, goods_receipt_item_id, created_by, created_by_ip)
--select o.outward_id, 
--psi.pkg_slip_item_id, psi.goods_receipt_item_id, 1, '::1'
--from dbo.pkg_slip_items psi
--inner join dbo.pkg_slips ps ON psi.pkg_slip_id = ps.pkg_slip_id
--inner join dbo.outwards o on ps.pkg_slip_no = o.outward_no





use POS_Raheja_Dev

alter table dbo.outward_goods_details add goods_receipt_item_id	int not null
go

alter table dbo.item_rates add is_sell_at_net_rate bit null
go

alter table dbo.inwards add working_period_id int null
go

alter table dbo.inwards
add transporter_id int null,
vehicle_no nvarchar(25) null
go

exec sp_rename 'outwards.truck_no', 'vehicle_no', 'column'



---- insert goods receipt details in inward details
--INSERT INTO dbo.inwards
--(inward_no, inward_date, reference_id, from_location_id, to_location_id,
--reference_type, remarks, is_deleted, created_by, created_by_ip, created_datetime,
--working_period_id, transporter_id, vehicle_no)
 
--select gr.goods_receipt_no, gr.goods_receipt_date, gr.goods_receipt_id,
--gr.goods_received_location_id, gr.goods_received_location_id, 'GOODS RECEIPT',
--'AUTO INSERT', 0, 1, '::1', GETDATE(), 1, 1, NULL
--from dbo.goods_receipts gr
--order by gr.goods_receipt_id




---- insert receipt items details against that goods receipt id with inward id
--insert into dbo.inward_goods_details
--(inward_id, goods_receipt_item_id, item_id, qty_in_pcs, qty_in_mtrs, inward_status,
--remarks, is_deleted, created_by, created_by_ip, created_datetime)
--select inw.inward_id, gri.goods_receipt_item_id, pbi.item_id, gri.received_qty_in_pcs,
--gri.received_qty_in_mtrs, 'P', 'AUTO', 0, 1, '::1', GETDATE()
--from dbo.goods_receipt_items gri
--inner join dbo.inwards inw ON gri.goods_receipt_id = inw.reference_id
--inner join dbo.purchase_bill_items pbi ON gri.purchase_bill_item_id = pbi.purchase_bill_item_id
--order by gri.goods_receipt_id



create table customer_transporter_mapping
(
mapping_id				int	identity(1,1) not null,
customer_address_id		int	not null,
transporter_address_id	int not null,
is_deleted				bit	not null,
created_by				int not null,
created_by_ip			nvarchar(25) not null,
created_datetime		datetime not null,
modified_by				int null,
modified_by_ip			nvarchar(25) null,
modified_datetime		datetime null,
deleted_by				int null,
deleted_by_ip			nvarchar(25) null,
deleted_datetime		datetime null,
row_guid				uniqueidentifier not null,
constraint [pk_customer_transporter_mapping_mapping_id] primary key clustered
	(
		[mapping_id] asc
	)
) ON [PRIMARY]
GO

alter table dbo.customer_transporter_mapping add constraint is_deleted default(0) for[is_deleted]
go

alter table dbo.customer_transporter_mapping add constraint created_datetime default(getdate()) for[created_datetime]
go

alter table dbo.customer_transporter_mapping add constraint row_guid default(newid()) for[row_guid]
go





use POS_Raheja_Live

DECLARE
	@stock_id			int = 122
	
DECLARE	
	@bale_no			nvarchar(10),
	@lot_no				nvarchar(10),
	@vendor_id			int,
	@item_id			int,
	@item_rate			decimal(18,2),
	@qty_in_pcs			decimal(18,2),
	@qty_in_mtrs		decimal(18,2),
	@stock_date			nvarchar(11),
	@goods_received_location_id int,
	@branch_id			int,
	@working_period_id	int,
	@created_by			int,
	@created_by_ip		nvarchar(25),
	@gst_applicable		nvarchar(5),	
	@purchase_bill_id	int,
	@purchase_bill_item_id	int,
	@goods_receipt_id		int,
	@goods_receipt_item_id	int,
	@inward_id				int,
	@inward_goods_id		int

-- -- Get the details from Stock details table
SELECT
	@vendor_id = sd.vendor_id,
	@bale_no = sd.bale_no,
	@lot_no = sd.lot_no,
	@item_id = sd.item_id,
	@item_rate = sd.purchase_rate,
	@qty_in_pcs = sd.received_qty_in_pcs,
	@qty_in_mtrs = sd.received_qty_in_mtrs,
	@stock_date = REPLACE(CONVERT(nvarchar(11), sd.stock_date, 106), ' ','/'),
	@branch_id	= sd.branch_id,
	@working_period_id = sd.working_period_id,
	@created_by = sd.created_by,
	@created_by_ip = sd.created_by_ip
FROM
	dbo.stock_details sd
WHERE
	sd.stock_id = @stock_id

-- -- Check vendor state and get GST applicable
SELECT
	@gst_applicable = CASE WHEN s.state_abbr = 'MH' THEN 'SGST' ELSE 'IGST' END
FROM
	dbo.client_addressess v
INNER JOIN
	dbo.states s ON v.state_id = s.state_id
WHERE
	v.client_address_id = @vendor_id

-- -- Check purchase bill id exist against the vendor and bale no
SELECT 
	@purchase_bill_id = pbi.purchase_bill_id
FROM
	dbo.purchase_bill_items pbi
INNER JOIN
	dbo.purchase_bills pb ON pbi.purchase_bill_id = pb.purchase_bill_id
WHERE
		pb.vendor_id = @vendor_id
	AND pbi.bale_no = @bale_no
GROUP BY
	pbi.purchase_bill_id

-- -- Get GST Rate Id
DECLARE
	@gst_rate_id int

EXEC @gst_rate_id = usp_gst_rate_id_get_by_item_id_gst_applicable_and_rate @item_id, @gst_applicable, @item_rate, @gst_rate_id

--select @gst_rate_id

-- -- If purchase bill id found
IF @purchase_bill_id > 0
	BEGIN

		DECLARE
			@is_item_id_exists bit = 0

		-- -- Check is item already exists
		SELECT
			@is_item_id_exists = 1
		FROM
			dbo.purchase_bill_items pbi
		WHERE
			pbi.item_id = @item_id

		IF @is_item_id_exists = 1
			BEGIN
				-- -- Update the item details in purchase bill item
				UPDATE
					pbi
				SET
					pbi.purchase_qty_in_pcs = sd.received_qty_in_pcs,
					pbi.purchase_qty_in_mtrs = sd.received_qty_in_mtrs
				FROM
					dbo.purchase_bill_items pbi
				INNER JOIN
					dbo.purchase_bills pb ON pbi.purchase_bill_id = pb.purchase_bill_id
				INNER JOIN
					dbo.stock_details sd ON pbi.bale_no = @bale_no AND pb.vendor_id = @vendor_id
				WHERE
					pbi.purchase_bill_id = @purchase_bill_id
					AND pbi.item_id = sd.item_id
					AND sd.stock_id = @stock_id
			END
		ELSE
			BEGIN
				
				-- -- Insert item details in purchase bill item
				exec @purchase_bill_id = usp_purchase_bills_insert_bill_details
					@purchase_bill_id, @vendor_id, @bale_no, @stock_date, 1,
					@bale_no, 1, 0, @gst_applicable, 1, 1, 1, '::1', @purchase_bill_id 

				IF @purchase_bill_id > 0
					BEGIN
						exec @purchase_bill_item_id = usp_purchase_bill_items_insert_bill_item
							@purchase_bill_item_id, @purchase_bill_id, @item_id,
							@bale_no, @lr_no, @qty_in_pcs, @qty_in_mtrs, @item_rate, null, 0, 0, @gst_rate_id, @tax_id,
							@created_by, @created_by_ip, @purchase_bill_item_id
					END
			END
	
		-- -- INSERT DETAILS FOR GOODS RECEIVED

		-- -- Check the purchase bill id exists in the Goods Receipt
		-- -- If exists then Get the Goods Receipt Id
		SELECT
			@goods_receipt_id = gr.goods_receipt_id
		FROM
			dbo.goods_receipts gr
		WHERE
			gr.purchase_bill_id = @purchase_bill_id
			
		IF @goods_receipt_id > 0
			BEGIN
				UPDATE
					gri
				SET
					gri.received_qty_in_pcs = @qty_in_cs,
					gri.received_qty_in_mtrs = @qty_in_mtrs
				FROM
					dbo.goods_receipt_items gri
				WHERE
					gri.goods_receipt_id = @goods_receipt_id
					AND gri.purchase_bill_item_id = @purchase_bill_item_id

			END
		ELSE
			BEGIN
				
				-- -- Insert Goods Received Details
				EXEC @goods_receipt_id = 
					usp_goods_receipts_insert_goods_receipt
						@goods_receipt_id,
						@purchase_bill_id,
						0,
						@stock_date,
						@goods_recived_location_id,
						@branch_id,
						@working_period_id,
						@created_by,
						@created_by_ip,
						@goods_receipt_id

				IF @goods_receipt_id > 0
					BEGIN
						
						-- -- Insert Goods Receipt Items
						EXEC @goods_receipt_item_id = 
							usp_goods_receipt_items_insert_goods_receipt_item
								0,
								@goods_receipt_id,
								@purchase_bill_item_id,
								@qty_in_pcs,
								@qty_in_mtrs,
								@created_by,
								@created_by_ip,
								@goods_receipt_item_id								
					END
			END
			
		-- -- INSERT DETAILS FOR INWARD DETAILS
		
		-- -- Check the goods receipt id exists in the Inward Details
		-- -- If exists then Get the Inward Id
		SELECT
			@inward_id = gr.goods_receipt_id
		FROM
			dbo.inwards i
		WHERE
			i.reference_id = @goods_receipt_id

		IF @inward_id > 0
			BEGIN
				UPDATE
					gri
				SET
					igd.qty_in_pcs = @qty_in_cs,
					igd.qty_in_mtrs = @qty_in_mtrs
				FROM
					dbo.inward_goods_details igd
				WHERE
						igd.inward_id = @inward_id
					AND igd.goods_receipt_item_id = @goods_receipt_item_id
					AND gri.item_id = @item_id

			END
		ELSE
			BEGIN
					
				-- -- Insert Inward Details
				EXEC @inward_goods_id = 
					usp_inwards_insert_inward_details
						@inward_id,
						0,
						@stock_date,
						@goods_receipt_id,
						@goods_received_location_id,
						@goods_received_location_id,
						'GOODS RECEIPT',
						0,
						NULL,
						'AUTO TRANSFER',						
						@working_period_id,
						@created_by,
						@created_by_ip,
						@inward_id

				IF @inward_id > 0
					BEGIN
						
						-- -- Insert Inward Goods Details
						EXEC @inward_goods_id = 
							usp_inward_goods_details_insert_inward_goods
								0,
								@inward_id,
								@goods_receipt_item_id,
								@item_id,
								@qty_in_pcs,
								@qty_in_mtrs,
								'P',
								NULL,
								@created_by,
								@created_by_ip,
								@inward_goods_id
					END
			END

	END

exec sp_rename 'tax_slabs.effective_date', 'effective_from_date', 'column'

alter table tax_slabs
add effective_to_date datetime
go

CREATE TABLE companies
(
company_id	int	identity(1,1)	not null,
company_name	nvarchar(200)	not null,
company_address	nvarchar(500)	not null,
country_id		int				not null,
state_id		int				not null,
city_id			int				not null,
website			nvarchar(200)	null,
gstin_no		nvarchar(25)	null,
is_deleted		bit				not null,
created_by		int				not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int			null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int			null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [companies_pk_company_id] primary key clustered
	([company_id] ASC)
) ON [PRIMARY]
GO

alter table companies add constraint [DF_companies_is_deleted] default(0) for[is_deleted]
go

alter table companies add constraint [DF_companies_created_datetime] default(getdate()) for[created_datetime]
go

alter table companies add constraint [DF_companies_row_guid] default(newid()) for[row_guid]
go


CREATE TABLE item_pictures
(
item_picture_id		int	identity(1,1)	not null,
item_id				int	not null,
item_picture_name	nvarchar(200)	not null,
item_picture_path	nvarchar(500)	not null,
is_deleted		bit				not null,
created_by		int				not null,
created_by_ip	nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int			null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime		null,
deleted_by			int			null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime		null,
row_guid			uniqueidentifier	not null,
constraint [item_pictures_pk_item_picture_id] primary key clustered
	([item_picture_id] ASC)
) ON [PRIMARY]
GO

alter table item_pictures add constraint [DF_item_pictures_is_deleted] default(0) for[is_deleted]
go

alter table item_pictures add constraint [DF_item_pictures_created_datetime] default(getdate()) for[created_datetime]
go

alter table item_pictures add constraint [DF_item_pictures_row_guid] default(newid()) for[row_guid]
go

--- change in qty logic 29/0/2018 15:56


alter table purchase_bill_items
add purchase_qty decimal(18,2)	null,
unit_of_measurement_id	int null
go


update dbo.purchase_bill_items set qty = 1, unit_of_measurement_id = 8 where purchase_bill_item_id in (390, 982)

update dbo.purchase_bill_items SET qty = purchase_qty_in_pcs, unit_of_measurement_id = 8 where purchase_qty_in_pcs > 0

alter table purchase_bill_items alter column qty decimal(18,2)	 not null
go
alter table purchase_bill_items alter column unit_of_measurement_id	int not null
go

update dbo.purchase_bill_items SET qty = purchase_qty_in_mtrs, unit_of_measurement_id = 1 where purchase_bill_item_id = 1246


-- -- query for stock in transit
select
	v.client_address_name as vendor_name, 	
	CASE WHEN iq.item_quality = 'NONE' THEN '' ELSE iq.item_quality + ' ' END + i.item_name as item_name,	
	pb.purchase_bill_no, pb.purchase_bill_date, pbi.bale_no, pbi.lr_no, 
	--pbi.purchase_bill_item_id, 
	pbi.purchase_qty_in_pcs	
from
	dbo.purchase_bill_items pbi
INNER JOIN dbo.purchase_bills pb ON pbi.purchase_bill_id = pb.purchase_bill_id
INNER JOIN dbo.items i ON pbi.item_id = i.item_id
INNER JOIN dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
INNER JOIN dbo.client_addressess v ON pb.vendor_id = v.client_address_id
where 
pbi.is_deleted = 0
AND pbi.purchase_qty_in_pcs > 0
and pb.purchase_bill_date >= '01/Apr/2018'
and NOT pb.purchase_bill_id in (SELECT gr.purchase_bill_id from goods_receipts gr)
--and pbi.purchase_qty_in_pcs <> ISNULL(gri.received_qty_in_pcs,0) 
order by pbi.created_datetime desc

---- short receipts

--select
--	dbo.udf_items_get_item_name_by_brand_category_and_quality(i.item_id) as item_name,
--	v.client_address_name as vendor_name, 
--	pbi.bale_no, pbi.lr_no, pb.purchase_bill_no, pb.purchase_bill_date, pbi.purchase_bill_item_id, pbi.purchase_qty_in_pcs,
--	isnull(gri.received_qty_in_pcs,0) as  goods_received_qty_in_pcs,
--	pbi.purchase_qty_in_pcs - ISNULL(gri.received_qty_in_pcs,0) as Differnce
--from
--	dbo.purchase_bill_items pbi
--INNER JOIN dbo.purchase_bills pb ON pbi.purchase_bill_id = pb.purchase_bill_id
--INNER JOIN dbo.client_addressess v ON pb.vendor_id = v.client_address_id
--inner join dbo.items i ON pbi.item_id = i.item_id
--left join dbo.goods_receipt_items gri ON pbi.purchase_bill_item_id = gri.purchase_bill_item_id
--where 
--pbi.is_deleted = 0
--and pb.purchase_bill_date >= '01/Apr/2018'
----and pbi.purchase_qty_in_pcs <> ISNULL(gri.received_qty_in_pcs,0) 
--order by pbi.created_datetime desc



-- -- query for stock in transit
select
	v.client_address_name as vendor_name, 	
	CASE WHEN iq.item_quality = 'NONE' THEN '' ELSE iq.item_quality + ' ' END + i.item_name as item_name,	
	pb.purchase_bill_no, pb.purchase_bill_date, SUBSTRING(t.client_address_name, 0, 11) as transporter_name, pbi.lr_no, 
	--pbi.purchase_bill_id, pbi.purchase_bill_item_id, 
	pbi.purchase_qty, pbi.purchase_rate, (pbi.purchase_qty * pbi.purchase_rate) as total_amount
from
	dbo.purchase_bill_items pbi
INNER JOIN dbo.purchase_bills pb ON pbi.purchase_bill_id = pb.purchase_bill_id
INNER JOIN dbo.items i ON pbi.item_id = i.item_id
INNER JOIN dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
INNER JOIN dbo.client_addressess v ON pb.vendor_id = v.client_address_id
inner join dbo.client_addressess t ON pb.transporter_id = t.client_address_id
where 
pbi.is_deleted = 0
AND pbi.purchase_qty > 0
--and pb.purchase_bill_date >= '01/Apr/2018'
and NOT pb.purchase_bill_id in (SELECT gr.purchase_bill_id from goods_receipts gr)
--and pbi.purchase_qty_in_pcs <> ISNULL(gri.received_qty_in_pcs,0) 
order by pbi.created_datetime desc

---- short receipts

--select
--	dbo.udf_items_get_item_name_by_brand_category_and_quality(i.item_id) as item_name,
--	v.client_address_name as vendor_name, 
--	pbi.bale_no, pbi.lr_no, pb.purchase_bill_no, pb.purchase_bill_date, pbi.purchase_bill_item_id, pbi.purchase_qty_in_pcs,
--	isnull(gri.received_qty_in_pcs,0) as  goods_received_qty_in_pcs,
--	pbi.purchase_qty_in_pcs - ISNULL(gri.received_qty_in_pcs,0) as Differnce
--from
--	dbo.purchase_bill_items pbi
--INNER JOIN dbo.purchase_bills pb ON pbi.purchase_bill_id = pb.purchase_bill_id
--INNER JOIN dbo.client_addressess v ON pb.vendor_id = v.client_address_id
--inner join dbo.items i ON pbi.item_id = i.item_id
--left join dbo.goods_receipt_items gri ON pbi.purchase_bill_item_id = gri.purchase_bill_item_id
--where 
--pbi.is_deleted = 0
--and pb.purchase_bill_date >= '01/Apr/2018'
----and pbi.purchase_qty_in_pcs <> ISNULL(gri.received_qty_in_pcs,0) 
--order by pbi.created_datetime desc

create table sales_return_bills
(
sales_return_bill_id	int	identity(1,1) not null,
sales_bill_id			int	not null,
sales_return_bill_no	int	not null,
sales_return_bill_date	date not null,
is_deleted				bit not null,
row_guid				uniqueidentifier not null,
created_by				int not null,
created_by_ip			nvarchar(5) not null,
created_datetime		datetime not null,
modified_by				int null,
modified_by_ip			nvarchar(5) null,
modified_datetime		datetime null,
deleted_by				int null,
deleted_by_ip			nvarchar(5) null,
deleted_datetime		datetime null,
constraint [pk_sales_return_bills_sales_return_bill_id] primary key clustered	
	(
		[sales_return_bill_id]
	)
)
GO

alter table sales_return_bills add constraint [DF_sales_return_bills_is_deleted] default(0) for[is_deleted]
go

alter table sales_return_bills add constraint [DF_sales_return_bills_created_datetime] default(getdate()) for[created_datetime]
go

alter table sales_return_bills add constraint [DF_sales_return_bills_row_guid] default(newid()) for[row_guid]
go

create table sales_return_bill_items
(
sales_return_bill_item_id	int not null,
sales_return_bill_id		int not null,
sales_bill_item_id			int not null,
return_qty					decimal(18,2) not null,
is_deleted					bit not null,
row_guid					uniqueidentifier not null,
created_by					int not null,
created_by_ip				nvarchar(5) not null,
created_datetime			datetime not null,
modified_by					int null,
modified_by_ip				nvarchar(5) null,
modified_datetime			datetime null,
deleted_by					int null,
deleted_by_ip				nvarchar(5) null,
deleted_datetime			datetime null,
constraint [pk_sales_return_bill_items_sales_return_bill_item_id] primary key clustered	
	(
		[sales_return_bill_item_id]
	)
)
GO

alter table sales_return_bill_items add constraint [DF_sales_return_bill_items_is_deleted] default(0) for[is_deleted]
go

alter table sales_return_bill_items add constraint [DF_sales_return_bill_items_created_datetime] default(getdate()) for[created_datetime]
go

alter table sales_return_bill_items add constraint [DF_sales_return_bill_items_row_guid] default(newid()) for[row_guid]
go


alter table goods_receipt_items
add received_qty decimal(18,2)	null,
unit_of_measurement_id	int null
go

alter table inward_goods_details
add inward_qty decimal(18,2)	null,
unit_of_measurement_id	int null
go

alter table pkg_slip_items
add pkg_qty decimal(18,2)	null,
unit_of_measurement_id	int null
go

alter table sales_bills_items
add sale_qty decimal(18,2)	null,
unit_of_measurement_id	int null
go

select * from dbo.goods_receipt_items gri where gri.received_qty is null

update dbo.goods_receipt_items set received_qty = received_qty_in_pcs, unit_of_measurement_id = 8 where received_qty_in_pcs > 0

update dbo.goods_receipt_items set received_qty = received_qty_in_mtrs, unit_of_measurement_id = 1 where received_qty_in_mtrs > 0

update dbo.goods_receipt_items set received_qty = received_qty_in_pcs, unit_of_measurement_id = 8 where received_qty IS null

select * from dbo.inward_goods_details igd where igd.qty_in_mtrs > 0

update dbo.inward_goods_details set inward_qty = qty_in_pcs, unit_of_measurement_id = 8 where qty_in_pcs > 0

update dbo.inward_goods_details set inward_qty = qty_in_mtrs, unit_of_measurement_id = 1 where qty_in_mtrs > 0

update dbo.inward_goods_details set inward_qty = 0, unit_of_measurement_id = 8 where inward_qty IS null

select * from dbo.pkg_slip_items psi where psi.pkg_qty_in_pcs  > 0

update dbo.pkg_slip_items set pkg_qty = pkg_qty_in_pcs, unit_of_measurement_id = 8 where pkg_qty_in_pcs > 0

update dbo.pkg_slip_items set pkg_qty = pkg_qty_in_mtrs, unit_of_measurement_id = 1 where pkg_qty_in_mtrs > 0

update dbo.pkg_slip_items set pkg_qty = 0, unit_of_measurement_id = 8 where pkg_qty IS null

select * from dbo.sales_bills_items sbi where sbi.item_qty_in_pcs > 0

update dbo.sales_bills_items set sale_qty = item_qty_in_pcs, unit_of_measurement_id = 8 where item_qty_in_pcs > 0

update dbo.sales_bills_items set sale_qty = item_qty_in_pcs, unit_of_measurement_id = 1 where item_qty_in_mtrs > 0

update dbo.sales_bills_items set sale_qty = 0, unit_of_measurement_id = 8 where sale_qty IS null

alter table goods_receipt_items alter column received_qty decimal(18,2)	 not null
go

alter table goods_receipt_items alter column unit_of_measurement_id int not null
go

alter table inward_goods_details alter column inward_qty decimal(18,2)	 not null
go

alter table inward_goods_details alter column unit_of_measurement_id int not null
go

alter table pkg_slip_items alter column pkg_qty decimal(18,2)	 not null
go

alter table pkg_slip_items alter column unit_of_measurement_id int not null
go

alter table sales_bills_items alter column sale_qty decimal(18,2)	 not null
go

alter table sales_bills_items alter column unit_of_measurement_id int not null
go

alter table dbo.purchase_bill_items drop column purchase_qty_in_pcs
go
alter table dbo.purchase_bill_items drop column purchase_qty_in_mtrs
go

alter table dbo.goods_receipt_items drop column received_qty_in_pcs
go
alter table dbo.goods_receipt_items drop column received_qty_in_mtrs
go

alter table dbo.inward_goods_details drop column qty_in_pcs
go
alter table dbo.inward_goods_details drop column qty_in_mtrs
go

alter table dbo.pkg_slip_items drop column pkg_qty_in_pcs
go
alter table dbo.pkg_slip_items drop column pkg_qty_in_mtrs
go

alter table dbo.sales_bills_items drop column item_qty_in_pcs
go
alter table dbo.sales_bills_items drop column item_qty_in_mtrs
go

alter table sales_return_bills
add branch_id int,
working_period_id int
go

alter table purchase_bills
add is_composition_bill bit null,
is_sample bit null
go

insert into dbo.menus
(menu_group_id, menu_name, page_link, menu_sequence, created_by, created_by_ip)
values
(5, 'Purchase Bill Register', 'MIS/PurchaseBillRegister', 2, 1, '::1')

select * from dbo.role_permissions

insert into dbo.role_permissions
(role_id, menu_group_id, menu_id, add_permission, view_permission, edit_permission, delete_permission, created_by, created_by_ip)
values
(1, 5, 27, 1, 1, 1, 1, 1, '::1')


SELECT
	sbi.item_id,
	iq.item_quality + ' ' + i.item_name AS item_name,
	gstc.hsn_code,
	sbi.unit_of_measurement_id,
	uom.unit_code,
	SUM(ISNULL(sbi.sale_qty,0)) - SUM(ISNULL(srbi.return_qty,0)) AS balance_qty,
	sbi.type_of_discount,
	sbi.cash_discount_percent,
	sbi.gst_rate_id,
	gstr.gst_rate,
	sbi.tax_id,
	gstr.gst_name,		
	sbi.sales_bill_item_id,
	sbi.goods_receipt_item_id
FROM
	dbo.sales_bills_items sbi
INNER JOIN
	dbo.sales_bills sb ON sbi.sales_bill_id = sb.sales_bill_id
INNER JOIN
	dbo.items i ON sbi.item_id = i.item_id
INNER JOIN
	dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
INNER JOIN
	dbo.units_of_measurements uom ON sbi.unit_of_measurement_id = uom.unit_of_measurement_id
INNER JOIN
	dbo.item_categories ic ON i.item_category_id = ic.item_category_id
INNER JOIN
	dbo.gst_categories gstc ON ic.gst_category_id = gstc.gst_category_id
INNER JOIN
	dbo.gst_rates gstr ON sbi.gst_rate_id = gstr.gst_rate_id
LEFT JOIN
	dbo.sales_return_bill_items srbi ON sbi.item_id = srbi.item_id
WHERE
	sb.consignee_id = 131
GROUP BY
	sbi.item_id,
	iq.item_quality,
	i.item_name,
	gstc.hsn_code,
	sbi.unit_of_measurement_id,
	uom.unit_code,
	sbi.type_of_discount,
	sbi.cash_discount_percent,
	sbi.gst_rate_id,
	gstr.gst_rate,
	sbi.tax_id,
	gstr.gst_name,		
	sbi.sales_bill_item_id,
	sbi.goods_receipt_item_id
HAVING
	SUM(ISNULL(sbi.sale_qty,0)) - SUM(ISNULL(srbi.return_qty,0)) > 0
	 
	
UNION

SELECT
	i.item_id,
	iq.item_quality + ' ' + i.item_name AS item_name,
	gstc.hsn_code,
	i.unit_of_measurement_id,
	uom.unit_code,
	0 AS balance_qty,
	NULL AS type_of_discount,
	0 AS cash_discount_percent,
	0 AS gst_rate_id,
	0 AS gst_rate,
	0 AS tax_id,
	'' AS gst_name,
	0 AS sales_bill_item_id,
	0 AS goods_receipt_item_id
FROM
	dbo.items i
INNER JOIN
	dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
INNER JOIN
	dbo.units_of_measurements uom ON i.unit_of_measurement_id = uom.unit_of_measurement_id
INNER JOIN
	dbo.item_categories ic ON i.item_category_id = ic.item_category_id
INNER JOIN
	dbo.gst_categories gstc ON ic.gst_category_id = gstc.gst_category_id
WHERE
		i.is_deleted = 0
	AND NOT i.item_id in (SELECT pbi.item_id FROM dbo.purchase_bill_items pbi WHERE pbi.is_deleted = 0 GROUP BY pbi.item_id)	
ORDER BY
	item_id


----------------------------- x------------------------------x --------------------------

-- --changes after 07/07/2018

 alter table sales_return_bills
 add consignee_id int null
 go

alter table sales_return_bills drop column sales_bill_id
go

alter table sales_return_bill_items drop column sales_bill_id
go

 alter table sales_return_bill_items
 add 
sale_rate			decimal(18,2) not null,
type_of_discount	nvarchar(25) null,
cash_discount_percent decimal(18,2) null,
discount_amount	decimal(18,2) null,
unit_of_measurement_id	int not null,
 is_tax_inclusive bit not null,
 gst_rate_id int null,
 tax_id	int null,
 item_remarks nvarchar(500) null
 go

alter table sales_return_bill_items
 add
 sales_bill_id int null
go

alter table sales_return_bill_items add constraint [DF_sales_return_bill_items_is_tax_inclusive] default(1) for[is_tax_inclusive]
go

alter table sales_return_bills
add sale_type_id int
go

create table sales_return_bill_adjustment
	(
		sales_return_bill_adjustment_id	int	identity(1,1) not null,
		sales_return_bill_id	int not null,
		sales_bill_id			int not null,
		created_by				int not null,
		created_by_ip			nvarchar(25) not null,
		created_datetime		datetime not null,
		row_guid				uniqueidentifier not null,
		constraint [pk_sales_return_bill_adjustment_sales_return_bill_adjustment_id] primary key clustered
			(
				[sales_return_bill_adjustment_id]
			) ON [PRIMARY]
	)
	go

	alter table sales_return_bill_adjustment add constraint [DF_sales_return_bill_adjustment_row_guid] default(NEWID()) for[row_guid]
	go

	alter table sales_return_bill_adjustment add constraint [DF_sales_return_bill_adjustment_created_datetime] default(GETDATE()) for[created_datetime]
	go

------- 28 07 2018 ------

create table location_types(
location_type_id	int	identity(1,1)	not null,
location_type		nvarchar(25)	not null,
is_deleted			bit	not null,
created_by			int		not null,
created_by_ip		nvarchar(25)	not null,
created_datetime	datetime	not null,
modified_by			int	null,
modified_by_ip		nvarchar(25)	null,
modified_datetime	datetime	null,
deleted_by			int null,
deleted_by_ip		nvarchar(25)	null,
deleted_datetime	datetime	null,
row_guid			uniqueidentifier	not null,
constraint [pk_location_types_location_type_id] primary key clustered
	(
		[location_type_id] ASC 
	)
) on [PRIMARY]
GO

ALTER TABLE dbo.location_types ADD CONSTRAINT [DF_location_types_is_deleted] DEFAULT(0) FOR[is_deleted]
GO

ALTER TABLE dbo.location_types ADD CONSTRAINT [DF_location_types_created_datetime] DEFAULT(GETDATE()) FOR[created_datetime]
GO

ALTER TABLE dbo.location_types ADD CONSTRAINT [DF_location_types_row_guid] DEFAULT(NEWID()) FOR[row_guid]
GO

alter table dbo.location_types alter column deleted_by bit null
go

ALTER TABLE dbo.locations
ADD location_type_id	int not null
go

INSERT INTO dbo.location_types
(location_type, created_by, created_by_ip)
values
('Store', 1, '::1'),
('Godown', 1, '::1')

select * from dbo.location_types

select * from dbo.locations


INSERT INTO dbo.locations
(location_type_id, location_name, location_address, city_id, location_area, contact_person, contact_nos, created_by, created_by_ip)
VALUES
(1, 'GOPAL GALLI A', 'MM MARKET', 1, 'MUMBAI', 'BANSI', NULL, 1, '::1'),
(1, 'GOPAL GALLI B', 'MM MARKET', 1, 'MUMBAI', 'BANSI', NULL, 1, '::1'),
(1, 'MANGALDAS MARKET', 'MM MARKET', 1, 'MUMBAI', 'BANSI', NULL, 1, '::1'),
(2, 'N.T.C.', 'BHIWANDI', 1, 'BHIWANDI', 'MANAGER', NULL, 1, '::1')

select * from dbo.pkg_slips

ALTER TABLE dbo.pkg_slips
ADD
purchase_bill_id	int,
to_location_id		int
GO

SELECT pb.purchase_bill_id, ps.bale_no
FROM dbo.pkg_slips ps
INNER JOIN dbo.purchase_bill_items pbi ON ps.bale_no = pbi.bale_no AND pbi.is_deleted = 0
INNER JOIN dbo.purchase_bills pb ON pbi.purchase_bill_id = pb.purchase_bill_id AND pb.is_deleted = 0
GROUP by pb.purchase_bill_id, ps.bale_no


UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '1918'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '1919'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '1988'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '1989'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '85411303'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541304'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541304A'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541321'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541321A'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541322'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541322A'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541323'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541323A'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541324'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541324A'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541327'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541327A'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541334'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541334A'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541335'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8541335A'
UPDATE dbo.pkg_slips SET vendor_id = 27		where bale_no = '8543807'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '083806'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1035'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1036'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1037'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1038'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1039'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1121'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1122'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1131'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1132'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1135'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1136'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1194'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1195'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1196'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1197'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1198'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1256'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1257'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1258'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1259'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1260'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1279'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1280'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1281'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1971'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '1994'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '230 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '231 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '2430'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '2431'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '2432'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '2433'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '2434'
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '358 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '359 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '378 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '379 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '386 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '416 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '428 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '453 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '454 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '459 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '460 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '461 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '462 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '605 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '612 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '615 '
UPDATE dbo.pkg_slips SET vendor_id = 29		where bale_no = '962 '
UPDATE dbo.pkg_slips SET vendor_id = 30		where bale_no = '1829'
UPDATE dbo.pkg_slips SET vendor_id = 30		where bale_no = '1830'
UPDATE dbo.pkg_slips SET vendor_id = 30		where bale_no = '1947'
UPDATE dbo.pkg_slips SET vendor_id = 30		where bale_no = '1948'
UPDATE dbo.pkg_slips SET vendor_id = 30		where bale_no = '1949'
UPDATE dbo.pkg_slips SET vendor_id = 30		where bale_no = '1950'
UPDATE dbo.pkg_slips SET vendor_id = 30		where bale_no = '1951'
UPDATE dbo.pkg_slips SET vendor_id = 30		where bale_no = '1952'
UPDATE dbo.pkg_slips SET vendor_id = 30		where bale_no = '1953'
UPDATE dbo.pkg_slips SET vendor_id = 30		where bale_no = '1954'
UPDATE dbo.pkg_slips SET vendor_id = 31		where bale_no = '2269'
UPDATE dbo.pkg_slips SET vendor_id = 32		where bale_no = '2268'
UPDATE dbo.pkg_slips SET vendor_id = 32		where bale_no = '2269'
UPDATE dbo.pkg_slips SET vendor_id = 32		where bale_no = '2270'
UPDATE dbo.pkg_slips SET vendor_id = 32		where bale_no = '2272'
UPDATE dbo.pkg_slips SET vendor_id = 33		where bale_no = '31	 '
UPDATE dbo.pkg_slips SET vendor_id = 34		where bale_no = '3112'
UPDATE dbo.pkg_slips SET vendor_id = 35		where bale_no = '2009'
UPDATE dbo.pkg_slips SET vendor_id = 35		where bale_no = '288 '
UPDATE dbo.pkg_slips SET vendor_id = 35		where bale_no = '289 '
UPDATE dbo.pkg_slips SET vendor_id = 35		where bale_no = '291 '
UPDATE dbo.pkg_slips SET vendor_id = 37		where bale_no = '2023'
UPDATE dbo.pkg_slips SET vendor_id = 37		where bale_no = '2038'
UPDATE dbo.pkg_slips SET vendor_id = 37		where bale_no = '2039'
UPDATE dbo.pkg_slips SET vendor_id = 37		where bale_no = '2048'
UPDATE dbo.pkg_slips SET vendor_id = 37		where bale_no = '2049'
UPDATE dbo.pkg_slips SET vendor_id = 38		where bale_no = '136/164037B'
UPDATE dbo.pkg_slips SET vendor_id = 39		where bale_no = '2030'
UPDATE dbo.pkg_slips SET vendor_id = 39		where bale_no = '2034'
UPDATE dbo.pkg_slips SET vendor_id = 40		where bale_no = '243/10270090'
UPDATE dbo.pkg_slips SET vendor_id = 40		where bale_no = '24310270090'
UPDATE dbo.pkg_slips SET vendor_id = 41		where bale_no = '2041'
UPDATE dbo.pkg_slips SET vendor_id = 42		where bale_no = '2042'
UPDATE dbo.pkg_slips SET vendor_id = 42		where bale_no = '2043'
UPDATE dbo.pkg_slips SET vendor_id = 42		where bale_no = '2044'
UPDATE dbo.pkg_slips SET vendor_id = 42		where bale_no = '2045'
UPDATE dbo.pkg_slips SET vendor_id = 49		where bale_no = '1260'
UPDATE dbo.pkg_slips SET vendor_id = 151	where bale_no = '2430'


update dbo.goods_receipts set goods_received_location_id = 1 where goods_received_location_id = 1

update dbo.goods_receipts set goods_received_location_id = 3 where goods_received_location_id = 2

update dbo.goods_receipts set goods_received_location_id = 4 where goods_received_location_id = 3

update dbo.inwards set from_location_id = 1 where from_location_id = 1
update dbo.inwards set from_location_id = 3 where from_location_id = 2
update dbo.inwards set from_location_id = 4 where from_location_id = 3

update dbo.inwards set to_location_id = 1 where to_location_id = 1
update dbo.inwards set to_location_id = 3 where to_location_id = 2
update dbo.inwards set to_location_id = 4 where to_location_id = 3

update dbo.pkg_slips set from_location_id = 1 where from_location_id = 1
update dbo.pkg_slips set from_location_id = 3 where from_location_id = 2
update dbo.pkg_slips set from_location_id = 4 where from_location_id = 3

--- WEEKLY SALES
SELECT
	SUM(dbo.udf_sales_bills_get_total_taxable_amount(sb.sales_bill_id)) taxable_amount,
	SUM(dbo.udf_sales_bills_get_total_gst_amount(sb.sales_bill_id)) gst_amount,
	SUM(dbo.udf_sales_bills_get_total_amount(sb.sales_bill_id)) total_amount
FROM dbo.sales_bills sb
WHERE DATEPART(DW, sb.sales_bill_date) = DATEPART(DW, CONVERT(DATE, GETDATE()))
AND sb.is_deleted = 0

--- TOP ITEM SALES
SELECT
	vwsisqpi.item_id, vwsisqpi.item_name, SUM(vwsisqpi.sale_qty), vwsisqpi.unit_code
FROM
	dbo.vw_sale_item_sum_qty_per_item vwsisqpi
GROUP BY
	vwsisqpi.item_id, vwsisqpi.item_name, vwsisqpi.unit_code
HAVING
	SUM(vwsisqpi.sale_qty) > 100
ORDER BY
	SUM(vwsisqpi.sale_qty) DESC


alter table dbo.inwards
add branch_id int null
go

update dbo.inwards set branch_id = 1

alter table dbo.inwards
add branch_id int not null
go

alter table dbo.purchase_bill_items
add gst_amount_as_per_vendor_bill decimal(18,2) null
go

alter table dbo.purchase_bills
add total_gst_amount_as_per_vendor_bill decimal(18,2) null
go


-------  CHANGES DONE ON AND AFTER 27/AUG/2018 --------




use POS_Raheja_Live

--- sum of item qty
SELECT
	ic.item_category_id,
	ic.item_category_name,
	SUM(sbi.sale_qty) AS sale_qty,
	uom.unit_code	
FROM
	dbo.sales_bills_items AS sbi
INNER JOIN
	dbo.items i ON sbi.item_id = i.item_id
INNER JOIN
	dbo.item_categories ic ON i.item_category_id = ic.item_category_id
INNER JOIN
	dbo.units_of_measurements AS uom ON sbi.unit_of_measurement_id = uom.unit_of_measurement_id
WHERE
	(sbi.is_deleted = 0)
	AND ic.item_category_id = 29
GROUP BY
	ic.item_category_id,
	ic.item_category_name,
	uom.unit_code
ORDER BY
	ic.item_category_name


--- Get sum of sale qty as per item_categories
SELECT
	ic.item_category_id,
	ic.item_category_name,
	UPPER(CONVERT(nvarchar(3), DATENAME(M,sb.sales_bill_date))) month_name,
	st.sale_type,
	SUM(sbi.sale_qty) AS sale_qty,
	uom.unit_code	
FROM
	dbo.sales_bills_items AS sbi
INNER JOIN
	dbo.sales_bills sb ON sbi.sales_bill_id = sb.sales_bill_id AND sb.is_deleted = 0
INNER JOIN
	dbo.sale_types st ON sb.sale_type_id = st.sale_type_id
INNER JOIN
	dbo.items i ON sbi.item_id = i.item_id
INNER JOIN
	dbo.item_categories ic ON i.item_category_id = ic.item_category_id
INNER JOIN
	dbo.units_of_measurements AS uom ON sbi.unit_of_measurement_id = uom.unit_of_measurement_id
WHERE
	(sbi.is_deleted = 0)
	AND ic.item_category_id = 29
GROUP BY
	ic.item_category_id,
	ic.item_category_name,
	uom.unit_code,
	CONVERT(nvarchar(3), DATENAME(M,sb.sales_bill_date)),
	st.sale_type,
	DATEPART(MM,sb.sales_bill_date)
ORDER BY
	ic.item_category_name,
	DATEPART(MM,sb.sales_bill_date)


--- Get sum of sale qty as per item_categories and branch wise
SELECT
	c.company_name,	
	b.branch_name,
	st.sale_type,
	UPPER(CONVERT(nvarchar(3), DATENAME(M,sb.sales_bill_date))) month_name,
	ic.item_category_id,
	ic.item_category_name,	
	SUM(sbi.sale_qty) AS sale_qty,
	uom.unit_code	
FROM
	dbo.sales_bills_items AS sbi
INNER JOIN
	dbo.sales_bills sb ON sbi.sales_bill_id = sb.sales_bill_id AND sb.is_deleted = 0
INNER JOIN
	dbo.sale_types st ON sb.sale_type_id = st.sale_type_id	
INNER JOIN
	dbo.items i ON sbi.item_id = i.item_id
INNER JOIN
	dbo.item_categories ic ON i.item_category_id = ic.item_category_id
INNER JOIN
	dbo.units_of_measurements AS uom ON sbi.unit_of_measurement_id = uom.unit_of_measurement_id
INNER JOIN
	dbo.branches b ON sb.branch_id = b.branch_id
INNER JOIN
	dbo.companies c ON b.company_id = c.company_id
WHERE
	(sbi.is_deleted = 0)
	AND ic.item_category_id = 29
GROUP BY
	c.company_name,	
	b.branch_name,	
	st.sale_type,
	DATEPART(MM,sb.sales_bill_date),
	ic.item_category_id,
	ic.item_category_name,
	uom.unit_code,
	CONVERT(nvarchar(3), DATENAME(M,sb.sales_bill_date))	
ORDER BY
	c.company_name,	
	b.branch_name,	
	DATEPART(MM,sb.sales_bill_date),	
	ic.item_category_name



--- Get sum of sale qty as per item_categories and branch wise
SELECT
	c.company_name,	
	b.branch_name,
	st.sale_type,
	UPPER(CONVERT(nvarchar(3), DATENAME(M,sb.sales_bill_date))) month_name,
	ic.item_category_id,
	ic.item_category_name,
	iq.item_quality,
	i.item_name,
	SUM(sbi.sale_qty) AS sale_qty,
	uom.unit_code	
FROM
	dbo.sales_bills_items AS sbi
INNER JOIN
	dbo.sales_bills sb ON sbi.sales_bill_id = sb.sales_bill_id AND sb.is_deleted = 0
INNER JOIN
	dbo.sale_types st ON sb.sale_type_id = st.sale_type_id	
INNER JOIN
	dbo.items i ON sbi.item_id = i.item_id
INNER JOIN
	dbo.item_categories ic ON i.item_category_id = ic.item_category_id
INNER JOIN
	dbo.units_of_measurements AS uom ON sbi.unit_of_measurement_id = uom.unit_of_measurement_id
INNER JOIN
	dbo.branches b ON sb.branch_id = b.branch_id
INNER JOIN
	dbo.companies c ON b.company_id = c.company_id
INNER JOIN
	dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
WHERE
	(sbi.is_deleted = 0)
	AND ic.item_category_id = 29
GROUP BY
	c.company_name,	
	b.branch_name,	
	st.sale_type,
	DATEPART(MM,sb.sales_bill_date),
	ic.item_category_id,
	ic.item_category_name,
	iq.item_quality,
	i.item_name,	
	uom.unit_code,
	CONVERT(nvarchar(3), DATENAME(M,sb.sales_bill_date))	
ORDER BY
	c.company_name,	
	b.branch_name,
	DATEPART(MM,sb.sales_bill_date),
	st.sale_type,
	ic.item_category_name,
	iq.item_quality,
	i.item_name
	


SELECT
	sbi.item_id,
	ic.item_category_id,
	ic.item_category_name,
	iq.item_quality_id,
	iq.item_quality,
	i.item_name,
	sbi.sale_qty AS sale_qty,
	--SUM(sbi.sale_qty) AS sale_qty,
	sbi.unit_of_measurement_id,
	uom.unit_code,
	sbi.goods_receipt_item_id
FROM
	dbo.sales_bills_items AS sbi
INNER JOIN
	dbo.items i ON sbi.item_id = i.item_id
INNER JOIN
	dbo.item_categories ic ON i.item_category_id = ic.item_category_id
INNER JOIN
	dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
INNER JOIN
	dbo.units_of_measurements AS uom ON sbi.unit_of_measurement_id = uom.unit_of_measurement_id
WHERE
	(sbi.is_deleted = 0)
	AND ic.item_category_id = 29
--GROUP BY
--	sbi.item_id,
--	ic.item_category_id,
--	ic.item_category_name,
--	iq.item_quality_id,
--	iq.item_quality,
--	i.item_name,	
--	sbi.goods_receipt_item_id,
--	sbi.unit_of_measurement_id,
--	uom.unit_code
ORDER BY
	ic.item_category_name,
	iq.item_quality,
	i.item_name


--- sum of item qty
SELECT
	sbi.item_id,
	ic.item_category_id,
	ic.item_category_name,
	iq.item_quality_id,
	iq.item_quality,
	i.item_name,
	--sbi.sale_qty AS sale_qty,
	SUM(sbi.sale_qty) AS sale_qty,
	sbi.unit_of_measurement_id,
	uom.unit_code	
FROM
	dbo.sales_bills_items AS sbi
INNER JOIN
	dbo.items i ON sbi.item_id = i.item_id
INNER JOIN
	dbo.item_categories ic ON i.item_category_id = ic.item_category_id
INNER JOIN
	dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
INNER JOIN
	dbo.units_of_measurements AS uom ON sbi.unit_of_measurement_id = uom.unit_of_measurement_id
WHERE
	(sbi.is_deleted = 0)
	AND ic.item_category_id = 29
GROUP BY
	sbi.item_id,
	ic.item_category_id,
	ic.item_category_name,
	iq.item_quality_id,
	iq.item_quality,
	i.item_name,	
	sbi.unit_of_measurement_id,
	uom.unit_code
ORDER BY
	ic.item_category_name,
	iq.item_quality,
	i.item_name
--------------------------------------XXXXXXXXXXXXXXXXXXXXXXXXXX-----------------------------------------

---- CHANGES DONE FROM 01/Sep/2018

update dbo.client_types set client_type = 'Karagir' where client_type_id = 5

alter table dbo.pkg_slips
add karagir_id int null
go

insert into dbo.location_types
(location_type, created_by, created_by_ip)
values
('Karagir', 1, '::1')

insert into dbo.locations
(location_name, location_type_id, location_address, city_id, location_area, contact_person, created_by, created_by_ip, created_datetime)
values
('Pandurang Karagir - Masjid', 3, 'Mumbai', 1, 'Masjid', 'Pandurang', 1, '::1', GETDATE()),
('Baban Karagir - Thane', 3, 'Thane', 1, 'Thane', 'Baban', 1, '::1', GETDATE())

----------------------------XXXXXXXXXXXXXXXXXXXXXXXXXXXXX-----------------------------------------------

-- -- CHANGES DONE FROM 16/10/2018 

alter table dbo.pkg_slips
add reference_no nvarchar(25)
go

alter table pkg_slip_items
add bale_no nvarchar(50) null
go

alter table pkg_slips drop column bale_no
go

update
	psi
SET
	psi.bale_no = ps.bale_no
FROM 
	dbo.pkg_slip_items psi
inner join dbo.pkg_slips ps ON psi.pkg_slip_id = ps.pkg_slip_id


create table job_works
(
job_work_id				int	identity(1,1) not null,
purchase_bill_id			int	not null,
reference_no			nvarchar(25) null,
karagir_id				int not null,
job_work_no				int not null,
job_work_date			datetime null,
remarks					nvarchar(500) null,
is_deleted				bit not null,
created_by				int not null,
created_by_ip			nvarchar(25) not null,
created_datetime			datetime not null,
modified_by				int null,
modified_by_ip			nvarchar(25) null,
modified_datetime		datetime null,
deleted_by				int null,
deleted_by_ip			nvarchar(25) null,
deleted_datetime			datetime null,
branch_id				int not null,
working_period_id		int not null,
row_guid					uniqueidentifier not null,
constraint [pk_job_works_job_work_id] primary key clustered
	(
		[job_work_id]
	)
)
go

alter table job_works add constraint [DF_job_works_is_deleted] default(0) for[is_deleted]
go

alter table job_works add constraint [DF_job_works_created_datetime] default(getdate()) for[created_datetime]
go

alter table job_works add constraint [DF_job_works_row_guid] default(newid()) for[row_guid]
go


create table job_work_items
(
job_work_item_id		int identity(1,1) not null,
job_work_id			int not null,
inward_goods_id			int not null,
item_qty					decimal(18,2) not null,
rate					decimal(18,2) null,
cut_mtrs				decimal(18,2) null,
remarks					nvarchar(500) null,
is_deleted				bit not null,
created_by				int not null,
created_by_ip			nvarchar(25) not null,
created_datetime			datetime not null,
modified_by				int null,
modified_by_ip			nvarchar(25) null,
modified_datetime		datetime null,
deleted_by				int null,
deleted_by_ip			nvarchar(25) null,
deleted_datetime			datetime null,
row_guid					uniqueidentifier not null,
constraint [pk_job_work_items_job_work_item_id] primary key clustered
	(
		[job_work_item_id]
	)
)
go

alter table job_work_items add constraint [DF_job_work_items_is_deleted] default(0) for[is_deleted]
go

alter table job_work_items add constraint [DF_job_work_items_created_datetime] default(getdate()) for[created_datetime]
go

alter table job_work_items add constraint [DF_job_work_items_row_guid] default(newid()) for[row_guid]
go


--insert into dbo.menus
--(menu_group_id, menu_name, page_link, menu_sequence, is_deleted, created_by, created_by_ip, created_datetime)
--values
--(2, 'Job Work', 'Purchase/JobWork', 5.00, 0, 1, '::1', GETDATE())

select top 1 * from dbo.menus m
order by m.menu_id desc

select * from dbo.role_permissions 

insert into dbo.role_permissions
(role_id, menu_group_id, menu_id, add_permission, view_permission, edit_permission, delete_permission, is_deleted, created_by, created_by_ip, created_datetime)
values
(1, 2, 32, 1, 1, 1, 1, 0, 1, '::1', GETDATE())

select pb.purchase_bill_no, ps.purchase_bill_id, l.location_name
from dbo.pkg_Slips ps
inner join dbo.purchase_bills pb ON ps.purchase_bill_id = pb.purchase_bill_id 
inner join dbo.locations l ON ps.to_location_id = l.location_id
where 
--not ps.karagir_id is null
--and 
ps.is_deleted = 0
and l.location_type_id = 3

select pbi.purchase_bill_item_id, pbi.item_id, i.item_name, iq.item_quality, pbi.purchase_qty, pbi.unit_of_measurement_id, gri.goods_receipt_item_id
from dbo.purchase_bill_items pbi
inner join dbo.items i ON pbi.item_id = i.item_id
inner join dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
inner join dbo.goods_receipt_items gri ON pbi.purchase_bill_item_id = gri.purchase_bill_item_id
where pbi.purchase_bill_id = 312

select inw.inward_id, inw.inward_no, i.item_name, iq.item_quality, igd.inward_qty, igd.unit_of_measurement_id
from dbo.inwards inw
inner join dbo.inward_goods_details igd ON inw.inward_id = igd.inward_id
inner join dbo.locations l ON inw.from_location_id = l.location_id
inner join dbo.items i ON igd.item_id = i.item_id
inner join dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
where igd.goods_receipt_item_id = 1300
and igd.is_deleted = 0
and l.location_type_id = 3


---------------- XXXXXXXXXXXXXXXXXXXX - xxxxxxxxxxxxxxx

--- stock of NTC
select ps.pkg_slip_id, ps.pkg_slip_date, pb.purchase_bill_no, i.item_name + ' ' + iq.item_quality, 
v.client_address_name, pbi.bale_no, psi.pkg_qty, l.location_name , o.location_id
from dbo.outwards o
inner join dbo.outward_goods_details ogd ON o.outward_id = ogd.outward_id
inner join dbo.pkg_slip_items psi ON ogd.pkg_slip_item_id = psi.pkg_slip_item_id
inner join dbo.pkg_slips ps ON psi.pkg_slip_id = ps.pkg_slip_id
inner join dbo.items i ON psi.item_id = i.item_id
inner join dbo.item_qualities iq ON i.item_quality_id = iq.item_quality_id
inner join dbo.locations l ON o.location_id = l.location_id
inner join dbo.goods_receipt_items gri ON psi.goods_receipt_item_id = gri.goods_receipt_item_id
inner join dbo.purchase_bill_items pbi ON gri.purchase_bill_item_id = pbi.purchase_bill_item_id
inner join dbo.purchase_bills pb ON pbi.purchase_bill_id = pb.purchase_bill_id
inner join dbo.client_addressess v ON pb.vendor_id = v.client_address_id
where 
--i.item_name like '%lohi%'
ps.to_location_id = 3

--------------------------------------- changes on 08/12/2018


create table daily_receivable_payable
(
daily_rec_pay_id	int	identity(1,1) not null,
particulars				nvarchar(500) not null,
amount					decimal(18,2) not null,
comments				nvarchar(500) null,
receivable_payable		nvarchar(25) not null,
is_deleted				bit not null,
created_by				int not null,
created_by_ip			nvarchar(25) not null,
created_datetime			datetime not null,
modified_by				int null,
modified_by_ip			nvarchar(25) null,
modified_datetime		datetime null,
deleted_by				int null,
deleted_by_ip			nvarchar(25) null,
deleted_datetime			datetime null,
row_guid					uniqueidentifier not null,
constraint [pk_daily_receivable_payable_daily_rec_pay_id] primary key clustered
	(
		[daily_rec_pay_id]
	)
)
go

alter table daily_receivable_payable add constraint [DF_daily_receivable_payable_is_deleted] default(0) for[is_deleted]
go

alter table daily_receivable_payable add constraint [DF_daily_receivable_payable_created_datetime] default(getdate()) for[created_datetime]
go

alter table daily_receivable_payable add constraint [DF_daily_receivable_payable_row_guid] default(newid()) for[row_guid]
go

select * from dbo.menus_group

insert into dbo.menus_group
(menu_group, is_deleted, created_by, created_by_ip, created_datetime)
values
('Accounts', 0, 1, '::1', GETDATE())


insert into dbo.menus
(menu_group_id, menu_name, page_link, menu_sequence, is_deleted, created_by, created_by_ip, created_datetime)
values
(6, 'Daily Receivable Payable', 'Accounts/DailyReceivablePayable', 1.00, 0, 1, '::1', GETDATE())

select top 1 * from dbo.menus m
order by m.menu_id desc

select * from dbo.role_permissions 

insert into dbo.role_permissions
(role_id, menu_group_id, menu_id, add_permission, view_permission, edit_permission, delete_permission, is_deleted, created_by, created_by_ip, created_datetime)
values
(1, 6, 36, 1, 1, 1, 1, 0, 1, '::1', GETDATE())



create table job_work_items_mtr_adjustment
(
job_work_item_mtr_adjustment_id int identity(1,1) not null,
job_work_id				int not null,
reference_no			nvarchar(25) not null,
adjusted_mtrs			decimal(18,3) not null,
is_deleted				bit not null,
created_by				int not null,
created_by_ip			nvarchar(25) not null,
created_datetime			datetime not null,
modified_by				int null,
modified_by_ip			nvarchar(25) null,
modified_datetime		datetime null,
deleted_by				int null,
deleted_by_ip			nvarchar(25) null,
deleted_datetime			datetime null,
row_guid					uniqueidentifier not null,
constraint [pk_job_work_items_mtr_adjustment_job_work_item_mtr_adjustment_id] primary key clustered
	(
		[job_work_item_mtr_adjustment_id]
	)
)
go

alter table job_work_items_mtr_adjustment add constraint [DF_job_work_items_mtr_adjustment_is_deleted] default(0) for[is_deleted]
go

alter table job_work_items_mtr_adjustment add constraint [DF_job_work_items_mtr_adjustment_created_datetime] default(getdate()) for[created_datetime]
go

alter table job_work_items_mtr_adjustment add constraint [DF_job_work_items_mtr_adjustment_row_guid] default(newid()) for[row_guid]
go

alter table job_works
drop column reference_no
go


alter table sales_orders
add is_tax_inclusive bit
go

alter table sales_orders add constraint [DF_sales_orders_is_tax_inclusive] default(0) for[is_tax_inclusive]
go

alter table sales_orders_items drop column sale_qty_in_pcs
go

alter table sales_orders_items drop column sale_qty_in_mtrs
go

alter table sales_orders_items add order_qty decimal(18,2)
go

alter table sales_orders_items add unit_of_measurement_id int
go


UPDATE       pkg_slips
SET                inward_id = inw.inward_id
FROM            pkg_slip_items AS psi INNER JOIN
                         pkg_slips ON psi.pkg_slip_id = pkg_slips.pkg_slip_id INNER JOIN
                         inward_goods_details AS igd ON psi.goods_receipt_item_id = igd.goods_receipt_item_id AND psi.item_id = igd.item_id INNER JOIN
                         inwards AS inw ON igd.inward_id = inw.inward_id
WHERE        (inw.reference_type = 'goods receipt')


alter table pkg_slips add inward_id int null
go

select 
vwsds.sale_type,
vwsds.salesman,
vwsds.month_name,
vwsds.financial_year,
sum(vwsds.sale_qty * vwsds.sale_rate) as sale_value,
sum(vwsds.sale_qty * vwsds.wholesale_rate) as wholesale_value,
sum(vwsds.sale_qty * vwsds.retail_rate) as retail_value,
case when sum(vwsds.sale_qty * vwsds.sale_rate) <= sum(vwsds.sale_qty * vwsds.wholesale_rate) then
	'SALE BELOW WHOLESALE'
ELSE CASE WHEN
	sum(vwsds.sale_qty * vwsds.sale_rate) >= sum(vwsds.sale_qty * vwsds.retail_rate) then
	'SALE ABOVE RETAIL'
ELSE
	'BETWEEN WHOLESALE AND RETAIL RATE' END END AS remarks
from 
dbo.vw_salesmanwise_daily_sales vwsds
WHERE vwsds.salesman_id = 31
--and vwsds.month_name = 'Feb'
group by
vwsds.sale_type,
vwsds.salesman,
vwsds.month_name,
vwsds.month_no,
vwsds.working_period_id,
vwsds.financial_year
ORDER by
vwsds.month_no
