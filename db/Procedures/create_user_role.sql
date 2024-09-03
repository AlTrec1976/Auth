CREATE OR REPLACE PROCEDURE public.create_user_role(IN userid uuid, IN roleid int4)
 LANGUAGE plpgsql
AS $procedure$
BEGIN
INSERT INTO public.users_roles (user_id,role_id)
VALUES (userid,roleid);
END;
$procedure$;