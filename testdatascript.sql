DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_testingResetData`()
begin
	set foreign_key_checks=0;
    set sql_safe_updates=0;
    delete from Batch;
    delete from Ingredient_Inventory_Subtraction;
    delete from Brew_Container;
    delete from Container_Status;
    delete from Product;
    delete from Batch_Container;
    delete from Container_Type;
    delete from Container_Size;
    delete from Product_Container_Size;
    
insert product_container_size (name, volume) values ('bottle', 12.5);
    
insert container_type (name) values ('brewing container');

insert container_size (name) values ('large');
    
insert batch (batch_id, equipment_id, recipe_id, volume, scheduled_start_date, estimated_finish_date) values (1, 1, 1, 37.8541178, '2020-11-28 00:00:01', '2020-12-10 00:00:01');
insert batch (batch_id, equipment_id, recipe_id, volume, scheduled_start_date, estimated_finish_date) values (2, 1, 2, 37.8541178, '2020-12-05 00:00:01', '2020-12-24 00:00:01');
insert batch (batch_id, equipment_id, recipe_id, volume, scheduled_start_date, estimated_finish_date) values (3, 1, 3, 41.6395296, '2020-11-03 00:00:01', '2020-11-18 00:00:01');
insert batch (batch_id, equipment_id, recipe_id, volume, scheduled_start_date, estimated_finish_date) values (4, 1, 4, 37.8541178, '2021-01-06 00:00:01', '2021-01-19 00:00:01');

insert container_status (container_status_id, name) values (1, 'Empty');
insert container_status (container_status_id, name) values (2, 'In Use');
insert container_status (container_status_id, name) values (3, 'Broken');

insert brew_container (brew_container_id, name, container_type_id, container_status_id, container_size_id) values (1, 'Container1', 1, 1, 1);
insert brew_container (brew_container_id, name, container_type_id, container_status_id, container_size_id) values (2, 'Container2', 1, 1, 1);
insert brew_container (brew_container_id, name, container_type_id, container_status_id, container_size_id) values (3, 'Container3', 1, 2, 1);
insert brew_container (brew_container_id, name, container_type_id, container_status_id, container_size_id) values (4, 'Container4', 1, 3, 1);

insert batch_container (batch_id, brew_container_id, date_in, date_out, volume) values (1, 3, '2020-11-28 00:00:01', '2020-12-12 00:00:01', 37.8541178);

insert product (batch_id, product_container_size_id, racked_date, sell_by_date, quantity_racked, quantity_remaining) values (3, 1, '2020-11-20 00:00:01', '2020-12-30 00:00:01', 80, 30);

	set foreign_key_checks=1;
	set sql_safe_updates=1;
end$$
DELIMITER ;