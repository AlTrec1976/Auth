CREATE OR REPLACE PROCEDURE public.delete_user_role(IN userid uuid, IN roleid int4)
 LANGUAGE plpgsql
AS $procedure$
BEGIN
DELETE FROM public.users_roles WHERE user_id = userid AND role_id = roleid;
END;
$procedure$;