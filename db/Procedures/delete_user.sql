CREATE OR REPLACE PROCEDURE public.delete_user(
	IN userid uuid)
LANGUAGE 'plpgsql'
AS $BODY$

BEGIN
DELETE FROM public.users_roles WHERE user_id = userid;
DELETE FROM public.users WHERE id = userid;
END;
$BODY$;