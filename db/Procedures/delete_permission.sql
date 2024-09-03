CREATE OR REPLACE PROCEDURE public.delete_permission(IN permission_id int4)
 LANGUAGE plpgsql
AS $procedure$

BEGIN
DELETE FROM public.roles_permissions WHERE permissionid = permission_id;
DELETE FROM public.permissions WHERE id = permission_id;

EXCEPTION
	WHEN others THEN
		ROLLBACK;
		RAISE;
END;
$procedure$;