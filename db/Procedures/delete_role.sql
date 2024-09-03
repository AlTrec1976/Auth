CREATE OR REPLACE PROCEDURE public.delete_role(IN wroleid int4)
 LANGUAGE plpgsql
AS $procedure$

BEGIN
DELETE FROM public.roles_permissions WHERE roleid = wroleid;
DELETE FROM public.users_roles WHERE role_id = wroleid;
DELETE FROM public.roles WHERE id = wroleid;

EXCEPTION
	WHEN others THEN
		ROLLBACK;
		RAISE;
END;
$procedure$;