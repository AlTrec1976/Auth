CREATE OR REPLACE PROCEDURE public.delete_role_permission(IN role_id int4,  IN permission_id int4)
 LANGUAGE plpgsql
AS $procedure$
BEGIN
DELETE FROM public.roles_permissions WHERE roleid = role_id AND permissionid=permission_id;
END;
$procedure$;