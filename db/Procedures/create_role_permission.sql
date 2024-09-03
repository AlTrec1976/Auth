CREATE OR REPLACE PROCEDURE public.create_role_permission(IN role_id int4,  IN permission_id int4)
 LANGUAGE plpgsql
AS $procedure$
BEGIN
INSERT INTO public.roles_permissions (roleid,permissionid)
VALUES (role_id,permission_id);
END;
$procedure$;